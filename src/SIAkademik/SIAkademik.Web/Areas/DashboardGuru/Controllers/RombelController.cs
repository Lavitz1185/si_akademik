using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIAkademik.Domain.Authentication;
using SIAkademik.Domain.ModulSiakad.Repositories;

namespace SIAkademik.Web.Areas.DashboardGuru.Controllers;

[Area(AreaNames.DashboardGuru)]
[Authorize(Roles = AppUserRoles.Guru)]
public class RombelController : Controller
{
    private readonly IRombelRepository _rombelRepository;

    public RombelController(IRombelRepository rombelRepository)
    {
        _rombelRepository = rombelRepository;
    }

    [HttpGet]
    public async Task<IActionResult> DaftarRombel(int idTahunAjaran)
    {
        var daftarRombel = await _rombelRepository.GetAllByTahunAjaran(idTahunAjaran);

        return Json(daftarRombel.Select(r => new
        {
            r.Id,
            r.Nama,
            Kelas = new { Jenjang = r.Kelas.Jenjang.Humanize(), Peminatan = r.Kelas.Peminatan.Humanize() }
        }));
    }
}
