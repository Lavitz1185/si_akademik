using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIAkademik.Domain.Abstracts;
using SIAkademik.Domain.Authentication;
using SIAkademik.Domain.Enums;
using SIAkademik.Domain.ModulSiakad.Entities;
using SIAkademik.Domain.ModulSiakad.Repositories;
using SIAkademik.Web.Areas.DashboardGuru.Models.KelasWaliModels;
using SIAkademik.Web.Authentication;
using SIAkademik.Web.Models;
using SIAkademik.Web.Services.Toastr;

namespace SIAkademik.Web.Areas.DashboardGuru.Controllers;

[Area(AreaNames.DashboardGuru)]
[Authorize(Roles = AppUserRoles.Guru)]
public class KelasWaliController : Controller
{
    private readonly ISignInManager _signInManager;
    private readonly IPegawaiRepository _pegawaiRepository;
    private readonly IRombelRepository _rombelRepository;
    private readonly ITahunAjaranRepository _tahunAjaranRepository;
    private readonly IJadwalMengajarRepository _jadwalMengajarRepository;
    private readonly IPertemuanRepository _pertemuanRepository;
    private readonly IAbsenKelasRepository _absenKelasRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IToastrNotificationService _toastrNotificationService;

    public KelasWaliController(
        ISignInManager signInManager,
        IPegawaiRepository pegawaiRepository,
        IRombelRepository rombelRepository,
        ITahunAjaranRepository tahunAjaranRepository,
        IJadwalMengajarRepository jadwalMengajarRepository,
        IPertemuanRepository pertemuanRepository,
        IAbsenKelasRepository absenKelasRepository,
        IUnitOfWork unitOfWork,
        IToastrNotificationService toastrNotificationService)
    {
        _signInManager = signInManager;
        _pegawaiRepository = pegawaiRepository;
        _rombelRepository = rombelRepository;
        _tahunAjaranRepository = tahunAjaranRepository;
        _jadwalMengajarRepository = jadwalMengajarRepository;
        _pertemuanRepository = pertemuanRepository;
        _absenKelasRepository = absenKelasRepository;
        _unitOfWork = unitOfWork;
        _toastrNotificationService = toastrNotificationService;
    }

    public async Task<IActionResult> Index(int? idTahunAjaran = null)
    {
        var pegawai = await _signInManager.GetPegawai();
        if (pegawai is null) return Forbid();
        pegawai = (await _pegawaiRepository.Get(pegawai.Id))!;

        var tahunAjaran = idTahunAjaran is null ?
            await _tahunAjaranRepository.GetNewest() :
            await _tahunAjaranRepository.Get(idTahunAjaran.Value);

        if (tahunAjaran is null) return View(new IndexVM());

        return View(new IndexVM
        {
            TahunAjaran = tahunAjaran,
            DaftarRombelWali = pegawai.DaftarRombelWali.Where(r => r.Kelas.TahunAjaran == tahunAjaran).ToList()
        });
    }

    public async Task<IActionResult> Detail(int id)
    {
        var pegawai = await _signInManager.GetPegawai();
        if (pegawai is null) return Forbid();
        pegawai = (await _pegawaiRepository.Get(pegawai.Id))!;

        var rombel = await _rombelRepository.Get(id);
        if (rombel is null || !pegawai.DaftarRombelWali.Contains(rombel)) return NotFound();

        return View(rombel);
    }

    public async Task<IActionResult> DetailJadwal(int id, int idJadwal, int? idPertemuan = null)
    {
        var pegawai = await _signInManager.GetPegawai();
        if (pegawai is null) return Forbid();
        pegawai = (await _pegawaiRepository.Get(pegawai.Id))!;

        var rombel = await _rombelRepository.Get(id);
        if (rombel is null || !pegawai.DaftarRombelWali.Contains(rombel)) return BadRequest();

        var jadwal = await _jadwalMengajarRepository.Get(idJadwal);
        if (jadwal is null || jadwal.Rombel != rombel) return BadRequest();

        if (idPertemuan is null) return View(new DetailJadwalVM { Rombel = rombel, JadwalMengajar = jadwal });

        var pertemuan = await _pertemuanRepository.Get(idPertemuan.Value);
        if (pertemuan is null || !jadwal.DaftarPertemuan.Contains(pertemuan))
            return View(new DetailJadwalVM { Rombel = rombel, JadwalMengajar = jadwal });

        return View(new DetailJadwalVM { Rombel = rombel, JadwalMengajar = jadwal, Pertemuan = pertemuan });
    }

