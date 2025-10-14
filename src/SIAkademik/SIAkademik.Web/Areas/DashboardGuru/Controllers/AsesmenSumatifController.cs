using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIAkademik.Domain.Abstracts;
using SIAkademik.Domain.Authentication;
using SIAkademik.Domain.ModulSiakad.Entities;
using SIAkademik.Domain.ModulSiakad.Repositories;
using SIAkademik.Web.Areas.DashboardGuru.Models.AsesmenSumatifModels;
using SIAkademik.Web.Authentication;
using SIAkademik.Web.Services.Toastr;

namespace SIAkademik.Web.Areas.DashboardGuru.Controllers;

[Area(AreaNames.DashboardGuru)]
[Authorize(Roles = AppUserRoles.Guru)]
public class AsesmenSumatifController : Controller
{
    private readonly IAsesmenSumatifRepository _asesmenSumatifRepository;
    private readonly IJadwalMengajarRepository _jadwalMengajarRepository;
    private readonly ITujuanPembelajaranRepository _tujuanPembelajaranRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IToastrNotificationService _toastrNotificationService;
    private readonly ISignInManager _signInManager;
    private readonly ITahunAjaranRepository _tahunAjaranRepository;
    private readonly IEvaluasiSiswaRepository _evalasiSiswaRepository;
    private readonly INilaiEvaluasiSiswaRepository _nilaiEvaluasiSiswaRepository;
    private readonly IRombelRepository _rombelRepository;

    public AsesmenSumatifController(
        IAsesmenSumatifRepository asesmenSumatifRepository,
        IJadwalMengajarRepository jadwalMengajarRepository,
        ITujuanPembelajaranRepository tujuanPembelajaranRepository,
        IUnitOfWork unitOfWork,
        IToastrNotificationService toastrNotificationService,
        ISignInManager signInManager,
        ITahunAjaranRepository tahunAjaranRepository,
        IEvaluasiSiswaRepository evalasiSiswaRepository,
        INilaiEvaluasiSiswaRepository nilaiEvaluasiSiswaRepository,
        IRombelRepository rombelRepository)
    {
        _asesmenSumatifRepository = asesmenSumatifRepository;
        _jadwalMengajarRepository = jadwalMengajarRepository;
        _tujuanPembelajaranRepository = tujuanPembelajaranRepository;
        _unitOfWork = unitOfWork;
        _toastrNotificationService = toastrNotificationService;
        _signInManager = signInManager;
        _tahunAjaranRepository = tahunAjaranRepository;
        _evalasiSiswaRepository = evalasiSiswaRepository;
        _nilaiEvaluasiSiswaRepository = nilaiEvaluasiSiswaRepository;
        _rombelRepository = rombelRepository;
    }

