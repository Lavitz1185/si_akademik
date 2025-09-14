using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIAkademik.Domain.Authentication;
using SIAkademik.Web.Areas.Profil.Models.Home;
using SIAkademik.Web.Authentication;

namespace SIAkademik.Web.Areas.Profil.Controllers;

[Area(AreaNames.Profil)]
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

    public IActionResult Kurikulum()
    {
        return View();
    }

    public IActionResult Fasilitas()
    {
        return View();
    }

    public IActionResult TentangKami()
    {
        return View();
    }

    public IActionResult CoreValue()
    {
        return View();
    }

    public IActionResult Kontak()
    {
        return View();
    }

    public IActionResult Login(string? returnUrl = null)
    {
        return View(new LoginVM
        {
            ReturnUrl = returnUrl ?? Url.Action(nameof(Index))!
        });
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginVM vm)
    {
        if (!ModelState.IsValid) return View(vm);

        var result = await _signInManager.Login(vm.UserName, vm.Password, vm.RememberMe);
        if (result.IsFailure)
        {
            ModelState.AddModelError(string.Empty, result.Error.Message);
            return View(vm);
        }

        if(result.Value == AppUserRoles.Admin)
            return RedirectToAction("Index", "Home", new { Area = AreaNames.DashboardAdmin});
        else if (result.Value == AppUserRoles.Guru)
            return RedirectToAction("Index", "Home", new { Area = AreaNames.DashboardGuru});
        else
            return RedirectToAction("Index", "Home", new { Area = AreaNames.DashboardSiswa});
    }

    public IActionResult AccessDenied()
    {
        return View();
    }
}
