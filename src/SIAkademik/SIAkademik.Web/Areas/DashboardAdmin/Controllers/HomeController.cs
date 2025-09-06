using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIAkademik.Domain.Authentication;
using SIAkademik.Web.Areas.DashboardAdmin.Models.Home;
using SIAkademik.Web.Authentication;

namespace SIAkademik.Web.Areas.DashboardAdmin.Controllers
{
    [Area(AreaNames.DashboardAdmin)]
    [Authorize(Roles = AppUserRoles.Admin)]
    public class HomeController : Controller
    {
        private readonly ISignInManager _signInManager;

        public HomeController(ISignInManager signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Login(string? returnUrl = null)
        {
            return View(new LoginVM
            {
                ReturnUrl = returnUrl ?? Url.Action(nameof(Index))!
            });
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM vm)
        {
            if (!ModelState.IsValid) return View(vm);

            var result = await _signInManager.Login(vm.UserName, vm.Password, vm.RememberMe, AppUserRoles.Admin);
            if (result.IsFailure)
            {
                ModelState.AddModelError(string.Empty, result.Error.Message);
                return View(vm);
            }

            return Redirect(vm.ReturnUrl);
        }

        [Authorize(Roles = AppUserRoles.Admin)]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.Logout();

            return RedirectToAction("Index", "Home", new { Area = AreaNames.Profil });
        }
    }
}
