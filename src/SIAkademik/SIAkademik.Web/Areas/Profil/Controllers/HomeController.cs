using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIAkademik.Domain.Authentication;

namespace SIAkademik.Web.Areas.Profil.Controllers;

[Area(AreaNames.Profil)]
public class HomeController : Controller
{
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
        ViewData[nameof(returnUrl)] = returnUrl;
        return View();
    }

    public IActionResult AccessDenied()
    {
        return View();
    }
}