    [HttpPost]
    public async Task<IActionResult> Tambah(TambahVM vm)
    {
        var pegawai = await _signInManager.GetPegawai();
        if (pegawai is null) return Forbid();

        var jadwalMengajar = await _jadwalMengajarRepository.Get(vm.IdJadwalMengajar);
        if (jadwalMengajar is null) return NotFound();

        if (jadwalMengajar.Pegawai != pegawai) return Forbid();

        if (!ModelState.IsValid)
        {
            _toastrNotificationService.AddError("Data tidak valid", "Tambah Target Capaian TP");
            return RedirectToAction("Detail", "JadwalMengajar", new { id = vm.IdJadwalMengajar });
        }

        var tujuanPembelajaran = await _tujuanPembelajaranRepository.Get(vm.IdTujuanPembelajaran);
        if (tujuanPembelajaran is null)
        {
            _toastrNotificationService.AddError("Tujuan Pembelajaran tidak ditemukan", "Tambah Target Capaian TP");
            return RedirectToAction("Detail", "JadwalMengajar", new { id = vm.IdJadwalMengajar });
        }

        if (jadwalMengajar.DaftarAsesmenSumatif.Any(a => a.TujuanPembelajaran == tujuanPembelajaran))
        {
            _toastrNotificationService.AddError("Tujuan Pembelajaran sudah ada untuk kelas ini", "Tambah Target Capaian TP");
            return RedirectToAction("Detail", "JadwalMengajar", new { id = vm.IdJadwalMengajar });
        }

        var asesmenSumatif = new AsesmenSumatif
        {
            IdJadwalMengajar = jadwalMengajar.Id,
            IdTujuanPembelajaran = tujuanPembelajaran.Id,
            JadwalMengajar = jadwalMengajar,
            TujuanPembelajaran = tujuanPembelajaran,
            BatasBawahCukup = vm.BatasBawahCukup,
            BatasBawahBaik = vm.BatasBawahBaik,
            BatasBawahSangatBaik = vm.BatasBawahSangatBaik
        };

        _asesmenSumatifRepository.Add(asesmenSumatif);
        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
            _toastrNotificationService.AddError("Simpan Gagal!", "Tambah Target Capaian TP");
        else
            _toastrNotificationService.AddSuccess("Simpan Berhasil!", "Tambah Target Capaian TP");

        return RedirectToAction("Detail", "JadwalMengajar", new { id = vm.IdJadwalMengajar });
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EditVM vm)
    {
        var pegawai = await _signInManager.GetPegawai();
        if (pegawai is null) return Forbid();

        var jadwalMengajar = await _jadwalMengajarRepository.Get(vm.Id);
        if (jadwalMengajar is null) return NotFound();

        if (jadwalMengajar.Pegawai != pegawai) return Forbid();

        if (!ModelState.IsValid)
        {
            _toastrNotificationService.AddError("Data tidak valid", "Edit Target Capaian TP");
            return RedirectToAction("Detail", "JadwalMengajar", new { id = vm.IdJadwalMengajar });
        }

        var asesmenSumatif = await _asesmenSumatifRepository.Get(vm.Id);
        if (asesmenSumatif is null)
        {
            _toastrNotificationService.AddError("Asesmen Sumatif tidak ditemukan", "Edit Target Capaian TP");
            return RedirectToAction("Detail", "JadwalMengajar", new { id = vm.IdJadwalMengajar });
        }

        asesmenSumatif.BatasBawahCukup = vm.BatasBawahCukup;
        asesmenSumatif.BatasBawahBaik = vm.BatasBawahBaik;
        asesmenSumatif.BatasBawahSangatBaik = vm.BatasBawahSangatBaik;

        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
            _toastrNotificationService.AddError("Simpan Gagal!", "Edit Target Capaian TP");
        else
            _toastrNotificationService.AddSuccess("Simpan Berhasil!", "Edit Target Capaian TP");

        return RedirectToAction("Detail", "JadwalMengajar", new { id = vm.IdJadwalMengajar });
    }

    [HttpPost]
    public async Task<IActionResult> Hapus(int id, int idJadwalMengajar)
    {
        var pegawai = await _signInManager.GetPegawai();
        if (pegawai is null) return Forbid();

        var jadwalMengajar = await _jadwalMengajarRepository.Get(idJadwalMengajar);
        if (jadwalMengajar is null) return NotFound();

        if (jadwalMengajar.Pegawai != pegawai) return Forbid();

        var asesmenSumatif = await _asesmenSumatifRepository.Get(id);
        if (asesmenSumatif is null)
        {
            _toastrNotificationService.AddError("Asesmen Sumatif tidak ditemukan", "Hapus Target Capaian TP");
            return RedirectToAction("Detail", "JadwalMengajar", new { id = idJadwalMengajar });
        }

        _asesmenSumatifRepository.Delete(asesmenSumatif);
        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
            _toastrNotificationService.AddError("Simpan Gagal!", "Hapus Target Capaian TP");
        else
            _toastrNotificationService.AddSuccess("Simpan Sukses!", "Hapus Target Capaian TP");

        return RedirectToAction("Detail", "JadwalMengajar", new { id = idJadwalMengajar });
    }

