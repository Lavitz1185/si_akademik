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

    public async Task<IActionResult> Index(int? idTahunAjaran = null, int? idRombel = null)
    {
        var pegawai = await _signInManager.GetPegawai();
        if (pegawai is null) return Forbid();

        var tahunAjaran = idTahunAjaran is null ?
            await _tahunAjaranRepository.GetNewest() :
            await _tahunAjaranRepository.Get(idTahunAjaran.Value);

        if (tahunAjaran is null) return View(new IndexVM());

        if (idRombel is null) return View(new IndexVM { TahunAjaran = tahunAjaran });

        var rombel = await _rombelRepository.Get(idRombel.Value);
        if (rombel is null) return NotFound();

        if (!pegawai.DaftarRombelWali.Contains(rombel)) return BadRequest();

        return View(new IndexVM { TahunAjaran = tahunAjaran, Rombel = rombel });
    }

    public async Task<IActionResult> Detail(int idSiswa, int idRombel)
    {
        var pegawai = await _signInManager.GetPegawai();
        if (pegawai is null) return Forbid();

        var rombel = await _rombelRepository.Get(idRombel);
        if (rombel is null) return NotFound();
        if (!pegawai.DaftarRombelWali.Contains(rombel)) return BadRequest();

        var siswa = await _siswaRepository.Get(idSiswa);
        if (siswa is null) return NotFound();

        var anggotaRombel = rombel.DaftarAnggotaRombel.FirstOrDefault(a => a.Siswa == siswa);
        if (anggotaRombel is null) return BadRequest();

        var daftarRaport = await _raportRepository.GetAllBy(siswa.Id, rombel.Id);

        return View(new DetailVM { AnggotaRombel = anggotaRombel, DaftarRaport = daftarRaport });
    }

    [HttpPost]
    public async Task<IActionResult> IsiNilai(int idSiswa, int idRombel)
    {
        var pegawai = await _signInManager.GetPegawai();
        if (pegawai is null) return Forbid();

        var rombel = await _rombelRepository.Get(idRombel);
        if (rombel is null) return NotFound();
        if (!pegawai.DaftarRombelWali.Contains(rombel)) return BadRequest();

        var siswa = await _siswaRepository.Get(idSiswa);
        if (siswa is null) return NotFound();

        var anggotaRombel = rombel.DaftarAnggotaRombel.FirstOrDefault(a => a.Siswa == siswa);
        if (anggotaRombel is null) return BadRequest();

        var daftarRaport = await _raportRepository.GetAllBy(siswa.Id, rombel.Id);

        foreach (var jadwal in rombel.DaftarJadwalMengajar)
        {
            if (!daftarRaport.Any(r => r.JadwalMengajar == jadwal))
            {
                var raportPengetahuan = new Raport
                {
                    JadwalMengajar = jadwal,
                    AnggotaRombel = anggotaRombel,
                    Deskripsi = string.Empty,
                    KategoriNilai = KategoriNilaiRaport.Pengetahuan,
                    Nama = jadwal.MataPelajaran.Nama,
                    Predikat = string.Empty
                };

                var raportKeterampilan = new Raport
                {
                    JadwalMengajar = jadwal,
                    AnggotaRombel = anggotaRombel,
                    Deskripsi = string.Empty,
                    KategoriNilai = KategoriNilaiRaport.Keterampilan,
                    Nama = jadwal.MataPelajaran.Nama,
                    Predikat = string.Empty
                };

                _raportRepository.Add(raportPengetahuan);
                _raportRepository.Add(raportKeterampilan);
            }
        }

        var result = await _unitOfWork.SaveChangesAsync();

        daftarRaport = await _raportRepository.GetAllBy(siswa.Id, rombel.Id);

        return RedirectToAction(nameof(Detail), new { idSiswa, idRombel });
    }

    public async Task<IActionResult> Tambah(int idSiswa, int idRombel, KategoriNilaiRaport kategori)
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

        return View(new TambahVM
        {
            IdRombel = rombel.Id,
            IdSiswa = siswa.Id,
            Kategori = kategori,
        });
    }

    [HttpPost]
    public async Task<IActionResult> Tambah(TambahVM vm)
    {
        if (!ModelState.IsValid) return View(vm);

        var pegawai = await _signInManager.GetPegawai();
        if (pegawai is null) return Forbid();

        var siswa = await _siswaRepository.Get(vm.IdSiswa);
        if (siswa is null) return NotFound();

        var rombel = await _rombelRepository.Get(vm.IdRombel);
        if (rombel is null) return NotFound();

        if (rombel.Wali != pegawai) return BadRequest();

        var anggotaRombel = rombel.DaftarAnggotaRombel.FirstOrDefault(a => a.Siswa == siswa);
        if (anggotaRombel is null) return NotFound();

        if (vm.Kategori == KategoriNilaiRaport.Pengetahuan || vm.Kategori == KategoriNilaiRaport.Keterampilan)
        {
            if (vm.IdJadwalMengajar is null)
            {
                ModelState.AddModelError(nameof(TambahVM.IdJadwalMengajar), "Jadwal Mengajar harus diisi");
                return View(vm);
            }

            var jadwalMengajar = await _jadwalMengajarRepository.Get(vm.IdJadwalMengajar.Value);
            if (jadwalMengajar is null)
            {
                ModelState.AddModelError(nameof(TambahVM.IdJadwalMengajar), $"Jadwal dengan Id '{vm.IdJadwalMengajar}' tidak ditemukan!");
                return View(vm);
            }

            if (jadwalMengajar.Rombel != anggotaRombel.Rombel)
            {
                ModelState.AddModelError(nameof(TambahVM.IdJadwalMengajar), "Jadwal salah!");
                return View(vm);
            }

            if (anggotaRombel.DaftarRaport.Any(r => r.KategoriNilai == vm.Kategori && r.JadwalMengajar == jadwalMengajar))
            {
                ModelState.AddModelError(nameof(TambahVM.IdJadwalMengajar),
                    $"Data Raport kategori {vm.Kategori.Humanize()} dengan mata pelajaran {jadwalMengajar.MataPelajaran.Nama} sudah ada!");

                return View(vm);
            }

            var raport = new Raport
            {
                Nama = jadwalMengajar.MataPelajaran.Nama,
                Deskripsi = vm.Dekripsi,
                KategoriNilai = vm.Kategori,
                Predikat = vm.Predikat,
                JadwalMengajar = jadwalMengajar,
                AnggotaRombel = anggotaRombel
            };

            _raportRepository.Add(raport);
        }
        else
        {
            if (vm.Nama is null)
            {
                ModelState.AddModelError(nameof(TambahVM.Nama), "Nama harus diisi!");
                return View(vm);
            }

            if (anggotaRombel.DaftarRaport.Any(r => r.Nama.ToLower() == vm.Nama.ToLower()))
            {
                ModelState.AddModelError(nameof(TambahVM.Nama), $"Data raport dengan nama '{vm.Nama}' sudah ada");
                return View(vm);
            }

            var raport = new Raport
            {
                Nama = vm.Nama,
                Deskripsi = vm.Dekripsi,
                AnggotaRombel = anggotaRombel,
                KategoriNilai = vm.Kategori,
                Predikat = vm.Predikat
            };

            _raportRepository.Add(raport);
        }

        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
        {
            ModelState.AddModelError(string.Empty, "Simpan Gagal!");
            return View(vm);
        }

        _toastrNotificationService.AddSuccess("Simpan Berhasil!");

        return RedirectToAction(nameof(Detail), new { idSiswa = vm.IdSiswa, idRombel = vm.IdRombel });
    }

    public async Task<IActionResult> Edit(int id)
    {
        var pegawai = await _signInManager.GetPegawai();
        if (pegawai is null) return Forbid();

        var raport = await _raportRepository.Get(id);
        if (raport is null) return NotFound();

        if (!pegawai.DaftarRombelWali.Contains(raport.AnggotaRombel.Rombel))
            return BadRequest();

        return View(new EditVM
        {
            Id = raport.Id,
            Nama = raport.Nama,
            Kategori = raport.KategoriNilai,
            Dekripsi = raport.Deskripsi,
            Predikat = raport.Predikat,
            IdJadwalMengajar = raport.JadwalMengajar?.Id
        });
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EditVM vm)
    {
        if (!ModelState.IsValid) return View(vm);

        var pegawai = await _signInManager.GetPegawai();
        if (pegawai is null) return Forbid();

        var raport = await _raportRepository.Get(vm.Id);
        if (raport is null) return NotFound();

        if (!pegawai.DaftarRombelWali.Contains(raport.AnggotaRombel.Rombel))
            return BadRequest();

        if (vm.Kategori == KategoriNilaiRaport.Pengetahuan || vm.Kategori == KategoriNilaiRaport.Keterampilan)
        {
            if (vm.IdJadwalMengajar is null)
            {
                ModelState.AddModelError(nameof(EditVM.IdJadwalMengajar), "JadwalMengajar Harus Diisi!");
                return View(vm);
            }

            var jadwalMengajar = await _jadwalMengajarRepository.Get(vm.IdJadwalMengajar.Value);
            if (jadwalMengajar is null)
            {
                ModelState.AddModelError(nameof(EditVM.IdJadwalMengajar), $"Jadwal dengan Id '{vm.IdJadwalMengajar}' tidak ditemukan");
                return View(vm);
            }

            if (jadwalMengajar.Rombel != raport.AnggotaRombel.Rombel)
            {
                ModelState.AddModelError(nameof(EditVM.IdJadwalMengajar), "Jadwal tidak benar");
                return View(vm);
            }

            if (raport.AnggotaRombel.DaftarRaport.Any(r => r.KategoriNilai == raport.KategoriNilai && 
                r != raport && 
                r.JadwalMengajar == jadwalMengajar)) 
            {
                ModelState.AddModelError(nameof(TambahVM.IdJadwalMengajar),
                    $"Data Raport kategori {vm.Kategori.Humanize()} dengan mata pelajaran {jadwalMengajar.MataPelajaran.Nama} sudah ada!");

                return View(vm);
            }

            raport.Nama = jadwalMengajar.MataPelajaran.Nama;
            raport.JadwalMengajar = jadwalMengajar;
            raport.Deskripsi = vm.Dekripsi;
            raport.Predikat = vm.Predikat;
        }
        else
        {
            if (vm.Nama is null)
            {
                ModelState.AddModelError(nameof(TambahVM.Nama), "Nama harus diisi!");
                return View(vm);
            }

            if (raport.AnggotaRombel.DaftarRaport.Any(r => r != raport && r.Nama.ToLower() == vm.Nama.ToLower()))
            {
                ModelState.AddModelError(nameof(TambahVM.Nama), $"Data raport dengan nama '{vm.Nama}' sudah ada");
                return View(vm);
            }

            raport.Nama = vm.Nama;
            raport.Deskripsi = vm.Dekripsi;
            raport.Predikat = vm.Predikat;
        }

        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
        {
            ModelState.AddModelError(string.Empty, "Simpan Gagal!");
            return View(vm);
        }

        _toastrNotificationService.AddSuccess("Simpan Berhasil!");

        return RedirectToAction(nameof(Detail), new { idSiswa = raport.AnggotaRombel.Siswa.Id, idRombel = raport.AnggotaRombel.Rombel.Id });
    }

    [HttpPost]
    public async Task<IActionResult> Hapus(int id)
    {
        var pegawai = await _signInManager.GetPegawai();
        if (pegawai is null) return Forbid();

        var raport = await _raportRepository.Get(id);
        if (raport is null) return NotFound();

        if (!pegawai.DaftarRombelWali.Contains(raport.AnggotaRombel.Rombel))
            return BadRequest();

        var idSiswa = raport.AnggotaRombel.Siswa.Id;
        var idRombel = raport.AnggotaRombel.Rombel.Id;

        _raportRepository.Delete(raport);
        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
            _toastrNotificationService.AddError("Hapus Gagal!");
        else
            _toastrNotificationService.AddSuccess("Hapus Berhasil!");

        return RedirectToAction(nameof(Detail), new { idSiswa, idRombel });
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
