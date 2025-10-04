using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIAkademik.Domain.Authentication;
using SIAkademik.Domain.Enums;
using SIAkademik.Domain.ModulSiakad.Repositories;
using SIAkademik.Web.Areas.DashboardSiswa.Models.Home;
using SIAkademik.Web.Authentication;
using SIAkademik.Web.Models;

namespace SIAkademik.Web.Areas.DashboardSiswa.Controllers;

[Area(AreaNames.DashboardSiswa)]
[Authorize(Roles = AppUserRoles.Siswa)]
public class HomeController : Controller
{
    private readonly ISignInManager _signInManager;
    private readonly ITahunAjaranRepository _tahunAjaranRepository;
    private readonly IJadwalMengajarRepository _jadwalMengajarRepository;

    public HomeController(
        ISignInManager signInManager,
        ITahunAjaranRepository tahunAjaranRepository,
        IJadwalMengajarRepository jadwalMengajarRepository)
    {
        _signInManager = signInManager;
        _tahunAjaranRepository = tahunAjaranRepository;
        _jadwalMengajarRepository = jadwalMengajarRepository;
    }

    public async Task<IActionResult> Index(DateOnly? tanggal)
    {
        var siswa = await _signInManager.GetSiswa();
        if (siswa is null) return Forbid();

        tanggal ??= DateOnly.FromDateTime(CultureInfos.DateTimeNow);

        var tahunAjaran = await _tahunAjaranRepository.GetNewest();
        if (tahunAjaran is null) return View(new IndexVM { Tanggal = tanggal.Value });

        var anggotaRombel = siswa.DaftarAnggotaRombel.FirstOrDefault(a => a.Rombel.Kelas.TahunAjaran == tahunAjaran);
        if (anggotaRombel is null) return View(new IndexVM { TahunAjaran = tahunAjaran, Tanggal = tanggal.Value });

        var hari = tanggal.Value.DayOfWeek;

        var daftarJadwalMengajar = await _jadwalMengajarRepository.GetAllByTahunAjaran(tahunAjaran.Id);
        var daftarHariMengajar = daftarJadwalMengajar
            .Where(j => j.Rombel == anggotaRombel.Rombel)
            .SelectMany(j => j.DaftarHariMengajar)
            .Where(h => HariExtension.FromHari(h.Hari) == hari)
            .ToList();

        return View(new IndexVM 
        { 
            AnggotaRombel = anggotaRombel,
            TahunAjaran = tahunAjaran,
            Tanggal = tanggal.Value,
            DaftarHariMengajar = daftarHariMengajar 
        });
    }

    public async Task<IActionResult> Logout()
    {
        await _signInManager.Logout();

        return RedirectToAction("Index", "Home", new { Area = AreaNames.Profil });
    }
}
