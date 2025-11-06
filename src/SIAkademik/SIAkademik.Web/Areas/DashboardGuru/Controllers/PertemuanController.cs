using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIAkademik.Domain.Abstracts;
using SIAkademik.Domain.Authentication;
using SIAkademik.Domain.Enums;
using SIAkademik.Domain.ModulSiakad.Entities;
using SIAkademik.Domain.ModulSiakad.Repositories;
using SIAkademik.Web.Areas.DashboardGuru.Models.PertemuanModels;
using SIAkademik.Web.Authentication;
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
    private readonly ISignInManager _signInManager;

    public PertemuanController(
        IPertemuanRepository pertemuanRepository,
        IRombelRepository rombelRepository,
        IJadwalMengajarRepository jadwalMengajarRepository,
        IAbsenRepository absenRepository,
        IUnitOfWork unitOfWork,
        IToastrNotificationService toastrNotificationService,
        ISignInManager signInManager)
    {
        _pertemuanRepository = pertemuanRepository;
        _rombelRepository = rombelRepository;
        _jadwalMengajarRepository = jadwalMengajarRepository;
        _absenRepository = absenRepository;
        _unitOfWork = unitOfWork;
        _toastrNotificationService = toastrNotificationService;
        _signInManager = signInManager;
    }

    [HttpPost]
    public async Task<IActionResult> Mulai(MulaiVM vm)
    {
        if (!ModelState.IsValid) return View(vm);

        var pertemuan = await _pertemuanRepository.Get(vm.Id);
        if (pertemuan is null) return NotFound();

        var returnUrl = vm.ReturnUrl ?? Url.Action(
            nameof(JadwalMengajarController.Detail),
            "JadwalMengajar",
            new { id = pertemuan.JadwalMengajar.Id });

        pertemuan.Keterangan = vm.Keterangan;
        pertemuan.StatusPertemuan = StatusPertemuan.Berjalan;

        var rombel = await _rombelRepository.Get(pertemuan.JadwalMengajar.Rombel.Id);
        var daftarAbsen = rombel!.DaftarAnggotaRombel.Select(a => new Absen
        {
            AnggotaRombel = a,
            Keterangan = string.Empty,
            Pertemuan = pertemuan,
            Tanggal = DateOnly.FromDateTime(pertemuan.TanggalPelaksanaan),
            Absensi = Absensi.Hadir
        }).ToList();

        pertemuan.DaftarAbsen = daftarAbsen;

        foreach (var absen in daftarAbsen) _absenRepository.Add(absen);

        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
        {
            _toastrNotificationService.AddError("Simpan Gagal!", "Mulai Pertemuan");
            return Redirect(returnUrl!);
        }

        _toastrNotificationService.AddSuccess("Simpan berhasil!", "Mulai Pertemuan");

        return Redirect(returnUrl!);
    }

    [HttpPost]
    public async Task<IActionResult> Akhiri(int id, string? returnUrl = null)
    {
        var pertemuan = await _pertemuanRepository.Get(id);
        if (pertemuan is null) return NotFound();

        returnUrl ??= Url.Action(
            nameof(JadwalMengajarController.Detail),
            "JadwalMengajar",
            new { Area = AreaNames.DashboardGuru, id = pertemuan.JadwalMengajar.Id });

        pertemuan.StatusPertemuan = StatusPertemuan.Selesai;

        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure) _toastrNotificationService.AddError("Simpan Gagal!");
        else _toastrNotificationService.AddSuccess("Simpan Berhasil!");

        return Redirect(returnUrl!);
    }

    public async Task<IActionResult> Absen(int id)
    {
        var pertemuan = await _pertemuanRepository.Get(id);
        if (pertemuan is null) return NotFound();

        return View(new AbsenVM
        {
            IdPertemuan = pertemuan.Id,
            DaftarAbsen = pertemuan.DaftarAbsen.Select(a => new AbsenEntryVM
            {
                IdSiswa = a.AnggotaRombel.Siswa.Id,
                NamaSiswa = a.AnggotaRombel.Siswa.Nama,
                Absensi = a.Absensi
            }).ToList()
        });
    }

    [HttpPost]
    public async Task<IActionResult> Absen(AbsenVM vm)
    {
        var pertemuan = await _pertemuanRepository.Get(vm.IdPertemuan);
        if (pertemuan is null) return NotFound();

        var daftarAbsen = pertemuan.DaftarAbsen;
        foreach (var absen in daftarAbsen)
        {
            var absenEntry = vm.DaftarAbsen.First(a => a.IdSiswa == absen.AnggotaRombel.Siswa.Id);
            absen.Absensi = absenEntry.Absensi;
        }

        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
        {
            ModelState.AddModelError(string.Empty, "Simpan Gagal!");
            return View(vm);
        }

        return RedirectToAction(nameof(JadwalMengajarController.Detail), "JadwalMengajar", new { id = pertemuan.JadwalMengajar.Id });
    }

    [HttpPost]
    public async Task<IActionResult> Tambah(TambahVM vm)
    {
        var pegawai = await _signInManager.GetPegawai();
        if (pegawai is null) return Forbid();

        var jadwalMengajar = await _jadwalMengajarRepository.Get(vm.IdJadwalMengajar);
        if (jadwalMengajar is null || jadwalMengajar.Pegawai != pegawai) return NotFound();

        if (!ModelState.IsValid)
        {
            _toastrNotificationService.AddError("Data tidak valid", "Tambah Pertemuan");
            return RedirectToAction(nameof(JadwalMengajarController.Detail), "JadwalMengajar", new { id = vm.IdJadwalMengajar });
        }

        if (jadwalMengajar.DaftarPertemuan.Any(p => p.Nomor == vm.Nomor))
        {
            _toastrNotificationService.AddError($"Nomor '{vm.Nomor}' sudah digunakan pertemuan lain", "Tambah Pertemuan");
            return RedirectToAction(nameof(JadwalMengajarController.Detail), "JadwalMengajar", new { id = vm.IdJadwalMengajar });
        }

        var pertemuan = new Pertemuan
        {
            Nomor = vm.Nomor,
            JadwalMengajar = jadwalMengajar,
            TanggalPelaksanaan = new DateTime(vm.TanggalPelaksanaan, vm.WaktuPelaksanaan),
            StatusPertemuan = StatusPertemuan.BelumMulai
        };

        _pertemuanRepository.Add(pertemuan);
        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
        {
            _toastrNotificationService.AddError("Simpan Gagal!", "Tambah Pertemuan");
            return View(vm);
        }

        _toastrNotificationService.AddSuccess("Tambah pertemuan sukses!", "Tambah Pertemuan");

        return RedirectToAction(nameof(JadwalMengajarController.Detail), "JadwalMengajar", new { id = jadwalMengajar.Id });
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EditVM vm)
    {
        var pegawai = await _signInManager.GetPegawai();
        if (pegawai is null) return Forbid();

        var pertemuan = await _pertemuanRepository.Get(vm.IdPertemuan);
        if (pertemuan is null) return NotFound();

        var jadwalMengajar = await _jadwalMengajarRepository.Get(pertemuan.JadwalMengajar.Id);

        if (!ModelState.IsValid)
        {
            _toastrNotificationService.AddError("Data tidak valid", "Edit Pertemuan");
            return RedirectToAction(nameof(JadwalMengajarController.Detail), "JadwalMengajar", new { id = jadwalMengajar!.Id });
        }

        if (jadwalMengajar!.DaftarPertemuan.Any(p => p.Id != pertemuan.Id && p.Nomor == vm.Nomor))
        {
            _toastrNotificationService.AddError($"Nomor '{vm.Nomor}' sudah digunakan!", "Edit Pertemuan");
            return RedirectToAction(nameof(JadwalMengajarController.Detail), "JadwalMengajar", new { id = jadwalMengajar.Id });
        }

        pertemuan.Nomor = vm.Nomor;
        pertemuan.TanggalPelaksanaan = new DateTime(vm.TanggalPelaksanaan, vm.WaktuPelaksanaan);
        pertemuan.Keterangan = vm.Keterangan;

        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
        {
            _toastrNotificationService.AddError("Simpan Gagal!", "Edit Pertemuan");
            return RedirectToAction(nameof(JadwalMengajarController.Detail), "JadwalMengajar", new { id = jadwalMengajar.Id });
        }

        _toastrNotificationService.AddSuccess("Edit pertemuan sukses!");

        return RedirectToAction(nameof(JadwalMengajarController.Detail), "JadwalMengajar", new { id = jadwalMengajar.Id });
    }

    [HttpPost]
    public async Task<IActionResult> Hapus(int id)
    {
        var pertemuan = await _pertemuanRepository.Get(id);
        if (pertemuan is null) return NotFound();

        var idJadwalMengajar = pertemuan.JadwalMengajar.Id;

        _pertemuanRepository.Delete(pertemuan);
        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
            _toastrNotificationService.AddError("Hapus pertemuan gagal!");
        else
            _toastrNotificationService.AddSuccess("Hapus pertemuan sukses!");

        return RedirectToAction(nameof(JadwalMengajarController.Detail), "JadwalMengajar", new { id = idJadwalMengajar });
    }

    [HttpGet]
    public async Task<IActionResult> TambahPartial(int idJadwalMengajar)
    {
        var pegawai = await _signInManager.GetPegawai();
        if (pegawai is null) return Forbid();

        var jadwalMengajar = await _jadwalMengajarRepository.Get(idJadwalMengajar);
        if (jadwalMengajar is null || jadwalMengajar.Pegawai != pegawai) return NotFound();

        var vm = new TambahVM
        {
            IdJadwalMengajar = jadwalMengajar.Id,
            TanggalPelaksanaan = CultureInfos.DateOnlyNow,
            WaktuPelaksanaan = CultureInfos.TimeOnlyNow
        };

        return PartialView("~/Areas/DashboardGuru/Views/Pertemuan/_FormTambah.cshtml", vm);
    }
}
