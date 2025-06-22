using Microsoft.AspNetCore.Mvc;

namespace SIAkademik.Web.Areas.Profil.Controllers
{
    [Area("Profil")]
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
    }
}
