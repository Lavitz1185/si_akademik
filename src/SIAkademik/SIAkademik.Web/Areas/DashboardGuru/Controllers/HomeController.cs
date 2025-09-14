using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIAkademik.Domain.Authentication;
using SIAkademik.Web.Authentication;

namespace SIAkademik.Web.Areas.DashboardGuru.Controllers;

[Area(AreaNames.DashboardGuru)]
[Authorize(Roles = AppUserRoles.Guru)]
public class HomeController : Controller
{
    private readonly ISignInManager _signInManager;

    public HomeController(ISignInManager signInManager)
    {
        _signInManager = signInManager;
    }

    public IActionResult Index()
    {
        return View();
    }

    [Authorize(Roles = AppUserRoles.Guru)]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.Logout();

        return RedirectToAction("Index", "Home", new { Area = AreaNames.Profil });
    }
}
