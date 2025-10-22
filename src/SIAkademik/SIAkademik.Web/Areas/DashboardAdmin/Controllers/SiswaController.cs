using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SIAkademik.Domain.Abstracts;
using SIAkademik.Domain.Authentication;
using SIAkademik.Domain.Enums;
using SIAkademik.Domain.ModulSiakad.Entities;
using SIAkademik.Domain.ModulSiakad.Repositories;
using SIAkademik.Infrastructure.Services.FileServices;
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
            Agama = [
                .. FilterEntryVM
                .FromEnum<Agama>()
                .Select(e => new FilterEntryVM<Agama> { Value = e.Value, Selected = agama.Contains(e.Value)})
            ],
            StatusAktif = [
                .. FilterEntryVM
                .FromEnum<StatusAktifMahasiswa>()
                .Select(e => new FilterEntryVM<StatusAktifMahasiswa> { Value = e.Value, Selected = statusAktif.Contains(e.Value)})
            ],
            JenisKelamin = [
                .. FilterEntryVM
                .FromEnum<JenisKelamin>()
                .Select(e => new FilterEntryVM<JenisKelamin> { Value = e.Value, Selected = jenisKelamin.Contains(e.Value)})
            ],
            TahunMasuk = [
                .. daftarSiswa
                .Select(t => t.TanggalMasuk.Year)
                .Distinct()
                .Select(e => new FilterEntryVM<int>{ Value = e, Selected = tahunMasuk.Contains(e)})
            ],
            TahunLahir = [
                .. daftarSiswa
                .Select(t => t.TanggalLahir.Year)
                .Distinct()
                .Select(e => new FilterEntryVM<int>{ Value = e, Selected = tahunLahir.Contains(e)})
            ],
            Jenjang = [
                .. FilterEntryVM
                .FromEnum<Jenjang>()
                .Select(e => new FilterEntryVM<Jenjang> { Value = e.Value, Selected = jenjang.Contains(e.Value)})
            ],
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
        jenisKelamin = vm.JenisKelamin.Where(e => e.Selected).Select(e => e.Value).ToList(),
        agama = vm.Agama.Where(e => e.Selected).Select(e => e.Value).ToList(),
        statusAktif = vm.StatusAktif.Where(e => e.Selected).Select(e => e.Value).ToList(),
        tahunMasuk = vm.TahunMasuk.Where(e => e.Selected).Select(e => e.Value).ToList(),
        tahunLahir = vm.TahunLahir.Where(e => e.Selected).Select(e => e.Value).ToList(),
        jenjang = vm.Jenjang.Where(e => e.Selected).Select(e => e.Value).ToList()
    });

    public IActionResult Tambah() => View(new TambahVM());

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

    [Route("[Area]/[Action]")]
    public async Task<IActionResult> ProsesKelulusan(int? idTahunAjaran)
    {
        var tahunAjaran = idTahunAjaran is null ?
            await _tahunAjaranRepository.GetNewest() :
            await _tahunAjaranRepository.Get(idTahunAjaran.Value);

        if (tahunAjaran is null) return View(new ProsesKelulusanVM());

        var daftarSiswa = await _siswaRepository.GetAllAktif();
        daftarSiswa = daftarSiswa
            .Where(s => 
                s.DaftarAnggotaRombel
                    .Any(a => a.Rombel.Kelas.Jenjang == Jenjang.XII && 
                         a.Rombel.TahunAjaran == tahunAjaran && 
                         a.NaikKelasLulus))
            .ToList();

        return View(new ProsesKelulusanVM
        {
            IdTahunAjaran = tahunAjaran.Id,
            DaftarEntry = [.. daftarSiswa.Select(s => new ProsesKelulusanEntryVM { IdSiswa = s.Id, Luluskan = false })],
            DaftarSiswa = daftarSiswa
        });
    }

    [HttpPost]
    [Route("[Area]/[Action]")]
    public async Task<IActionResult> ProsesKelulusan(ProsesKelulusanVM vm)
    {
        if (vm.IdTahunAjaran is null)
        {
            _toastrNotificationService.AddError("Tidak ada tahun ajaran aktif!");
            return RedirectToAction(nameof(ProsesKelulusan));
        }

        var daftarSiswa = await _siswaRepository.GetAllAktif();
        daftarSiswa = daftarSiswa.Where(s => s.Jenjang == Jenjang.XII).ToList();

        foreach (var entry in vm.DaftarEntry.Where(e => e.Luluskan))
        {
            var siswa = daftarSiswa.FirstOrDefault(s => s.Id == entry.IdSiswa);
            if (siswa is not null)
                siswa.StatusAktif = StatusAktifMahasiswa.TidakAktif;
        }

        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
            _toastrNotificationService.AddError("Simpan gagal!");
        else
            _toastrNotificationService.AddSuccess("Simpan sukses!");

        return RedirectToAction(nameof(ProsesKelulusan), new { idTahunAjaran = vm.IdTahunAjaran });
    }

    [Route("[Area]/[Action]")]
    public async Task<IActionResult> NaikKelas(int? idTahunAjaran = null, Jenjang jenjang = Jenjang.X)
    {
        if (jenjang == Jenjang.XII) return BadRequest();

        var tahunAjaran = idTahunAjaran is null ?
            await _tahunAjaranRepository.GetNewest() :
            await _tahunAjaranRepository.Get(idTahunAjaran.Value);

        if (tahunAjaran is null) return View(new NaikKelasVM { DaftarEntry = [], jenjang = jenjang });

        var daftarSiswa = await _siswaRepository.GetAllAktif();
        daftarSiswa = daftarSiswa
            .Where(s => s.Jenjang == jenjang &&
                s.DaftarAnggotaRombel.Any(s => s.Rombel.TahunAjaran == tahunAjaran && s.Rombel.Kelas.Jenjang == jenjang && s.NaikKelasLulus))
            .ToList();

        return View(new NaikKelasVM
        {
            TahunAjaran = tahunAjaran,
            IdTahunAjaran = tahunAjaran.Id,
            DaftarSiswa = daftarSiswa,
            jenjang = jenjang,
            DaftarEntry = daftarSiswa.Select(s => new NaikKelasEntryVM { IdSiswa = s.Id }).ToList()
        });
    }

    [Route("[Area]/[Action]")]
    [HttpPost]
    public async Task<IActionResult> NaikKelas(NaikKelasVM vm)
    {
        if (vm.jenjang == vm.JenjangTujuan)
            return RedirectToAction(nameof(NaikKelas), new { vm.jenjang, vm.IdTahunAjaran });

        var daftarSiswa = await _siswaRepository.GetAllAktif();
        daftarSiswa = daftarSiswa.Where(s => s.Jenjang == vm.jenjang).ToList();

        foreach (var entry in vm.DaftarEntry.Where(e => e.NaikKelas))
        {
            var siswa = daftarSiswa.FirstOrDefault(s => s.Id == entry.IdSiswa);
            if (siswa is not null)
                siswa.Jenjang = vm.JenjangTujuan;
        }

        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
            _toastrNotificationService.AddError("Simpan Gagal!");
        else
            _toastrNotificationService.AddSuccess("Simpan Berhasil!");

        return RedirectToAction(nameof(NaikKelas), new { vm.jenjang, vm.IdTahunAjaran });
    }
}
