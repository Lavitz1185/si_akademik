using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIAkademik.Domain.Abstracts;
using SIAkademik.Domain.Authentication;
using SIAkademik.Domain.ModulSiakad.Entities;
using SIAkademik.Domain.ModulSiakad.Repositories;
using SIAkademik.Web.Areas.DashboardAdmin.Models.JadwalMengajarModels;
using SIAkademik.Web.Services.Toastr;

namespace SIAkademik.Web.Areas.DashboardAdmin.Controllers;

[Area(AreaNames.DashboardAdmin)]
[Authorize(Roles = AppUserRoles.Admin)]
public class JadwalMengajarController : Controller
{
    private readonly IJadwalMengajarRepository _jadwalMengajarRepository;
    private readonly ITahunAjaranRepository _tahunAjaranRepository;
    private readonly IMataPelajaranRepository _mataPelajaranRepository;
    private readonly IRombelRepository _rombelRepository;
    private readonly IPegawaiRepository _pegawaiRepository;
    private readonly IHariMengajarRepository _hariMengajarRepository;
    private readonly IPertemuanRepository _pertemuanRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IToastrNotificationService _toastrNotificationService;

    public JadwalMengajarController(
        IJadwalMengajarRepository jadwalMengajarRepository,
        ITahunAjaranRepository tahunAjaranRepository,
        IMataPelajaranRepository mataPelajaranRepository,
        IPegawaiRepository pegawaiRepository,
        IUnitOfWork unitOfWork,
        IToastrNotificationService toastrNotificationService,
        IRombelRepository rombelRepository,
        IHariMengajarRepository hariMengajarRepository,
        IPertemuanRepository pertemuanRepository)
    {
        _jadwalMengajarRepository = jadwalMengajarRepository;
        _tahunAjaranRepository = tahunAjaranRepository;
        _mataPelajaranRepository = mataPelajaranRepository;
        _pegawaiRepository = pegawaiRepository;
        _unitOfWork = unitOfWork;
        _toastrNotificationService = toastrNotificationService;
        _rombelRepository = rombelRepository;
        _hariMengajarRepository = hariMengajarRepository;
        _pertemuanRepository = pertemuanRepository;
    }

    public async Task<IActionResult> Index(int? idTahunAjaran = null, int? idRombel = null)
    {
        var tahunAjaran = idTahunAjaran is not null ?
            await _tahunAjaranRepository.Get(idTahunAjaran.Value) :
            await _tahunAjaranRepository.GetNewest();

        if (tahunAjaran is null) return View(new IndexVM());

        var daftarJadwal = await _jadwalMengajarRepository.GetAllByTahunAjaran(tahunAjaran.Id);

        var rombel = await _rombelRepository.Get(idRombel ?? 0);
        if (rombel is null || rombel.Kelas.TahunAjaran != tahunAjaran)
            return View(new IndexVM { DaftarJadwalMengajar = daftarJadwal, TahunAjaran = tahunAjaran, IdTahunAjaran = tahunAjaran.Id });

        return View(new IndexVM
        {
            TahunAjaran = tahunAjaran,
            IdTahunAjaran = tahunAjaran.Id,
            IdRombel = rombel.Id,
            DaftarJadwalMengajar = daftarJadwal.Where(j => j.Rombel == rombel).ToList(),
        });
    }

    public async Task<IActionResult> Tambah(int idTahunAjaran)
    {
        var tahunAjaran = await _tahunAjaranRepository.Get(idTahunAjaran);
        if (tahunAjaran is null) return NotFound();

        return View(new TambahVM { IdTahunAjaran = tahunAjaran.Id });
    }

