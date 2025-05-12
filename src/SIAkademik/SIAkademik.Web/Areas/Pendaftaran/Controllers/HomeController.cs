using Microsoft.AspNetCore.Mvc;

namespace SIAkademik.Web.Areas.Pendaftaran.Controllers
{
    [Area("Pendaftaran")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
