using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIAkademik.Domain.Abstracts;
using SIAkademik.Domain.Authentication;
using SIAkademik.Domain.Enums;
using SIAkademik.Domain.ModulSiakad.Entities;
using SIAkademik.Domain.ModulSiakad.Repositories;
using SIAkademik.Web.Areas.DashboardAdmin.Models.KelasModels;
using SIAkademik.Web.Services.Toastr;

namespace SIAkademik.Web.Areas.DashboardAdmin.Controllers;

[Area(AreaNames.DashboardAdmin)]
[Authorize(Roles = AppUserRoles.Admin)]
public class KelasController : Controller
{
    private readonly IKelasRepository _kelasRepository;
    private readonly IRombelRepository _rombelRepository;
    private readonly IPeminatanRepository _peminatanRepository;
    private readonly ITahunAjaranRepository _tahunAjaranRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IToastrNotificationService _toastrNotificationService;

    public KelasController(
        IKelasRepository kelasRepository,
        IRombelRepository rombelRepository,
        IUnitOfWork unitOfWork,
        ITahunAjaranRepository tahunAjaranRepository,
        IToastrNotificationService toastrNotificationService,
        IPeminatanRepository peminatanRepository)
    {
        _kelasRepository = kelasRepository;
        _rombelRepository = rombelRepository;
        _unitOfWork = unitOfWork;
        _tahunAjaranRepository = tahunAjaranRepository;
        _toastrNotificationService = toastrNotificationService;
        _peminatanRepository = peminatanRepository;
    }

    public async Task<IActionResult> Index(int? idTahunAjaran = null)
    {
        var tahunAjaran = idTahunAjaran is null ? null : await _tahunAjaranRepository.Get(idTahunAjaran.Value);

        return View(new IndexVM
        {
            TahunAjaran = tahunAjaran,
            DaftarKelas = tahunAjaran?.DaftarKelas ?? await _kelasRepository.GetAll(),
        });
    }

    public IActionResult Tambah(int? idTahunAjaran = null) => View(new TambahVM() { IdTahunAjaran = idTahunAjaran ?? default });

    [HttpPost]
    public async Task<IActionResult> Tambah(TambahVM vm)
    {
        if (!ModelState.IsValid) return View(vm);

        var tahunAjaran = await _tahunAjaranRepository.Get(vm.IdTahunAjaran);
        if (tahunAjaran is null)
        {
            ModelState.AddModelError(nameof(TambahVM.IdTahunAjaran), $"Tahun Ajaran dengan Id '{vm.IdTahunAjaran}' tidak dapat ditemukan");
            return View(vm);
        }

        var peminatan = await _peminatanRepository.Get(vm.PeminatanId);
        if (peminatan is null)
        {
            ModelState.AddModelError(nameof(TambahVM.PeminatanId), $"Peminatan dengan Id '{vm.PeminatanId}' tidak dapat ditemukan");
            return View(vm);
        }

        var kelas = new Kelas
        {
            Jenjang = vm.Jenjang,
            Peminatan = peminatan,
            TahunAjaran = tahunAjaran
        };

        _kelasRepository.Add(kelas);
        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
        {
            ModelState.AddModelError(string.Empty, "Simpan kelas baru gagal!");
            return View(vm);
        }

        _toastrNotificationService.AddSuccess("Berhasil menambahkan kelas baru!");

        return RedirectToAction(nameof(Index), new { idTahunAjaran = vm.IdTahunAjaran });
    }

    public async Task<IActionResult> Edit(int id)
    {
        var kelas = await _kelasRepository.Get(id);
        if (kelas is null) return NotFound();

        return View(new EditVM
        {
            Id = id,
            Jenjang = kelas.Jenjang,
            PeminatanId = kelas.Peminatan.Id,
            IdTahunAjaran = kelas.TahunAjaran.Id
        });
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EditVM vm)
    {
        if (!ModelState.IsValid) return View(vm);

        var kelas = await _kelasRepository.Get(vm.Id);
        if (kelas is null) return NotFound();

        var tahunAjaran = await _tahunAjaranRepository.Get(vm.IdTahunAjaran);
        if (tahunAjaran is null)
        {
            ModelState.AddModelError(nameof(EditVM.IdTahunAjaran), $"Tahun ajaran dengan Id '{vm.IdTahunAjaran}' tidak ditemukan");
            return View(vm);
        }

        var peminatan = await _peminatanRepository.Get(vm.PeminatanId);
        if (peminatan is null)
        {
            ModelState.AddModelError(nameof(EditVM.PeminatanId), $"Peminatan dengan Id '{vm.PeminatanId}' tidak dapat ditemukan");
            return View(vm);
        }

        kelas.Jenjang = vm.Jenjang;
        kelas.Peminatan = peminatan;
        kelas.TahunAjaran = tahunAjaran;

        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
        {
            ModelState.AddModelError(string.Empty, "Gagal menyimpan perubahan");
            return View(vm);
        }

        _toastrNotificationService.AddSuccess($"Berhasil mengubah data kelas dengan Id '{kelas.Id}'!");

        return RedirectToAction(nameof(Index), new { idTahunAjaran = kelas.TahunAjaran.Id });
    }

    [HttpPost]
    public async Task<IActionResult> Hapus(int id)
    {
        var kelas = await _kelasRepository.Get(id);
        if (kelas is null) return NotFound();

        var idTahunAjaran = kelas.TahunAjaran.Id;

        _kelasRepository.Delete(kelas);
        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
            _toastrNotificationService.AddError("Gagal menghapus kelas!");
        else
            _toastrNotificationService.AddSuccess("Sukses menghapus kelas!");

        return RedirectToAction(nameof(Index), new { idTahunAjaran });
    }

    [HttpGet]
    public async Task<IActionResult> DaftarKelas(int idTahunAjaran)
    {
        var daftarKelas = await _kelasRepository.GetAllByTahunAjaran(idTahunAjaran);
        return Json(daftarKelas.Select(x => new { x.Id, Jenjang = x.Jenjang.Humanize(), Peminatan = x.Peminatan.Nama }));
    }
}
