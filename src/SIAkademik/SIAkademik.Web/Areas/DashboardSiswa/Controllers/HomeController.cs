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
using SIAkademik.Web.Areas.DashboardSiswa.Models.Home;
using SIAkademik.Web.Authentication;
using SIAkademik.Web.Models;
using SIAkademik.Web.Services.Toastr;

namespace SIAkademik.Web.Areas.DashboardSiswa.Controllers;

[Area(AreaNames.DashboardSiswa)]
[Authorize(Roles = AppUserRoles.Siswa)]
public class HomeController : Controller
{
    private readonly ISignInManager _signInManager;
    private readonly ITahunAjaranRepository _tahunAjaranRepository;
    private readonly IJadwalMengajarRepository _jadwalMengajarRepository;
    private readonly IToastrNotificationService _toastrNotificationService;
    private readonly IFileService _fileService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordHasher<AppUser> _passwordHasher;
    private readonly IAppUserRepository _appUserRepository;

    public HomeController(
        ISignInManager signInManager,
        ITahunAjaranRepository tahunAjaranRepository,
        IJadwalMengajarRepository jadwalMengajarRepository,
        IToastrNotificationService toastrNotificationService,
        IFileService fileService,
        IUnitOfWork unitOfWork,
        IPasswordHasher<AppUser> passwordHasher,
        IAppUserRepository appUserRepository)
    {
        _signInManager = signInManager;
        _tahunAjaranRepository = tahunAjaranRepository;
        _jadwalMengajarRepository = jadwalMengajarRepository;
        _toastrNotificationService = toastrNotificationService;
        _fileService = fileService;
        _unitOfWork = unitOfWork;
        _passwordHasher = passwordHasher;
        _appUserRepository = appUserRepository;
    }

    public async Task<IActionResult> Index(DateOnly? tanggal)
    {
        var siswa = await _signInManager.GetSiswa();
        if (siswa is null) return Forbid();

        tanggal ??= DateOnly.FromDateTime(CultureInfos.DateTimeNow);

        if (!siswa.IsBiodataComplete())
            _toastrNotificationService.AddWarning("Biodata anda belum lengkap. Silahkan lengkapi!");

        var tahunAjaran = await _tahunAjaranRepository.GetNewest();
        if (tahunAjaran is null) return View(new IndexVM { Siswa = siswa, Tanggal = tanggal.Value });

        var anggotaRombel = siswa.DaftarAnggotaRombel.FirstOrDefault(a => a.Rombel.Kelas.TahunAjaran == tahunAjaran);
        if (anggotaRombel is null) return View(new IndexVM { Siswa = siswa, TahunAjaran = tahunAjaran, Tanggal = tanggal.Value });

        var hari = tanggal.Value.DayOfWeek;

        var daftarJadwalMengajar = await _jadwalMengajarRepository.GetAllByTahunAjaran(tahunAjaran.Id);
        var daftarHariMengajar = daftarJadwalMengajar
            .Where(j => j.Rombel == anggotaRombel.Rombel)
            .SelectMany(j => j.DaftarHariMengajar)
            .Where(h => HariExtension.FromHari(h.Hari) == hari)
            .ToList();

        return View(new IndexVM
        {
            Siswa = siswa,
            AnggotaRombel = anggotaRombel,
            TahunAjaran = tahunAjaran,
            Tanggal = tanggal.Value,
            DaftarHariMengajar = daftarHariMengajar
        });
    }

    public async Task<IActionResult> Logout()
    {
        await _signInManager.Logout();

        return RedirectToAction("Index", "Home", new { Area = AreaNames.Profil });
    }

    public async Task<IActionResult> Profil()
    {
        var siswa = await _signInManager.GetSiswa();
        if (siswa is null) return Forbid();

        return View(siswa);
    }

