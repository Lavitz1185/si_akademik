using Microsoft.AspNetCore.Mvc;

namespace SIAkademik.Web.Areas.Profil.Controllers;

[Area(AreaNames.Profil)]
public class GaleriController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
