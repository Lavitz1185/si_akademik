using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIAkademik.Domain.Authentication;
using SIAkademik.Domain.ModulSiakad.Repositories;

namespace SIAkademik.Web.Areas.DashboardGuru.Controllers;

[Area(AreaNames.DashboardGuru)]
[Authorize(Roles = AppUserRoles.Guru)]
public class PertemuanController : Controller
{
    private readonly IPertemuanRepository _pertemuanRepository;

    public PertemuanController(IPertemuanRepository pertemuanRepository)
    {
        _pertemuanRepository = pertemuanRepository;
    }

    public async Task<IActionResult> Detail(int id)
    {
        var pertemuan = await _pertemuanRepository.Get(id);
        if (pertemuan is null) return NotFound();

        return View(pertemuan);
    }
}
