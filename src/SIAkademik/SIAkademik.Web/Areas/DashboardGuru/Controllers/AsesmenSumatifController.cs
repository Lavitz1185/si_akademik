using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIAkademik.Domain.Abstracts;
using SIAkademik.Domain.Authentication;
using SIAkademik.Domain.ModulSiakad.Entities;
using SIAkademik.Domain.ModulSiakad.Repositories;
using SIAkademik.Web.Areas.DashboardGuru.Models.AsesmenSumatifModels;
using SIAkademik.Web.Services.Toastr;

namespace SIAkademik.Web.Areas.DashboardGuru.Controllers;

[Area(AreaNames.DashboardGuru)]
[Authorize(Roles = AppUserRoles.Guru)]
public class AsesmenSumatifController : Controller
{
    private readonly IAsesmenSumatifRepository _asesmenSumatifRepository;
    private readonly IJadwalMengajarRepository _jadwalMengajarRepository;
    private readonly ITujuanPembelajaranRepository _tujuanPembelajaranRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IToastrNotificationService _toastrNotificationService;

    public AsesmenSumatifController(
        IAsesmenSumatifRepository asesmenSumatifRepository,
        IJadwalMengajarRepository jadwalMengajarRepository,
        ITujuanPembelajaranRepository tujuanPembelajaranRepository,
        IUnitOfWork unitOfWork,
        IToastrNotificationService toastrNotificationService)
    {
        _asesmenSumatifRepository = asesmenSumatifRepository;
        _jadwalMengajarRepository = jadwalMengajarRepository;
        _tujuanPembelajaranRepository = tujuanPembelajaranRepository;
        _unitOfWork = unitOfWork;
        _toastrNotificationService = toastrNotificationService;
    }

    [HttpPost]
    public async Task<IActionResult> Tambah(TambahVM vm)
    {
        if (!ModelState.IsValid)
        {
            _toastrNotificationService.AddError("Data tidak valid", "Tambah Target Capaian TP");
            return RedirectToAction("Detail", "JadwalMengajar", new { id = vm.IdJadwalMengajar });
        }

        var jadwalMengajar = await _jadwalMengajarRepository.Get(vm.IdJadwalMengajar);
        if (jadwalMengajar is null)
        {
            _toastrNotificationService.AddError("Jadwal Mengajar tidak ditemukan", "Tambah Target Capaian TP");
            return RedirectToAction("Detail", "JadwalMengajar", new { id = vm.IdJadwalMengajar });
        }

        var tujuanPembelajaran = await _tujuanPembelajaranRepository.Get(vm.IdTujuanPembelajaran);
        if (tujuanPembelajaran is null)
        {
            _toastrNotificationService.AddError("Tujuan Pembelajaran tidak ditemukan", "Tambah Target Capaian TP");
            return RedirectToAction("Detail", "JadwalMengajar", new { id = vm.IdJadwalMengajar });
        }

        if (jadwalMengajar.DaftarAsesmenSumatif.Any(a => a.TujuanPembelajaran == tujuanPembelajaran))
        {
            _toastrNotificationService.AddError("Tujuan Pembelajaran sudah ada untuk kelas ini", "Tambah Target Capaian TP");
            return RedirectToAction("Detail", "JadwalMengajar", new { id = vm.IdJadwalMengajar });
        }

        var asesmenSumatif = new AsesmenSumatif
        {
            IdJadwalMengajar = jadwalMengajar.Id,
            IdTujuanPembelajaran = tujuanPembelajaran.Id,
            JadwalMengajar = jadwalMengajar,
            TujuanPembelajaran = tujuanPembelajaran,
            BatasBawahCukup = vm.BatasBawahCukup,
            BatasBawahBaik = vm.BatasBawahBaik,
            BatasBawahSangatBaik = vm.BatasBawahSangatBaik
        };

        _asesmenSumatifRepository.Add(asesmenSumatif);
        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
            _toastrNotificationService.AddError("Simpan Gagal!", "Tambah Target Capaian TP");
        else
            _toastrNotificationService.AddSuccess("Simpan Berhasil!", "Tambah Target Capaian TP");

        return RedirectToAction("Detail", "JadwalMengajar", new { id = vm.IdJadwalMengajar });
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EditVM vm)
    {
        if (!ModelState.IsValid)
        {
            _toastrNotificationService.AddError("Data tidak valid", "Edit Target Capaian TP");
            return RedirectToAction("Detail", "JadwalMengajar", new { id = vm.IdJadwalMengajar });
        }

        var asesmenSumatif = await _asesmenSumatifRepository.Get(vm.Id);
        if (asesmenSumatif is null)
        {
            _toastrNotificationService.AddError("Asesmen Sumatif tidak ditemukan", "Edit Target Capaian TP");
            return RedirectToAction("Detail", "JadwalMengajar", new { id = vm.IdJadwalMengajar });
        }

        asesmenSumatif.BatasBawahCukup = vm.BatasBawahCukup;
        asesmenSumatif.BatasBawahBaik = vm.BatasBawahBaik;
        asesmenSumatif.BatasBawahSangatBaik = vm.BatasBawahSangatBaik;

        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
            _toastrNotificationService.AddError("Simpan Gagal!", "Edit Target Capaian TP");
        else
            _toastrNotificationService.AddSuccess("Simpan Berhasil!", "Edit Target Capaian TP");

        return RedirectToAction("Detail", "JadwalMengajar", new { id = vm.IdJadwalMengajar });
    }

    [HttpPost]
    public async Task<IActionResult> Hapus(int id, int idJadwalMengajar)
    {
        var asesmenSumatif = await _asesmenSumatifRepository.Get(id);
        if (asesmenSumatif is null)
        {
            _toastrNotificationService.AddError("Asesmen Sumatif tidak ditemukan", "Hapus Target Capaian TP");
            return RedirectToAction("Detail", "JadwalMengajar", new { id = idJadwalMengajar });
        }

        _asesmenSumatifRepository.Delete(asesmenSumatif);
        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
            _toastrNotificationService.AddError("Simpan Gagal!", "Hapus Target Capaian TP");
        else
            _toastrNotificationService.AddSuccess("Simpan Sukses!", "Hapus Target Capaian TP");

        return RedirectToAction("Detail", "JadwalMengajar", new { id = idJadwalMengajar });
    }
}
