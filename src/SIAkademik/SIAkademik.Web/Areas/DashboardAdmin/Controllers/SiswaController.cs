using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SIAkademik.Domain.Abstracts;
using SIAkademik.Domain.Authentication;
using SIAkademik.Domain.Enums;
using SIAkademik.Domain.ModulSiakad.Entities;
using SIAkademik.Domain.ModulSiakad.Repositories;
using SIAkademik.Web.Areas.DashboardAdmin.Models.SiswaModels;
using SIAkademik.Web.Models;
using SIAkademik.Web.Services.Toastr;

namespace SIAkademik.Web.Areas.DashboardAdmin.Controllers;

[Area(AreaNames.DashboardAdmin)]
[Authorize(Roles = AppUserRoles.Admin)]
public class SiswaController : Controller
{
    private readonly ISiswaRepository _siswaRepository;
    private readonly IAppUserRepository _appUserRepository;
    private readonly ITahunAjaranRepository _tahunAjaranRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IToastrNotificationService _toastrNotificationService;
    private readonly IPasswordHasher<AppUser> _passwordHasher;

    public SiswaController(
        ISiswaRepository siswaRepository,
        IAppUserRepository appUserRepository,
        IUnitOfWork unitOfWork,
        IToastrNotificationService toastrNotificationService,
        IPasswordHasher<AppUser> passwordHasher,
        ITahunAjaranRepository tahunAjaranRepository)
    {
        _siswaRepository = siswaRepository;
        _appUserRepository = appUserRepository;
        _unitOfWork = unitOfWork;
        _toastrNotificationService = toastrNotificationService;
        _passwordHasher = passwordHasher;
        _tahunAjaranRepository = tahunAjaranRepository;
    }

    public async Task<IActionResult> Index(
        List<JenisKelamin> jenisKelamin,
        List<Agama> agama,
        List<StatusAktifMahasiswa> statusAktif,
        List<int> tahunMasuk,
        List<int> tahunLahir,
        List<Jenjang> jenjang)
    {
        var daftarSiswa = await _siswaRepository.GetAll();

        return View(new IndexVM
        {
            Agama = FilterEntryVM.FromEnum(agama),
            StatusAktif = FilterEntryVM.FromEnum(statusAktif),
            JenisKelamin = FilterEntryVM.FromEnum(jenisKelamin),
            TahunMasuk = daftarSiswa
                .Select(t => t.TanggalMasuk.Year)
                .Distinct()
                .Order()
                .ToFilterEntryList(tahunMasuk),
            TahunLahir = daftarSiswa
                .Select(t => t.TanggalLahir.Year)
                .Distinct()
                .Order()
                .ToFilterEntryList(tahunLahir),
            Jenjang = FilterEntryVM.FromEnum(jenjang),
            DaftarSiswa = [
                .. daftarSiswa
                .Where(s => 
                    (jenisKelamin.Count == 0 || jenisKelamin.Contains(s.JenisKelamin)) &&
                    (agama.Count == 0 || agama.Contains(s.Agama)) &&
                    (statusAktif.Count == 0 || statusAktif.Contains(s.StatusAktif)) &&
                    (tahunMasuk.Count == 0 || tahunMasuk.Contains(s.TanggalMasuk.Year)) &&
                    (tahunLahir.Count == 0 || tahunLahir.Contains(s.TanggalLahir.Year)) &&
                    (jenjang.Count == 0 || jenjang.Contains(s.Jenjang))
                )
            ]
        });
    }

    [HttpPost]
    public IActionResult Index(IndexVM vm) => RedirectToAction(nameof(Index), new
    {
        jenisKelamin = vm.JenisKelamin.Selected(),
        agama = vm.Agama.Selected(),
        statusAktif = vm.StatusAktif.Selected(),
        tahunMasuk = vm.TahunMasuk.Selected(),
        tahunLahir = vm.TahunLahir.Selected(),
        jenjang = vm.Jenjang.Selected()
    });

    public IActionResult Tambah() => View(new TambahVM());

    public async Task<IActionResult> Detail(
        int id,
        List<JenisKelamin> jenisKelamin,
        List<Agama> agama,
        List<StatusAktifMahasiswa> statusAktif,
        List<int> tahunMasuk,
        List<int> tahunLahir,
        List<Jenjang> jenjang)
    {
        var siswa = await _siswaRepository.Get(id);
        if (siswa is null) return NotFound();

        return View(new DetailVM
        {
            Siswa = siswa,
            JenisKelamin = jenisKelamin,
            Agama = agama,
            StatusAktif = statusAktif,
            TahunMasuk = tahunMasuk,
            TahunLahir = tahunLahir
        });
    }