    [HttpPost]
    public async Task<IActionResult> Tambah(TambahVM vm)
    {
        if (!ModelState.IsValid) return View(vm);

        var mataPelajaran = await _mataPelajaranRepository.Get(vm.IdMataPelajaran);
        if (mataPelajaran is null)
        {
            ModelState.AddModelError(nameof(TambahVM.IdMataPelajaran), "Mata Pelajaran tidak ditemukan");
            return View(vm);
        }

        var rombel = await _rombelRepository.Get(vm.IdRombel);
        if (rombel is null)
        {
            ModelState.AddModelError(nameof(TambahVM.IdRombel), "Rombel tidak ditemukan");
            return View(vm);
        }

        var pegawai = await _pegawaiRepository.Get(vm.NIPPegawai);
        if (pegawai is null)
        {
            ModelState.AddModelError(nameof(TambahVM.NIPPegawai), "Pegawai tidak ditemukan");
            return View(vm);
        }

        if (await _jadwalMengajarRepository.IsExist(mataPelajaran.Id, rombel.Id, pegawai.Id))
        {
            ModelState.AddModelError(string.Empty, $"Jadwal mata pelajaran {mataPelajaran.Nama} untuk rombel {rombel.Kelas.Jenjang.Humanize()}" +
                $" {rombel.Kelas.Peminatan.Nama} {rombel.Nama} dengan guru {pegawai.Nama} sudah ada!");

            return View(vm);
        }

        var jadwalMengajar = new JadwalMengajar
        {
            MataPelajaran = mataPelajaran,
            Pegawai = pegawai,
            Rombel = rombel
        };

        var daftarPertemuan = Enumerable.Range(1, vm.JumlahPertemuan)
            .Select(i => new Pertemuan
            {
                Nomor = i,
                JadwalMengajar = jadwalMengajar,
                StatusPertemuan = StatusPertemuan.BelumMulai
            }).ToList();

        jadwalMengajar.DaftarPertemuan = daftarPertemuan;

        _jadwalMengajarRepository.Add(jadwalMengajar);

        foreach (var pertemuan in daftarPertemuan) _pertemuanRepository.Add(pertemuan);

        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
        {
            ModelState.AddModelError(string.Empty, "Simpan gagal!");
            return View(vm);
        }

        _toastrNotificationService.AddSuccess("Jadwal mengajar berhasil ditambahkan!");
        return RedirectToAction(nameof(Index), new { idTahunAjaran = vm.IdTahunAjaran });
    }

    public async Task<IActionResult> Edit(int id)
    {
        var jadwalMengajar = await _jadwalMengajarRepository.Get(id);
        if (jadwalMengajar is null) return NotFound();

        return View(new EditVM
        {
            Id = jadwalMengajar.Id,
            IdMataPelajaran = jadwalMengajar.MataPelajaran.Id,
            IdRombel = jadwalMengajar.Rombel.Id,
            NIPPegawai = jadwalMengajar.Pegawai.Id,
            IdTahunAjaran = jadwalMengajar.Rombel.Kelas.TahunAjaran.Id,
        });
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EditVM vm)
    {
        if (!ModelState.IsValid) return View(vm);

        var jadwalMengajar = await _jadwalMengajarRepository.Get(vm.Id);
        if (jadwalMengajar is null) return NotFound();

        var mataPelajaran = await _mataPelajaranRepository.Get(vm.IdMataPelajaran);
        if (mataPelajaran is null)
        {
            ModelState.AddModelError(nameof(TambahVM.IdMataPelajaran), "Mata Pelajaran tidak ditemukan");
            return View(vm);
        }

        var rombel = await _rombelRepository.Get(vm.IdRombel);
        if (rombel is null)
        {
            ModelState.AddModelError(nameof(TambahVM.IdRombel), "Rombel tidak ditemukan");
            return View(vm);
        }

        var pegawai = await _pegawaiRepository.Get(vm.NIPPegawai);
        if (pegawai is null)
        {
            ModelState.AddModelError(nameof(TambahVM.NIPPegawai), "Pegawai tidak ditemukan");
            return View(vm);
        }

        if (await _jadwalMengajarRepository.IsExist(mataPelajaran.Id, rombel.Id, pegawai.Id, jadwalMengajar.Id))
        {
            ModelState.AddModelError(string.Empty, $"Jadwal mata pelajaran {mataPelajaran.Nama} untuk rombel {rombel.Kelas.Jenjang.Humanize()}" +
                $" {rombel.Kelas.Peminatan.Nama} {rombel.Nama} dengan guru {pegawai.Nama} sudah ada!");

            return View(vm);
        }

        jadwalMengajar.MataPelajaran = mataPelajaran;
        jadwalMengajar.Rombel = rombel;
        jadwalMengajar.Pegawai = pegawai;

        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
        {
            ModelState.AddModelError(string.Empty, "Simpan gagal!");
            return View(vm);
        }

        _toastrNotificationService.AddSuccess("Jadwal mengajar berhasil diubah!");
        return RedirectToAction(nameof(Index), new { idTahunAjaran = vm.IdTahunAjaran });
    }

