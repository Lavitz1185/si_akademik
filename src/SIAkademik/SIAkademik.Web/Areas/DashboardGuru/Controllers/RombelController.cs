using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIAkademik.Domain.Authentication;
using SIAkademik.Domain.ModulSiakad.Repositories;
using SIAkademik.Web.Authentication;

namespace SIAkademik.Web.Areas.DashboardGuru.Controllers;

[Area(AreaNames.DashboardGuru)]
[Authorize(Roles = AppUserRoles.Guru)]
public class RombelController : Controller
{
    private readonly IRombelRepository _rombelRepository;
    private readonly ISignInManager _signInManager;

    public RombelController(
        IRombelRepository rombelRepository,
        ISignInManager signInManager)
    {
        _rombelRepository = rombelRepository;
        _signInManager = signInManager;
    }

    [HttpGet]
    public async Task<IActionResult> DaftarRombel(int idTahunAjaran)
    {
        var pegawai = await _signInManager.GetPegawai();
        if (pegawai is null) return Forbid();

        var daftarRombel = await _rombelRepository.GetAllByTahunAjaran(idTahunAjaran);

        return Json(daftarRombel.Where(r => r.Wali == pegawai).Select(r => new
        {
            r.Id,
            r.Nama,
            Kelas = new { Jenjang = r.Kelas.Jenjang.Humanize(), Peminatan = r.Kelas.Peminatan.Nama }
        }));
    }
}
