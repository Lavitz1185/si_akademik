using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIAkademik.Domain.Abstracts;
using SIAkademik.Domain.Authentication;
using SIAkademik.Domain.ModulSiakad.Entities;
using SIAkademik.Domain.ModulSiakad.Repositories;
using SIAkademik.Web.Areas.DashboardAdmin.Models.DivisiModels;
using SIAkademik.Web.Services.Toastr;

namespace SIAkademik.Web.Areas.DashboardAdmin.Controllers;

[Area(AreaNames.DashboardAdmin)]
[Authorize(Roles = AppUserRoles.Admin)]
public class DivisiController : Controller
{
    private readonly IDivisiRepository _divisiRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IToastrNotificationService _toastrNotificationService;

    public DivisiController(
        IDivisiRepository divisiRepository,
        IUnitOfWork unitOfWork,
        IToastrNotificationService toastrNotificationService)
    {
        _divisiRepository = divisiRepository;
        _unitOfWork = unitOfWork;
        _toastrNotificationService = toastrNotificationService;
    }

    public async Task<IActionResult> Index()
    {
        var daftarDivisi = await _divisiRepository.GetAll();

        return View(daftarDivisi);
    }

    public IActionResult Tambah() => View(new TambahVM());

    [HttpPost]
    public async Task<IActionResult> Tambah(TambahVM vm)
    {
        if (!ModelState.IsValid) return View(vm);

        if (await _divisiRepository.IsExistByNama(vm.Nama))
        {
            ModelState.AddModelError(nameof(TambahVM.Nama), $"Nama sudah digunakan!");
            return View(vm);
        }

        var divisi = new Divisi
        {
            Nama = vm.Nama
        };

        _divisiRepository.Add(divisi);
        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
        {
            ModelState.AddModelError(string.Empty, "Simpan data divisi baru gagal!");
            return View(vm);
        }

        _toastrNotificationService.AddSuccess("Simpan data divisi baru berhasil!");
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var divisi = await _divisiRepository.Get(id);
        if (divisi is null) return NotFound();

        return View(new EditVM
        {
            Id = divisi.Id,
            Nama = divisi.Nama
        });
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EditVM vm)
    {
        if (!ModelState.IsValid) return View(vm);

        var divisi = await _divisiRepository.Get(vm.Id);
        if (divisi is null) return NotFound();

        if (await _divisiRepository.IsExistByNama(vm.Nama, vm.Id))
        {
            ModelState.AddModelError(nameof(EditVM.Nama), $"Nama sudah digunakan!");
            return View(vm);
        }

        divisi.Nama = vm.Nama;

        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
        {
            ModelState.AddModelError(string.Empty, "Ubah data divisi gagal!");
            return View(vm);
        }

        _toastrNotificationService.AddSuccess("Ubah data divisi berhasil!");
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Hapus(int id)
    {
        var divisi = await _divisiRepository.Get(id);
        if (divisi is null) return NotFound();

        _divisiRepository.Delete(divisi);
        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
            _toastrNotificationService.AddError("Hapus data divisi gagal!");
        else
            _toastrNotificationService.AddSuccess("Hapus data divisi berhasil!");

        return RedirectToAction(nameof(Index));
    }
}