    public async Task<IActionResult> EditProfil()
    {
        var siswa = await _signInManager.GetSiswa();
        if (siswa is null) return Forbid();

        return View(new EditProfilVM
        {
            Nama = siswa.Nama,
            NISN = siswa.NISN,
            NIS = siswa.NIS,
            JenisKelamin = siswa.JenisKelamin,
            TanggalLahir = siswa.TanggalLahir,
            TempatLahir = siswa.TempatLahir,
            Agama = siswa.Agama,
            TanggalMasuk = siswa.TanggalMasuk,
            StatusAktif = siswa.StatusAktif,
            Jenjang = siswa.Jenjang,
            FotoProfil = siswa.FotoProfil,

            //Data Diri
            Suku = siswa.Suku,
            Alamat = new AlamatVM
            {
                KodePos = siswa.AlamatLengkap.KodePos,
                Jalan = siswa.AlamatLengkap.Jalan,
                RT = siswa.AlamatLengkap.RT,
                RW = siswa.AlamatLengkap.RW,
                KelurahanDesa = siswa.AlamatLengkap.KelurahanDesa,
                Kecamatan = siswa.AlamatLengkap.Kecamatan,
                KotaKabupaten = siswa.AlamatLengkap.KotaKabupaten,
                Provinsi = siswa.AlamatLengkap.Provinsi,
            },
            GolonganDarah = siswa.GolonganDarah,
            TinggiBadan = siswa.TinggiBadan,
            BeratBadan = siswa.BeratBadan,
            Hobi = siswa.Hobi,
            NoHP = siswa.NoHP?.Value,
            JumlahSaudara = siswa.JumlahSaudara,
            AnakKe = siswa.AnakKe,
            NomorKartuKeluarga = siswa.NomorKartuKeluarga,
            NomorKartuPelajar = siswa.NomorKartuPelajar,
            Email = siswa.Email,
            AsalSekolah = siswa.AsalSekolah,
            AktaKelahiranLama = siswa.AktaKelahiran,
            IjazahSMPLama = siswa.IjazahSMP,

            //Data Ayah
            NamaAyah = siswa.NamaAyah,
            NIKAyah = siswa.NIKAyah,
            PekerjaanAyah = siswa.PekerjaanAyah,
            AgamaAyah = siswa.AgamaAyah,
            NoHPAyah = siswa.NoHPAyah?.Value,
            TanggalLahirAyah = siswa.TanggalLahirAyah,
            StatusHidupAyah = siswa.StatusHidupAyah,
            PendidikanTerakhirAyah = siswa.PendidikanTerakhirAyah,

            //Data Ibu
            NamaIbu = siswa.NamaIbu,
            NIKIbu = siswa.NIKIbu,
            PekerjaanIbu = siswa.PekerjaanIbu,
            AgamaIbu = siswa.AgamaIbu,
            NoHPIbu = siswa.NoHPIbu?.Value,
            TanggalLahirIbu = siswa.TanggalLahirIbu,
            StatusHidupIbu = siswa.StatusHidupIbu,
            PendidikanTerakhirIbu = siswa.PendidikanTerakhirIbu,

            //Data Wali
            NamaWali = siswa.NamaWali,
            NIKWali = siswa.NIKWali,
            PekerjaanWali = siswa.PekerjaanWali,
            AgamaWali = siswa.AgamaWali,
            NoHPWali = siswa.NoHPWali?.Value,
            TanggalLahirWali = siswa.TanggalLahirWali,
            StatusHidupWali = siswa.StatusHidupWali,
            PendidikanTerakhirWali = siswa.PendidikanTerakhirWali,
            HubunganDenganWali = siswa.HubunganDenganWali,
        });
    }