    [HttpPost]
    public async Task<IActionResult> Tambah(TambahVM vm)
    {
        if (!ModelState.IsValid) return View(vm);

        if ((await _siswaRepository.GetByNISN(vm.NISN)) is not null)
        {
            ModelState.AddModelError(nameof(TambahVM.NISN), $"NISN '{vm.NISN}' sudah digunakan!");
            return View(vm);
        }

        if ((await _siswaRepository.GetByNIS(vm.NIS)) is not null)
        {
            ModelState.AddModelError(nameof(TambahVM.NIS), $"NIS '{vm.NIS}' sudah digunakan!");
            return View(vm);
        }

        //Tambah Data
        var siswa = new Siswa
        {
            NISN = vm.NISN,
            NIS = vm.NIS,
            Nama = vm.Nama,
            Agama = vm.Agama,
            TanggalLahir = vm.TanggalLahir,
            TanggalMasuk = vm.TanggalMasuk,
            JenisKelamin = vm.JenisKelamin,
            TempatLahir = vm.TempatLahir,
            StatusAktif = vm.StatusAktif,
            Jenjang = vm.Jenjang
        };

        var appUser = new AppUser
        {
            UserName = vm.NISN,
            PasswordHash = _passwordHasher.HashPassword(null, vm.NISN),
            Role = AppUserRoles.Siswa,
        };

        siswa.Account = appUser;

        _siswaRepository.Add(siswa);
        _appUserRepository.Add(appUser);
        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
        {
            ModelState.AddModelError(string.Empty, "Simpan data siswa baru gagal!");
            return View(vm);
        }

        _toastrNotificationService.AddSuccess("Tambah data siswa berhasil!");

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var siswa = await _siswaRepository.Get(id);
        if (siswa is null) return NotFound();

        return View(new EditVM
        {
            Id = id,
            NIS = siswa.NIS,
            NISN = siswa.NISN,
            Agama = siswa.Agama,
            JenisKelamin = siswa.JenisKelamin,
            TanggalLahir = siswa.TanggalLahir,
            Nama = siswa.Nama,
            TanggalMasuk = siswa.TanggalMasuk,
            TempatLahir = siswa.TempatLahir,
            StatusAktif = siswa.StatusAktif,
            Jenjang = siswa.Jenjang
        });
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EditVM vm)
    {
        if (!ModelState.IsValid) return View(vm);

        var siswa = await _siswaRepository.Get(vm.Id);
        if (siswa is null) return NotFound();

        var duplicateNISN = await _siswaRepository.GetByNISN(vm.NISN);
        if (duplicateNISN is not null & duplicateNISN != siswa)
        {
            ModelState.AddModelError(nameof(TambahVM.NISN), $"NISN '{vm.NISN}' sudah digunakan!");
            return View(vm);
        }

        var duplicateNIS = await _siswaRepository.GetByNIS(vm.NIS);
        if (duplicateNIS is not null & duplicateNIS != siswa)
        {
            ModelState.AddModelError(nameof(TambahVM.NIS), $"NIS '{vm.NIS}' sudah digunakan!");
            return View(vm);
        }

        if (siswa.NISN != vm.NISN && siswa.Account.UserName == siswa.NISN)
        {
            var appUser = (await _appUserRepository.Get(siswa.Account.Id))!;
            appUser.UserName = vm.NISN;
            appUser.PasswordHash = _passwordHasher.HashPassword(null, vm.NISN);
        }

        siswa.NIS = vm.NIS;
        siswa.NISN = vm.NISN;
        siswa.Nama = vm.Nama;
        siswa.Agama = vm.Agama;
        siswa.JenisKelamin = vm.JenisKelamin;
        siswa.TempatLahir = vm.TempatLahir;
        siswa.TanggalLahir = vm.TanggalLahir;
        siswa.TanggalMasuk = vm.TanggalMasuk;
        siswa.StatusAktif = vm.StatusAktif;
        siswa.Jenjang = vm.Jenjang;

        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
        {
            ModelState.AddModelError(string.Empty, "Ubah data siswa gagal!");
            return View(vm);
        }

        _toastrNotificationService.AddSuccess("Ubah data siswa berhasil!");

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Hapus(int id)
    {
        var siswa = await _siswaRepository.Get(id);
        if (siswa is null) return NotFound();

        _siswaRepository.Delete(siswa);
        _appUserRepository.Delete(siswa.Account);
        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
            _toastrNotificationService.AddError("Hapus data siswa gagal!");
        else
            _toastrNotificationService.AddSuccess("Hapus data siswa berhasil!");

        return RedirectToAction(nameof(Index));
    }
}
