using Microsoft.AspNetCore.Mvc;
using SIAkademik.Domain.ModulProfil.Entities;
using SIAkademik.Domain.ModulProfil.Repositories;
using SIAkademik.Web.Areas.Profil.Models.BeritaModels;

namespace SIAkademik.Web.Areas.Profil.Controllers;

[Area(AreaNames.Profil)]
public class BeritaController : Controller
{
    private readonly IBeritaRepository _beritaRepository;

    public BeritaController(IBeritaRepository beritaRepository)
    {
        _beritaRepository = beritaRepository;
    }

    public async Task<IActionResult> Index()
    {
        var daftarBerita = await _beritaRepository.GetAll();

        return View(daftarBerita);
    }

    public async Task<IActionResult> Detail(int id)
    {
        var daftarBerita = await _beritaRepository.GetAll();

        var berita = daftarBerita.FirstOrDefault(b => b.Id == id);
        if (berita is null) return NotFound();

        var indexBerita = daftarBerita.IndexOf(berita);

        return View(new DetailVM
        {
            Berita = berita,
            Sebelumnya = indexBerita > 0 ? daftarBerita[indexBerita - 1] : null,
            Selanjutnya = indexBerita < daftarBerita.Count - 1 ? daftarBerita[indexBerita + 1] : null
        });
    }
}
