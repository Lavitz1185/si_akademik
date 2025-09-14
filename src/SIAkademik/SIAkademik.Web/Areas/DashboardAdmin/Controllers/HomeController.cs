using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIAkademik.Domain.Authentication;
using SIAkademik.Web.Authentication;
using SIAkademik.Web.Services.Toastr;

namespace SIAkademik.Web.Areas.DashboardAdmin.Controllers
{
    [Area(AreaNames.DashboardAdmin)]
    [Authorize(Roles = AppUserRoles.Admin)]
    public class HomeController : Controller
    {
        private readonly ISignInManager _signInManager;
        private readonly IToastrNotificationService _notificationService;

        public HomeController(ISignInManager signInManager, IToastrNotificationService notificationService)
        {
            _signInManager = signInManager;
            _notificationService = notificationService;
        }

        public IActionResult Index()
        {
            _notificationService.AddInformation("Selamat Datang");
            return View();
        }

        [Authorize(Roles = AppUserRoles.Admin)]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.Logout();

            return RedirectToAction("Index", "Home", new { Area = AreaNames.Profil });
        }
    }
}
