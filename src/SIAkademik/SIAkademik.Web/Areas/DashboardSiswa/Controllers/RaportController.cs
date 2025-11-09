using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Razor.Templating.Core;
using SIAkademik.Domain.Authentication;
using SIAkademik.Domain.ModulSiakad.Repositories;
using SIAkademik.Web.Areas.DashboardSiswa.Models.RaportModels;
using SIAkademik.Web.Authentication;
using SIAkademik.Web.Models;
using SIAkademik.Web.Services.PDFGenerator;

namespace SIAkademik.Web.Areas.DashboardSiswa.Controllers;

[Area(AreaNames.DashboardSiswa)]
[Authorize(Roles = AppUserRoles.Siswa)]
public class RaportController : Controller
{
    private readonly ISignInManager _signInManager;
    private readonly ITahunAjaranRepository _tahunAjaranRepository;
    private readonly IRaportRepository _raportRepository;
    private readonly IRombelRepository _rombelRepository;
    private readonly IRazorTemplateEngine _razorTemplateEngine;
    private readonly IPDFGeneratorService _pDFGeneratorService;

    public RaportController(
        ISignInManager signInManager,
        ITahunAjaranRepository tahunAjaranRepository,
        IRaportRepository raportRepository,
        IRombelRepository rombelRepository,
        IRazorTemplateEngine razorTemplateEngine,
        IPDFGeneratorService pDFGeneratorService)
    {
        _signInManager = signInManager;
        _tahunAjaranRepository = tahunAjaranRepository;
        _raportRepository = raportRepository;
        _rombelRepository = rombelRepository;
        _razorTemplateEngine = razorTemplateEngine;
        _pDFGeneratorService = pDFGeneratorService;
    }

    public async Task<IActionResult> Index(int? idTahunAjaran = null)
    {
        var siswa = await _signInManager.GetSiswa();
        if (siswa is null) return Forbid();

        var tahunAjaran = idTahunAjaran is null ?
            await _tahunAjaranRepository.Get(CultureInfos.DateOnlyNow) :
            await _tahunAjaranRepository.Get(idTahunAjaran.Value);

        if (tahunAjaran is null) return View(new IndexVM { Siswa = siswa });

        var anggotaRombel = siswa.DaftarAnggotaRombel.FirstOrDefault(a => a.Rombel.TahunAjaran == tahunAjaran);
        if (anggotaRombel is null) return View(new IndexVM { Siswa = siswa, TahunAjaran = tahunAjaran, IdTahunAjaran = tahunAjaran.Id });

        var daftarRaport = await _raportRepository.GetAllBy(siswa.Id, anggotaRombel.Rombel.Id);

        return View(new IndexVM
        {
            Siswa = siswa,
            AnggotaRombel = anggotaRombel,
            IdTahunAjaran = tahunAjaran.Id,
            TahunAjaran = tahunAjaran,
            DaftarRaport = daftarRaport
        });
    }

    public async Task<IActionResult> Cetak(int idRombel)
    {
        var siswa = await _signInManager.GetSiswa();
        if (siswa is null) return NotFound();

        var rombel = await _rombelRepository.Get(idRombel);
        if (rombel is null) return NotFound();

        var anggotaRombel = rombel.DaftarAnggotaRombel.FirstOrDefault(a => a.Siswa == siswa);
        if (anggotaRombel is null) return NotFound();

        return View(anggotaRombel);
    }

    public async Task<IActionResult> RaportPDF(int idRombel, bool download = false)
    {
        var siswa = await _signInManager.GetSiswa();
        if (siswa is null) return NotFound();

        var rombel = await _rombelRepository.Get(idRombel);
        if (rombel is null) return NotFound();

        var anggotaRombel = rombel.DaftarAnggotaRombel.FirstOrDefault(a => a.Siswa == siswa);
        if (anggotaRombel is null) return NotFound();

        var html = await _razorTemplateEngine.RenderAsync("Views/Shared/_Format2RaportPartial.cshtml", anggotaRombel);
        var header = await _razorTemplateEngine.RenderAsync("Views/Shared/_Header2LaporanPartial.cshtml", anggotaRombel);
        var footer = await _razorTemplateEngine.RenderAsync("Views/Shared/_Footer2LaporanPartial.cshtml", anggotaRombel);

        var fileName = $"Raport_{siswa.Nama}({siswa.NISN})_{rombel.Kelas.Jenjang.Humanize()}" +
            $"_{rombel.TahunAjaran.Periode.Replace("/", "-")}" +
            $"_{rombel.TahunAjaran.Semester.Humanize()}";

        var pdfBinary = await _pDFGeneratorService.GeneratePDF(
            html,
            header,
            footer,
            fileName,
            marginTop: 120,
            marginBottom: 50,
            marginLeft: 80,
            marginRight: 80);

        if (download)
            return File(pdfBinary, "application/pdf", fileDownloadName: fileName);

        return File(pdfBinary, "application/pdf");
    }
}