    [HttpPost]
    public async Task<IActionResult> EditProfil(EditProfilVM vm)
    {
        var siswa = await _signInManager.GetSiswa();
        if (siswa is null) return Forbid();

        if (!ModelState.IsValid) return View(vm);

        var noHP = NoHP.Create(vm.NoHP!);
        if (noHP.IsFailure)
        {
            ModelState.AddModelError(nameof(EditProfilVM.NoHP), "No. HP/WA tidak valid");
            return View(vm);
        }

        var noHPAyah = NoHP.Create(vm.NoHPAyah!);
        if (noHPAyah.IsFailure)
        {
            ModelState.AddModelError(nameof(EditProfilVM.NoHPAyah), "No. HP/WA ayah tidak valid");
            return View(vm);
        }

        var noHPIbu = NoHP.Create(vm.NoHPIbu!);
        if (noHPIbu.IsFailure)
        {
            ModelState.AddModelError(nameof(EditProfilVM.NoHPIbu), "No. HP/WA ibu tidak valid");
            return View(vm);
        }

        var noHPWali = NoHP.Create(vm.NoHPWali!);
        if (noHPWali.IsFailure)
        {
            ModelState.AddModelError(nameof(EditProfilVM.NoHPWali), "No. HP/WA wali tidak valid");
            return View(vm);
        }

        siswa.Nama = vm.Nama;
        siswa.NISN = vm.NISN;
        siswa.NIS = vm.NIS;
        siswa.JenisKelamin = vm.JenisKelamin;
        siswa.TanggalLahir = vm.TanggalLahir;
        siswa.TempatLahir = vm.TempatLahir;
        siswa.Agama = vm.Agama;
        siswa.TanggalMasuk = vm.TanggalMasuk;
        siswa.StatusAktif = vm.StatusAktif;
        siswa.Jenjang = vm.Jenjang;

        //Data Diri
        siswa.Suku = vm.Suku;
        siswa.GolonganDarah = vm.GolonganDarah;
        siswa.TinggiBadan = vm.TinggiBadan;
        siswa.BeratBadan = vm.BeratBadan;
        siswa.Hobi = vm.Hobi;
        siswa.NoHP = noHP.Value;
        siswa.JumlahSaudara = vm.JumlahSaudara;
        siswa.AnakKe = vm.AnakKe;
        siswa.NomorKartuKeluarga = vm.NomorKartuKeluarga;
        siswa.NomorKartuPelajar = vm.NomorKartuPelajar;
        siswa.Email = vm.Email;
        siswa.AsalSekolah = vm.AsalSekolah;

        if (vm.AktaKelahiran is not null)
        {
            var aktaKelahiran = await _fileService.UploadFile<EditProfilVM>(
            vm.AktaKelahiran!,
            "aktaKelahiran",
            new string[] { ".jpeg", ".pdf", ".jpg" },
            0,
            104858);

            if (aktaKelahiran.IsFailure)
            {
                ModelState.AddModelError(nameof(EditProfilVM.AktaKelahiran), $"Upload File Akta Kelahiran Gagal : {aktaKelahiran.Error.Message}");
                return View(vm);
            }

            siswa.AktaKelahiran = aktaKelahiran.Value;
        }
        else if (siswa.AktaKelahiran is null)
        {
            ModelState.AddModelError(nameof(EditProfilVM.AktaKelahiran), "Akta Kelahiran Harus Diisi");
            return View(vm);
        }

        if (vm.IjazahSMP is not null)
        {
            var ijazahSMP = await _fileService.UploadFile<EditProfilVM>(
                vm.IjazahSMP!,
                "ijazahSMP",
                new string[] { ".jpeg", ".pdf", ".jpg" },
                0,
                104858);

            if (ijazahSMP.IsFailure)
            {
                ModelState.AddModelError(nameof(EditProfilVM.IjazahSMP), $"Upload File Akta Kelahiran Gagal : {ijazahSMP.Error.Message}");
                return View(vm);
            }

            siswa.IjazahSMP = ijazahSMP.Value;
        }
        else if (siswa.IjazahSMP is null)
        {
            ModelState.AddModelError(nameof(EditProfilVM.IjazahSMP), "Ijazah SMP Harus Diisi");
            return View(vm);
        }

        siswa.AlamatLengkap = new Alamat
        {
            KodePos = vm.Alamat.KodePos,
            Jalan = vm.Alamat.Jalan,
            RT = vm.Alamat.RT,
            RW = vm.Alamat.RW,
            KelurahanDesa = vm.Alamat.KelurahanDesa,
            Kecamatan = vm.Alamat.Kecamatan,
            KotaKabupaten = vm.Alamat.KotaKabupaten,
            Provinsi = vm.Alamat.Provinsi,
        };

        //Data Ayah
        siswa.NamaAyah = vm.NamaAyah;
        siswa.NIKAyah = vm.NIKAyah;
        siswa.PekerjaanAyah = vm.PekerjaanAyah;
        siswa.AgamaAyah = vm.AgamaAyah;
        siswa.NoHPAyah = noHPAyah.Value;
        siswa.TanggalLahirAyah = vm.TanggalLahirAyah;
        siswa.StatusHidupAyah = vm.StatusHidupAyah;
        siswa.PendidikanTerakhirAyah = vm.PendidikanTerakhirAyah;

        //Data Ibu
        siswa.NamaIbu = vm.NamaIbu;
        siswa.NIKIbu = vm.NIKIbu;
        siswa.PekerjaanIbu = vm.PekerjaanIbu;
        siswa.AgamaIbu = vm.AgamaIbu;
        siswa.NoHPIbu = noHPIbu.Value;
        siswa.TanggalLahirIbu = vm.TanggalLahirIbu;
        siswa.StatusHidupIbu = vm.StatusHidupIbu;
        siswa.PendidikanTerakhirIbu = vm.PendidikanTerakhirIbu;

        //Data Wali
        siswa.NamaWali = vm.NamaWali;
        siswa.NIKWali = vm.NIKWali;
        siswa.PekerjaanWali = vm.PekerjaanWali;
        siswa.AgamaWali = vm.AgamaWali;
        siswa.NoHPWali = noHPWali.Value;
        siswa.TanggalLahirWali = vm.TanggalLahirWali;
        siswa.StatusHidupWali = vm.StatusHidupWali;
        siswa.PendidikanTerakhirWali = vm.PendidikanTerakhirWali;
        siswa.HubunganDenganWali = vm.HubunganDenganWali;

        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
        {
            ModelState.AddModelError(string.Empty, "Simpan gagal!");
            return View(vm);
        }
        else
        {
            if (vm.AktaKelahiran is not null && vm.AktaKelahiranLama is not null)
                _fileService.Delete(vm.AktaKelahiranLama!);

            if (vm.IjazahSMP is not null && vm.IjazahSMPLama is not null)
                _fileService.Delete(vm.IjazahSMPLama!);
        }

        _toastrNotificationService.AddSuccess("Simpan Sukses");

        return RedirectToAction(nameof(Profil));
    }

