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
    private readonly IAnggotaRombelRepository _anggotaRombelRepository;

    public KelasWaliController(
        ISignInManager signInManager,
        IPegawaiRepository pegawaiRepository,
        IRombelRepository rombelRepository,
        ITahunAjaranRepository tahunAjaranRepository,
        IJadwalMengajarRepository jadwalMengajarRepository,
        IPertemuanRepository pertemuanRepository,
        IAbsenKelasRepository absenKelasRepository,
        IUnitOfWork unitOfWork,
        IToastrNotificationService toastrNotificationService,
        IAnggotaRombelRepository anggotaRombelRepository)
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
        _anggotaRombelRepository = anggotaRombelRepository;
    }

    public async Task<IActionResult> Index(int? idTahunAjaran = null)
    {
        var pegawai = await _signInManager.GetPegawai();
        if (pegawai is null) return Forbid();

        var tahunAjaran = idTahunAjaran is null ?
            await _tahunAjaranRepository.Get(CultureInfos.DateOnlyNow) :
            await _tahunAjaranRepository.Get(idTahunAjaran.Value);

        if (tahunAjaran is null) return View(new IndexVM());

        return View(new IndexVM
        {
            TahunAjaran = tahunAjaran,
            IdTahunAjaran = tahunAjaran.Id,
            DaftarRombelWali = pegawai.DaftarRombelWali.Where(r => r.TahunAjaran == tahunAjaran).ToList()
        });
    }

    public async Task<IActionResult> Detail(int id)
    {
        var pegawai = await _signInManager.GetPegawai();
        if (pegawai is null) return Forbid();

        var rombel = await _rombelRepository.Get(id);
        if (rombel is null || rombel.Wali != pegawai) return NotFound();

        return View(rombel);
    }

    public async Task<IActionResult> DetailJadwal(int id, int idJadwal, int? idPertemuan = null)
    {
        var pegawai = await _signInManager.GetPegawai();
        if (pegawai is null) return Forbid();

        var rombel = await _rombelRepository.Get(id);
        if (rombel is null || rombel.Wali != pegawai) return BadRequest();

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
            Rombel = rombel,
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

        var rombel = await _rombelRepository.Get(id);
        if (rombel is null || rombel.Wali != pegawai) return NotFound();

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

    [HttpPost]
    public async Task<IActionResult> HapusAbsen(int id, DateOnly tanggal)
    {
        var pegawai = await _signInManager.GetPegawai();
        if (pegawai is null) return Forbid();

        var rombel = await _rombelRepository.Get(id);
        if (rombel is null || rombel.Wali != pegawai) return NotFound();

        var daftarAbsen = await _absenKelasRepository.GetAllByRombel(rombel.Id);

        foreach (var absen in daftarAbsen.Where(a => a.Tanggal == tanggal))
            _absenKelasRepository.Delete(absen);

        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsSuccess)
            _toastrNotificationService.AddSuccess("Absen berhasil dihapus", "Hapus Absen");
        else
            _toastrNotificationService.AddError("Absen gagal dihapus", "Hapus Absen");

        return RedirectToAction(nameof(Absen), new { id, tanggal });
    }

    [Route("[Area]/[Action]")]
    public async Task<IActionResult> ProsesKelulusan(int? idTahunAjaran = null, int? idRombel = null, int? idRombelTinggal = null)
    {
        var pegawai = await _signInManager.GetPegawai();
        if (pegawai is null) return Forbid();

        var tahunAjaran = idTahunAjaran is null ?
            (await _tahunAjaranRepository.GetAll(Semester.Genap)).LastOrDefault() :
            await _tahunAjaranRepository.Get(idTahunAjaran.Value);

        if (tahunAjaran is null) return View(new ProsesKelulusanVM { Pegawai = pegawai });

        if (tahunAjaran.Semester != Semester.Genap)
        {
            _toastrNotificationService.AddError("Proses Kelulusan hanya bisa dilakukan di semester genap");
            return View(new ProsesKelulusanVM { Pegawai = pegawai });
        }

        var tahunAjaranBaru = await _tahunAjaranRepository.Get(tahunAjaran.Tahun + 1, Semester.Ganjil);
        if (tahunAjaranBaru is null)
        {
            _toastrNotificationService.AddError($"Tahun Ajaran {tahunAjaran.Tahun + 1}/{tahunAjaran.Tahun + 2} " +
                $"{Semester.Ganjil.Humanize()} belum ada, segera hubungi Admin");
            return View(new ProsesKelulusanVM { Pegawai = pegawai, TahunAjaran = tahunAjaran, IdTahunAjaran = tahunAjaran.Id });
        }

        var rombel = idRombel is null ?
            (await _rombelRepository.GetAll(tahunAjaran.Id, pegawai.Id)).Where(r => r.Kelas.Jenjang == Jenjang.XII).FirstOrDefault() :
            await _rombelRepository.Get(idRombel.Value);

        if (rombel is null || rombel.TahunAjaran != tahunAjaran)
            rombel = (await _rombelRepository.GetAll(tahunAjaran.Id, pegawai.Id)).Where(r => r.Kelas.Jenjang == Jenjang.XII).FirstOrDefault();

        if (rombel is null || rombel.TahunAjaran != tahunAjaran || rombel.Wali != pegawai || rombel.Kelas.Jenjang != Jenjang.XII)
            return View(new ProsesKelulusanVM
            {
                Pegawai = pegawai,
                TahunAjaran = tahunAjaran,
                IdTahunAjaran = tahunAjaran.Id,
                TahunAjaranBaru = tahunAjaranBaru,
                IdTahunAjaranBaru = tahunAjaranBaru.Id
            });

        var daftarRombelTinggal = await _rombelRepository.GetAll(rombel.Kelas.Id, tahunAjaranBaru.Id);
        var rombelTinggal = idRombelTinggal is null ?
            daftarRombelTinggal.FirstOrDefault() :
            daftarRombelTinggal.FirstOrDefault(r => r.Id == idRombelTinggal.Value);

        if (rombelTinggal is null)
            return View(new ProsesKelulusanVM
            {
                Pegawai = pegawai,
                TahunAjaran = tahunAjaran,
                IdTahunAjaran = tahunAjaran.Id,
                TahunAjaranBaru = tahunAjaranBaru,
                IdTahunAjaranBaru = tahunAjaranBaru.Id,
                Rombel = rombel,
                IdRombel = rombel.Id
            });

        return View(new ProsesKelulusanVM
        {
            Pegawai = pegawai,
            TahunAjaran = tahunAjaran,
            IdTahunAjaran = tahunAjaran.Id,
            TahunAjaranBaru = tahunAjaranBaru,
            IdTahunAjaranBaru = tahunAjaranBaru.Id,
            Rombel = rombel,
            IdRombel = rombel.Id,
            RombelTinggal = rombelTinggal,
            IdRombelTinggal = rombelTinggal.Id,
            DaftarEntry = [
                ..rombel.DaftarAnggotaRombel
                    .Where(a => a.Aktif && a.Siswa.StatusAktif == StatusAktifMahasiswa.Aktif)
                    .Select(a => new ProsesKelulusanEntryVM { AnggotaRombel = a, IdAnggotaRombel = a.Id, Selected = false })
            ]
        });
    }

    [Route("[Area]/[Action]")]
    [HttpPost]
    public async Task<IActionResult> ProsesKelulusan(ProsesKelulusanVM vm)
    {
        var pegawai = await _signInManager.GetPegawai();
        if (pegawai is null) return Forbid();

        if (vm.IdTahunAjaran is null ||
            vm.IdTahunAjaranBaru is null ||
            vm.IdRombel is null ||
            vm.IdRombelTinggal is null)
        {
            _toastrNotificationService.AddError("Data tidak valid!");
            return RedirectToAction(nameof(ProsesKelulusan));
        }

        var tahunAjaran = await _tahunAjaranRepository.Get(vm.IdTahunAjaran.Value);
        if (tahunAjaran is null)
        {
            _toastrNotificationService.AddError("Tahun Ajaran tidak ditemukan");
            return RedirectToAction(nameof(ProsesKelulusan));
        }

        if (tahunAjaran.Semester != Semester.Genap)
        {
            _toastrNotificationService.AddError("Proses Kelulusan hanya bisa dilakukan di semester genap");
            return RedirectToAction(nameof(ProsesKelulusan));
        }

        var rombel = await _rombelRepository.Get(vm.IdRombel.Value);
        if (rombel is null || rombel.TahunAjaran != tahunAjaran || rombel.Wali != pegawai || rombel.Kelas.Jenjang != Jenjang.XII)
        {
            _toastrNotificationService.AddError("Rombel tidak ditemukan");
            return RedirectToAction(nameof(ProsesKelulusan), new { vm.IdTahunAjaran });
        }

        var tahunAjaranBaru = await _tahunAjaranRepository.Get(vm.IdTahunAjaranBaru.Value);
        if (tahunAjaranBaru is null || tahunAjaranBaru.Tahun != (tahunAjaran.Tahun + 1) || tahunAjaranBaru.Semester != Semester.Ganjil)
        {
            _toastrNotificationService.AddError("Tahun Ajaran Baru tidak ditemukan");
            return RedirectToAction(nameof(ProsesKelulusan), new { vm.IdTahunAjaran, vm.IdRombel });
        }

        var rombelTinggal = await _rombelRepository.Get(vm.IdRombelTinggal.Value);
        if (rombelTinggal is null || rombelTinggal.TahunAjaran != tahunAjaranBaru || rombelTinggal.Kelas != rombel.Kelas)
        {
            _toastrNotificationService.AddError("Rombel Tinggal Kelas tidak ditemukan");
            return RedirectToAction(nameof(ProsesKelulusan), new { vm.IdTahunAjaran, vm.IdRombel });
        }

        foreach(var entry in vm.DaftarEntry)
        {
            var anggotaRombel = rombel.DaftarAnggotaRombel.FirstOrDefault(a => a.Id == entry.IdAnggotaRombel);
            if (anggotaRombel is null || !anggotaRombel.Aktif) continue;

            anggotaRombel.Aktif = false;
            anggotaRombel.TanggalKeluar = CultureInfos.DateOnlyNow;

            if (entry.Selected)
            {
                anggotaRombel.Siswa.StatusAktif = StatusAktifMahasiswa.TidakAktif;
                anggotaRombel.NaikKelasLulus = true;
            }
            else
            {
                anggotaRombel.NaikKelasLulus = false;

                if (!rombelTinggal.DaftarAnggotaRombel.Any(a => a.Siswa == anggotaRombel.Siswa))
                {
                    var anggotaRombelTinggal = new AnggotaRombel
                    {
                        Rombel = rombelTinggal,
                        Siswa = anggotaRombel.Siswa,
                        Aktif = true,
                        TanggalMasuk = CultureInfos.DateOnlyNow
                    };
                    _anggotaRombelRepository.Add(anggotaRombelTinggal);
                }
            }
        }

        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
        {
            _toastrNotificationService.AddError("Simpan Gagal");
            return RedirectToAction(nameof(ProsesKelulusan), new { vm.IdTahunAjaran, vm.IdRombel, vm.IdRombelTinggal });
        }

        _toastrNotificationService.AddSuccess("Simpan Berhasil");
        return RedirectToAction(nameof(ProsesKelulusan), new { vm.IdTahunAjaran, vm.IdRombel, vm.IdRombelTinggal });
    }

    [Route("[Area]/[Action]")]
    public async Task<IActionResult> NaikKelas(
        int? idTahunAjaran = null, 
        int? idRombel = null)
    {
        var pegawai = await _signInManager.GetPegawai();
        if (pegawai is null) return Forbid();

        var tahunAjaran = idTahunAjaran is null ? 
            (await _tahunAjaranRepository.GetAll(Semester.Genap)).LastOrDefault() :
            await _tahunAjaranRepository.Get(idTahunAjaran.Value);

        if (tahunAjaran is null) return View(new NaikKelasVM { Pegawai = pegawai });

        if (tahunAjaran.Semester != Semester.Genap)
        {
            _toastrNotificationService.AddError("Kenaikan kelas hanya bisa dilakukan di semester genap");
            return View(new NaikKelasVM { Pegawai = pegawai });
        }

        var rombel = idRombel is null ?
        (await _rombelRepository.GetAll(tahunAjaran.Id, pegawai.Id)).Where(r => r.Kelas.Jenjang != Jenjang.XII).FirstOrDefault() :
        await _rombelRepository.Get(idRombel.Value);

        if (rombel is null || rombel.TahunAjaran != tahunAjaran)
            rombel = (await _rombelRepository.GetAll(tahunAjaran.Id, pegawai.Id)).Where(r => r.Kelas.Jenjang != Jenjang.XII).FirstOrDefault();

        if (rombel is null || 
            rombel.TahunAjaran != tahunAjaran || 
            rombel.Kelas.Jenjang == Jenjang.XII || 
            rombel.Wali != pegawai)
            return View(new NaikKelasVM { Pegawai = pegawai, TahunAjaran = tahunAjaran, IdTahunAjaran = tahunAjaran.Id });

        var tahunAjaranBaru = await _tahunAjaranRepository.Get(tahunAjaran.Tahun + 1, Semester.Ganjil);
        if (tahunAjaranBaru is null)
        {
            _toastrNotificationService.AddError($"Tahun Ajaran {tahunAjaran.Tahun + 1}/{tahunAjaran.Tahun + 2} " +
                $"{Semester.Ganjil.Humanize()} belum dibuat, segera hubungi Admin");

            return View(new NaikKelasVM
            {
                Pegawai = pegawai,
                TahunAjaran = tahunAjaran,
                IdTahunAjaran = tahunAjaran.Id,
                Rombel = rombel,
                IdRombel = rombel.Id
            });
        }

        var daftarRombel = await _rombelRepository.GetAllByTahunAjaran(tahunAjaranBaru.Id);
        var daftarRombelTinggal = daftarRombel.Where(r => r.Kelas == rombel.Kelas).ToList();
        var daftarRombelNaik = daftarRombel
            .Where(r =>
                r.Kelas.Jenjang != Jenjang.XII &&
                r.Kelas.Jenjang == rombel.Kelas.Jenjang + 1 &&
                (rombel.Kelas.Peminatan.Jenis == JenisPeminatan.Umum || r.Kelas.Peminatan == rombel.Kelas.Peminatan))
            .ToList();

        var rombelTinggal = daftarRombelTinggal.FirstOrDefault();
        var rombelNaik = daftarRombelNaik.FirstOrDefault();

        return View(new NaikKelasVM
        {
            Pegawai = pegawai,
            TahunAjaran = tahunAjaran,
            IdTahunAjaran = tahunAjaran.Id,
            TahunAjaranBaru = tahunAjaranBaru,
            IdTahunAjaranBaru = tahunAjaranBaru.Id,
            Rombel = rombel,
            IdRombel = rombel.Id,
            DaftarRombelTinggalKelas = daftarRombelTinggal,
            RombelTinggal = rombelTinggal,
            IdRombelTinggal = rombelTinggal?.Id,
            DaftarRombelNaikKelas = daftarRombelNaik,
            RombelNaikKelas = rombelNaik,
            IdRombelNaikKelas = rombelNaik?.Id,
            DaftarEntry = [
                ..rombel.DaftarAnggotaRombel
                    .Where(a => a.Aktif)
                    .Select(a => new NaikKelasEntryVM { AnggotaRombel = a, IdAnggotaRombel = a.Id, Selected = false})
            ]
        });
    }

    [Route("[Area]/NaikKelas/[Action]")]
    [HttpPost]
    public async Task<IActionResult> ProsesNaikKelas(NaikKelasVM vm)
    {
        var pegawai = await _signInManager.GetPegawai();
        if (pegawai is null) return Forbid();

        if (vm.IdTahunAjaran is null ||
            vm.IdTahunAjaranBaru is null ||
            vm.IdRombel is null || 
            vm.IdRombelNaikKelas is null)
        {
            _toastrNotificationService.AddError("Data data tidak valid");
            return RedirectToAction(nameof(NaikKelas));
        }

        var tahunAjaran = await _tahunAjaranRepository.Get(vm.IdTahunAjaran.Value);
        if (tahunAjaran is null)
        {
            _toastrNotificationService.AddError("Tahun Ajaran tidak ditemukan");
            return RedirectToAction(nameof(NaikKelas));
        }

        if (tahunAjaran.Semester != Semester.Genap)
        {
            _toastrNotificationService.AddError("Proses kenaikan kelas hanya dapat dilakukan pada semester genap");
            return RedirectToAction(nameof(NaikKelas));
        }

        var rombel = await _rombelRepository.Get(vm.IdRombel.Value);
        if (rombel is null || rombel.Wali != pegawai || rombel.Kelas.Jenjang == Jenjang.XII)
        {
            _toastrNotificationService.AddError("Rombel tidak ditemukan");
            return RedirectToAction(nameof(NaikKelas), new { vm.IdTahunAjaran });
        }

        var tahunAjaranBaru = await _tahunAjaranRepository.Get(vm.IdTahunAjaranBaru.Value);
        if (tahunAjaranBaru is null || tahunAjaranBaru.Tahun != (tahunAjaran.Tahun + 1) || tahunAjaranBaru.Semester != Semester.Ganjil)
        {
            _toastrNotificationService.AddError("Tahun Ajaran baru tidak ditemukan");
            return RedirectToAction(nameof(NaikKelas), new { vm.IdTahunAjaran, vm.IdRombel });
        }

        var rombelNaikKelas = await _rombelRepository.Get(vm.IdRombelNaikKelas.Value);
        if (rombelNaikKelas is null || 
            rombelNaikKelas.Kelas.Jenjang != (rombel.Kelas.Jenjang + 1) ||
            (rombel.Kelas.Peminatan.Jenis != JenisPeminatan.Umum && rombelNaikKelas.Kelas.Peminatan != rombel.Kelas.Peminatan))
        {
            _toastrNotificationService.AddError("Rombel Naik Kelas tidak ditemukan");
            return RedirectToAction(nameof(NaikKelas), new { vm.IdTahunAjaran, vm.IdRombel });
        }

        foreach (var entry in vm.DaftarEntry)
        {
            var anggotaRombel = rombel.DaftarAnggotaRombel.FirstOrDefault(a => a.Id == entry.IdAnggotaRombel);
            if (anggotaRombel is null) continue;

            if (entry.Selected)
            {
                anggotaRombel.Aktif = false;
                anggotaRombel.NaikKelasLulus = true;
                anggotaRombel.TanggalKeluar = CultureInfos.DateOnlyNow;
                anggotaRombel.Siswa.Jenjang = rombelNaikKelas.Kelas.Jenjang;

                if (!rombelNaikKelas.DaftarAnggotaRombel.Any(a => a.Siswa == anggotaRombel.Siswa))
                {
                    var anggotaRombelNaikKelas = new AnggotaRombel
                    {
                        Siswa = anggotaRombel.Siswa,
                        Rombel = rombelNaikKelas,
                        Aktif = true,
                        TanggalMasuk = CultureInfos.DateOnlyNow
                    };

                    _anggotaRombelRepository.Add(anggotaRombelNaikKelas);
                }
            }
        }

        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
        {
            _toastrNotificationService.AddError("Simpan Gagal");
            return RedirectToAction(nameof(NaikKelas), new { vm.IdTahunAjaran, vm.IdRombel });
        }

        _toastrNotificationService.AddSuccess("Simpan Berhasil");
        return RedirectToAction(nameof(NaikKelas), new { vm.IdTahunAjaran, vm.IdRombel });
    }

    [Route("[Area]/NaikKelas/[Action]")]
    [HttpPost]
    public async Task<IActionResult> ProsesTinggalKelas(NaikKelasVM vm)
    {
        var pegawai = await _signInManager.GetPegawai();
        if (pegawai is null) return Forbid();

        if (vm.IdTahunAjaran is null ||
            vm.IdTahunAjaranBaru is null ||
            vm.IdRombel is null ||
            vm.IdRombelTinggal is null)
        {
            _toastrNotificationService.AddError("Data data tidak valid");
            return RedirectToAction(nameof(NaikKelas));
        }

        var tahunAjaran = await _tahunAjaranRepository.Get(vm.IdTahunAjaran.Value);
        if (tahunAjaran is null)
        {
            _toastrNotificationService.AddError("Tahun Ajaran tidak ditemukan");
            return RedirectToAction(nameof(NaikKelas));
        }

        if (tahunAjaran.Semester != Semester.Genap)
        {
            _toastrNotificationService.AddError("Proses kenaikan kelas hanya dapat dilakukan pada semester genap");
            return RedirectToAction(nameof(NaikKelas));
        }

        var rombel = await _rombelRepository.Get(vm.IdRombel.Value);
        if (rombel is null || rombel.Wali != pegawai || rombel.Kelas.Jenjang == Jenjang.XII)
        {
            _toastrNotificationService.AddError("Rombel tidak ditemukan");
            return RedirectToAction(nameof(NaikKelas), new { vm.IdTahunAjaran });
        }

        var tahunAjaranBaru = await _tahunAjaranRepository.Get(vm.IdTahunAjaranBaru.Value);
        if (tahunAjaranBaru is null || tahunAjaranBaru.Tahun != (tahunAjaran.Tahun + 1) || tahunAjaranBaru.Semester != Semester.Ganjil)
        {
            _toastrNotificationService.AddError("Tahun Ajaran baru tidak ditemukan");
            return RedirectToAction(nameof(NaikKelas), new { vm.IdTahunAjaran, vm.IdRombel });
        }

        var rombelTinggalKelas = await _rombelRepository.Get(vm.IdRombelTinggal.Value);
        if (rombelTinggalKelas is null || rombelTinggalKelas.Kelas != rombel.Kelas)
        {
            _toastrNotificationService.AddError("Rombel Naik Kelas tidak ditemukan");
            return RedirectToAction(nameof(NaikKelas), new { vm.IdTahunAjaran, vm.IdRombel });
        }

        foreach (var entry in vm.DaftarEntry)
        {
            var anggotaRombel = rombel.DaftarAnggotaRombel.FirstOrDefault(a => a.Id == entry.IdAnggotaRombel);
            if (anggotaRombel is null) continue;

            if (entry.Selected)
            {
                anggotaRombel.Aktif = false;
                anggotaRombel.NaikKelasLulus = false;
                anggotaRombel.TanggalKeluar = CultureInfos.DateOnlyNow;

                if (!rombelTinggalKelas.DaftarAnggotaRombel.Any(a => a.Siswa == anggotaRombel.Siswa))
                {
                    var anggotaRombelTinggalKelas = new AnggotaRombel
                    {
                        Siswa = anggotaRombel.Siswa,
                        Rombel = rombelTinggalKelas,
                        Aktif = true,
                        TanggalMasuk = CultureInfos.DateOnlyNow
                    };

                    _anggotaRombelRepository.Add(anggotaRombelTinggalKelas);
                }
            }
        }

        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
        {
            _toastrNotificationService.AddError("Simpan Gagal");
            return RedirectToAction(nameof(NaikKelas), new { vm.IdTahunAjaran, vm.IdRombel });
        }

        _toastrNotificationService.AddSuccess("Simpan Berhasil");
        return RedirectToAction(nameof(NaikKelas), new { vm.IdTahunAjaran, vm.IdRombel });
    }
}
