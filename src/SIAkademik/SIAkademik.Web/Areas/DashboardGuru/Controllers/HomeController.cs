using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIAkademik.Domain.Abstracts;
using SIAkademik.Domain.Authentication;
using SIAkademik.Domain.Enums;
using SIAkademik.Domain.ModulSiakad.Entities;
using SIAkademik.Domain.ModulSiakad.Repositories;
using SIAkademik.Domain.ValueObjects;
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
    private readonly IUnitOfWork _unitOfWork;
    private readonly IToastrNotificationService _toastrNotificationService;

    public HomeController(
        ISignInManager signInManager,
        IPegawaiRepository pegawaiRepository,
        IUnitOfWork unitOfWork,
        IDivisiRepository divisiRepository,
        IJabatanRepository jabatanRepository,
        IToastrNotificationService toastrNotificationService)
    {
        _signInManager = signInManager;
        _pegawaiRepository = pegawaiRepository;
        _unitOfWork = unitOfWork;
        _divisiRepository = divisiRepository;
        _jabatanRepository = jabatanRepository;
        _toastrNotificationService = toastrNotificationService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> Logout()
    {
        await _signInManager.Logout();

        return RedirectToAction("Index", "Home", new { Area = AreaNames.Profil });
    }

    public async Task<IActionResult> EditProfil()
    {
        var user = await _signInManager.GetUser();
        if (user is null) return Forbid();

        var guru = user.Guru;
        if (guru is null) return Forbid();

        guru = (await _pegawaiRepository.Get(guru.Id))!;

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
            DivisiId = guru.Divisi.Id,
            Email = guru.Email,
            GolonganDarah = guru.GolonganDarah,
            JabatanId = guru.Jabatan.Id,
            JenisKelamin = guru.JenisKelamin,
            Nama = guru.Nama,
            NamaInstagram = guru.NamaInstagram,
            NIK = guru.NIK,
            NoHP = guru.NoHP.Value,
            NoRekening = guru.NoRekening,
            StatusPerkawinan = guru.StatusPerkawinan,
            TanggalLahir = guru.TanggalLahir,
            TanggalMasuk = guru.TanggalMasuk,
            TempatLahir = guru.TempatLahir
        });
    }

    [HttpPost]
    public async Task<IActionResult> EditProfil(EditProfilVM vm)
    {
        if (!ModelState.IsValid) return View(vm);

        var user = await _signInManager.GetUser();
        var guru = user?.Guru;
        if (user is null || guru is null) return Forbid();

        var divisi = await _divisiRepository.Get(vm.DivisiId);
        if (divisi is null)
        {
            ModelState.AddModelError(nameof(EditProfilVM.DivisiId), $"Divisi dengan Id '{vm.DivisiId}' tidak ditemukan");
            return View(vm);
        }

        var jabatan = await _jabatanRepository.Get(vm.JabatanId);
        if (jabatan is null)
        {
            ModelState.AddModelError(nameof(EditProfilVM.JabatanId), $"Jabatan dengan Id '{vm.JabatanId}' tidak ditemukan");
            return View(vm);
        }

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
        guru.Divisi = divisi;
        guru.Email = vm.Email;
        guru.GolonganDarah = vm.GolonganDarah;
        guru.Jabatan = jabatan;
        guru.JenisKelamin = vm.JenisKelamin;
        guru.Nama = vm.Nama;
        guru.NamaInstagram = vm.NamaInstagram;
        guru.NIK = vm.NIK;
        guru.NoHP = noHP.Value;
        guru.NoRekening = vm.NoRekening;
        guru.StatusPerkawinan = vm.StatusPerkawinan;
        guru.TanggalLahir = vm.TanggalLahir;
        guru.TanggalMasuk = vm.TanggalMasuk;
        guru.TempatLahir = vm.TempatLahir;

        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
        {
            ModelState.AddModelError(string.Empty, "Simpan gagal!");
            return View(vm);
        }

        _toastrNotificationService.AddSuccess("Profil berhasil diubah!");

        return RedirectToAction(nameof(EditProfil));
    }
}
