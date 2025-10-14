using Microsoft.AspNetCore.Mvc;

namespace SIAkademik.Web.Areas.Profil.Controllers;

[Area(AreaNames.Profil)]
public class StatistikController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
