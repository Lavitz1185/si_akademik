using Microsoft.AspNetCore.Mvc;

namespace SIAkademik.Web.Areas.Profil.Controllers;

[Area("Profil")]
public class BeritaController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
