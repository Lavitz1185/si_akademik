using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIAkademik.Domain.Abstracts;
using SIAkademik.Domain.Authentication;
using SIAkademik.Domain.ModulSiakad.Entities;
using SIAkademik.Domain.ModulSiakad.Repositories;
using SIAkademik.Web.Areas.DashboardGuru.Models.EvaluasiSiswaModels;
using SIAkademik.Web.Authentication;
using SIAkademik.Web.Services.Toastr;

namespace SIAkademik.Web.Areas.DashboardGuru.Controllers;

[Area(AreaNames.DashboardGuru)]
[Authorize(Roles = AppUserRoles.Guru)]
public class EvaluasiSiswaController : Controller
{
    private readonly ISignInManager _signInManager;
    private readonly IEvaluasiSiswaRepository _evaluasiSiswaRepository;
    private readonly INilaiEvaluasiSiswaRepository _nilaiEvaluasiSiswaRepository;
    private readonly IAsesmenSumatifRepository _asesmenSumatifRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IToastrNotificationService _toastrNotificationService;

    public EvaluasiSiswaController(
        ISignInManager signInManager,
        IEvaluasiSiswaRepository evaluasiSiswaRepository,
        INilaiEvaluasiSiswaRepository nilaiEvaluasiSiswaRepository,
        IAsesmenSumatifRepository asesmenSumatifRepository,
        IUnitOfWork unitOfWork,
        IToastrNotificationService toastrNotificationService)
    {
        _signInManager = signInManager;
        _evaluasiSiswaRepository = evaluasiSiswaRepository;
        _nilaiEvaluasiSiswaRepository = nilaiEvaluasiSiswaRepository;
        _asesmenSumatifRepository = asesmenSumatifRepository;
        _unitOfWork = unitOfWork;
        _toastrNotificationService = toastrNotificationService;
    }

