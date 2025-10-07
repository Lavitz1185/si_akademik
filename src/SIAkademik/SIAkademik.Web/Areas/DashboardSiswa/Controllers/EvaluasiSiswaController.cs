using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIAkademik.Domain.Authentication;
using SIAkademik.Domain.ModulSiakad.Repositories;
using SIAkademik.Web.Areas.DashboardSiswa.Models.NilaiModels;
using SIAkademik.Web.Authentication;

namespace SIAkademik.Web.Areas.DashboardSiswa.Controllers;

[Area(AreaNames.DashboardSiswa)]
[Authorize(Roles = AppUserRoles.Siswa)]
public class EvaluasiSiswaController : Controller
{
    private readonly ISignInManager _signInManager;
    private readonly IJadwalMengajarRepository _jadwalMengajarRepository;
    private readonly ITahunAjaranRepository _tahunAjaranRepository;

    public EvaluasiSiswaController(
        ISignInManager signInManager,
        IJadwalMengajarRepository jadwalMengajarRepository,
        ITahunAjaranRepository tahunAjaranRepository)
    {
        _signInManager = signInManager;
        _jadwalMengajarRepository = jadwalMengajarRepository;
        _tahunAjaranRepository = tahunAjaranRepository;
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

        var daftarJadwalMengajar = await _jadwalMengajarRepository.GetAllByTahunAjaranAndRombel(tahunAjaran.Id, anggotaRombel.Rombel.Id);

        return View(new IndexVM
        {
            Siswa = siswa,
            AnggotaRombel = anggotaRombel,
            IdTahunAjaran = tahunAjaran.Id,
            TahunAjaran = tahunAjaran,
            DaftarJadwalMengajar = daftarJadwalMengajar
        });
    }

    public async Task<IActionResult> Detail(int idJadwalMengajar)
    {
        var siswa = await _signInManager.GetSiswa();
        if (siswa is null) return Forbid();

        var jadwalMengajar = await _jadwalMengajarRepository.Get(idJadwalMengajar);
        if (jadwalMengajar is null) return NotFound();

        var anggotaRombel = siswa.DaftarAnggotaRombel.FirstOrDefault(a => a.Rombel == jadwalMengajar.Rombel);
        if (anggotaRombel is null) return BadRequest();

        return View(new DetailVM { AnggotaRombel = anggotaRombel, JadwalMengajar = jadwalMengajar });
    }
}
