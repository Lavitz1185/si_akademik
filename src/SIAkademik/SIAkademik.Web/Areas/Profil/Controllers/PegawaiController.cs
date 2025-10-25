using Microsoft.AspNetCore.Mvc;
using SIAkademik.Domain.ModulSiakad.Repositories;

namespace SIAkademik.Web.Areas.Profil.Controllers;

[Area(AreaNames.Profil)]
public class PegawaiController : Controller
{
    private readonly IPegawaiRepository _pegawaiRepository;

    public PegawaiController(IPegawaiRepository pegawaiRepository)
    {
        _pegawaiRepository = pegawaiRepository;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _pegawaiRepository.GetAll());
    }
}
