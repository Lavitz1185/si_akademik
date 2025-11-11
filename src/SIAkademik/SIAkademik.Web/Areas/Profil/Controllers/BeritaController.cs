using Microsoft.AspNetCore.Mvc;
using SIAkademik.Domain.ModulProfil.Entities;
using SIAkademik.Domain.ModulProfil.Repositories;
using SIAkademik.Web.Areas.Profil.Models.BeritaModels;
using SIAkademik.Web.Models;

namespace SIAkademik.Web.Areas.Profil.Controllers;

[Area(AreaNames.Profil)]
public class BeritaController : Controller
{
    private readonly IBeritaRepository _beritaRepository;

    public BeritaController(IBeritaRepository beritaRepository)
    {
        _beritaRepository = beritaRepository;
    }

    public async Task<IActionResult> Index(
        int pageSize = 6,
        int pageIndex = 0,
        int? idKategoriBerita = null,
        string? searchString = null)
    {
        var daftarBerita = await _beritaRepository.GetAll();

        return View(new IndexVM
        {
            SearchString = searchString,
            IdKategoriBerita = idKategoriBerita,
            DaftarBerita = daftarBerita
                .Where(b => (idKategoriBerita is null || b.KategoriBerita.Id == idKategoriBerita) &&
                            (searchString is null || searchString
                                .ToLower()
                                .Split(" ")
                                .Any(s => b.Judul.Contains(s, StringComparison.InvariantCultureIgnoreCase))))
                .ToPagedList(pageSize, pageIndex)
        });
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
