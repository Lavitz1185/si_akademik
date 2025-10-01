using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIAkademik.Domain.Abstracts;
using SIAkademik.Domain.Authentication;
using SIAkademik.Domain.ModulSiakad.Entities;
using SIAkademik.Domain.ModulSiakad.Repositories;
using SIAkademik.Web.Areas.DashboardAdmin.Models.PeminatanModels;
using SIAkademik.Web.Services.Toastr;

namespace SIAkademik.Web.Areas.DashboardAdmin.Controllers;

[Area(AreaNames.DashboardAdmin)]
[Authorize(Roles = AppUserRoles.Admin)]
public class PeminatanController : Controller
{
    private readonly IPeminatanRepository _peminatanRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IToastrNotificationService _toastrNotificationService;

    public PeminatanController(
        IPeminatanRepository peminatanRepository,
        IUnitOfWork unitOfWork,
        IToastrNotificationService toastrNotificationService)
    {
        _peminatanRepository = peminatanRepository;
        _unitOfWork = unitOfWork;
        _toastrNotificationService = toastrNotificationService;
    }

    public async Task<IActionResult> Index() => View(await _peminatanRepository.GetAll());

    public IActionResult Tambah() => View(new TambahVM());

    [HttpPost]
    public async Task<IActionResult> Tambah(TambahVM vm)
    {
        if (!ModelState.IsValid) return View(vm);

        if (await _peminatanRepository.IsExist(vm.Nama))
        {
            ModelState.AddModelError(nameof(TambahVM.Nama), $"Nama '{vm.Nama}' sudah digunakan!");
            return View(vm);
        }

        var peminatan = new Peminatan
        {
            Nama = vm.Nama,
            Jenis = vm.Jenis,
        };

        _peminatanRepository.Add(peminatan);
        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
        {
            ModelState.AddModelError(string.Empty, "Simpan Gagal!");
            return View(vm);
        }

        _toastrNotificationService.AddSuccess("Simpan Berhasil!");

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var peminatan = await _peminatanRepository.Get(id);
        if (peminatan is null) return NotFound();

        return View(new EditVM { Id = peminatan.Id, Nama = peminatan.Nama, Jenis = peminatan.Jenis });
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EditVM vm)
    {
        if (!ModelState.IsValid) return View(vm);

        var peminatan = await _peminatanRepository.Get(vm.Id);
        if (peminatan is null) return NotFound();

        if (await _peminatanRepository.IsExist(vm.Nama, peminatan.Id))
        {
            ModelState.AddModelError(nameof(EditVM.Nama), $"Nama '{vm.Nama}' sudah digunakan");
            return View(vm);
        }

        peminatan.Nama = vm.Nama;
        peminatan.Jenis = vm.Jenis;

        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
        {
            ModelState.AddModelError(string.Empty, "Simpan Gagal!");
            return View(vm);
        }

        _toastrNotificationService.AddSuccess("Simpan Berhasil!");

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Hapus(int id)
    {
        var peminatan = await _peminatanRepository.Get(id);
        if (peminatan is null) return NotFound();

        _peminatanRepository.Delete(peminatan);
        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
            _toastrNotificationService.AddError("Hapus Gagal!");
        else
            _toastrNotificationService.AddSuccess("Hapus Sukses!");

        return RedirectToAction(nameof(Index));
    }
}
