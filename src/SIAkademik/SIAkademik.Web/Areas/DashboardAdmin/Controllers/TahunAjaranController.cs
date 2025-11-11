using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIAkademik.Domain.Abstracts;
using SIAkademik.Domain.Authentication;
using SIAkademik.Domain.Enums;
using SIAkademik.Domain.ModulSiakad.Entities;
using SIAkademik.Domain.ModulSiakad.Repositories;
using SIAkademik.Web.Areas.DashboardAdmin.Models.TahunAjaranModels;
using SIAkademik.Web.Services.Toastr;

namespace SIAkademik.Web.Areas.DashboardAdmin.Controllers;

[Area(AreaNames.DashboardAdmin)]
[Authorize(Roles = AppUserRoles.Admin)]
public class TahunAjaranController : Controller
{
    private readonly ITahunAjaranRepository _tahunAjaranRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IToastrNotificationService _toastrNotificationService;

    public TahunAjaranController(
        ITahunAjaranRepository tahunAjaranRepository,
        IUnitOfWork unitOfWork,
        IToastrNotificationService toastrNotificationService)
    {
        _tahunAjaranRepository = tahunAjaranRepository;
        _unitOfWork = unitOfWork;
        _toastrNotificationService = toastrNotificationService;
    }

    public async Task<IActionResult> Index()
    {
        var daftarTahunAjaran = await _tahunAjaranRepository.GetAll();

        return View(daftarTahunAjaran);
    }

    public IActionResult Tambah(int? tahun = null, Semester? semester = null, string? returnUrl = null) => 
        View(new TambahVM
        {
            Tahun = tahun ?? default,
            Semester = semester ?? default,
            ReturnUrl = returnUrl
        });

    [HttpPost]
    public async Task<IActionResult> Tambah(TambahVM vm)
    {
        if(!ModelState.IsValid) return View(vm);

        var tahunAjaran = new TahunAjaran
        {
            Tahun = vm.Tahun,
            Semester = vm.Semester,
            TanggalMulai = vm.TanggalMulai,
            TanggalSelesai = vm.TanggalSelesai
        };

        _tahunAjaranRepository.Add(tahunAjaran);

        var result = await _unitOfWork.SaveChangesAsync();
        if(result.IsFailure)
        {
            ModelState.AddModelError(string.Empty, "Simpan data gagal!");
            return View(vm);
        }

        _toastrNotificationService.AddSuccess("Tahun Ajaran Baru Berhasil Ditambahkan");

        return Redirect(vm.ReturnUrl ?? Url.Action(nameof(Index))!);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var tahunAjaran = await _tahunAjaranRepository.Get(id);
        if (tahunAjaran is null) return NotFound();

        return View(new EditVM
        {
            Id = id,
            Tahun = tahunAjaran.Tahun,
            Semester = tahunAjaran.Semester,
            TanggalMulai = tahunAjaran.TanggalMulai,
            TanggalSelesai = tahunAjaran.TanggalSelesai
        });
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EditVM vm)
    {
        if (!ModelState.IsValid) return View(vm);

        var tahunAjaran = await _tahunAjaranRepository.Get(vm.Id);
        if (tahunAjaran is null) return View(vm);

        tahunAjaran.Tahun = vm.Tahun;
        tahunAjaran.Semester = vm.Semester;
        tahunAjaran.TanggalMulai = vm.TanggalMulai;
        tahunAjaran.TanggalSelesai = vm.TanggalSelesai;

        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
        {
            ModelState.AddModelError(string.Empty, "Simpan data gagal!");
            return View(vm);
        }

        _toastrNotificationService.AddSuccess("Data Tahun Ajaran Berhasil Diubah");

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Hapus(int id)
    {
        var tahunAjaran = await _tahunAjaranRepository.Get(id);
        if(tahunAjaran is null) return NotFound();

        _tahunAjaranRepository.Delete(tahunAjaran);

        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
            _toastrNotificationService
                .AddError($"Gagal hapus tahun ajaran {tahunAjaran.Periode} {tahunAjaran.Semester.Humanize()}");
        else
            _toastrNotificationService
                .AddSuccess($"Sukses hapus tahun ajaran {tahunAjaran.Periode} {tahunAjaran.Semester.Humanize()}");

        return RedirectToAction(nameof(Index));
    }
}
