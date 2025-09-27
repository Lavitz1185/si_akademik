using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIAkademik.Domain.Abstracts;
using SIAkademik.Domain.Authentication;
using SIAkademik.Domain.Enums;
using SIAkademik.Domain.ModulSiakad.Entities;
using SIAkademik.Domain.ModulSiakad.Repositories;
using SIAkademik.Web.Areas.DashboardGuru.Models.JadwalMengajarModels;
using SIAkademik.Web.Models;
using SIAkademik.Web.Services.Toastr;

namespace SIAkademik.Web.Areas.DashboardGuru.Controllers;

[Area(AreaNames.DashboardGuru)]
[Authorize(Roles = AppUserRoles.Guru)]
public class PertemuanController : Controller
{
    private readonly IPertemuanRepository _pertemuanRepository;
    private readonly IRombelRepository _rombelRepository;
    private readonly IJadwalMengajarRepository _jadwalMengajarRepository;
    private readonly IAbsenRepository _absenRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IToastrNotificationService _toastrNotificationService;

    public PertemuanController(
        IPertemuanRepository pertemuanRepository,
        IRombelRepository rombelRepository,
        IJadwalMengajarRepository jadwalMengajarRepository,
        IAbsenRepository absenRepository,
        IUnitOfWork unitOfWork,
        IToastrNotificationService toastrNotificationService)
    {
        _pertemuanRepository = pertemuanRepository;
        _rombelRepository = rombelRepository;
        _jadwalMengajarRepository = jadwalMengajarRepository;
        _absenRepository = absenRepository;
        _unitOfWork = unitOfWork;
        _toastrNotificationService = toastrNotificationService;
    }

    public async Task<IActionResult> Mulai(int id)
    {
        var pertemuan = await _pertemuanRepository.Get(id);
        if (pertemuan is null) return NotFound();

        return View(new MulaiVM
        {
            Id = pertemuan.Id,
            TanggalPelaksanaan = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, CultureInfos.TimeZoneInfo)
        });
    }

    [HttpPost]
    public async Task<IActionResult> Mulai(MulaiVM vm)
    {
        if (!ModelState.IsValid) return View(vm);

        var pertemuan = await _pertemuanRepository.Get(vm.Id);
        if (pertemuan is null) return NotFound();

        pertemuan.TanggalPelaksanaan = vm.TanggalPelaksanaan;
        pertemuan.Keterangan = vm.Keterangan;

        var rombel = await _rombelRepository.Get(pertemuan.JadwalMengajar.Rombel.Id);
        var daftarAbsen = rombel!.DaftarAnggotaRombel.Select(a => new Absen
        {
            AnggotaRombel = a,
            Keterangan = string.Empty,
            Pertemuan = pertemuan,
            Tanggal = DateOnly.FromDateTime(pertemuan.TanggalPelaksanaan.Value),
            Absensi = Absensi.Hadir
        }).ToList();

        pertemuan.DaftarAbsen = daftarAbsen;

        foreach (var absen in daftarAbsen) _absenRepository.Add(absen);

        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
        {
            ModelState.AddModelError(string.Empty, "Simpan Gagal!");
            return View(vm);
        }

        _toastrNotificationService.AddSuccess("Simpan berhasil!");

        return RedirectToAction(
            nameof(JadwalMengajarController.Detail),
            "JadwalMengajar",
            new { Area = AreaNames.DashboardGuru, id = pertemuan.JadwalMengajar.Id });
    }
}