    [HttpPost]
    public async Task<IActionResult> Hapus(int id)
    {
        var jadwalMengajar = await _jadwalMengajarRepository.Get(id);
        if (jadwalMengajar is null) return NotFound();

        var idTahunAjaran = jadwalMengajar.Rombel.Kelas.TahunAjaran.Id;

        _jadwalMengajarRepository.Delete(jadwalMengajar);
        var result = await _unitOfWork.SaveChangesAsync();

        if (result.IsFailure)
            _toastrNotificationService.AddError("Jadwal mengajar gagal dihapus!");
        else
            _toastrNotificationService.AddSuccess("Jadwal mengajar berhasil dihapus!");

        return RedirectToAction(nameof(Index), new { idTahunAjaran });
    }

    public async Task<IActionResult> TambahHari(int id) 
    {
        var jadwalMengajar = await _jadwalMengajarRepository.Get(id);
        if (jadwalMengajar is null) return NotFound();

        return View(new TambahHariVM { IdJadwalMengajar = jadwalMengajar.Id });
    }

    [HttpPost]
    public async Task<IActionResult> TambahHari(TambahHariVM vm)
    {
        if (!ModelState.IsValid) return View(vm);

        var jadwalMengajar = await _jadwalMengajarRepository.Get(vm.IdJadwalMengajar);
        if (jadwalMengajar is null) return NotFound();

        var hariMengajar = new HariMengajar
        {
            Hari = vm.Hari,
            JamMulai = vm.JamMulai,
            JamAkhir = vm.JamAkhir,
            JadwalMengajar = jadwalMengajar
        };

        _hariMengajarRepository.Add(hariMengajar);
        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
        {
            ModelState.AddModelError(string.Empty, "Simpan gagal!");
            return View(vm);
        }

        _toastrNotificationService.AddSuccess("Hari mengajar berhasil ditambahkan!");
        return RedirectToAction(nameof(Index), new { idTahunAjaran = jadwalMengajar.Rombel.Kelas.TahunAjaran.Id });
    }

    public async Task<IActionResult> EditHari(int id, int idHariMengajar)
    {
        var jadwalMengajar = await _jadwalMengajarRepository.Get(id);
        if (jadwalMengajar is null) return NotFound();

        var hariMengajar = jadwalMengajar.DaftarHariMengajar.FirstOrDefault(h => h.Id == idHariMengajar);
        if (hariMengajar is null) return NotFound();

        return View(new EditHariVM
        {
            IdHariMengajar = hariMengajar.Id,
            IdJadwalMengajar = jadwalMengajar.Id,
            Hari = hariMengajar.Hari,
            JamMulai = hariMengajar.JamMulai,
            JamAkhir = hariMengajar.JamAkhir
        });
    }

    [HttpPost]
    public async Task<IActionResult> EditHari(EditHariVM vm)
    {
        if (!ModelState.IsValid) return View(vm);

        var jadwalMengajar = await _jadwalMengajarRepository.Get(vm.IdJadwalMengajar);
        if (jadwalMengajar is null) return NotFound();

        var hariMengajar = jadwalMengajar.DaftarHariMengajar.FirstOrDefault(h => h.Id == vm.IdHariMengajar);
        if (hariMengajar is null) return NotFound();

        hariMengajar.Hari = vm.Hari;
        hariMengajar.JamMulai = vm.JamMulai;
        hariMengajar.JamAkhir = vm.JamAkhir;

        _hariMengajarRepository.Update(hariMengajar);
        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
        {
            ModelState.AddModelError(string.Empty, "Simpan gagal!");
            return View(vm);
        }

        _toastrNotificationService.AddSuccess("Hari mengajar berhasil diubah!");
        return RedirectToAction(nameof(Index), new { idTahunAjaran = jadwalMengajar.Rombel.Kelas.TahunAjaran.Id });
    }

    [HttpPost]
    public async Task<IActionResult> HapusHari(int id, int idHariMengajar)
    {
        var jadwalMengajar = await _jadwalMengajarRepository.Get(id);
        if (jadwalMengajar is null) return NotFound();

        var hariMengajar = jadwalMengajar.DaftarHariMengajar.FirstOrDefault(h => h.Id == idHariMengajar);
        if (hariMengajar is null) return NotFound();

        _hariMengajarRepository.Delete(hariMengajar);
        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
            _toastrNotificationService.AddError("Hapus Gagal!");
        else
            _toastrNotificationService.AddSuccess("Hapus Berhasil!");

        return RedirectToAction(nameof(Index), new { idTahunAjaran = jadwalMengajar.Rombel.Kelas.TahunAjaran.Id });
    }
}
