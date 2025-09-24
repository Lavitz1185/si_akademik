using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIAkademik.Domain.Abstracts;
using SIAkademik.Domain.Authentication;
using SIAkademik.Domain.ModulSiakad.Entities;
using SIAkademik.Domain.ModulSiakad.Repositories;
using SIAkademik.Web.Areas.DashboardAdmin.Models.JadwalMengajarModels;
using SIAkademik.Web.Services.Toastr;
using System.Threading.Tasks;

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
    private readonly IUnitOfWork _unitOfWork;
    private readonly IToastrNotificationService _toastrNotificationService;

    public JadwalMengajarController(
        IJadwalMengajarRepository jadwalMengajarRepository,
        ITahunAjaranRepository tahunAjaranRepository,
        IMataPelajaranRepository mataPelajaranRepository,
        IPegawaiRepository pegawaiRepository,
        IUnitOfWork unitOfWork,
        IToastrNotificationService toastrNotificationService,
        IRombelRepository rombelRepository)
    {
        _jadwalMengajarRepository = jadwalMengajarRepository;
        _tahunAjaranRepository = tahunAjaranRepository;
        _mataPelajaranRepository = mataPelajaranRepository;
        _pegawaiRepository = pegawaiRepository;
        _unitOfWork = unitOfWork;
        _toastrNotificationService = toastrNotificationService;
        _rombelRepository = rombelRepository;
    }

    public async Task<IActionResult> Index(int? idTahunAjaran = null)
    {
        var tahunAjaran = idTahunAjaran is not null ?
            await _tahunAjaranRepository.Get(idTahunAjaran.Value) :
            (await _tahunAjaranRepository.GetAll()).OrderBy(t => t.Id).FirstOrDefault();

        if (tahunAjaran is null) return View(new IndexVM());

        var daftarJadwal = await _jadwalMengajarRepository.GetAllByTahunAjaran(tahunAjaran.Id);

        return View(new IndexVM { DaftarJadwalMengajar = daftarJadwal, TahunAjaran = tahunAjaran });
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
                $" {rombel.Kelas.Peminatan.Humanize()} {rombel.Nama} dengan guru {pegawai.Nama} sudah ada1!");

            return View(vm);
        }

        var jadwalMengajar = new JadwalMengajar
        {
            MataPelajaran = mataPelajaran,
            Pegawai = pegawai,
            Rombel = rombel
        };

        mataPelajaran.DaftarJadwalMengajar.Add(jadwalMengajar);
        pegawai.DaftarJadwalMengajar.Add(jadwalMengajar);
        rombel.DaftarJadwalMengajar.Add(jadwalMengajar);

        _jadwalMengajarRepository.Add(jadwalMengajar);
        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
        {
            ModelState.AddModelError(string.Empty, "Simpan gagal!");
            return View(vm);
        }

        _toastrNotificationService.AddSuccess("Jadwal mengajar berhasil ditambahkan!");
        return RedirectToAction(nameof(Index), new { idTahunAjaran = vm.IdTahunAjaran });
    }
}
