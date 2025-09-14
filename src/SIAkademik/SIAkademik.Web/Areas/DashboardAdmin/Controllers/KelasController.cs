using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIAkademik.Domain.Abstracts;
using SIAkademik.Domain.Authentication;
using SIAkademik.Domain.ModulSiakad.Repositories;

namespace SIAkademik.Web.Areas.DashboardAdmin.Controllers;

[Area(AreaNames.DashboardAdmin)]
[Authorize(Roles = AppUserRoles.Admin)]
public class KelasController : Controller
{
    private readonly IKelasRepository _kelasRepository;
    private readonly IRombelRepository _rombelRepository;
    private readonly ITahunAjaranRepository _tahunAjaranRepository;
    private readonly IUnitOfWork _unitOfWork;

    public KelasController(
        IKelasRepository kelasRepository,
        IRombelRepository rombelRepository,
        IUnitOfWork unitOfWork,
        ITahunAjaranRepository tahunAjaranRepository)
    {
        _kelasRepository = kelasRepository;
        _rombelRepository = rombelRepository;
        _unitOfWork = unitOfWork;
        _tahunAjaranRepository = tahunAjaranRepository;
    }

    public async Task<IActionResult> Index(int? idTahunAjaran = null)
    {
        var tahunAjaran = idTahunAjaran is null ? 
            (await _tahunAjaranRepository.GetAll()).FirstOrDefault() : 
            await _tahunAjaranRepository.Get(idTahunAjaran.Value);

        if(tahunAjaran is null) return NotFound();

        return View(tahunAjaran.DaftarKelas);
    }
}
