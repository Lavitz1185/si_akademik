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
using SIAkademik.Web.Areas.DashboardAdmin.Models.PegawaiModels;
using SIAkademik.Web.Models;
using SIAkademik.Web.Services.Toastr;

namespace SIAkademik.Web.Areas.DashboardAdmin.Controllers;

[Area(AreaNames.DashboardAdmin)]
[Authorize(Roles = AppUserRoles.Admin)]
public class PegawaiController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPegawaiRepository _pegawaiRepository;
    private readonly IAppUserRepository _appUserRepository;
    private readonly IJabatanRepository _jabatanRepository;
    private readonly IDivisiRepository _divisiRepository;
    private readonly IPasswordHasher<AppUser> _passwordHasher;
    private readonly IToastrNotificationService _toastrNotificationService;

    public PegawaiController(
        IUnitOfWork unitOfWork,
        IPegawaiRepository pegawaiRepository,
        IAppUserRepository appUserRepository,
        IJabatanRepository jabatanRepository,
        IDivisiRepository divisiRepository,
        IPasswordHasher<AppUser> passwordHasher,
        IToastrNotificationService toastrNotificationService)
    {
        _unitOfWork = unitOfWork;
        _pegawaiRepository = pegawaiRepository;
        _appUserRepository = appUserRepository;
        _jabatanRepository = jabatanRepository;
        _divisiRepository = divisiRepository;
        _passwordHasher = passwordHasher;
        _toastrNotificationService = toastrNotificationService;
    }

    public async Task<IActionResult> Index(
        List<JenisKelamin> jenisKelamin,
        List<Agama> agama,
        List<StatusPerkawinan> statusPerkawinan,
        List<int> divisi,
        List<int> tahunMasuk,
        List<int> tahunLahir,
        List<GolonganDarah> golonganDarah,
        List<int> jabatan)
    {
        var daftarPegawai = await _pegawaiRepository.GetAll();
        var daftarDivisi = await _divisiRepository.GetAll();
        var daftarJabatan = await _jabatanRepository.GetAll();

        return View(new IndexVM
        {
            JenisKelamin = FilterEntryVM.FromEnum(jenisKelamin),
            Agama = FilterEntryVM.FromEnum(agama),
            StatusPerkawinan = FilterEntryVM.FromEnum(statusPerkawinan),
            GolonganDarah = FilterEntryVM.FromEnum(golonganDarah),
            Divisi = daftarDivisi.Select(d => d.Id).ToFilterEntryList(divisi),
            Jabatan = daftarJabatan.Select(d => d.Id).ToFilterEntryList(jabatan),
            TahunMasuk = daftarPegawai
                .Select(e => e.TanggalMasuk.Year)
                .Distinct()
                .Order()
                .ToFilterEntryList(tahunMasuk),
            TahunLahir = daftarPegawai
                .Select(e => e.TanggalLahir.Year)
                .Distinct()
                .Order()
                .ToFilterEntryList(tahunLahir),
            DaftarPegawai = [
                ..daftarPegawai
                .Where(p =>
                    (jenisKelamin.Count == 0 || jenisKelamin.Contains(p.JenisKelamin)) &&
                    (agama.Count == 0 || agama.Contains(p.Agama)) &&
                    (statusPerkawinan.Count == 0 || statusPerkawinan.Contains(p.StatusPerkawinan)) &&
                    (golonganDarah.Count == 0 || golonganDarah.Contains(p.GolonganDarah)) &&
                    (divisi.Count == 0 || divisi.Contains(p.Divisi.Id)) &&
                    (jabatan.Count == 0 || jabatan.Contains(p.Jabatan.Id)) &&
                    (tahunMasuk.Count == 0 || tahunMasuk.Contains(p.TanggalMasuk.Year)) &&
                    (tahunLahir.Count == 0 || tahunLahir.Contains(p.TanggalLahir.Year))
                )
            ]
        });
    }

    [HttpPost]
    public IActionResult Index(IndexVM vm) => RedirectToAction(nameof(Index), new
    {
        jenisKelamin = vm.JenisKelamin.Selected(),
        agama = vm.Agama.Selected(),
        statusPerkawinan = vm.StatusPerkawinan.Selected(),
        golonganDarah = vm.GolonganDarah.Selected(),
        divisi = vm.Divisi.Selected(),
        jabatan = vm.Jabatan.Selected(),
        tahunMasuk = vm.TahunMasuk.Selected(),
        tahunLahir = vm.TahunLahir.Selected()
    });

    public async Task<IActionResult> DetailPegawai(string nip)
    {
        var pegawai = await _pegawaiRepository.Get(nip);

        if (pegawai is null) return NotFound();

        return View(pegawai);
    }

    public IActionResult Tambah() => View(new TambahVM());

    [HttpPost]
    public async Task<IActionResult> Tambah(TambahVM vm)
    {
        //Validasi
        if (!ModelState.IsValid) return View(vm);

        if ((await _pegawaiRepository.Get(vm.NIP)) is not null)
        {
            ModelState.AddModelError(nameof(TambahVM.NIP), $"NIP '{vm.NIP}' sudah digunakan! Gunakan NIP lain.");
            return View(vm);
        }

        var noHP = NoHP.Create(vm.NoHP);
        if (noHP.IsFailure)
        {
            ModelState.AddModelError(nameof(TambahVM.NoHP), noHP.Error.Message);
            return View(vm);
        }

        if (await _pegawaiRepository.IsExistByEmail(vm.Email))
        {
            ModelState.AddModelError(nameof(TambahVM.Email), $"Email '{vm.Email}' sudah digunakan! Gunakan email lain.");
            return View(vm);
        }

        var jabatan = await _jabatanRepository.Get(vm.JabatanId);
        if (jabatan is null)
        {
            ModelState.AddModelError(nameof(TambahVM.JabatanId), $"Jabatan dengan Id '{vm.JabatanId}' tidak ditemukan");
            return View(vm);
        }

        var divisi = await _divisiRepository.Get(vm.DivisiId);
        if (divisi is null)
        {
            ModelState.AddModelError(nameof(TambahVM.DivisiId), $"Divisi dengan Id '{vm.DivisiId}' tidak ditemukan");
            return View(vm);
        }

        //Tambah data baru
        var pegawai = new Pegawai
        {
            Id = vm.NIP,
            Nama = vm.Nama,
            Agama = vm.Agama,
            AlamatKTP = new Alamat
            {
                Jalan = vm.Alamat.Jalan,
                RT = vm.Alamat.RT,
                RW = vm.Alamat.RW,
                KelurahanDesa = vm.Alamat.KelurahanDesa,
                Kecamatan = vm.Alamat.Kecamatan,
                KotaKabupaten = vm.Alamat.KotaKabupaten,
                Provinsi = vm.Alamat.Provinsi,
                KodePos = vm.Alamat.KodePos
            },
            Email = vm.Email,
            NoHP = noHP.Value,
            GolonganDarah = vm.GolonganDarah,
            JenisKelamin = vm.JenisKelamin,
            NamaInstagram = vm.NamaInstagram ?? string.Empty,
            NIK = vm.NIK,
            NoRekening = vm.NoRekening,
            StatusPerkawinan = vm.StatusPerkawinan,
            TanggalLahir = vm.TanggalLahir,
            TanggalMasuk = vm.TanggalMasuk,
            TempatLahir = vm.TempatLahir,
            Jabatan = jabatan,
            Divisi = divisi,
        };

        var appUser = new AppUser
        {
            UserName = pegawai.Email,
            PasswordHash = _passwordHasher.HashPassword(null, vm.Password),
            Role = AppUserRoles.Guru,
            Guru = pegawai,
        };

        pegawai.Account = appUser;

        _appUserRepository.Add(appUser);
        _pegawaiRepository.Add(pegawai);
        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
        {
            ModelState.AddModelError(string.Empty, "Gagal menyimpan data pegawai baru!");
            return View(vm);
        }

        _toastrNotificationService.AddSuccess("Data pegawai baru berhasil ditambahkan");

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(string nip)
    {
        var pegawai = await _pegawaiRepository.Get(nip);

        if (pegawai == null) return NotFound();

        return View(
            new EditVM
            {
                NIP = pegawai.Id,
                Agama = pegawai.Agama,
                Alamat = new AlamatVM
                {
                    Jalan = pegawai.AlamatKTP.Jalan,
                    RT = pegawai.AlamatKTP.RT,
                    RW = pegawai.AlamatKTP.RW,
                    KelurahanDesa = pegawai.AlamatKTP.KelurahanDesa,
                    Kecamatan = pegawai.AlamatKTP.Kecamatan,
                    KotaKabupaten = pegawai.AlamatKTP.KotaKabupaten,
                    Provinsi = pegawai.AlamatKTP.Provinsi,
                    KodePos = pegawai.AlamatKTP.KodePos
                },
                DivisiId = pegawai.Divisi.Id,
                Email = pegawai.Email,
                GolonganDarah = pegawai.GolonganDarah,
                JabatanId = pegawai.Jabatan.Id,
                JenisKelamin = pegawai.JenisKelamin,
                Nama = pegawai.Nama,
                NamaInstagram = pegawai.NamaInstagram,
                NIK = pegawai.NIK,
                NoHP = pegawai.NoHP.Value,
                NoRekening = pegawai.NoRekening,
                StatusPerkawinan = pegawai.StatusPerkawinan,
                TanggalLahir = pegawai.TanggalLahir,
                TanggalMasuk = pegawai.TanggalMasuk,
                TempatLahir = pegawai.TempatLahir
            }
        );
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EditVM vm)
    {
        if (!ModelState.IsValid) return View(vm);

        var pegawai = await _pegawaiRepository.Get(vm.NIP);
        if (pegawai is null) return NotFound();

        var noHP = NoHP.Create(vm.NoHP);
        if (noHP.IsFailure)
        {
            ModelState.AddModelError(nameof(EditVM.NoHP), noHP.Error.Message);
            return View(vm);
        }

        if (await _pegawaiRepository.IsExistByEmail(vm.Email, pegawai.Id))
        {
            ModelState.AddModelError(nameof(EditVM.Email), $"Email '{vm.Email}' sudah digunakan! Gunakan email lain.");
            return View(vm);
        }

        var jabatan = await _jabatanRepository.Get(vm.JabatanId);
        if (jabatan is null)
        {
            ModelState.AddModelError(nameof(EditVM.JabatanId), $"Jabatan dengan Id '{vm.JabatanId}' tidak ditemukan");
            return View(vm);
        }

        var divisi = await _divisiRepository.Get(vm.DivisiId);
        if (divisi is null)
        {
            ModelState.AddModelError(nameof(EditVM.DivisiId), $"Divisi dengan Id '{vm.DivisiId}' tidak ditemukan");
            return View(vm);
        }

        //Edit Data
        pegawai.Nama = vm.Nama;
        pegawai.StatusPerkawinan = vm.StatusPerkawinan;
        pegawai.NoHP = noHP.Value;
        pegawai.NamaInstagram = vm.NamaInstagram;
        pegawai.AlamatKTP = new Alamat
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
        pegawai.Agama = vm.Agama;
        pegawai.TempatLahir = vm.TempatLahir;
        pegawai.TanggalLahir = vm.TanggalLahir;
        pegawai.Email = vm.Email;
        pegawai.JenisKelamin = vm.JenisKelamin;
        pegawai.NIK = vm.NIK;
        pegawai.TanggalMasuk = vm.TanggalMasuk;
        pegawai.GolonganDarah = vm.GolonganDarah;
        pegawai.Divisi = divisi;
        pegawai.Jabatan = jabatan;
        pegawai.NoRekening = vm.NoRekening;

        var account = (await _appUserRepository.Get(pegawai.Account.Id))!;
        account.UserName = vm.Email;

        if (vm.Password is not null)
        {

            account.PasswordHash = _passwordHasher.HashPassword(null, vm.Password);
        }

        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
        {
            ModelState.AddModelError(string.Empty, "Gagal menguban data pegawai!");
            return View(vm);
        }

        _toastrNotificationService.AddSuccess("Data pegawai berhasil diubah!");

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Hapus(string nip)
    {
        var pegawai = await _pegawaiRepository.Get(nip);

        if (pegawai is null) return NotFound();

        _pegawaiRepository.Delete(pegawai);

        if (pegawai.Account is not null)
            _appUserRepository.Delete(pegawai.Account);

        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
            _toastrNotificationService.AddError("Gagal Menghapus Data Pegawai");
        else
            _toastrNotificationService.AddSuccess("Berhasil Menghapus Data Pegawai");

        return RedirectToAction(nameof(Index));
    }
}
