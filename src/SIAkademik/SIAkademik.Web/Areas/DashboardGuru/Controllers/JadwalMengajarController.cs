using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIAkademik.Domain.Abstracts;
using SIAkademik.Domain.Authentication;
using SIAkademik.Domain.ModulSiakad.Repositories;
using SIAkademik.Web.Areas.DashboardGuru.Models.JadwalMengajarModels;
using SIAkademik.Web.Authentication;
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
        pegawai = (await _pegawaiRepository.Get(pegawai.Id))!;

        var tahunAjaran = idTahunAjaran is null ?
            await _tahunAjaranRepository.GetNewest() :
            await _tahunAjaranRepository.Get(idTahunAjaran.Value);

        if (tahunAjaran is null) return View(new IndexVM());

        var daftarJadwalMengajar = pegawai.DaftarJadwalMengajar
            .Where(j => j.Rombel.Kelas.TahunAjaran == tahunAjaran)
            .ToList();

        return View(new IndexVM { TahunAjaran = tahunAjaran, DaftarJadwalMengajar = daftarJadwalMengajar });
    }

    public async Task<IActionResult> Detail(int id)
    {
        var jadwalMengajar = await _jadwalMengajarRepository.Get(id);

        if (jadwalMengajar is null) return NotFound();

        return View(jadwalMengajar);
    }
}
