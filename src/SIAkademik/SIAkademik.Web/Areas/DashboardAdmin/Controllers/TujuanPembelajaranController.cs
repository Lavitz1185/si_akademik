using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIAkademik.Domain.Abstracts;
using SIAkademik.Domain.Authentication;
using SIAkademik.Domain.Enums;
using SIAkademik.Domain.ModulSiakad.Entities;
using SIAkademik.Domain.ModulSiakad.Repositories;
using SIAkademik.Web.Areas.DashboardAdmin.Models.TujuanPembelajaranModels;
using SIAkademik.Web.Services.Toastr;

namespace SIAkademik.Web.Areas.DashboardAdmin.Controllers;

[Area(AreaNames.DashboardAdmin)]
[Authorize(Roles = AppUserRoles.Admin)]
public class TujuanPembelajaranController : Controller
{
    private readonly ITujuanPembelajaranRepository _tujuanPembelajaranRepository;
    private readonly IMataPelajaranRepository _mataPelajaranRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IToastrNotificationService _toastrNotificationService;

    public TujuanPembelajaranController(
        ITujuanPembelajaranRepository tujuanPembelajaranRepository,
        IMataPelajaranRepository mataPelajaranRepository,
        IUnitOfWork unitOfWork,
        IToastrNotificationService toastrNotificationService)
    {
        _tujuanPembelajaranRepository = tujuanPembelajaranRepository;
        _mataPelajaranRepository = mataPelajaranRepository;
        _unitOfWork = unitOfWork;
        _toastrNotificationService = toastrNotificationService;
    }

    public async Task<IActionResult> Index(int? idMataPelajaran = null, Fase? fase = null)
    {
        var daftarTujuanPembelajaran = new List<TujuanPembelajaran>();
        MataPelajaran? mataPelajaran = idMataPelajaran is not null ?
            await _mataPelajaranRepository.Get(idMataPelajaran.Value) :
            null;

        if (mataPelajaran is not null && fase is not null)
            daftarTujuanPembelajaran = await _tujuanPembelajaranRepository.GetAll(mataPelajaran.Id, fase.Value);
        else if (mataPelajaran is not null)
            daftarTujuanPembelajaran = await _tujuanPembelajaranRepository.GetAll(mataPelajaran.Id);
        else if (fase is not null)
            daftarTujuanPembelajaran = await _tujuanPembelajaranRepository.GetAll(fase.Value);
        else
            daftarTujuanPembelajaran = await _tujuanPembelajaranRepository.GetAll();

        return View(new IndexVM
        {
            IdMataPelajaran = mataPelajaran?.Id,
            Fase = fase,
            DaftarTujuanPembelajaran = daftarTujuanPembelajaran
        });
    }

    public async Task<IActionResult> Tambah(int? idMataPelajaran = null, Fase? fase = null)
    {
        MataPelajaran? mataPelajaran = idMataPelajaran is null ? null : await _mataPelajaranRepository.Get(idMataPelajaran.Value);

        return View(new TambahVM
        {
            IdMataPelajaran = mataPelajaran?.Id ?? default,
            Fase = fase ?? default,
            idMataPelajaran = mataPelajaran?.Id,
            fase = fase
        });
    }

    [HttpPost]
    public async Task<IActionResult> Tambah(TambahVM vm)
    {
        if (!ModelState.IsValid) return View(vm);

        var mataPelajaran = await _mataPelajaranRepository.Get(vm.IdMataPelajaran);
        if (mataPelajaran is null)
        {
            ModelState.AddModelError(nameof(TambahVM.IdMataPelajaran), $"Mata Pelajaran dengan Id '{vm.IdMataPelajaran}' tidak ditemukan!");
            return View(vm);
        }

        if (await _tujuanPembelajaranRepository.IsExist(vm.Nomor, vm.IdMataPelajaran, vm.Fase))
        {
            ModelState.AddModelError(nameof(TambahVM.Nomor),
                $"TP dengan nomor '{vm.Nomor}' sudah ada untuk mata pelajaran {mataPelajaran.Nama}({mataPelajaran.Peminatan.Nama}) dan " +
                $"fase {vm.Fase.Humanize()}");
            return View(vm);
        }

        if (await _tujuanPembelajaranRepository.IsExist(vm.Deskripsi, vm.IdMataPelajaran, vm.Fase))
        {
            ModelState.AddModelError(nameof(TambahVM.Deskripsi),
                $"TP dengan deskripsi ini sudah ada untuk mata pelajaran {mataPelajaran.Nama}({mataPelajaran.Peminatan.Nama}) dan " +
                $"fase {vm.Fase.Humanize()}");
            return View(vm);
        }

        var tujuanPembelajaran = new TujuanPembelajaran
        {
            Nomor = vm.Nomor,
            Deskripsi = vm.Deskripsi,
            Fase = vm.Fase,
            MataPelajaran = mataPelajaran
        };

        _tujuanPembelajaranRepository.Add(tujuanPembelajaran);
        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
        {
            ModelState.AddModelError(string.Empty, "Simpan Gagal!");
            return View(vm);
        }

        _toastrNotificationService.AddSuccess("Simpan Berhasil!");
        return RedirectToAction(nameof(Index), new { vm.idMataPelajaran, vm.fase });
    }

