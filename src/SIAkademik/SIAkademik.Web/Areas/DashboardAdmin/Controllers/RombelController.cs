
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIAkademik.Domain.Abstracts;
using SIAkademik.Domain.Authentication;
using SIAkademik.Domain.ModulSiakad.Entities;
using SIAkademik.Domain.ModulSiakad.Repositories;
using SIAkademik.Web.Areas.DashboardAdmin.Models.RombelModels;
using SIAkademik.Web.Services.Toastr;

namespace SIAkademik.Web.Areas.DashboardAdmin.Controllers;

[Area(AreaNames.DashboardAdmin)]
[Authorize(Roles = AppUserRoles.Admin)]
public class RombelController : Controller
{
    private readonly IRombelRepository _rombelRepository;
    private readonly IKelasRepository _kelasRepository;
    private readonly ITahunAjaranRepository _tahunAjaranRepository;
    private readonly IPegawaiRepository _pegawaiRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IToastrNotificationService _toastrNotificationService;

    public RombelController(
        IRombelRepository rombelRepository,
        IKelasRepository kelasRepository,
        ITahunAjaranRepository tahunAjaranRepository,
        IPegawaiRepository pegawaiRepository,
        IUnitOfWork unitOfWork,
        IToastrNotificationService toastrNotificationService)
    {
        _rombelRepository = rombelRepository;
        _kelasRepository = kelasRepository;
        _tahunAjaranRepository = tahunAjaranRepository;
        _pegawaiRepository = pegawaiRepository;
        _unitOfWork = unitOfWork;
        _toastrNotificationService = toastrNotificationService;
    }

    public async Task<IActionResult> Index(int? idKelas = null, int? idTahunAjaran = null)
    {
        var tahunAjaran = idTahunAjaran is null ? null : await _tahunAjaranRepository.Get(idTahunAjaran.Value);
        Kelas? kelas = null;

        if (idKelas is not null)
        {
            if (tahunAjaran is not null)
                kelas = tahunAjaran.DaftarKelas.FirstOrDefault(k => k.Id == idKelas.Value);
            else
                kelas = await _kelasRepository.Get(idKelas.Value);
        }

        var daftarRombel = await _rombelRepository.GetAll();

        if (tahunAjaran is not null)
            daftarRombel = daftarRombel.Where(r => r.Kelas.TahunAjaran == tahunAjaran).ToList();

        if (kelas is not null)
            daftarRombel = daftarRombel.Where(r => r.Kelas == kelas).ToList();

        return View(new IndexVM
        {
            TahunAjaran = tahunAjaran,
            Kelas = kelas,
            DaftarRombel = daftarRombel
        });
    }

    public IActionResult Tambah() => View(new TambahVM());

    [HttpPost]
    public async Task<IActionResult> Tambah(TambahVM vm)
    {
        if (!ModelState.IsValid) return View(vm);

        var kelas = await _kelasRepository.Get(vm.IdKelas);
        if (kelas is null)
        {
            ModelState.AddModelError(nameof(TambahVM.IdKelas), $"Kelas dengan Id '{vm.IdKelas}'");
            return View(vm);
        }

        var wali = await _pegawaiRepository.Get(vm.NIPWali);
        if (wali is null)
        {
            ModelState.AddModelError(nameof(TambahVM.NIPWali), $"Pegawai dengan NIP '{vm.NIPWali}' tidak ditemukan");
            return View(vm);
        }

        if (kelas.DaftarRombel.Any(r => r.Nama.ToLower() == vm.Nama.ToLower()))
        {
            ModelState.AddModelError(nameof(TambahVM.Nama), $"Nama '{vm.Nama}' sudah digunakan");
            return View(vm);
        }

        // Tambah Data
        var rombel = new Rombel
        {
            Nama = vm.Nama,
            Kelas = kelas,
            Wali = wali
        };

        _rombelRepository.Add(rombel);
        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
        {
            ModelState.AddModelError(string.Empty, "Simpan data rombel baru gagal!");
            return View(vm);
        }

        _toastrNotificationService.AddSuccess("Simpan data rombel baru berhasil!");

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var rombel = await _rombelRepository.Get(id);
        if (rombel is null) return NotFound();

        var kelas = await _kelasRepository.Get(rombel.Kelas.Id);

        return View(new EditVM
        {
            Id = rombel.Id,
            Nama = rombel.Nama,
            IdKelas = rombel.Kelas.Id,
            NIPWali = rombel.Wali.Id,
            IdTahunAjaran = kelas!.TahunAjaran.Id
        });
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EditVM vm)
    {
        if (!ModelState.IsValid) return View(vm);

        var kelas = await _kelasRepository.Get(vm.IdKelas);
        if (kelas is null)
        {
            ModelState.AddModelError(nameof(EditVM.IdKelas), $"Kelas dengan Id '{vm.IdKelas}'");
            return View(vm);
        }

        var wali = await _pegawaiRepository.Get(vm.NIPWali);
        if (wali is null)
        {
            ModelState.AddModelError(nameof(EditVM.NIPWali), $"Pegawai dengan NIP '{vm.NIPWali}' tidak ditemukan");
            return View(vm);
        }

        if (kelas.DaftarRombel.Any(r => r.Id != vm.Id && r.Nama.ToLower() == vm.Nama.ToLower()))
        {
            ModelState.AddModelError(nameof(EditVM.Nama), $"Nama '{vm.Nama}' sudah digunakan");
            return View(vm);
        }

        //Edit data
        var rombel = await _rombelRepository.Get(vm.Id);
        if (rombel is null) return NotFound();

        rombel.Nama = vm.Nama;
        rombel.Kelas = kelas;
        rombel.Wali = wali;

        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
        {
            ModelState.AddModelError(string.Empty, "Ubah data rombel gagal!");
            return View(vm);
        }

        _toastrNotificationService.AddSuccess("Ubah data rombel berhasil!");

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Hapus(int id)
    {
        var rombel = await _rombelRepository.Get(id);
        if (rombel is null) return NotFound();

        _rombelRepository.Delete(rombel);

        var result = await _unitOfWork.SaveChangesAsync();

        if (result.IsFailure) _toastrNotificationService.AddError("Hapus data rombel gagal!");
        else _toastrNotificationService.AddSuccess("Hapus data rombel berhasil!");

        return RedirectToAction(nameof(Index));
    }
}
