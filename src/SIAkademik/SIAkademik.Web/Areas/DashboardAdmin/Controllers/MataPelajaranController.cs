using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIAkademik.Domain.Abstracts;
using SIAkademik.Domain.Authentication;
using SIAkademik.Domain.ModulSiakad.Entities;
using SIAkademik.Domain.ModulSiakad.Repositories;
using SIAkademik.Web.Areas.DashboardAdmin.Models.MataPelajaranModels;
using SIAkademik.Web.Services.Toastr;

namespace SIAkademik.Web.Areas.DashboardAdmin.Controllers;

[Area(AreaNames.DashboardAdmin)]
[Authorize(Roles = AppUserRoles.Admin)]
public class MataPelajaranController : Controller
{
    private readonly IMataPelajaranRepository _mataPelajaranRepository;
    private readonly IRombelRepository _rombelRepository;
    private readonly IPegawaiRepository _pegawaiRepository;
    private readonly IJadwalMengajarRepository _jadwalMengajarRepository;
    private readonly IPeminatanRepository _peminatanRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IToastrNotificationService _toastrNotificationService;

    public MataPelajaranController(
        IMataPelajaranRepository mataPelajaranRepository,
        IRombelRepository rombelRepository,
        IPegawaiRepository pegawaiRepository,
        IJadwalMengajarRepository jadwalMengajarRepository,
        IUnitOfWork unitOfWork,
        IToastrNotificationService toastrNotificationService,
        IPeminatanRepository peminatanRepository)
    {
        _mataPelajaranRepository = mataPelajaranRepository;
        _rombelRepository = rombelRepository;
        _pegawaiRepository = pegawaiRepository;
        _jadwalMengajarRepository = jadwalMengajarRepository;
        _unitOfWork = unitOfWork;
        _toastrNotificationService = toastrNotificationService;
        _peminatanRepository = peminatanRepository;
    }

    public async Task<IActionResult> Index()
    {
        var daftarMataPelajaran = await _mataPelajaranRepository.GetAll();

        return View(daftarMataPelajaran);
    }

    public IActionResult Tambah() => View(new TambahVM());

    [HttpPost]
    public async Task<IActionResult> Tambah(TambahVM vm)
    {
        if (!ModelState.IsValid) return View(vm);

        var peminatan = await _peminatanRepository.Get(vm.PeminatanId);
        if (peminatan is null)
        {
            ModelState.AddModelError(nameof(TambahVM.PeminatanId), $"Peminatan dengan Id '{vm.PeminatanId}' tidak ditemukan");
            return View(vm);
        }

        var mataPelajaran = new MataPelajaran
        {
            Nama = vm.Nama,
            Peminatan = peminatan,
            KKM = vm.KKM
        };

        _mataPelajaranRepository.Add(mataPelajaran);
        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
        {
            ModelState.AddModelError(string.Empty, "Simpan data mata pelajaran gagal!");
            return View(vm);
        }

        _toastrNotificationService.AddSuccess("Data mata pelajaran berhasil ditambahkan");

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var mataPelajaran = await _mataPelajaranRepository.Get(id);
        if (mataPelajaran is null) return NotFound();

        return View(new EditVM
        {
            Id = id,
            Nama = mataPelajaran.Nama,
            PeminatanId = mataPelajaran.Peminatan.Id,
            KKM = mataPelajaran.KKM
        });
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EditVM vm)
    {
        if (!ModelState.IsValid) return View(vm);

        var mataPelajaran = await _mataPelajaranRepository.Get(vm.Id);
        if (mataPelajaran is null) return NotFound();

        var peminatan = await _peminatanRepository.Get(vm.PeminatanId);
        if (peminatan is null)
        {
            ModelState.AddModelError(nameof(EditVM.PeminatanId), $"Peminatan dengan Id '{vm.PeminatanId}' tidak ditemukan");
            return View(vm);
        }

        mataPelajaran.Nama = vm.Nama;
        mataPelajaran.Peminatan = peminatan;
        mataPelajaran.KKM = vm.KKM;

        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
        {
            ModelState.AddModelError(string.Empty, "Simpan data mata pelajaran gagal!");
            return View(vm);
        }

        _toastrNotificationService.AddSuccess("Data mata pelajaran berhasil diubah!");

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Hapus(int id)
    {
        var mataPelajaran = await _mataPelajaranRepository.Get(id);

        if (mataPelajaran is null) return NotFound();

        _mataPelajaranRepository.Delete(mataPelajaran);
        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
            _toastrNotificationService.AddError("Hapus data mata pelajaran gagal!");
        else
            _toastrNotificationService.AddSuccess("Hapus data mata pelajaran sukses!");

        return RedirectToAction(nameof(Index));
    }
}
