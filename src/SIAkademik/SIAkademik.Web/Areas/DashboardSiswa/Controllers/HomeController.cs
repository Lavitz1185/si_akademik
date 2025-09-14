using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIAkademik.Domain.Authentication;
using SIAkademik.Web.Authentication;

namespace SIAkademik.Web.Areas.DashboardSiswa.Controllers;

[Area(AreaNames.DashboardSiswa)]
[Authorize(Roles = AppUserRoles.Siswa)]
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

    public async Task<IActionResult> Logout()
    {
        await _signInManager.Logout();

        return RedirectToAction("Index", "Home", new { Area = AreaNames.Profil });
    }
}