    public async Task<IActionResult> Edit(int id, int? idMataPelajaran = null, Fase? fase = null)
    {
        var tujuanPembelajaran = await _tujuanPembelajaranRepository.Get(id);
        if (tujuanPembelajaran is null) return NotFound();

        MataPelajaran? mataPelajaran = idMataPelajaran is null ? null : await _mataPelajaranRepository.Get(idMataPelajaran.Value);

        return View(new EditVM
        {
            Id = tujuanPembelajaran.Id,
            Deskripsi = tujuanPembelajaran.Deskripsi,
            Nomor = tujuanPembelajaran.Nomor,
            Fase = tujuanPembelajaran.Fase,
            IdMataPelajaran = tujuanPembelajaran.MataPelajaran.Id,
            fase = fase,
            idMataPelajaran = mataPelajaran?.Id
        });
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EditVM vm)
    {
        if (!ModelState.IsValid) return View(vm);

        var tujuanPembelajaran = await _tujuanPembelajaranRepository.Get(vm.Id);
        if (tujuanPembelajaran is null) return NotFound();

        var mataPelajaran = await _mataPelajaranRepository.Get(vm.IdMataPelajaran);
        if (mataPelajaran is null)
        {
            ModelState.AddModelError(nameof(EditVM.IdMataPelajaran), $"Mata Pelajaran dengan Id '{vm.IdMataPelajaran}' tidak ditemukan!");
            return View(vm);
        }

        if (await _tujuanPembelajaranRepository.IsExist(vm.Nomor, vm.IdMataPelajaran, vm.Fase, vm.Id))
        {
            ModelState.AddModelError(nameof(EditVM.Nomor),
                $"TP dengan nomor '{vm.Nomor}' sudah ada untuk mata pelajaran {mataPelajaran.Nama}({mataPelajaran.Peminatan.Nama}) dan " +
                $"fase {vm.Fase.Humanize()}");
            return View(vm);
        }

        if (await _tujuanPembelajaranRepository.IsExist(vm.Deskripsi, vm.IdMataPelajaran, vm.Fase, vm.Id))
        {
            ModelState.AddModelError(nameof(EditVM.Deskripsi),
                $"TP dengan deskripsi ini sudah ada untuk mata pelajaran {mataPelajaran.Nama}({mataPelajaran.Peminatan.Nama}) dan " +
                $"fase {vm.Fase.Humanize()}");
            return View(vm);
        }

        tujuanPembelajaran.Nomor = vm.Nomor;
        tujuanPembelajaran.Deskripsi = vm.Deskripsi;
        tujuanPembelajaran.Fase = vm.Fase;
        tujuanPembelajaran.MataPelajaran = mataPelajaran;

        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
        {
            ModelState.AddModelError(string.Empty, "Simpan Gagal!");
            return View(vm);
        }

        _toastrNotificationService.AddSuccess("Simpan Berhasil!");
        return RedirectToAction(nameof(Index), new { vm.idMataPelajaran, vm.fase });
    }

    [HttpPost]
    public async Task<IActionResult> Hapus(int id, int? idMataPelajaran = null, Fase? fase = null)
    {
        var tujuanPembelajaran = await _tujuanPembelajaranRepository.Get(id);
        if (tujuanPembelajaran is null) return NotFound();

        MataPelajaran? mataPelajaran = idMataPelajaran is null ? null : await _mataPelajaranRepository.Get(idMataPelajaran.Value);

        _tujuanPembelajaranRepository.Delete(tujuanPembelajaran);
        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
            _toastrNotificationService.AddError("Hapus Gagal!");
        else
            _toastrNotificationService.AddSuccess("Hapus Berhasil!");

        return RedirectToAction(nameof(Index), new { idMataPelajaran = mataPelajaran?.Id, fase });
    }
}
