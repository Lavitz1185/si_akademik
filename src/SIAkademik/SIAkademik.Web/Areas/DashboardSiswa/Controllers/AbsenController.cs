using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIAkademik.Domain.Authentication;
using SIAkademik.Domain.ModulSiakad.Repositories;
using SIAkademik.Web.Areas.DashboardSiswa.Models.AbsenModels;
using SIAkademik.Web.Authentication;

namespace SIAkademik.Web.Areas.DashboardSiswa.Controllers;

[Area(AreaNames.DashboardSiswa)]
[Authorize(Roles = AppUserRoles.Siswa)]
public class AbsenController : Controller
{
    private readonly ISignInManager _signInManager;
    private readonly ITahunAjaranRepository _tahunAjaranRepository;
    private readonly IAbsenKelasRepository _absenKelasRepository;

    public AbsenController(
        ISignInManager signInManager,
        ITahunAjaranRepository tahunAjaranRepository,
        IAbsenKelasRepository absenKelasRepository)
    {
        _signInManager = signInManager;
        _tahunAjaranRepository = tahunAjaranRepository;
        _absenKelasRepository = absenKelasRepository;
    }

    public async Task<IActionResult> Index(int? idTahunAjaran = null)
    {
        var siswa = await _signInManager.GetSiswa();
        if (siswa is null) return Forbid();

        var tahunAjaran = idTahunAjaran is null ?
            await _tahunAjaranRepository.GetNewest() :
            await _tahunAjaranRepository.Get(idTahunAjaran.Value);

        if (tahunAjaran is null) return View(new IndexVM { Siswa = siswa });

        var anggotaRombel = siswa.DaftarAnggotaRombel.Where(a => a.Rombel.Kelas.TahunAjaran == tahunAjaran).FirstOrDefault();
        if (anggotaRombel is null) return View(new IndexVM { Siswa = siswa, TahunAjaran = tahunAjaran, IdTahunAjaran = tahunAjaran.Id});

        var daftarAbsenKelas = await _absenKelasRepository.GetAllBySiswaAndRombel(anggotaRombel.IdSiswa, anggotaRombel.IdRombel);

        return View(new IndexVM
        {
            Siswa = siswa,
            TahunAjaran = tahunAjaran,
            IdTahunAjaran = tahunAjaran.Id,
            AnggotaRombel = anggotaRombel,
            DaftarAbsenKelas = daftarAbsenKelas
        });
    }
}