    public async Task<IActionResult> Absen(int id, DateOnly? tanggal)
    {
        var pegawai = await _signInManager.GetPegawai();
        if (pegawai is null) return Forbid();
        pegawai = (await _pegawaiRepository.Get(pegawai.Id))!;

        var rombel = await _rombelRepository.Get(id);
        if (rombel is null || !pegawai.DaftarRombelWali.Contains(rombel)) return NotFound();

        tanggal ??= DateOnly.FromDateTime(TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, CultureInfos.TimeZoneInfo));

        return View(new AbsenVM
        {
            Id = id,
            Tanggal = tanggal.Value,
            DaftarAbsenEntry = rombel.DaftarAnggotaRombel
                .SelectMany(a => a.DaftarAbsenKelas)
                .Where(k => k.Tanggal == tanggal)
                .Select(k => new AbsenEntryVM
                {
                    IdAbsen = k.Id,
                    NISSiswa = k.AnggotaRombel.Siswa.NIS,
                    NISNSiswa = k.AnggotaRombel.Siswa.NISN,
                    NamaSiswa = k.AnggotaRombel.Siswa.Nama,
                    Absensi = k.Absensi,
                    Catatan = k.Catatan
                }).ToList()
        });
    }

    [HttpPost]
    public async Task<IActionResult> Absen(AbsenVM vm)
    {
        if (!ModelState.IsValid) return View(vm);

        var pegawai = await _signInManager.GetPegawai();
        if (pegawai is null) return Forbid();
        pegawai = (await _pegawaiRepository.Get(pegawai.Id))!;

        var rombel = await _rombelRepository.Get(vm.Id);
        if (rombel is null || !pegawai.DaftarRombelWali.Contains(rombel)) return NotFound();

        foreach (var absenEntry in vm.DaftarAbsenEntry)
        {
            var absen = await _absenKelasRepository.Get(absenEntry.IdAbsen);

            if (absen is null) return NotFound();

            absen.Absensi = absenEntry.Absensi;
            absen.Catatan = absenEntry.Catatan;
            _absenKelasRepository.Update(absen);
        }

        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
        {
            _toastrNotificationService.AddSuccess("Simpan gagal!");
            return View(vm);
        }

        _toastrNotificationService.AddSuccess("Simpan sukses!");

        return RedirectToAction(nameof(Absen), new { id = vm.Id, tanggal = vm.Tanggal });
    }

    [HttpPost]
    public async Task<IActionResult> BuatAbsen(int id, DateOnly tanggal)
    {
        var pegawai = await _signInManager.GetPegawai();
        if (pegawai is null) return Forbid();
        pegawai = (await _pegawaiRepository.Get(pegawai.Id))!;

        var rombel = await _rombelRepository.Get(id);
        if (rombel is null || !pegawai.DaftarRombelWali.Contains(rombel)) return NotFound();

        var daftarAbsen = new List<AbsenKelas>();
        foreach (var anggotaRombel in rombel.DaftarAnggotaRombel)
            daftarAbsen.Add(new AbsenKelas
            {
                Tanggal = tanggal,
                Catatan = string.Empty,
                Absensi = Absensi.Hadir,
                AnggotaRombel = anggotaRombel,
            });

        foreach (var absen in daftarAbsen)
            _absenKelasRepository.Add(absen);

        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
            _toastrNotificationService.AddError("Buat absen gagal!");
        else
            _toastrNotificationService.AddSuccess("Buat absen sukses!");

        return RedirectToAction(nameof(Absen), new { id, tanggal });
    }
}
