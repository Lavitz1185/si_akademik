using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIAkademik.Domain.Authentication;
using SIAkademik.Domain.ModulSiakad.Entities;
using SIAkademik.Domain.ModulSiakad.Repositories;
using SIAkademik.Web.Areas.DashboardSiswa.Models.NilaiModels;
using SIAkademik.Web.Authentication;

namespace SIAkademik.Web.Areas.DashboardSiswa.Controllers;

[Area(AreaNames.DashboardSiswa)]
[Authorize(Roles = AppUserRoles.Siswa)]
public class NilaiController : Controller
{
    private readonly ISignInManager _signInManager;
    private readonly ITahunAjaranRepository _tahunAjaranRepository;
    private readonly IAsesmenSumatifRepository _asesmenSumatifRepository;

    public NilaiController(
        ISignInManager signInManager,
        ITahunAjaranRepository tahunAjaranRepository,
        IAsesmenSumatifRepository asesmenSumatifRepository)
    {
        _signInManager = signInManager;
        _tahunAjaranRepository = tahunAjaranRepository;
        _asesmenSumatifRepository = asesmenSumatifRepository;
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

        return View(new IndexVM { Siswa = siswa, TahunAjaran = tahunAjaran, IdTahunAjaran = tahunAjaran.Id, AnggotaRombel = anggotaRombel });
    }

    public async Task<IActionResult> Detail(int idTahunAjaran, int idAsesmenSumatif)
    {
        var siswa = await _signInManager.GetSiswa();
        if (siswa is null) return Forbid();

        var tahunAjaran = await _tahunAjaranRepository.Get(idTahunAjaran);
        if (tahunAjaran is null) return NotFound();

        var anggotaRombel = siswa.DaftarAnggotaRombel.FirstOrDefault(a => a.Rombel.Kelas.TahunAjaran == tahunAjaran);
        if (anggotaRombel is null) return NotFound();

        var asesmenSumatif = await _asesmenSumatifRepository.Get(idAsesmenSumatif);
        if (asesmenSumatif is null) return NotFound();
        if (asesmenSumatif.JadwalMengajar.Rombel != anggotaRombel.Rombel) return BadRequest();

        return View(new DetailVM
        {
            Siswa = siswa,
            AnggotaRombel = anggotaRombel,
            TahunAjaran = tahunAjaran,
            AsesmenSumatif = asesmenSumatif
        });
    }
}
