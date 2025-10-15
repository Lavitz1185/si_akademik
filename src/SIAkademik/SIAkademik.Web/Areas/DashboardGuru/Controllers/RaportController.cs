using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Razor.Templating.Core;
using SIAkademik.Domain.Abstracts;
using SIAkademik.Domain.Authentication;
using SIAkademik.Domain.ModulSiakad.Entities;
using SIAkademik.Domain.ModulSiakad.Repositories;
using SIAkademik.Web.Areas.DashboardGuru.Models.RaportModels;
using SIAkademik.Web.Authentication;
using SIAkademik.Web.Services.PDFGenerator;
using SIAkademik.Web.Services.Toastr;

namespace SIAkademik.Web.Areas.DashboardGuru.Controllers;

[Area(AreaNames.DashboardGuru)]
[Authorize(Roles = AppUserRoles.Guru)]
public class RaportController : Controller
{
    private readonly IRombelRepository _rombelRepository;
    private readonly ISignInManager _signInManager;
    private readonly ITahunAjaranRepository _tahunAjaranRepository;
    private readonly ISiswaRepository _siswaRepository;
    private readonly IRaportRepository _raportRepository;
    private readonly IJadwalMengajarRepository _jadwalMengajarRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IToastrNotificationService _toastrNotificationService;
    private readonly IPDFGeneratorService _pDFGeneratorService;
    private readonly IRazorTemplateEngine _razorTemplateEngine;

    public RaportController(
        IRombelRepository rombelRepository,
        ISignInManager signInManager,
        ITahunAjaranRepository tahunAjaranRepository,
        ISiswaRepository siswaRepository,
        IRaportRepository raportRepository,
        IUnitOfWork unitOfWork,
        IJadwalMengajarRepository jadwalMengajarRepository,
        IToastrNotificationService toastrNotificationService,
        IPDFGeneratorService pDFGeneratorService,
        IRazorTemplateEngine razorTemplateEngine)
    {
        _rombelRepository = rombelRepository;
        _signInManager = signInManager;
        _tahunAjaranRepository = tahunAjaranRepository;
        _siswaRepository = siswaRepository;
        _raportRepository = raportRepository;
        _unitOfWork = unitOfWork;
        _jadwalMengajarRepository = jadwalMengajarRepository;
        _toastrNotificationService = toastrNotificationService;
        _pDFGeneratorService = pDFGeneratorService;
        _razorTemplateEngine = razorTemplateEngine;
    }

    public async Task<IActionResult> Index(int? idTahunAjaran = null, int? idRombel = null, int? idJadwalMengajar = null)
    {
        var pegawai = await _signInManager.GetPegawai();
        if (pegawai is null) return Forbid();

        var tahunAjaran = idTahunAjaran is null ?
            await _tahunAjaranRepository.GetNewest() :
            await _tahunAjaranRepository.Get(idTahunAjaran.Value);

        if (tahunAjaran is null) return View(new IndexVM { Pegawai = pegawai });

        if (idRombel is null) return View(new IndexVM { Pegawai = pegawai, IdTahunAjaran = tahunAjaran.Id, TahunAjaran = tahunAjaran });

        var rombel = await _rombelRepository.Get(idRombel.Value);
        if (rombel is null) return View(new IndexVM { Pegawai = pegawai, IdTahunAjaran = tahunAjaran.Id, TahunAjaran = tahunAjaran });

        if (rombel.Wali != pegawai)
        {
            _toastrNotificationService.AddError("Anda bukan wali kelas untuk kelas ini!");
            return View(new IndexVM { Pegawai = pegawai, IdTahunAjaran = tahunAjaran.Id, TahunAjaran = tahunAjaran });
        }

        if (idJadwalMengajar is null)
            return View(new IndexVM
            {
                Pegawai = pegawai,
                IdTahunAjaran = tahunAjaran.Id,
                TahunAjaran = tahunAjaran,
                Rombel = rombel,
                IdRombel = rombel.Id
            });

        var jadwalMengajar = await _jadwalMengajarRepository.Get(idJadwalMengajar.Value);
        if (jadwalMengajar is null || jadwalMengajar.Rombel != rombel)
            return View(new IndexVM
            {
                Pegawai = pegawai,
                IdTahunAjaran = tahunAjaran.Id,
                TahunAjaran = tahunAjaran,
                Rombel = rombel,
                IdRombel = rombel.Id
            });

        return View(new IndexVM
        {
            Pegawai = pegawai,
            IdTahunAjaran = tahunAjaran.Id,
            IdRombel = rombel.Id,
            TahunAjaran = tahunAjaran,
            Rombel = rombel,
            JadwalMengajar = jadwalMengajar,
            IdJadwalMengajar = jadwalMengajar.Id,
        });
    }

