using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIAkademik.Domain.Authentication;
using SIAkademik.Domain.ModulSiakad.Repositories;
using SIAkademik.Web.Areas.DashboardSiswa.Models.JadwalMengajarModels;
using SIAkademik.Web.Authentication;

namespace SIAkademik.Web.Areas.DashboardSiswa.Controllers;

[Area(AreaNames.DashboardSiswa)]
[Authorize(Roles = AppUserRoles.Siswa)]
public class JadwalMengajarController : Controller
{
    private readonly IJadwalMengajarRepository _jadwalMengajarRepository;
    private readonly ITahunAjaranRepository _tahunAjaranRepository;
    private readonly ISignInManager _signInManager;

    public JadwalMengajarController(
        IJadwalMengajarRepository jadwalMengajarRepository,
        ITahunAjaranRepository tahunAjaranRepository,
        ISignInManager signInManager)
    {
        _jadwalMengajarRepository = jadwalMengajarRepository;
        _tahunAjaranRepository = tahunAjaranRepository;
        _signInManager = signInManager;
    }

    public async Task<IActionResult> Index(int? idTahunAjaran = null)
    {
        var siswa = await _signInManager.GetSiswa();
        if (siswa is null) return Forbid();

        var tahunAjaran = idTahunAjaran is null ?
            await _tahunAjaranRepository.GetNewest() :
            await _tahunAjaranRepository.Get(idTahunAjaran.Value);

        if (tahunAjaran is null) return View(new IndexVM { Siswa = siswa });

        var anggotaRombel = siswa.DaftarAnggotaRombel.FirstOrDefault(a => a.Rombel.Kelas.TahunAjaran == tahunAjaran);
        if (anggotaRombel is null) return View(new IndexVM { Siswa = siswa, TahunAjaran = tahunAjaran, IdTahunAjaran = tahunAjaran.Id });

        var daftarJadwalMengajar = await _jadwalMengajarRepository.GetAllByTahunAjaran(tahunAjaran.Id);

        return View(new IndexVM
        {
            Siswa = siswa,
            TahunAjaran = tahunAjaran,
            IdTahunAjaran = tahunAjaran.Id,
            DaftarJadwalMengajar = [.. daftarJadwalMengajar.Where(j => j.Rombel == anggotaRombel.Rombel)],
            AnggotaRombel = anggotaRombel
        });
    }

    public async Task<IActionResult> Detail(int id)
    {
        var siswa = await _signInManager.GetSiswa();
        if (siswa is null) return Forbid();

        var jadwalMengajar = await _jadwalMengajarRepository.Get(id);
        if (jadwalMengajar is null) return NotFound();

        var anggotaRombel = siswa.DaftarAnggotaRombel.FirstOrDefault(a => a.Rombel == jadwalMengajar.Rombel);
        if (anggotaRombel is null) return BadRequest();

        return View(new DetailVM { AnggotaRombel = anggotaRombel, JadwalMengajar = jadwalMengajar });
    }
}