    [HttpPost]
    public async Task<IActionResult> Tambah(TambahVM vm)
    {
        var pegawai = await _signInManager.GetPegawai();
        if (pegawai is null) return Forbid();

        var asesmenSumatif = await _asesmenSumatifRepository.Get(vm.IdAsesmenSumatif);
        if (asesmenSumatif is null)
        {
            _toastrNotificationService.AddError("Target Capaian tidak ditemukan!", $"Tambah {vm.Jenis.Humanize()}");
            return RedirectToAction("Index", "AsesmenSumatif");
        }

        if (asesmenSumatif.JadwalMengajar.Pegawai != pegawai)
        {
            _toastrNotificationService.AddError("Anda tidak memiliki hak untuk menambah data ini!", $"Tambah {vm.Jenis.Humanize()}");
            return RedirectToAction("Index", "AsesmenSumatif");
        }

        if (!ModelState.IsValid)
        {
            _toastrNotificationService.AddError("Data tidak valid!", $"Tambah {vm.Jenis.Humanize()}");
            return RedirectToAction(
                "Index",
                "AsesmenSumatif",
                new
                {
                    idTahunAjaran = asesmenSumatif.JadwalMengajar.Rombel.Kelas.TahunAjaran.Id,
                    idJadwalMengajar = asesmenSumatif.JadwalMengajar.Id,
                    idAsesmenSumatif = asesmenSumatif.Id
                });
        }

        if (asesmenSumatif.DaftarEvaluasiSiswa.Any(e => e.Jenis == vm.Jenis && e.Deskripsi.ToLower() == vm.Deskripsi.ToLower()))
        {
            _toastrNotificationService.AddError($"Tugas dengan deskripsi '{vm.Deskripsi}' sudah ada untuk target capaian ini", $"Tambah {vm.Jenis.Humanize()}");
            return RedirectToAction(
                "Index", 
                "AsesmenSumatif", 
                new 
                { 
                    idTahunAjaran = asesmenSumatif.JadwalMengajar.Rombel.Kelas.TahunAjaran.Id,
                    idJadwalMengajar = asesmenSumatif.JadwalMengajar.Id,
                    idAsesmenSumatif = asesmenSumatif.Id
                });
        }

        var evaluasiSiswa = new EvaluasiSiswa
        {
            Deskripsi = vm.Deskripsi,
            Jenis = vm.Jenis,
            AsesmenSumatif = asesmenSumatif
        };

        _evaluasiSiswaRepository.Add(evaluasiSiswa);
        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
            _toastrNotificationService.AddError("Simpan Gagal!", $"Tambah {vm.Jenis.Humanize()}");
        else
            _toastrNotificationService.AddSuccess("Simpan Berhasil!", $"Tambah {vm.Jenis.Humanize()}");

        return RedirectToAction(
                "Index",
                "AsesmenSumatif",
                new
                {
                    idTahunAjaran = asesmenSumatif.JadwalMengajar.Rombel.Kelas.TahunAjaran.Id,
                    idJadwalMengajar = asesmenSumatif.JadwalMengajar.Id,
                    idAsesmenSumatif = asesmenSumatif.Id
                });
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EditVM vm)
    {
        var pegawai = await _signInManager.GetPegawai();
        if (pegawai is null) return Forbid();

        var evaluasiSiswa = await _evaluasiSiswaRepository.Get(vm.Id);
        if (evaluasiSiswa is null) return NotFound();

        var asesmenSumatif = await _asesmenSumatifRepository.Get(evaluasiSiswa.AsesmenSumatif.Id);
        if (asesmenSumatif is null) return NotFound();

        if (!ModelState.IsValid)
        {
            _toastrNotificationService.AddError("Data tidak valid!", $"Tambah {vm.Jenis.Humanize()}");
            return RedirectToAction(
                "Index",
                "AsesmenSumatif",
                new
                {
                    idTahunAjaran = asesmenSumatif.JadwalMengajar.Rombel.Kelas.TahunAjaran.Id,
                    idJadwalMengajar = asesmenSumatif.JadwalMengajar.Id,
                    idAsesmenSumatif = asesmenSumatif.Id
                });
        }

        if (asesmenSumatif
            .DaftarEvaluasiSiswa
            .Any(e => e.Id != vm.Id && e.Jenis == vm.Jenis && e.Deskripsi.ToLower() == vm.Deskripsi.ToLower()))
        {
            _toastrNotificationService.AddError(
                $"Tugas dengan deskripsi '{vm.Deskripsi}' sudah ada untuk target capaian ini", 
                $"Edit {evaluasiSiswa.Jenis.Humanize()}");

            return RedirectToAction(
                "Index",
                "AsesmenSumatif",
                new
                {
                    idTahunAjaran = evaluasiSiswa.AsesmenSumatif.JadwalMengajar.Rombel.Kelas.TahunAjaran.Id,
                    idJadwalMengajar = evaluasiSiswa.AsesmenSumatif.JadwalMengajar.Id,
                    idAsesmenSumatif = evaluasiSiswa.AsesmenSumatif.Id
                });
        }

        evaluasiSiswa.Deskripsi = vm.Deskripsi;

        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
            _toastrNotificationService.AddError("Simpan Gagal!", $"Edit {evaluasiSiswa.Jenis.Humanize()}");
        else
            _toastrNotificationService.AddSuccess("Simpan Berhasil!", $"Edit {evaluasiSiswa.Jenis.Humanize()}");

        return RedirectToAction(
                "Index",
                "AsesmenSumatif",
                new
                {
                    idTahunAjaran = evaluasiSiswa.AsesmenSumatif.JadwalMengajar.Rombel.Kelas.TahunAjaran.Id,
                    idJadwalMengajar = evaluasiSiswa.AsesmenSumatif.JadwalMengajar.Id,
                    idAsesmenSumatif = evaluasiSiswa.AsesmenSumatif.Id
                });
    }

    [HttpPost]
    public async Task<IActionResult> Hapus(int id)
    {
        var pegawai = await _signInManager.GetPegawai();
        if (pegawai is null) return Forbid();

        var evaluasiSiswa = await _evaluasiSiswaRepository.Get(id);
        if (evaluasiSiswa is null) return NotFound();

        if (evaluasiSiswa.AsesmenSumatif.JadwalMengajar.Pegawai != pegawai) return Forbid();

        var idTahunAjaran = evaluasiSiswa.AsesmenSumatif.JadwalMengajar.Rombel.Kelas.TahunAjaran.Id;
        var idJadwalMengajar = evaluasiSiswa.AsesmenSumatif.JadwalMengajar.Id;
        var idAsesmenSumatif = evaluasiSiswa.AsesmenSumatif.Id;

        _evaluasiSiswaRepository.Delete(evaluasiSiswa);
        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
            _toastrNotificationService.AddError("Hapus Gagal!", $"Hapus {evaluasiSiswa.Jenis.Humanize()}");
        else
            _toastrNotificationService.AddSuccess("Hapus Berhasil!", $"Hapus {evaluasiSiswa.Jenis.Humanize()}");

        return RedirectToAction("Index", "AsesmenSumatif", new { idAsesmenSumatif, idTahunAjaran, idJadwalMengajar });
    }
}
