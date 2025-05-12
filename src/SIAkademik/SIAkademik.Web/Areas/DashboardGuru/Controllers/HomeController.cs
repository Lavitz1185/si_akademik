using Microsoft.AspNetCore.Mvc;

namespace SIAkademik.Web.Areas.DashboardGuru.Controllers
{
    [Area("DashboardGuru")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
