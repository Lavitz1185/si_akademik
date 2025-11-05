using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SIAkademik.Domain.Abstracts;
using SIAkademik.Domain.Authentication;
using SIAkademik.Domain.Enums;
using SIAkademik.Domain.ModulSiakad.Entities;
using SIAkademik.Domain.ModulSiakad.Repositories;
using SIAkademik.Domain.ValueObjects;
using SIAkademik.Infrastructure.Services.FileServices;
using SIAkademik.Web.Areas.DashboardGuru.Models.Home;
using SIAkademik.Web.Authentication;
using SIAkademik.Web.Models;
using SIAkademik.Web.Services.Toastr;

namespace SIAkademik.Web.Areas.DashboardGuru.Controllers;

[Area(AreaNames.DashboardGuru)]
[Authorize(Roles = AppUserRoles.Guru)]
public class HomeController : Controller
{
    private readonly ISignInManager _signInManager;
    private readonly IPegawaiRepository _pegawaiRepository;
    private readonly IDivisiRepository _divisiRepository;
    private readonly IJabatanRepository _jabatanRepository;
    private readonly IJadwalMengajarRepository _jadwalMengajarRepository;
    private readonly IRombelRepository _rombelRepository;
    private readonly ITahunAjaranRepository _tahunAjaranRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IToastrNotificationService _toastrNotificationService;
    private readonly IPasswordHasher<AppUser> _passwordHasher;
    private readonly IFileService _fileService;
    private readonly IPertemuanRepository _pertemuanRepository;

    public HomeController(
        ISignInManager signInManager,
        IPegawaiRepository pegawaiRepository,
        IUnitOfWork unitOfWork,
        IDivisiRepository divisiRepository,
        IJabatanRepository jabatanRepository,
        IToastrNotificationService toastrNotificationService,
        IJadwalMengajarRepository jadwalMengajarRepository,
        IRombelRepository rombelRepository,
        ITahunAjaranRepository tahunAjaranRepository,
        IPasswordHasher<AppUser> passwordHasher,
        IFileService fileService,
        IPertemuanRepository pertemuanRepository)
    {
        _signInManager = signInManager;
        _pegawaiRepository = pegawaiRepository;
        _unitOfWork = unitOfWork;
        _divisiRepository = divisiRepository;
        _jabatanRepository = jabatanRepository;
        _toastrNotificationService = toastrNotificationService;
        _jadwalMengajarRepository = jadwalMengajarRepository;
        _rombelRepository = rombelRepository;
        _tahunAjaranRepository = tahunAjaranRepository;
        _passwordHasher = passwordHasher;
        _fileService = fileService;
        _pertemuanRepository = pertemuanRepository;
    }

    public async Task<IActionResult> Index(DateOnly? tanggal = null)
    {
        tanggal ??= DateOnly.FromDateTime(CultureInfos.DateTimeNow);

        var guru = await _signInManager.GetPegawai();
        if (guru is null) return Forbid();

        var tahunAjaran = await _tahunAjaranRepository.GetNewest();
        if (tahunAjaran is null) return View(new IndexVM { Pegawai = guru, Tanggal = tanggal.Value });

        var hari = tanggal.Value.DayOfWeek;
        var jadwalHariIni = guru.DaftarJadwalMengajar
            .Where(j => j.Rombel.TahunAjaran == tahunAjaran)
            .SelectMany(j => j.DaftarHariMengajar)
            .Where(h => HariExtension.FromHari(h.Hari) == hari)
            .ToList();

        var pertemuanHariIni = guru.DaftarJadwalMengajar
            .Where(j => j.Rombel.TahunAjaran == tahunAjaran)
            .SelectMany(j => j.DaftarPertemuan)
            .Where(p => DateOnly.FromDateTime(p.TanggalPelaksanaan) == tanggal)
            .ToList();

        var rombelWali = guru.DaftarRombelWali
            .Where(j => j.TahunAjaran == tahunAjaran)
            .ToList();

        return View(new IndexVM
        {
            Pegawai = guru,
            TahunAjaran = tahunAjaran,
            JadwalHariIni = jadwalHariIni,
            PertemuanHariIni = pertemuanHariIni,
            RombelWali = rombelWali,
            Tanggal = tanggal.Value
        });
    }

    public async Task<IActionResult> Logout()
    {
        await _signInManager.Logout();

        return RedirectToAction("Index", "Home", new { Area = AreaNames.Profil });
    }

    public async Task<IActionResult> Profil()
    {
        var pegawai = await _signInManager.GetPegawai();
        if (pegawai is null) return Forbid();

        return View(pegawai);
    }

    public async Task<IActionResult> EditProfil()
    {
        var guru = await _signInManager.GetPegawai();
        if (guru is null) return Forbid();

        return View(new EditProfilVM
        {
            Agama = guru.Agama,
            Alamat = new AlamatVM
            {
                Jalan = guru.AlamatKTP.Jalan,
                RT = guru.AlamatKTP.RT,
                RW = guru.AlamatKTP.RW,
                KelurahanDesa = guru.AlamatKTP.KelurahanDesa,
                Kecamatan = guru.AlamatKTP.Kecamatan,
                KotaKabupaten = guru.AlamatKTP.KotaKabupaten,
                Provinsi = guru.AlamatKTP.Provinsi,
                KodePos = guru.AlamatKTP.KodePos
            },
            Email = guru.Email,
            GolonganDarah = guru.GolonganDarah,
            JenisKelamin = guru.JenisKelamin,
            Nama = guru.Nama,
            NamaInstagram = guru.NamaInstagram,
            NIK = guru.NIK,
            NoHP = guru.NoHP.Value,
            NoRekening = guru.NoRekening,
            StatusPerkawinan = guru.StatusPerkawinan,
            TanggalLahir = guru.TanggalLahir,
            TempatLahir = guru.TempatLahir
        });
    }

