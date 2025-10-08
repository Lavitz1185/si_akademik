using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIAkademik.Domain.Abstracts;
using SIAkademik.Domain.Authentication;
using SIAkademik.Domain.Enums;
using SIAkademik.Domain.ModulSiakad.Entities;
using SIAkademik.Domain.ModulSiakad.Repositories;
using SIAkademik.Web.Areas.DashboardAdmin.Models.RombelModels;
using SIAkademik.Web.Services.Toastr;
using System.Security.Cryptography.Xml;

namespace SIAkademik.Web.Areas.DashboardAdmin.Controllers;

[Area(AreaNames.DashboardAdmin)]
[Authorize(Roles = AppUserRoles.Admin)]
public class RombelController : Controller
{
    private readonly IRombelRepository _rombelRepository;
    private readonly IKelasRepository _kelasRepository;
    private readonly ITahunAjaranRepository _tahunAjaranRepository;
    private readonly IPegawaiRepository _pegawaiRepository;
    private readonly ISiswaRepository _siswaRepository;
    private readonly IAnggotaRombelRepository _anggotaRombelRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IToastrNotificationService _toastrNotificationService;

    public RombelController(
        IRombelRepository rombelRepository,
        IKelasRepository kelasRepository,
        ITahunAjaranRepository tahunAjaranRepository,
        IPegawaiRepository pegawaiRepository,
        ISiswaRepository siswaRepository,
        IAnggotaRombelRepository anggotaRombelRepository,
        IUnitOfWork unitOfWork,
        IToastrNotificationService toastrNotificationService)
    {
        _rombelRepository = rombelRepository;
        _kelasRepository = kelasRepository;
        _tahunAjaranRepository = tahunAjaranRepository;
        _pegawaiRepository = pegawaiRepository;
        _siswaRepository = siswaRepository;
        _anggotaRombelRepository = anggotaRombelRepository;
        _unitOfWork = unitOfWork;
        _toastrNotificationService = toastrNotificationService;
    }

    public async Task<IActionResult> Index(int? idKelas = null, int? idTahunAjaran = null)
    {
        var tahunAjaran = idTahunAjaran is null ? 
            await _tahunAjaranRepository.GetNewest() : 
            await _tahunAjaranRepository.Get(idTahunAjaran.Value);

        Kelas? kelas = null;

        if (idKelas is not null)
        {
            if (tahunAjaran is not null)
                kelas = tahunAjaran.DaftarKelas.FirstOrDefault(k => k.Id == idKelas.Value);
            else
                kelas = await _kelasRepository.Get(idKelas.Value);
        }

        var daftarRombel = await _rombelRepository.GetAll();

        if (tahunAjaran is not null)
            daftarRombel = daftarRombel.Where(r => r.Kelas.TahunAjaran == tahunAjaran).ToList();

        if (kelas is not null)
            daftarRombel = daftarRombel.Where(r => r.Kelas == kelas).ToList();

        return View(new IndexVM
        {
            TahunAjaran = tahunAjaran,
            IdTahunAjaran = tahunAjaran?.Id,
            Kelas = kelas,
            IdKelas = kelas?.Id,
            DaftarRombel = daftarRombel
        });
    }

    public IActionResult Tambah(int? idKelas = null, int? idTahunAjaran = null) => 
        View(new TambahVM { IdKelas = idKelas ?? default, IdTahunAjaran = idTahunAjaran ?? default });

    [HttpPost]
    public async Task<IActionResult> Tambah(TambahVM vm)
    {
        if (!ModelState.IsValid) return View(vm);

        var kelas = await _kelasRepository.Get(vm.IdKelas);
        if (kelas is null)
        {
            ModelState.AddModelError(nameof(TambahVM.IdKelas), $"Kelas dengan Id '{vm.IdKelas}'");
            return View(vm);
        }

        var wali = await _pegawaiRepository.Get(vm.NIPWali);
        if (wali is null)
        {
            ModelState.AddModelError(nameof(TambahVM.NIPWali), $"Pegawai dengan NIP '{vm.NIPWali}' tidak ditemukan");
            return View(vm);
        }

        if (kelas.DaftarRombel.Any(r => r.Nama.ToLower() == vm.Nama.ToLower()))
        {
            ModelState.AddModelError(nameof(TambahVM.Nama), $"Nama '{vm.Nama}' sudah digunakan");
            return View(vm);
        }

        // Tambah Data
        var rombel = new Rombel
        {
            Nama = vm.Nama,
            Kelas = kelas,
            Wali = wali
        };

        _rombelRepository.Add(rombel);
        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
        {
            ModelState.AddModelError(string.Empty, "Simpan data rombel baru gagal!");
            return View(vm);
        }

        _toastrNotificationService.AddSuccess("Simpan data rombel baru berhasil!");

        return RedirectToAction(nameof(Index), new { idKelas = vm.IdKelas, idTahunAjaran = kelas.TahunAjaran.Id });
    }

