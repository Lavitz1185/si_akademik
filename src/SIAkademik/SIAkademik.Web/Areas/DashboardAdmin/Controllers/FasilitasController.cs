using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIAkademik.Domain.Abstracts;
using SIAkademik.Domain.Authentication;
using SIAkademik.Domain.ModulProfil.Entities;
using SIAkademik.Domain.ModulProfil.Repositories;
using SIAkademik.Infrastructure.Services.FileServices;
using SIAkademik.Web.Areas.DashboardAdmin.Models.FasilitasModels;
using SIAkademik.Web.Services.Toastr;

namespace SIAkademik.Web.Areas.DashboardAdmin.Controllers;

[Area(AreaNames.DashboardAdmin)]
[Authorize(Roles = AppUserRoles.Admin)]
public class FasilitasController : Controller
{
    private readonly IFasilitasRepository _fasilitasRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IToastrNotificationService _toastrNotificationService;
    private readonly IFileService _fileService;

    public FasilitasController(
        IFasilitasRepository fasilitasRepository,
        IUnitOfWork unitOfWork,
        IToastrNotificationService toastrNotificationService,
        IFileService fileService)
    {
        _fasilitasRepository = fasilitasRepository;
        _unitOfWork = unitOfWork;
        _toastrNotificationService = toastrNotificationService;
        _fileService = fileService;
    }

    public async Task<IActionResult> Index() => View(await _fasilitasRepository.GetAll());

    public IActionResult Tambah() => View(new TambahVM());

    [HttpPost]
    public async Task<IActionResult> Tambah(TambahVM vm)
    {
        if (!ModelState.IsValid) return View(vm);

        if (vm.Foto is null)
        {
            ModelState.AddModelError(nameof(TambahVM.Foto), "Foto harus diupload");
            return View(vm);
        }

        if (await _fasilitasRepository.IsExist(vm.Nama))
        {
            ModelState.AddModelError(nameof(TambahVM.Nama), $"Nama '{vm.Nama}' sudah digunakan");
            return View(vm);
        }

        var foto = await _fileService.UploadFile<TambahVM>(
            vm.Foto,
            "/images/fasilitas",
            [".jpeg", ".jpg", ".png"],
            0,
            104858);

        if (foto.IsFailure)
        {
            ModelState.AddModelError(nameof(TambahVM.Foto), foto.Error.Message);
            return View(vm);
        }

        var fasilitas = new Fasilitas
        {
            Nama = vm.Nama,
            Deskripsi = vm.Deskripsi,
            Foto = foto.Value
        };

        _fasilitasRepository.Add(fasilitas);
        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
        {
            ModelState.AddModelError(string.Empty, "Simpan Gagal!");

            _fileService.Delete(foto.Value);

            return View(vm);
        }

        _toastrNotificationService.AddSuccess("Simpan Berhasil");

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var fasilitas = await _fasilitasRepository.Get(id);
        if (fasilitas is null) return NotFound();

        return View(new EditVM
        {
            Id = fasilitas.Id,
            Deskripsi = fasilitas.Deskripsi,
            Nama = fasilitas.Nama,
            FotoLama = fasilitas.Foto
        });
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EditVM vm)
    {
        if (!ModelState.IsValid) return View(vm);

        var fasilitas = await _fasilitasRepository.Get(vm.Id);
        if (fasilitas is null) return NotFound();

        if (await _fasilitasRepository.IsExist(vm.Nama, fasilitas.Id))
        {
            ModelState.AddModelError(nameof(EditVM.Nama), $"Nama '{vm.Nama}' sudah digunakan");
            return View(vm);
        }

        fasilitas.Nama = vm.Nama;
        fasilitas.Deskripsi = vm.Deskripsi;

        if (vm.FotoBaru is not null)
        {
            var foto = await _fileService.UploadFile<EditVM>(
                vm.FotoBaru,
                "/images/fasilitas",
                [".jpeg", ".jpg", ".png"],
                0,
                104858);

            if (foto.IsFailure)
            {
                ModelState.AddModelError(nameof(EditVM.FotoBaru), foto.Error.Message);
                return View(vm);
            }

            fasilitas.Foto = foto.Value;
        }

        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
        {
            if (vm.FotoBaru is not null) _fileService.Delete(fasilitas.Foto);

            ModelState.AddModelError(string.Empty, "Simpan Gagal!");

            return View(vm);
        }

        if (vm.FotoBaru is not null) _fileService.Delete(vm.FotoLama);

        _toastrNotificationService.AddSuccess("Simpan Berhasil");

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Hapus(int id)
    {
        var fasilitas = await _fasilitasRepository.Get(id);
        if (fasilitas is null) return NotFound();

        var foto = fasilitas.Foto;

        _fasilitasRepository.Delete(fasilitas);
        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsSuccess)
        {

            _fileService.Delete(foto);
            _toastrNotificationService.AddSuccess("Hapus Berhasil");
        }
        else
            _toastrNotificationService.AddError("Hapus Gagal!");

        return RedirectToAction(nameof(Index));
    }
}
