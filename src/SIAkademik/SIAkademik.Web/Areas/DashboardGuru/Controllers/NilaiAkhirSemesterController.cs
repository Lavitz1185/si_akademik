using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIAkademik.Domain.Abstracts;
using SIAkademik.Domain.Authentication;
using SIAkademik.Domain.ModulSiakad.Entities;
using SIAkademik.Domain.ModulSiakad.Repositories;
using SIAkademik.Web.Areas.DashboardGuru.Models.NilaiAkhirSemesterModels;
using SIAkademik.Web.Authentication;
using SIAkademik.Web.Services.Toastr;

namespace SIAkademik.Web.Areas.DashboardGuru.Controllers;

[Area(AreaNames.DashboardGuru)]
[Authorize(Roles = AppUserRoles.Guru)]
public class NilaiAkhirSemesterController : Controller
{
    private readonly ISignInManager _signInManager;
    private readonly ITahunAjaranRepository _tahunAjaranRepository;
    private readonly IJadwalMengajarRepository _jadwalMengajarRepository;
    private readonly IAsesmenSumatifAkhirSemesterRepository _asesmenSumatifAkhirSemesterRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IToastrNotificationService _toastrNotificationService;

    public NilaiAkhirSemesterController(
        ISignInManager signInManager,
        ITahunAjaranRepository tahunAjaranRepository,
        IJadwalMengajarRepository jadwalMengajarRepository,
        IAsesmenSumatifAkhirSemesterRepository asesmenSumatifAkhirSemesterRepository,
        IUnitOfWork unitOfWork,
        IToastrNotificationService toastrNotificationService)
    {
        _signInManager = signInManager;
        _tahunAjaranRepository = tahunAjaranRepository;
        _jadwalMengajarRepository = jadwalMengajarRepository;
        _asesmenSumatifAkhirSemesterRepository = asesmenSumatifAkhirSemesterRepository;
        _unitOfWork = unitOfWork;
        _toastrNotificationService = toastrNotificationService;
    }

    public async Task<IActionResult> Index(int? idTahunAjaran = null, int? idJadwalMengajar = null)
    {
        var pegawai = await _signInManager.GetPegawai();
        if (pegawai is null) return Forbid();

        var tahunAjaran = idTahunAjaran is null ?
            await _tahunAjaranRepository.GetNewest() :
            await _tahunAjaranRepository.Get(idTahunAjaran.Value);

        if (tahunAjaran is null) return View(new IndexVM { Pegawai = pegawai });

        var jadwalMengajar = idJadwalMengajar is null ?
            (await _jadwalMengajarRepository.GetAllByTahunAjaran(tahunAjaran.Id)).FirstOrDefault(j => j.Pegawai == pegawai) :
            await _jadwalMengajarRepository.Get(idJadwalMengajar.Value);

        if (jadwalMengajar is null || jadwalMengajar.Pegawai != pegawai || jadwalMengajar.Rombel.Kelas.TahunAjaran != tahunAjaran)
            return View(new IndexVM { Pegawai = pegawai, TahunAjaran = tahunAjaran, IdTahunAjaran = tahunAjaran.Id });

        foreach (var anggotaRombel in jadwalMengajar.Rombel.DaftarAnggotaRombel)
        {
            if (!jadwalMengajar.DaftarAsesmenSumatifAkhirSemester.Any(a => a.AnggotaRombel == anggotaRombel))
            {
                var asesmenSumatifAkhirSemester = new AsesmenSumatifAkhirSemester
                {
                    AnggotaRombel = anggotaRombel,
                    JadwalMengajar = jadwalMengajar,
                    Nilai = 0
                };

                _asesmenSumatifAkhirSemesterRepository.Add(asesmenSumatifAkhirSemester);
            }
        }

        await _unitOfWork.SaveChangesAsync();

        return View(new IndexVM
        {
            Pegawai = pegawai,
            TahunAjaran = tahunAjaran,
            JadwalMengajar = jadwalMengajar,
            IdTahunAjaran = tahunAjaran.Id,
            IdJadwalMengajar = jadwalMengajar.Id,
            DaftarNilaiEntryVM = jadwalMengajar
                .DaftarAsesmenSumatifAkhirSemester
                .Select(a => new NilaiEntryVM { IdAnggotaRombel = a.AnggotaRombelId, Nama = a.AnggotaRombel.Siswa.Nama, Nilai = a.Nilai})
                .ToList()
        });
    }

    [HttpPost]
    public async Task<IActionResult> Simpan(IndexVM vm)
    {
        if (vm.IdTahunAjaran is null || vm.IdJadwalMengajar is null)
        {
            _toastrNotificationService.AddError("Silahkan pilih Tahun Ajaran dan Jadwal mengajar terlebih dahulu");
            return RedirectToAction(nameof(Index));
        }

        var tahunAjaran = await _tahunAjaranRepository.Get(vm.IdTahunAjaran.Value);
        if (tahunAjaran is null)
        {
            _toastrNotificationService.AddError("Tahun Ajaran tidak ditemukan");
            return RedirectToAction(nameof(Index));
        }

        var jadwalMengajar = await _jadwalMengajarRepository.Get(vm.IdJadwalMengajar.Value);
        if (jadwalMengajar is null || jadwalMengajar.Rombel.Kelas.TahunAjaran != tahunAjaran)
        {
            _toastrNotificationService.AddError("Jadwal Mengajar tidak ditemukan");
            return RedirectToAction(nameof(Index), new { vm.IdTahunAjaran });
        }

        foreach (var entry in vm.DaftarNilaiEntryVM)
        {
            var asesmenSumatifAkhirSemester = jadwalMengajar
                .DaftarAsesmenSumatifAkhirSemester
                .FirstOrDefault(a => a.AnggotaRombelId == entry.IdAnggotaRombel);

            if (asesmenSumatifAkhirSemester is not null)
                asesmenSumatifAkhirSemester.Nilai = entry.Nilai;
        }

        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
            _toastrNotificationService.AddError("Simpan Gagal!");
        else
            _toastrNotificationService.AddSuccess("Simpan Berhasil!");

        return RedirectToAction(nameof(Index), new { vm.IdTahunAjaran, vm.IdJadwalMengajar });
    }
}
