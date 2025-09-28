using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIAkademik.Domain.Abstracts;
using SIAkademik.Domain.Authentication;
using SIAkademik.Domain.ModulSiakad.Entities;
using SIAkademik.Domain.ModulSiakad.Repositories;
using SIAkademik.Web.Areas.DashboardGuru.Models.NilaiModels;
using SIAkademik.Web.Authentication;
using SIAkademik.Web.Services.Toastr;

namespace SIAkademik.Web.Areas.DashboardGuru.Controllers;

[Area(AreaNames.DashboardGuru)]
[Authorize(Roles = AppUserRoles.Guru)]
public class NilaiController : Controller
{
    private readonly INilaiRepository _nilaiRepository;
    private readonly IJadwalMengajarRepository _jadwalMengajarRepository;
    private readonly ITahunAjaranRepository _tahunAjaranRepository;
    private readonly ISignInManager _signInManager;
    private readonly IPegawaiRepository _pegawaiRepository;
    private readonly ISiswaRepository _siswaRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IToastrNotificationService _toastrNotificationService;

    public NilaiController(
        INilaiRepository nilaiRepository,
        IJadwalMengajarRepository jadwalMengajarRepository,
        ITahunAjaranRepository tahunAjaranRepository,
        ISignInManager signInManager,
        IPegawaiRepository pegawaiRepository,
        ISiswaRepository siswaRepository,
        IUnitOfWork unitOfWork,
        IToastrNotificationService toastrNotificationService)
    {
        _nilaiRepository = nilaiRepository;
        _jadwalMengajarRepository = jadwalMengajarRepository;
        _tahunAjaranRepository = tahunAjaranRepository;
        _signInManager = signInManager;
        _pegawaiRepository = pegawaiRepository;
        _siswaRepository = siswaRepository;
        _unitOfWork = unitOfWork;
        _toastrNotificationService = toastrNotificationService;
    }

    public async Task<IActionResult> Index(int? idTahunAjaran = null, int? idJadwalMengajar = null)
    {
        var pegawai = await _signInManager.GetPegawai();
        if (pegawai is null) return Forbid();
        pegawai = (await _pegawaiRepository.Get(pegawai.Id))!;

        var tahunAjaran = idTahunAjaran is null ?
            await _tahunAjaranRepository.GetNewest() :
            await _tahunAjaranRepository.Get(idTahunAjaran.Value);

        if (tahunAjaran is null) return View(new IndexVM());

        var daftarJadwal = pegawai.DaftarJadwalMengajar
            .Where(j => j.Rombel.Kelas.TahunAjaran == tahunAjaran)
            .ToList();

        if (idJadwalMengajar is null) return View(new IndexVM { TahunAjaran = tahunAjaran, DaftarJadwalMengajar = daftarJadwal });

        var jadwalMengajar = await _jadwalMengajarRepository.Get(idJadwalMengajar.Value);
        if (jadwalMengajar is null || !daftarJadwal.Contains(jadwalMengajar)) 
            return View(new IndexVM { TahunAjaran = tahunAjaran, DaftarJadwalMengajar = daftarJadwal });

        return View(new IndexVM { TahunAjaran = tahunAjaran, DaftarJadwalMengajar = daftarJadwal, JadwalMengajar = jadwalMengajar });
    }

    public async Task<IActionResult> Detail(int idJadwalMengajar, int idSiswa)
    {
        var pegawai = await _signInManager.GetPegawai();
        if (pegawai is null) return Forbid();
        pegawai = (await _pegawaiRepository.Get(pegawai.Id))!;

        var jadwalMengajar = await _jadwalMengajarRepository.Get(idJadwalMengajar);
        if (jadwalMengajar is null) return NotFound();

        if (!pegawai.DaftarJadwalMengajar.Contains(jadwalMengajar)) return Forbid();

        var siswa = await _siswaRepository.Get(idSiswa);
        if (siswa is null) return NotFound();

        var anggotaRombel = jadwalMengajar.Rombel.DaftarAnggotaRombel.FirstOrDefault(a => a.Siswa == siswa);
        if (anggotaRombel is null) return NotFound();

        return View(new DetailVM 
        { 
            DaftarNilai = anggotaRombel.DaftarNilai.Where(n => n.JadwalMengajar == jadwalMengajar).ToList(),
            JadwalMengajar = jadwalMengajar,
            Siswa = siswa
        });
    }

