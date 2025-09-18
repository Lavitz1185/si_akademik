using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIAkademik.Domain.Authentication;
using SIAkademik.Domain.ModulSiakad.Repositories;

namespace SIAkademik.Web.Areas.DashboardAdmin.Controllers;

[Area(AreaNames.DashboardAdmin)]
[Authorize(Roles = AppUserRoles.Admin)]
public class JadwalMengajarController : Controller
{
    private readonly IJadwalMengajarRepository _jadwalMengajarRepository;

    public JadwalMengajarController(IJadwalMengajarRepository jadwalMengajarRepository)
    {
        _jadwalMengajarRepository = jadwalMengajarRepository;
    }

    public IActionResult Index()
    {
        return View();
    }
}
