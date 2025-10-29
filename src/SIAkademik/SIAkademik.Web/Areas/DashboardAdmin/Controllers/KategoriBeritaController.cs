using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIAkademik.Domain.Abstracts;
using SIAkademik.Domain.Authentication;
using SIAkademik.Domain.ModulProfil.Entities;
using SIAkademik.Domain.ModulProfil.Repositories;
using SIAkademik.Web.Areas.DashboardAdmin.Models.KategoriBeritaModels;
using SIAkademik.Web.Services.Toastr;

namespace SIAkademik.Web.Areas.DashboardAdmin.Controllers;

[Area(AreaNames.DashboardAdmin)]
[Authorize(Roles = AppUserRoles.Admin)]
public class KategoriBeritaController : Controller
{
    private readonly IKategoriBeritaRepository _kategoriBeritaRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IToastrNotificationService _toastrNotificationService;

    public KategoriBeritaController(
        IKategoriBeritaRepository kategoriBeritaRepository,
        IUnitOfWork unitOfWork,
        IToastrNotificationService toastrNotificationService)
    {
        _kategoriBeritaRepository = kategoriBeritaRepository;
        _unitOfWork = unitOfWork;
        _toastrNotificationService = toastrNotificationService;
    }

    public async Task<IActionResult> Index() => View(await _kategoriBeritaRepository.GetAll());

    public IActionResult Tambah() => View(new TambahVM());

    [HttpPost]
    public async Task<IActionResult> Tambah(TambahVM vm)
    {
        if (!ModelState.IsValid) return View(vm);

        if(await _kategoriBeritaRepository.IsExist(vm.Nama))
        {
            ModelState.AddModelError(nameof(TambahVM.Nama), $"Nama '{vm.Nama}' sudah digunakan!");
            return View(vm);
        }

        var kategoriBerita = new KategoriBerita
        {
            Nama = vm.Nama.Trim().ApplyCase(LetterCasing.Title),
        };

        _kategoriBeritaRepository.Add(kategoriBerita);
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
        var kategoriBerita = await _kategoriBeritaRepository.Get(id);
        if (kategoriBerita is null) return NotFound();

        return View(new EditVM { Id = kategoriBerita.Id, Nama = kategoriBerita.Nama });
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EditVM vm)
    {
        if (!ModelState.IsValid) return View(vm);

        if (await _kategoriBeritaRepository.IsExist(vm.Nama, vm.Id))
        {
            ModelState.AddModelError(nameof(EditVM.Nama), $"Nama '{vm.Nama}' sudah digunakan");
            return View(vm);
        }

        var kategoriBerita = await _kategoriBeritaRepository.Get(vm.Id);
        if (kategoriBerita is null) return NotFound();

        kategoriBerita.Nama = vm.Nama;

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
        var kategoriBerita = await _kategoriBeritaRepository.Get(id);
        if (kategoriBerita is null) return NotFound();

        _kategoriBeritaRepository.Delete(kategoriBerita);
        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsSuccess)
            _toastrNotificationService.AddSuccess("Simpan Berhasil!");
        else
            _toastrNotificationService.AddError("Simpan Gagal!");

        return RedirectToAction(nameof(Index));
    }
}
