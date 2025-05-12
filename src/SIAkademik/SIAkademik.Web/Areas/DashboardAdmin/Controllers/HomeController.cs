using Microsoft.AspNetCore.Mvc;

namespace SIAkademik.Web.Areas.DashboardAdmin.Controllers
{
    [Area("DashboardAdmin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
