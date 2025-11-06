using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIAkademik.Domain.Abstracts;
using SIAkademik.Domain.Authentication;
using SIAkademik.Domain.Enums;
using SIAkademik.Domain.ModulSiakad.Entities;
using SIAkademik.Domain.ModulSiakad.Repositories;
using SIAkademik.Web.Areas.DashboardGuru.Models.JadwalMengajarModels;
using SIAkademik.Web.Authentication;
using SIAkademik.Web.Models;
using SIAkademik.Web.Services.Toastr;

namespace SIAkademik.Web.Areas.DashboardGuru.Controllers;

[Area(AreaNames.DashboardGuru)]
[Authorize(Roles = AppUserRoles.Guru)]
public class JadwalMengajarController : Controller
{
    private readonly IPegawaiRepository _pegawaiRepository;
    private readonly IRombelRepository _rombelRepository;
    private readonly ITahunAjaranRepository _tahunAjaranRepository;
    private readonly IJadwalMengajarRepository _jadwalMengajarRepository;
    private readonly IPertemuanRepository _pertemuanRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IToastrNotificationService _toastrNotificationService;
    private readonly ISignInManager _signInManager;

    public JadwalMengajarController(
        IPegawaiRepository pegawaiRepository,
        IRombelRepository rombelRepository,
        ITahunAjaranRepository tahunAjaranRepository,
        IJadwalMengajarRepository jadwalMengajarRepository,
        IPertemuanRepository pertemuanRepository,
        IUnitOfWork unitOfWork,
        IToastrNotificationService toastrNotificationService,
        ISignInManager signInManager)
    {
        _pegawaiRepository = pegawaiRepository;
        _rombelRepository = rombelRepository;
        _tahunAjaranRepository = tahunAjaranRepository;
        _jadwalMengajarRepository = jadwalMengajarRepository;
        _pertemuanRepository = pertemuanRepository;
        _unitOfWork = unitOfWork;
        _toastrNotificationService = toastrNotificationService;
        _signInManager = signInManager;
    }

    public async Task<IActionResult> Index(int? idTahunAjaran = null)
    {
        var pegawai = await _signInManager.GetPegawai();
        if (pegawai is null) return Forbid();

        var tahunAjaran = idTahunAjaran is null ?
            await _tahunAjaranRepository.Get(CultureInfos.DateOnlyNow) :
            await _tahunAjaranRepository.Get(idTahunAjaran.Value);

        if (tahunAjaran is null) return View(new IndexVM());

        var daftarJadwalMengajar = pegawai.DaftarJadwalMengajar
            .Where(j => j.Rombel.TahunAjaran == tahunAjaran)
            .ToList();

        return View(new IndexVM { TahunAjaran = tahunAjaran, DaftarJadwalMengajar = daftarJadwalMengajar });
    }

    public async Task<IActionResult> Detail(int id)
    {
        var pegawai = await _signInManager.GetPegawai();
        if (pegawai is null) return Forbid();

        var jadwalMengajar = await _jadwalMengajarRepository.Get(id);

        if (jadwalMengajar is null || jadwalMengajar.Pegawai != pegawai) return NotFound();

        if (jadwalMengajar.DaftarAsesmenSumatif.Count == 0)
            _toastrNotificationService.AddWarning("Belum ada target capaian TP. Silahkan pilih minimal 1 TP");

        return View(jadwalMengajar);
    }

    [HttpGet]
    public async Task<IActionResult> DaftarJadwalMengajar(int idTahunAjaran)
    {
        var pegawai = await _signInManager.GetPegawai();
        if (pegawai is null) return Forbid();
        pegawai = (await _pegawaiRepository.Get(pegawai.Id))!;

        var tahunAjaran = await _tahunAjaranRepository.Get(idTahunAjaran);
        if (tahunAjaran is null) return NotFound();

        var daftarJadwal = pegawai.DaftarJadwalMengajar
            .Where(j => j.Rombel.TahunAjaran == tahunAjaran)
            .Select(j => new
            {
                j.Id,
                Pegawai = new { j.Pegawai.Id, j.Pegawai.Nama },
                MataPelajaran = new { j.MataPelajaran.Id, j.MataPelajaran.Nama },
                Rombel = new 
                { 
                    j.Rombel.Id, 
                    j.Rombel.Nama, 
                    Kelas = new { Jenjang = j.Rombel.Kelas.Jenjang.Humanize(), Peminatan = j.Rombel.Kelas.Peminatan.Nama } 
                }
            }).ToList();

        return Json(daftarJadwal);
    }
}
