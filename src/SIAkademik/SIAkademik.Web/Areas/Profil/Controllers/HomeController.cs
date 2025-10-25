using Microsoft.AspNetCore.Mvc;
using SIAkademik.Domain.Authentication;
using SIAkademik.Domain.ModulProfil.Repositories;
using SIAkademik.Domain.ModulSiakad.Repositories;
using SIAkademik.Web.Areas.Profil.Models.Home;
using SIAkademik.Web.Authentication;

namespace SIAkademik.Web.Areas.Profil.Controllers;

[Area(AreaNames.Profil)]
public class HomeController : Controller
{
    private readonly ISignInManager _signInManager;
    private readonly IInformasiUmumRepository _informasiUmumRepository;
    private readonly IPegawaiRepository _pegawaiRepository;
    private readonly ISiswaRepository _siswaRepository;

    public HomeController(
        ISignInManager signInManager,
        IInformasiUmumRepository informasiUmumRepository,
        IPegawaiRepository pegawaiRepository,
        ISiswaRepository siswaRepository)
    {
        _signInManager = signInManager;
        _informasiUmumRepository = informasiUmumRepository;
        _pegawaiRepository = pegawaiRepository;
        _siswaRepository = siswaRepository;
    }

    public async Task<IActionResult> Index()
    {
        return View(new IndexVM
        {
            InformasiUmum = await _informasiUmumRepository.Get(),
            DaftarPegawai = await _pegawaiRepository.GetAll(),
            DaftarSiswa = await _siswaRepository.GetAll()
        });
    }

    public IActionResult Kurikulum()
    {
        return View();
    }

    public IActionResult Fasilitas()
    {
        return View();
    }

    public async Task<IActionResult> TentangKami()
    {
        return View(await _informasiUmumRepository.Get());
    }

    public IActionResult CoreValue()
    {
        return View();
    }

    public async Task<IActionResult> Kontak()
    {
        return View(await _informasiUmumRepository.Get());
    }

    public IActionResult Login(string? returnUrl = null)
    {
        return View(new LoginVM
        {
            ReturnUrl = returnUrl ?? Url.Action(nameof(Index))!
        });
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginVM vm)
    {
        if (!ModelState.IsValid) return View(vm);

        var result = await _signInManager.Login(vm.UserName, vm.Password, vm.RememberMe);
        if (result.IsFailure)
        {
            ModelState.AddModelError(string.Empty, result.Error.Message);
            return View(vm);
        }

        if(result.Value == AppUserRoles.Admin)
            return RedirectToAction("Index", "Home", new { Area = AreaNames.DashboardAdmin});
        else if (result.Value == AppUserRoles.Guru)
            return RedirectToAction("Index", "Home", new { Area = AreaNames.DashboardGuru});
        else
            return RedirectToAction("Index", "Home", new { Area = AreaNames.DashboardSiswa});
    }

    public IActionResult AccessDenied()
    {
        return View();
    }
}
