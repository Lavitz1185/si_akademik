using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SIAkademik.Domain.Abstracts;
using SIAkademik.Domain.Authentication;
using SIAkademik.Domain.ModulSiakad.Repositories;
using SIAkademik.Domain.Services;
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
        private readonly IPasswordHasher<AppUser> _passwordHasher;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(
            ISignInManager signInManager,
            IToastrNotificationService notificationService,
            ISiswaRepository siswaRepository,
            IRombelRepository rombelRepository,
            IPegawaiRepository pegawaiRepository,
            ITahunAjaranRepository tahunAjaranRepository,
            IPasswordHasher<AppUser> passwordHasher,
            IUnitOfWork unitOfWork,
            IHolidayService holidayService)
        {
            _signInManager = signInManager;
            _notificationService = notificationService;
            _siswaRepository = siswaRepository;
            _rombelRepository = rombelRepository;
            _pegawaiRepository = pegawaiRepository;
            _tahunAjaranRepository = tahunAjaranRepository;
            _passwordHasher = passwordHasher;
            _unitOfWork = unitOfWork;
            _holidayService = holidayService;
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

        public IActionResult UbahPassword() => View(new UbahPasswordVM());

        [HttpPost]
        public async Task<IActionResult> UbahPassword(UbahPasswordVM vm)
        {
            var user = await _signInManager.GetUser();
            if (user is null) return Forbid();

            if (!ModelState.IsValid) return View(vm);

            if (_passwordHasher.VerifyHashedPassword(null, user.PasswordHash, vm.PasswordLama) == PasswordVerificationResult.Failed)
            {
                ModelState.AddModelError(nameof(UbahPasswordVM.PasswordLama), "Password Lama salah!");
                return View(vm);
            }

            if (vm.PasswordLama == vm.PasswordBaru)
            {
                ModelState.AddModelError(nameof(UbahPasswordVM.PasswordBaru), "Password baru sama dengan password lama. Ganti dengan password yang berbeda");
                return View(vm);
            }

            user.PasswordHash = _passwordHasher.HashPassword(null, vm.PasswordBaru);

            var result = await _unitOfWork.SaveChangesAsync();
            if (result.IsFailure)
            {
                ModelState.AddModelError(string.Empty, "Simpan gagal!");
                return View(vm);
            }

            _notificationService.AddSuccess("Password berhasil diganti!");
            return RedirectToAction(nameof(Index));
        }
    }
}