    public async Task<IActionResult> Index(int? idTahunAjaran = null, int? idJadwalMengajar = null, int? idAsesmenSumatif = null)
    {
        var pegawai = await _signInManager.GetPegawai();
        if (pegawai is null) return Forbid();

        var tahunAjaran = idTahunAjaran is null ?
            await _tahunAjaranRepository.GetNewest() :
            await _tahunAjaranRepository.Get(idTahunAjaran.Value);

        if (tahunAjaran is null) return View(new IndexVM { Pegawai = pegawai });

        var jadwalMengajar = idJadwalMengajar is null ?
            (await _jadwalMengajarRepository.GetAllByTahunAjaran(tahunAjaran.Id)).FirstOrDefault(j => j.Pegawai == pegawai) :
            await _jadwalMengajarRepository.Get(idJadwalMengajar.Value);

        if (jadwalMengajar is null || jadwalMengajar.Pegawai != pegawai || jadwalMengajar.Rombel.Kelas.TahunAjaran != tahunAjaran)
            return View(new IndexVM { Pegawai = pegawai, TahunAjaran = tahunAjaran, IdTahunAjaran = tahunAjaran.Id });

        var asesmenSumatif = idAsesmenSumatif is null ?
            null :
            await _asesmenSumatifRepository.Get(idAsesmenSumatif.Value);

        if (asesmenSumatif is null || asesmenSumatif.JadwalMengajar != jadwalMengajar)
            return View(new IndexVM
            {
                Pegawai = pegawai,
                TahunAjaran = tahunAjaran,
                IdTahunAjaran = tahunAjaran.Id,
                JadwalMengajar = jadwalMengajar,
                IdJadwalMengajar = jadwalMengajar.Id
            });

        return View(new IndexVM
        {
            Pegawai = pegawai,
            IdTahunAjaran = tahunAjaran.Id,
            IdJadwalMengajar = jadwalMengajar.Id,
            IdAsesmenSumatif = asesmenSumatif.Id,
            TahunAjaran = tahunAjaran,
            JadwalMengajar = jadwalMengajar,
            AsesmenSumatif = asesmenSumatif
        });
    }

    public async Task<IActionResult> Detail(int idEvaluasiSiswa)
    {
        var pegawai = await _signInManager.GetPegawai();
        if (pegawai is null) return Forbid();

        var evaluasiSiswa = await _evalasiSiswaRepository.Get(idEvaluasiSiswa);
        if (evaluasiSiswa is null) return NotFound();

        if (evaluasiSiswa.AsesmenSumatif.JadwalMengajar.Pegawai != pegawai) return Forbid();

        var rombel = (await _rombelRepository.Get(evaluasiSiswa.AsesmenSumatif.JadwalMengajar.Rombel.Id))!;
        foreach (var anggotaRombel in rombel.DaftarAnggotaRombel)
        {
            if (!evaluasiSiswa.DaftarNilaiEvaluasiSiswa.Any(n => n.AnggotaRombel == anggotaRombel))
            {
                var nilaiEvaluasiSiswa = new NilaiEvaluasiSiswa
                {
                    AnggotaRombel = anggotaRombel,
                    EvaluasiSiswa = evaluasiSiswa,
                    Nilai = 0
                };

                _nilaiEvaluasiSiswaRepository.Add(nilaiEvaluasiSiswa);
            }
        }

        await _unitOfWork.SaveChangesAsync();

        return View(new DetailVM
        {
            AsesmenSumatif = (await _asesmenSumatifRepository.Get(evaluasiSiswa.AsesmenSumatif.Id))!,
            EvaluasiSiswa = evaluasiSiswa,
            IdEvaluasiSiswa = idEvaluasiSiswa,
            DaftarDetailEntryVM = evaluasiSiswa
                .DaftarNilaiEvaluasiSiswa
                .Select(n => new DetailEntryVM { IdAnggotaRombel = n.AnggotaRombel.Id, Nama = n.AnggotaRombel.Siswa.Nama, Nilai = n.Nilai })
                .ToList()
        });
    }

    [HttpPost]
    public async Task<IActionResult> SimpanNilai(DetailVM vm)
    {
        var pegawai = await _signInManager.GetPegawai();
        if (pegawai is null) return Forbid();

        var evaluasiSiswa = await _evalasiSiswaRepository.Get(vm.IdEvaluasiSiswa);
        if (evaluasiSiswa is null) return NotFound();

        if (evaluasiSiswa.AsesmenSumatif.JadwalMengajar.Pegawai != pegawai) return Forbid();

        foreach (var entry in vm.DaftarDetailEntryVM)
        {
            var nilaiEvaluasiSiswa = evaluasiSiswa.DaftarNilaiEvaluasiSiswa.FirstOrDefault(n => n.IdAnggotaRombel == entry.IdAnggotaRombel);
            if (nilaiEvaluasiSiswa is not null)
                nilaiEvaluasiSiswa.Nilai = entry.Nilai;
        }

        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
            _toastrNotificationService.AddError("Simpan Gagal!");
        else
            _toastrNotificationService.AddSuccess("Simpan Berhasil");

        return RedirectToAction(nameof(Detail), new { idEvaluasiSiswa = vm.IdEvaluasiSiswa });
    }
}