    [Route("[Area]/Ekstrakulikuler")]
    public async Task<IActionResult> NilaiEkstrakulikuler(int? idTahunAjaran = null, int? idRombel = null)
    {
        var pegawai = await _signInManager.GetPegawai();
        if (pegawai is null) return Forbid();

        var tahunAjaran = idTahunAjaran is null ?
            await _tahunAjaranRepository.GetNewest() :
            await _tahunAjaranRepository.Get(idTahunAjaran.Value);

        if (tahunAjaran is null) return View(new NilaiEkstrakulikulerVM { Pegawai = pegawai });

        if (idRombel is null) return View(new NilaiEkstrakulikulerVM { Pegawai = pegawai, IdTahunAjaran = tahunAjaran.Id, TahunAjaran = tahunAjaran });

        var rombel = await _rombelRepository.Get(idRombel.Value);
        if (rombel is null) return View(new NilaiEkstrakulikulerVM { Pegawai = pegawai, IdTahunAjaran = tahunAjaran.Id, TahunAjaran = tahunAjaran });

        if (rombel.Wali != pegawai)
        {
            _toastrNotificationService.AddError("Anda bukan wali kelas untuk kelas ini!");
            return View(new NilaiEkstrakulikulerVM { Pegawai = pegawai, IdTahunAjaran = tahunAjaran.Id, TahunAjaran = tahunAjaran });
        }

        return View(new NilaiEkstrakulikulerVM
        {
            Pegawai = pegawai,
            IdTahunAjaran = tahunAjaran.Id,
            IdRombel = rombel.Id,
            TahunAjaran = tahunAjaran,
            Rombel = rombel
        });
    }

    [HttpPost]
    public async Task<IActionResult> HapusEkstrakulikuler(int idTahunAjaran, int idRombel, int idEkstrakulikuler)
    {
        var pegawai = await _signInManager.GetPegawai();
        if (pegawai is null) return Forbid();

        var tahunAjaran = await _tahunAjaranRepository.Get(idTahunAjaran);
        if (tahunAjaran is null)
        {
            _toastrNotificationService.AddError("Tahun Ajaran tidak ditemukan", "Hapus Ekstrakulikuler");
            return RedirectToAction(nameof(NilaiEkstrakulikuler));
        }

        var rombel = await _rombelRepository.Get(idRombel);
        if (rombel is null || rombel.Kelas.TahunAjaran != tahunAjaran || rombel.Wali != pegawai)
        {
            _toastrNotificationService.AddError("Rombel tidak ditemukan", "Hapus Ekstrakulikuler");
            return RedirectToAction(nameof(NilaiEkstrakulikuler), new { idTahunAjaran });
        }

        var ekstrakulikuler = await _raportRepository.Get(idEkstrakulikuler);
        if (ekstrakulikuler is null)
        {
            _toastrNotificationService.AddError("Ekstrakulikuler tidak ditemukan", "Hapus Ekstrakulikuler");
            return RedirectToAction(nameof(NilaiEkstrakulikuler), new { idTahunAjaran, idRombel });
        }

        _raportRepository.Delete(ekstrakulikuler);
        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsSuccess)
            _toastrNotificationService.AddSuccess("Simpan Berhasil", "Hapus Ekstrakulikuler");
        else
            _toastrNotificationService.AddError("Simpan Gagal", "Hapus Ekstrakulikuler");