    public async Task<IActionResult> EditFotoProfil()
    {
        var siswa = await _signInManager.GetSiswa();
        if (siswa is null) return Forbid();

        return View(new EditFotoProfilVM { FotoProfilLama = siswa.FotoProfil });
    }

    [HttpPost]
    public async Task<IActionResult> EditFotoProfil(EditFotoProfilVM vm)
    {
        var siswa = await _signInManager.GetSiswa();
        if (siswa is null) return Forbid();

        if (!ModelState.IsValid) return View(vm);

        if (vm.FotoProfil is not null)
        {
            var fotoProfil = await _fileService.UploadFile<EditFotoProfilVM>(
                vm.FotoProfil,
                "ijazahSMP",
                [".jpeg", ".jpg"],
                0,
                104858);

            if (fotoProfil.IsFailure)
            {
                ModelState.AddModelError(nameof(EditFotoProfilVM.FotoProfil), $"Upload Foto Profil Gagal : {fotoProfil.Error.Message}");
                return View(vm);
            }

            siswa.FotoProfil = fotoProfil.Value;

            var result = await _unitOfWork.SaveChangesAsync();
            if (result.IsFailure)
            {
                _toastrNotificationService.AddError("Simpan gagal!");
                return View(vm);
            }
            else
                _toastrNotificationService.AddSuccess("Simpan Berhasil!");
        }
        else if(vm.FotoProfilLama is not null)
        {
            ModelState.AddModelError(nameof(EditFotoProfilVM.FotoProfil), "Foto Profil Harus Diupload!");
            return View(vm);
        }

        return RedirectToAction(nameof(Profil));
    }

    public async Task<IActionResult> UbahPassword()
    {
        var siswa = await _signInManager.GetSiswa();
        if (siswa is null) return Forbid();

        return View(new UbahPasswordVM());
    }

    [HttpPost]
    public async Task<IActionResult> UbahPassword(UbahPasswordVM vm)
    {
        var siswa = await _signInManager.GetSiswa();
        if (siswa is null) return Forbid();

        if (!ModelState.IsValid) return View(vm);

        if(_passwordHasher.VerifyHashedPassword(siswa.Account, siswa.Account.PasswordHash, vm.PasswordLama) == PasswordVerificationResult.Failed)
        {
            ModelState.AddModelError(nameof(UbahPasswordVM.PasswordLama), "Password lama yang dimasukkan tidak benar!");
            return View(vm);
        }

        if(vm.PasswordLama == vm.PasswordBaru)
        {
            ModelState.AddModelError(nameof(UbahPasswordVM.PasswordBaru), "Password lama sama dengan password baru!");
            return View(vm);
        }

        var account = (await _appUserRepository.Get(siswa.Account.Id))!;
        account.PasswordHash = _passwordHasher.HashPassword(null, vm.PasswordBaru);

        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
        {
            ModelState.AddModelError(string.Empty, "Simpan Gagal!");
            return View(vm);
        }

        _toastrNotificationService.AddSuccess("Password berhasil diubah!");

        return RedirectToAction(nameof(Profil));
    }
}