    [HttpPost]
    public async Task<IActionResult> EditProfil(EditProfilVM vm)
    {
        if (!ModelState.IsValid) return View(vm);

        var guru = await _signInManager.GetPegawai();
        if (guru is null) return Forbid();

        var noHP = NoHP.Create(vm.NoHP);
        if (noHP.IsFailure)
        {
            ModelState.AddModelError(nameof(EditProfilVM.NoHP), noHP.Error.Message);
            return View(vm);
        }

        guru.AlamatKTP = new()
        {
            Jalan = vm.Alamat.Jalan,
            RT = vm.Alamat.RT,
            RW = vm.Alamat.RW,
            KelurahanDesa = vm.Alamat.KelurahanDesa,
            Kecamatan = vm.Alamat.Kecamatan,
            KotaKabupaten = vm.Alamat.KotaKabupaten,
            Provinsi = vm.Alamat.Provinsi,
            KodePos = vm.Alamat.KodePos
        };

        guru.Agama = vm.Agama;
        guru.Email = vm.Email;
        guru.GolonganDarah = vm.GolonganDarah;
        guru.JenisKelamin = vm.JenisKelamin;
        guru.Nama = vm.Nama;
        guru.NamaInstagram = vm.NamaInstagram;
        guru.NIK = vm.NIK;
        guru.NoHP = noHP.Value;
        guru.NoRekening = vm.NoRekening;
        guru.StatusPerkawinan = vm.StatusPerkawinan;
        guru.TanggalLahir = vm.TanggalLahir;
        guru.TempatLahir = vm.TempatLahir;

        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
        {
            ModelState.AddModelError(string.Empty, "Simpan gagal!");
            return View(vm);
        }

        _toastrNotificationService.AddSuccess("Profil berhasil diubah!");

        return RedirectToAction(nameof(Profil));
    }

    public async Task<IActionResult> UbahPassword()
    {
        var pegawai = await _signInManager.GetPegawai();
        if (pegawai is null) return Forbid();

        return View(new UbahPasswordVM
        {
            Nama = pegawai.Nama,
            Agama = pegawai.Agama,
            JenisKelamin = pegawai.JenisKelamin,
            TanggalLahir = pegawai.TanggalLahir,
            TempatLahir = pegawai.TempatLahir
        });
    }

    [HttpPost]
    public async Task<IActionResult> UbahPassword(UbahPasswordVM vm)
    {
        var pegawai = await _signInManager.GetPegawai();
        if (pegawai is null) return Forbid();

        if (!ModelState.IsValid) return View(vm);

        if (_passwordHasher.VerifyHashedPassword(null, pegawai.Account!.PasswordHash, vm.PasswordLama) == PasswordVerificationResult.Failed)
        {
            ModelState.AddModelError(nameof(UbahPasswordVM.PasswordLama), "Password Lama salah!");
            return View(vm);
        }

        if (vm.PasswordLama == vm.PasswordBaru)
        {
            ModelState.AddModelError(nameof(UbahPasswordVM.PasswordBaru), "Password baru sama dengan password lama. Ganti dengan password yang berbeda");
            return View(vm);
        }

        pegawai.Account.PasswordHash = _passwordHasher.HashPassword(null, vm.PasswordBaru);

        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
        {
            ModelState.AddModelError(string.Empty, "Simpan gagal!");
            return View(vm);
        }

        _toastrNotificationService.AddSuccess("Password berhasil diganti!");
        return RedirectToAction(nameof(Profil));
    }

    public async Task<IActionResult> EditFotoProfil()
    {
        var pegawai = await _signInManager.GetPegawai();
        if (pegawai is null) return Forbid();

        return View(new EditFotoProfilVM { FotoProfilLama = pegawai.FotoProfil });
    }

    [HttpPost]
    public async Task<IActionResult> EditFotoProfil(EditFotoProfilVM vm)
    {
        var pegawai = await _signInManager.GetPegawai();
        if (pegawai is null) return Forbid();

        if (!ModelState.IsValid) return View(vm);

        if (vm.FotoProfil is not null)
        {
            var fotoProfil = await _fileService.UploadFile<EditFotoProfilVM>(
                vm.FotoProfil,
                "FotoProfil",
                [".jpeg", ".jpg"],
                0,
                104858);

            if (fotoProfil.IsFailure)
            {
                ModelState.AddModelError(nameof(EditFotoProfilVM.FotoProfil), $"Upload Foto Profil Gagal : {fotoProfil.Error.Message}");
                return View(vm);
            }

            pegawai.FotoProfil = fotoProfil.Value;

            var result = await _unitOfWork.SaveChangesAsync();
            if (result.IsFailure)
            {
                _toastrNotificationService.AddError("Simpan gagal!");
                return View(vm);
            }
            else
                _toastrNotificationService.AddSuccess("Simpan Berhasil!");

            if (vm.FotoProfilLama is not null)
                _fileService.Delete(vm.FotoProfilLama);
        }
        else if (vm.FotoProfilLama is not null)
        {
            ModelState.AddModelError(nameof(EditFotoProfilVM.FotoProfil), "Foto Profil Harus Diupload!");
            return View(vm);
        }

        return RedirectToAction(nameof(Profil));
    }
}