        return RedirectToAction(nameof(NilaiEkstrakulikuler), new { idTahunAjaran, idRombel });
    }

    [HttpPost]
    public async Task<IActionResult> TambahEkstrakulikuler(TambahEkstrakulikulerVM vm)
    {
        if (!ModelState.IsValid)
        {
            _toastrNotificationService.AddError("Data tidak valid", "Tambah Ekstrakulikuler");
            return RedirectToAction(nameof(NilaiEkstrakulikuler), new { vm.IdTahunAjaran, vm.IdRombel });
        }

        var pegawai = await _signInManager.GetPegawai();
        if (pegawai is null) return Forbid();

        var tahunAjaran = await _tahunAjaranRepository.Get(vm.IdTahunAjaran);
        if (tahunAjaran is null)
        {
            _toastrNotificationService.AddError("Tahun Ajaran tidak ditemukan", "Tambah Ekstrakulikuler");
            return RedirectToAction(nameof(NilaiEkstrakulikuler));
        }

        var rombel = await _rombelRepository.Get(vm.IdRombel);
        if (rombel is null || rombel.Kelas.TahunAjaran != tahunAjaran || rombel.Wali != pegawai)
        {
            _toastrNotificationService.AddError("Rombel tidak ditemukan", "Tambah Ekstrakulikuler");
            return RedirectToAction(nameof(NilaiEkstrakulikuler), new { vm.IdTahunAjaran });
        }

        var anggotaRombel = rombel.DaftarAnggotaRombel.FirstOrDefault(a => a.Id == vm.IdAnggotaRombel);
        if (anggotaRombel is null)
        {
            _toastrNotificationService.AddError("Siswa tidak dalam rombel ini", "Tambah Ekstrakulikuler");
            return RedirectToAction(nameof(NilaiEkstrakulikuler), new { vm.IdTahunAjaran, vm.IdRombel });
        }

        if (anggotaRombel.DaftarRaport.Any(r => r.KategoriNilai == KategoriNilaiRaport.Ekstrakulikuler && r.Nama.ToLower() == vm.Nama.ToLower()))
        {
            _toastrNotificationService.AddError($"Ekstrakulikuler dengan nama {vm.Nama} sudah ada", "Tambah Ekstrakulikuler");
            return RedirectToAction(nameof(NilaiEkstrakulikuler), new { vm.IdTahunAjaran, vm.IdRombel });
        }

        var ekstrakulikuler = new Raport
        {
            KategoriNilai = KategoriNilaiRaport.Ekstrakulikuler,
            AnggotaRombel = anggotaRombel,
            Nama = vm.Nama,
            Deskripsi = vm.Keterangan,
            Predikat = vm.Predikat
        };

        _raportRepository.Add(ekstrakulikuler);
        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsSuccess)
            _toastrNotificationService.AddSuccess("Simpan Berhasil", "Tambah Ekstrakulikuler");
        else
            _toastrNotificationService.AddError("Simpan Gagal", "Tambah Ekstrakulikuler");

        return RedirectToAction(nameof(NilaiEkstrakulikuler), new { vm.IdTahunAjaran, vm.IdRombel });
    }

    [HttpPost]
    public async Task<IActionResult> EditEkstrakulikuler(EditEkstrakulikulerVM vm)
    {
        if (!ModelState.IsValid)
        {
            _toastrNotificationService.AddError("Data tidak valid", "Edit Ekstrakulikuler");
            return RedirectToAction(nameof(NilaiEkstrakulikuler), new { vm.IdTahunAjaran, vm.IdRombel });
        }

        var pegawai = await _signInManager.GetPegawai();
        if (pegawai is null) return Forbid();

        var tahunAjaran = await _tahunAjaranRepository.Get(vm.IdTahunAjaran);
        if (tahunAjaran is null)
        {
            _toastrNotificationService.AddError("Tahun Ajaran tidak ditemukan", "Edit Ekstrakulikuler");
            return RedirectToAction(nameof(NilaiEkstrakulikuler));
        }

        var rombel = await _rombelRepository.Get(vm.IdRombel);
        if (rombel is null || rombel.Kelas.TahunAjaran != tahunAjaran || rombel.Wali != pegawai)
        {
            _toastrNotificationService.AddError("Rombel tidak ditemukan", "Edit Ekstrakulikuler");
            return RedirectToAction(nameof(NilaiEkstrakulikuler), new { vm.IdTahunAjaran });
        }

        var ekstrakulikuler = await _raportRepository.Get(vm.IdEkstrakulikuler);
        if (ekstrakulikuler is null)
        {
            _toastrNotificationService.AddError("Ekstrakulikuler tidak ditemukan", "Edit Ekstrakulikuler");
            return RedirectToAction(nameof(NilaiEkstrakulikuler), new { vm.IdTahunAjaran, vm.IdRombel });
        }

        var anggotaRombel = rombel.DaftarAnggotaRombel.First(a => a == ekstrakulikuler.AnggotaRombel);
        if (anggotaRombel
            .DaftarRaport
            .Any(r => r.Id != vm.IdEkstrakulikuler && r.KategoriNilai == KategoriNilaiRaport.Ekstrakulikuler && r.Nama.ToLower() == vm.Nama.ToLower()))
        {
            _toastrNotificationService.AddError($"Ekstrakulikuler dengan nama {vm.Nama} sudah ada", "Edit Ekstrakulikuler");
            return RedirectToAction(nameof(NilaiEkstrakulikuler), new { vm.IdTahunAjaran, vm.IdRombel });
        }

        ekstrakulikuler.Nama = vm.Nama;
        ekstrakulikuler.Predikat = vm.Predikat;
        ekstrakulikuler.Deskripsi = vm.Keterangan;

        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsSuccess)
            _toastrNotificationService.AddSuccess("Simpan Berhasil", "Edit Ekstrakulikuler");
        else
            _toastrNotificationService.AddError("Simpan Gagal", "Edit Ekstrakulikuler");

        return RedirectToAction(nameof(NilaiEkstrakulikuler), new { vm.IdTahunAjaran, vm.IdRombel });
    }

    public async Task<IActionResult> Cetak(int idSiswa, int idRombel)
    {
        var pegawai = await _signInManager.GetPegawai();
        if (pegawai is null) return Forbid();

        var siswa = await _siswaRepository.Get(idSiswa);
        if (siswa is null) return NotFound();

        var rombel = await _rombelRepository.Get(idRombel);
        if (rombel is null) return NotFound();

        if (rombel.Wali != pegawai) return BadRequest();

        var anggotaRombel = rombel.DaftarAnggotaRombel.FirstOrDefault(a => a.Siswa == siswa);
        if (anggotaRombel is null) return NotFound();

        return View(anggotaRombel);
    }

    public async Task<IActionResult> RaportPDF(int idSiswa, int idRombel, bool download = false)
    {
        var pegawai = await _signInManager.GetPegawai();
        if (pegawai is null) return Forbid();

        var siswa = await _siswaRepository.Get(idSiswa);
        if (siswa is null) return NotFound();

        var rombel = await _rombelRepository.Get(idRombel);
        if (rombel is null) return NotFound();

        if (rombel.Wali != pegawai) return BadRequest();

        var anggotaRombel = rombel.DaftarAnggotaRombel.FirstOrDefault(a => a.Siswa == siswa);
        if (anggotaRombel is null) return NotFound();

        var html = await _razorTemplateEngine.RenderAsync("Views/Shared/_Format1RaportPartial.cshtml", anggotaRombel);

        var fileName = $"Raport_{siswa.Nama}({siswa.NISN})_{rombel.Kelas.Jenjang.Humanize()}" +
            $"_{rombel.Kelas.TahunAjaran.Periode.Replace("/", "-")}" +
            $"_{rombel.Kelas.TahunAjaran.Semester.Humanize()}";

        var pdfBinary = await _pDFGeneratorService.GeneratePDF(html, fileName);

        if (download)
            return File(pdfBinary, "application/pdf", fileDownloadName: fileName);

        return File(pdfBinary, "application/pdf");
    }
}