    public async Task<IActionResult> Tambah(int idSiswa, int idJadwalMengajar)
    {
        var pegawai = await _signInManager.GetPegawai();
        if (pegawai is null) return Forbid();
        pegawai = (await _pegawaiRepository.Get(pegawai.Id))!;

        var jadwalMengajar = await _jadwalMengajarRepository.Get(idJadwalMengajar);
        if (jadwalMengajar is null) return NotFound();

        if (!pegawai.DaftarJadwalMengajar.Contains(jadwalMengajar)) return BadRequest();

        var siswa = await _siswaRepository.Get(idSiswa);
        if (siswa is null) return NotFound();
        if (!siswa.DaftarAnggotaRombel.Any(a => a.Rombel == jadwalMengajar.Rombel))
            return BadRequest();

        return View(new TambahVM
        {
            IdSiswa = idSiswa,
            IdJadwalMengajar = idJadwalMengajar
        });
    }

    [HttpPost]
    public async Task<IActionResult> Tambah(TambahVM vm)
    {
        if (!ModelState.IsValid) return View(vm);

        var pegawai = await _signInManager.GetPegawai();
        if (pegawai is null) return Forbid();
        pegawai = (await _pegawaiRepository.Get(pegawai.Id))!;

        var jadwalMengajar = await _jadwalMengajarRepository.Get(vm.IdJadwalMengajar);
        if (jadwalMengajar is null) return NotFound();

        if (!pegawai.DaftarJadwalMengajar.Contains(jadwalMengajar)) return BadRequest();

        var siswa = await _siswaRepository.Get(vm.IdSiswa);
        if (siswa is null) return NotFound();

        var anggotaRombel = siswa.DaftarAnggotaRombel.FirstOrDefault(a => a.Rombel == jadwalMengajar.Rombel);
        if (anggotaRombel is null) return BadRequest();

        var nilai = new Nilai
        {
            Deskripsi = vm.Deskripsi,
            Jenis = vm.Jenis,
            Skor = vm.Skor,
            JadwalMengajar = jadwalMengajar,
            AnggotaRombel = anggotaRombel
        };

        _nilaiRepository.Add(nilai);
        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
        {
            ModelState.AddModelError(string.Empty, "Simpan Gagal!");
            return View(vm);
        }

        _toastrNotificationService.AddSuccess("Nilai baru berhasil ditambahkan!");
        return RedirectToAction(nameof(Detail), new { idJadwalMengajar = jadwalMengajar.Id, idSiswa = siswa.Id });
    }

    public async Task<IActionResult> Edit(int id)
    {
        var nilai = await _nilaiRepository.Get(id);
        if (nilai is null) return NotFound();

        var pegawai = await _signInManager.GetPegawai();
        if (pegawai is null) return Forbid();
        pegawai = (await _pegawaiRepository.Get(pegawai.Id))!;

        if (!pegawai.DaftarJadwalMengajar.Contains(nilai.JadwalMengajar))
            return Forbid();

        return View(new EditVM
        {
            Id = nilai.Id,
            Deskripsi = nilai.Deskripsi,
            Jenis = nilai.Jenis,
            Skor = nilai.Skor
        });
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EditVM vm)
    {
        if (!ModelState.IsValid) return View(vm);

        var nilai = await _nilaiRepository.Get(vm.Id);
        if (nilai is null) return NotFound();

        var pegawai = await _signInManager.GetPegawai();
        if (pegawai is null) return Forbid();
        pegawai = (await _pegawaiRepository.Get(pegawai.Id))!;

        if (!pegawai.DaftarJadwalMengajar.Contains(nilai.JadwalMengajar))
            return Forbid();

        nilai.Deskripsi = vm.Deskripsi;
        nilai.Jenis = vm.Jenis;
        nilai.Skor = vm.Skor;

        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
        {
            ModelState.AddModelError(string.Empty, "Simpan Gagal!");
            return View(vm);
        }

        _toastrNotificationService.AddSuccess("Nilai berhasil diubah!");
        return RedirectToAction(
            nameof(Detail),
            new { idJadwalMengajar = nilai.JadwalMengajar.Id, idSiswa = nilai.AnggotaRombel.Siswa.Id });
    }

    [HttpPost]
    public async Task<IActionResult> Hapus(int id)
    {
        var nilai = await _nilaiRepository.Get(id);
        if (nilai is null) return NotFound();

        var pegawai = await _signInManager.GetPegawai();
        if (pegawai is null) return Forbid();
        pegawai = (await _pegawaiRepository.Get(pegawai.Id))!;

        if (!pegawai.DaftarJadwalMengajar.Contains(nilai.JadwalMengajar))
            return Forbid();

        _nilaiRepository.Delete(nilai);
        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
            _toastrNotificationService.AddError("Hapus Gagal!");
        else
            _toastrNotificationService.AddSuccess("Hapus Berhasil!");

        return RedirectToAction(
            nameof(Detail),
            new { idJadwalMengajar = nilai.JadwalMengajar.Id, idSiswa = nilai.AnggotaRombel.Siswa.Id });
    }
}
