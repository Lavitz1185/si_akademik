using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIAkademik.Domain.Abstracts;
using SIAkademik.Domain.Authentication;
using SIAkademik.Domain.Enums;
using SIAkademik.Domain.ModulSiakad.Entities;
using SIAkademik.Domain.ModulSiakad.Repositories;
using SIAkademik.Web.Areas.DashboardGuru.Models.EvaluasiSiswaModels;
using SIAkademik.Web.Authentication;
using SIAkademik.Web.Services.Toastr;

namespace SIAkademik.Web.Areas.DashboardGuru.Controllers;

[Area(AreaNames.DashboardGuru)]
[Authorize(Roles = AppUserRoles.Guru)]
public class EvaluasiSiswaController : Controller
{
    private readonly ISignInManager _signInManager;
    private readonly IEvaluasiSiswaRepository _evaluasiSiswaRepository;
    private readonly IJadwalMengajarRepository _jadwalMengajarRepository;
    private readonly ITahunAjaranRepository _tahunAjaranRepository;
    private readonly IToastrNotificationService _toastrNotificationService;
    private readonly INilaiEvaluasiSiswaRepository _nilaiEvaluasiSiswaRepository;
    private readonly IUnitOfWork _unitOfWork;

    public EvaluasiSiswaController(
        ISignInManager signInManager,
        IEvaluasiSiswaRepository evaluasiSiswaRepository,
        IJadwalMengajarRepository jadwalMengajarRepository,
        ITahunAjaranRepository tahunAjaranRepository,
        IToastrNotificationService toastrNotificationService,
        INilaiEvaluasiSiswaRepository nilaiEvaluasiSiswaRepository,
        IUnitOfWork unitOfWork)
    {
        _signInManager = signInManager;
        _evaluasiSiswaRepository = evaluasiSiswaRepository;
        _jadwalMengajarRepository = jadwalMengajarRepository;
        _tahunAjaranRepository = tahunAjaranRepository;
        _toastrNotificationService = toastrNotificationService;
        _nilaiEvaluasiSiswaRepository = nilaiEvaluasiSiswaRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IActionResult> Index(int? idTahunAjaran = null, int? idJadwalMengajar = null, JenisNilai jenis = JenisNilai.Tugas)
    {
        var pegawai = await _signInManager.GetPegawai();
        if (pegawai is null) return Forbid();

        var tahunAjaran = idTahunAjaran is null ?
            await _tahunAjaranRepository.GetNewest() :
            await _tahunAjaranRepository.Get(idTahunAjaran.Value);

        if (tahunAjaran is null) return View(new IndexVM { Pegawai = pegawai, Jenis = jenis });

        var daftarJadwalMengajar = await _jadwalMengajarRepository.GetAllByTahunAjaran(tahunAjaran.Id);
        daftarJadwalMengajar = daftarJadwalMengajar.Where(j => j.Rombel.Wali == pegawai).ToList();

        var jadwalMengajar = idJadwalMengajar is null ?
            daftarJadwalMengajar.FirstOrDefault() :
            daftarJadwalMengajar.FirstOrDefault(j => j.Id == idJadwalMengajar);

        if (jadwalMengajar is null)
            return View(new IndexVM
            {
                Pegawai = pegawai,
                TahunAjaran = tahunAjaran,
                IdTahunAjaran = tahunAjaran.Id,
                Jenis = jenis,
                DaftarJadwalMengajar = daftarJadwalMengajar
            });

        return View(new IndexVM
        {
            Pegawai = pegawai,
            TahunAjaran = tahunAjaran,
            IdTahunAjaran = tahunAjaran.Id,
            JadwalMengajar = jadwalMengajar,
            IdJadwalMengajar = jadwalMengajar.Id,
            Jenis = jenis,
            DaftarEvaluasiSiswa = jadwalMengajar.DaftarEvaluasiSiswa.Where(e => e.Jenis == jenis).ToList(),
            DaftarJadwalMengajar = daftarJadwalMengajar
        });
    }

    [HttpPost]
    public async Task<IActionResult> Tambah(int idTahunAjaran, int idJadwalMengajar, JenisNilai jenis, string deskripsi)
    {
        var pegawai = await _signInManager.GetPegawai();
        if (pegawai is null) return Forbid();

        var tahunAjaran = await _tahunAjaranRepository.Get(idTahunAjaran);
        if (tahunAjaran is null) return NotFound();

        var jadwalMengajar = await _jadwalMengajarRepository.Get(idJadwalMengajar);
        if (jadwalMengajar is null) return NotFound();
        if (jadwalMengajar.Rombel.Kelas.TahunAjaran != tahunAjaran || jadwalMengajar.Rombel.Wali != pegawai)
            return BadRequest();

        if (jenis == JenisNilai.UAS || jenis == JenisNilai.UTS)
            if (jadwalMengajar.DaftarEvaluasiSiswa.Any(e => e.Jenis == jenis))
            {
                _toastrNotificationService.AddError($"Nilai {jenis.Humanize()} hanya boleh ada 1 per mata pelajaran");
                return RedirectToAction(nameof(Index), new { idJadwalMengajar, idTahunAjaran, jenis });
            }
            else
            if (jadwalMengajar.DaftarEvaluasiSiswa.Any(e => e.Deskripsi.ToLower() == deskripsi.ToLower()))
            {
                _toastrNotificationService.AddError($"{jenis.Humanize()} dengan deskripsi '{deskripsi}' sudah ada");
                return RedirectToAction(nameof(Index), new { idJadwalMengajar, idTahunAjaran, jenis });
            }

        var evaluasiSiswa = new EvaluasiSiswa
        {
            Deskripsi = deskripsi,
            Jenis = jenis,
            JadwalMengajar = jadwalMengajar,
        };

        _evaluasiSiswaRepository.Add(evaluasiSiswa);

        foreach (var anggotaRombel in jadwalMengajar.Rombel.DaftarAnggotaRombel)
        {
            var nilaiEvaluasiSiswa = new NilaiEvaluasiSiswa
            {
                AnggotaRombel = anggotaRombel,
                EvaluasiSiswa = evaluasiSiswa,
                Nilai = 0
            };

            _nilaiEvaluasiSiswaRepository.Add(nilaiEvaluasiSiswa);
        }

        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
            _toastrNotificationService.AddError("Simpan gagal!");
        else
            _toastrNotificationService.AddSuccess("Simpan berhasil!");

        return RedirectToAction(nameof(Index), new { idJadwalMengajar, idTahunAjaran, jenis });
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, string deskripsi)
    {
        var pegawai = await _signInManager.GetPegawai();
        if (pegawai is null) return Forbid();

        var evaluasiSiswa = await _evaluasiSiswaRepository.Get(id);
        if (evaluasiSiswa is null) return NotFound();

        if (evaluasiSiswa.JadwalMengajar.Rombel.Wali != pegawai)
            return BadRequest();

        if (evaluasiSiswa.JadwalMengajar.DaftarEvaluasiSiswa.Any(e => e.Deskripsi.ToLower() == deskripsi.ToLower()))
            _toastrNotificationService.AddError($"{evaluasiSiswa.Jenis.Humanize()} dengan deskripsi '{deskripsi}' sudah ada");
        else
        {
            evaluasiSiswa.Deskripsi = deskripsi;

            var result = await _unitOfWork.SaveChangesAsync();
            if (result.IsFailure)
                _toastrNotificationService.AddError("Simpan gagal!");
            else
                _toastrNotificationService.AddSuccess("Simpan berhasil!");
        }

        return RedirectToAction(
            nameof(Index),
            new
            {
                idJadwalMengajar = evaluasiSiswa.JadwalMengajar.Id,
                idTahunAjaran = evaluasiSiswa.JadwalMengajar.Rombel.Kelas.TahunAjaran.Id,
                jenis = evaluasiSiswa.Jenis
            });
    }

    [HttpPost]
    public async Task<IActionResult> Hapus(int id, string deskripsi)
    {
        var pegawai = await _signInManager.GetPegawai();
        if (pegawai is null) return Forbid();

        var evaluasiSiswa = await _evaluasiSiswaRepository.Get(id);
        if (evaluasiSiswa is null) return NotFound();

        if (evaluasiSiswa.JadwalMengajar.Rombel.Wali != pegawai) return BadRequest();

        _evaluasiSiswaRepository.Delete(evaluasiSiswa);

        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
            _toastrNotificationService.AddError("Simpan gagal!");
        else
            _toastrNotificationService.AddSuccess("Simpan berhasil!");

        return RedirectToAction(
            nameof(Index),
            new
            {
                idJadwalMengajar = evaluasiSiswa.JadwalMengajar.Id,
                idTahunAjaran = evaluasiSiswa.JadwalMengajar.Rombel.Kelas.TahunAjaran.Id,
                jenis = evaluasiSiswa.Jenis
            });
    }

    public async Task<IActionResult> IsiNilai(int id)
    {
        var pegawai = await _signInManager.GetPegawai();
        if (pegawai is null) return Forbid();

        var evaluasiSiswa = await _evaluasiSiswaRepository.Get(id);
        if (evaluasiSiswa is null) return NotFound();
        if (evaluasiSiswa.JadwalMengajar.Rombel.Wali != pegawai) return BadRequest();

        return View(new IsiNilaiVM
        {
            Id = id,
            EvaluasiSiswa = evaluasiSiswa,
            DaftarIsiNilaiEntry = evaluasiSiswa
                .DaftarNilaiEvaluasiSiswa
                .Select(e => new IsiNilaiEntryVM { IdAnggotaRombel = e.IdAnggotaRombel, NamaSiswa = e.AnggotaRombel.Siswa.Nama, Nilai = e.Nilai })
                .ToList()
        });
    }

    [HttpPost]
    public async Task<IActionResult> IsiNilai(IsiNilaiVM vm)
    {
        var pegawai = await _signInManager.GetPegawai();
        if (pegawai is null) return Forbid();

        var evaluasiSiswa = await _evaluasiSiswaRepository.Get(vm.Id);
        if (evaluasiSiswa is null) return NotFound();
        if (evaluasiSiswa.JadwalMengajar.Rombel.Wali != pegawai) return BadRequest();

        foreach (var entry in vm.DaftarIsiNilaiEntry)
        {
            var nilaiEvaluasiSiswa = evaluasiSiswa.DaftarNilaiEvaluasiSiswa.FirstOrDefault(e => e.IdAnggotaRombel == entry.IdAnggotaRombel);

            if (nilaiEvaluasiSiswa is not null)
            {
                nilaiEvaluasiSiswa.Nilai = entry.Nilai;
                _nilaiEvaluasiSiswaRepository.Update(nilaiEvaluasiSiswa);
            }
        }

        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
            _toastrNotificationService.AddError("Simpan Gagal!");
        else
            _toastrNotificationService.AddSuccess("Simpan Berhasil!");

        return RedirectToAction(nameof(IsiNilai), new {id = vm.Id});
    }
}
