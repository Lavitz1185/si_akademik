using Microsoft.AspNetCore.Mvc;

namespace SIAkademik.Web.Areas.DashboardSiswa.Controllers
{
    [Area(AreaNames.DashboardSiswa)]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
