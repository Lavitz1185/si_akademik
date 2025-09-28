using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIAkademik.Domain.Authentication;
using SIAkademik.Domain.ModulSiakad.Repositories;
using SIAkademik.Web.Areas.DashboardGuru.Models.KelasWaliModels;
using SIAkademik.Web.Authentication;

namespace SIAkademik.Web.Areas.DashboardGuru.Controllers;

[Area(AreaNames.DashboardGuru)]
[Authorize(Roles = AppUserRoles.Guru)]
public class KelasWaliController : Controller
{
    private readonly ISignInManager _signInManager;
    private readonly IPegawaiRepository _pegawaiRepository;
    private readonly IRombelRepository _rombelRepository;
    private readonly ITahunAjaranRepository _tahunAjaranRepository;

    public KelasWaliController(
        ISignInManager signInManager,
        IPegawaiRepository pegawaiRepository,
        IRombelRepository rombelRepository,
        ITahunAjaranRepository tahunAjaranRepository)
    {
        _signInManager = signInManager;
        _pegawaiRepository = pegawaiRepository;
        _rombelRepository = rombelRepository;
        _tahunAjaranRepository = tahunAjaranRepository;
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

        return View(new IndexVM 
        { 
            TahunAjaran = tahunAjaran, 
            DaftarRombelWali = pegawai.DaftarRombelWali.Where(r => r.Kelas.TahunAjaran == tahunAjaran).ToList()
        });
    }
}
