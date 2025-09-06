using Microsoft.AspNetCore.Mvc;

namespace SIAkademik.Web.Areas.Pendaftaran.Controllers
{
    [Area(AreaNames.Pendaftaran)]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
