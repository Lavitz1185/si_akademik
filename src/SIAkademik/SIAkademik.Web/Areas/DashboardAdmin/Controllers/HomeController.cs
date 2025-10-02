using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIAkademik.Domain.Authentication;
using SIAkademik.Domain.ModulSiakad.Repositories;
using SIAkademik.Web.Areas.DashboardAdmin.Models.Home;
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
        private readonly ISiswaRepository _siswaRepository;
        private readonly IRombelRepository _rombelRepository;
        private readonly IPegawaiRepository _pegawaiRepository;
        private readonly ITahunAjaranRepository _tahunAjaranRepository;

        public HomeController(
            ISignInManager signInManager,
            IToastrNotificationService notificationService,
            ISiswaRepository siswaRepository,
            IRombelRepository rombelRepository,
            IPegawaiRepository pegawaiRepository,
            ITahunAjaranRepository tahunAjaranRepository)
        {
            _signInManager = signInManager;
            _notificationService = notificationService;
            _siswaRepository = siswaRepository;
            _rombelRepository = rombelRepository;
            _pegawaiRepository = pegawaiRepository;
            _tahunAjaranRepository = tahunAjaranRepository;
        }

        public async Task<IActionResult> Index()
        {
            var tahunAjaran = await _tahunAjaranRepository.GetNewest();
            if (tahunAjaran is null) return View(new IndexVM());

            var daftarSiswa = await _siswaRepository.GetAll();
            var daftarRombel = await _rombelRepository.GetAllByTahunAjaran(tahunAjaran.Id);
            var daftarPegawai = await _pegawaiRepository.GetAll();

            return View(new IndexVM
            {
                TahunAjaran = tahunAjaran,
                DaftarSiswa = daftarSiswa,
                DaftarRombel = daftarRombel,
                DaftarPegawai = daftarPegawai
            });
        }

        [Authorize(Roles = AppUserRoles.Admin)]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.Logout();

            return RedirectToAction("Index", "Home", new { Area = AreaNames.Profil });
        }
    }
}
