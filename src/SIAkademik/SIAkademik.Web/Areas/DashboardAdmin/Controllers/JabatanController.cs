using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIAkademik.Domain.Abstracts;
using SIAkademik.Domain.Authentication;
using SIAkademik.Domain.Enums;
using SIAkademik.Domain.ModulSiakad.Entities;
using SIAkademik.Domain.ModulSiakad.Repositories;
using SIAkademik.Web.Areas.DashboardAdmin.Models.JabatanModels;
using SIAkademik.Web.Services.Toastr;

namespace SIAkademik.Web.Areas.DashboardAdmin.Controllers;

[Area(AreaNames.DashboardAdmin)]
[Authorize(Roles = AppUserRoles.Admin)]
public class JabatanController : Controller
{
    private readonly IJabatanRepository _jabatanRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IToastrNotificationService _toastrNotificationService;

    public JabatanController(
        IJabatanRepository jabatanRepository,
        IUnitOfWork unitOfWork,
        IToastrNotificationService toastrNotificationService)
    {
        _jabatanRepository = jabatanRepository;
        _unitOfWork = unitOfWork;
        _toastrNotificationService = toastrNotificationService;
    }

    public async Task<IActionResult> Index()
    {
        var daftarJabatan = await _jabatanRepository.GetAll();

        return View(daftarJabatan);
    }

    public IActionResult Tambah(string? returnUrl = null) => View(new TambahVM { ReturnUrl = returnUrl ?? Url.ActionLink(nameof(Index))! });

    [HttpPost]
    public async Task<IActionResult> Tambah(TambahVM vm)
    {
        if (!ModelState.IsValid) return View(vm);

        if (await _jabatanRepository.IsExistByNama(vm.Nama))
        {
            ModelState.AddModelError(nameof(TambahVM.Nama), "Nama sudah digunakan!");
            return View(vm);
        }

        var jabatan = new Jabatan
        {
            Nama = vm.Nama,
            Jenis = vm.Jenis,
        };

        _jabatanRepository.Add(jabatan);
        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
        {
            ModelState.AddModelError(string.Empty, "Simpan gagal!");
            return View(vm);
        }

        _toastrNotificationService.AddSuccess("Simpan data jabatan baru berhasil!");

        return Redirect(vm.ReturnUrl);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var jabatan = await _jabatanRepository.Get(id);
        if (jabatan is null) return NotFound();

        return View(new EditVM
        {
            Id = jabatan.Id,
            Nama = jabatan.Nama,
            Jenis = jabatan.Jenis
        });
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EditVM vm)
    {
        if (!ModelState.IsValid) return View(vm);

        var jabatan = await _jabatanRepository.Get(vm.Id);
        if (jabatan is null) return NotFound();

        if (await _jabatanRepository.IsExistByNama(vm.Nama, vm.Id))
        {
            ModelState.AddModelError(nameof(EditVM.Nama), "Nama sudah digunakan!");
            return View(vm);
        }

        jabatan.Nama = vm.Nama;
        jabatan.Jenis = vm.Jenis;

        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
        {
            ModelState.AddModelError(string.Empty, "Simpan gagal!");
            return View(vm);
        }

        _toastrNotificationService.AddSuccess("Ubah data jabatan berhasil!");

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Hapus(int id)
    {
        var jabatan = await _jabatanRepository.Get(id);
        if (jabatan is null) return NotFound();

        _jabatanRepository.Delete(jabatan);
        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
            _toastrNotificationService.AddError("Hapus data jabatan gagal!");
        else
            _toastrNotificationService.AddSuccess("Hapus data jabatan berhasil!");

        return RedirectToAction(nameof(Index));
    }
}