    public async Task<IActionResult> Edit(int id)
    {
        var rombel = await _rombelRepository.Get(id);
        if (rombel is null) return NotFound();

        var kelas = await _kelasRepository.Get(rombel.Kelas.Id);

        return View(new EditVM
        {
            Id = rombel.Id,
            Nama = rombel.Nama,
            IdKelas = rombel.Kelas.Id,
            NIPWali = rombel.Wali.Id,
            IdTahunAjaran = kelas!.TahunAjaran.Id
        });
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EditVM vm)
    {
        if (!ModelState.IsValid) return View(vm);

        var kelas = await _kelasRepository.Get(vm.IdKelas);
        if (kelas is null)
        {
            ModelState.AddModelError(nameof(EditVM.IdKelas), $"Kelas dengan Id '{vm.IdKelas}'");
            return View(vm);
        }

        var wali = await _pegawaiRepository.Get(vm.NIPWali);
        if (wali is null)
        {
            ModelState.AddModelError(nameof(EditVM.NIPWali), $"Pegawai dengan NIP '{vm.NIPWali}' tidak ditemukan");
            return View(vm);
        }

        if (kelas.DaftarRombel.Any(r => r.Id != vm.Id && r.Nama.ToLower() == vm.Nama.ToLower()))
        {
            ModelState.AddModelError(nameof(EditVM.Nama), $"Nama '{vm.Nama}' sudah digunakan");
            return View(vm);
        }

        //Edit data
        var rombel = await _rombelRepository.Get(vm.Id);
        if (rombel is null) return NotFound();

        rombel.Nama = vm.Nama;
        rombel.Kelas = kelas;
        rombel.Wali = wali;

        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
        {
            ModelState.AddModelError(string.Empty, "Ubah data rombel gagal!");
            return View(vm);
        }

        _toastrNotificationService.AddSuccess("Ubah data rombel berhasil!");

        return RedirectToAction(nameof(Index), new { idTahunAjaran = kelas.TahunAjaran.Id, idKelas = kelas.Id });
    }

    [HttpPost]
    public async Task<IActionResult> Hapus(int id)
    {
        var rombel = await _rombelRepository.Get(id);
        if (rombel is null) return NotFound();

        var idKelas = rombel.Kelas.Id;
        var idTahunAjaran = rombel.Kelas.TahunAjaran.Id;

        _rombelRepository.Delete(rombel);

        var result = await _unitOfWork.SaveChangesAsync();

        if (result.IsFailure) _toastrNotificationService.AddError("Hapus data rombel gagal!");
        else _toastrNotificationService.AddSuccess("Hapus data rombel berhasil!");

        return RedirectToAction(nameof(Index), new { idKelas, idTahunAjaran });
    }

    public async Task<IActionResult> Detail(int id)
    {
        var rombel = await _rombelRepository.Get(id);
        if (rombel is null) return NotFound();

        var kelas = await _kelasRepository.Get(rombel.Kelas.Id);

        rombel.Kelas = kelas!;

        return View(rombel);
    }

    [HttpPost]
    public async Task<IActionResult> TambahSiswa(int id, int idSiswa)
    {
        var rombel = await _rombelRepository.Get(id);
        if (rombel is null) return NotFound();

        var siswa = await _siswaRepository.Get(idSiswa);
        if (siswa is null) return NotFound();

        var kelas = await _kelasRepository.Get(rombel.Kelas.Id);

        if (rombel.DaftarAnggotaRombel.Any(a => a.Siswa == siswa))
        {
            _toastrNotificationService.AddError($"Siswa dengan Id '{idSiswa}' sudah ada dalam rombel");
            return RedirectToAction(nameof(Detail), new { id });
        }

        if (kelas!.DaftarRombel.Any(r => r != rombel && r.DaftarAnggotaRombel.Any(a => a.Siswa == siswa)))
        {
            _toastrNotificationService.AddError($"Siswa dengan Id '{idSiswa}' sudah ada dalam rombel di kelas {kelas.Peminatan.Nama}" +
                $" {kelas.Jenjang.Humanize()} - {kelas.TahunAjaran.Periode} {kelas.TahunAjaran.Semester.Humanize()}");
            return RedirectToAction(nameof(Detail), new { id });
        }

        var anggotaRombel = new AnggotaRombel
        {
            IdRombel = rombel.Id,
            IdSiswa = siswa.Id,
            TanggalMasuk = DateOnly.FromDateTime(DateTime.Now),
            Rombel = rombel,
            Siswa = siswa
        };

        _anggotaRombelRepository.Add(anggotaRombel);
        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
            _toastrNotificationService.AddError("Siswa gagal ditambahkan ke rombel");
        else
            _toastrNotificationService.AddSuccess("Siswa berhasil ditambahkan ke rombel");

        return RedirectToAction(nameof(Detail), new { id });
    }

    [HttpPost]
    public async Task<IActionResult> HapusSiswa(int id, int idSiswa)
    {
        var rombel = await _rombelRepository.Get(id);
        if (rombel is null) return NotFound();

        var siswa = await _siswaRepository.Get(idSiswa);
        if (siswa is null) return NotFound();

        var anggotaRombel = rombel.DaftarAnggotaRombel.FirstOrDefault(a => a.Siswa == siswa);
        if (anggotaRombel is null) return NotFound();

        _anggotaRombelRepository.Delete(anggotaRombel);
        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
            _toastrNotificationService.AddError("Siswa gagal dihapus dari rombel");
        else
            _toastrNotificationService.AddSuccess("Siswa berhasil dihapus dari rombel");

        return RedirectToAction(nameof(Detail), new { id });
    }

    [HttpGet]
    public async Task<IActionResult> DaftarRombel(int idTahunAjaran)
    {
        var daftarRombel = await _rombelRepository.GetAllByTahunAjaran(idTahunAjaran);

        return Json(daftarRombel.Select(r => new
        {
            r.Id,
            r.Nama,
            Kelas = new { Jenjang = r.Kelas.Jenjang.Humanize(), Peminatan = r.Kelas.Peminatan.Nama }
        }));
    }
}
