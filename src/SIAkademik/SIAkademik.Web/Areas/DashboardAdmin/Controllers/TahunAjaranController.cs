using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIAkademik.Domain.Abstracts;
using SIAkademik.Domain.Authentication;
using SIAkademik.Domain.Enums;
using SIAkademik.Domain.ModulSiakad.Entities;
using SIAkademik.Domain.ModulSiakad.Repositories;
using SIAkademik.Web.Areas.DashboardAdmin.Models.TahunAjaranModels;
using SIAkademik.Web.Services.Toastr;

namespace SIAkademik.Web.Areas.DashboardAdmin.Controllers;

[Area(AreaNames.DashboardAdmin)]
[Authorize(Roles = AppUserRoles.Admin)]
public class TahunAjaranController : Controller
{
    private readonly ITahunAjaranRepository _tahunAjaranRepository;
    private readonly IKelasRepository _kelasRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IToastrNotificationService _toastrNotificationService;

    public TahunAjaranController(
        ITahunAjaranRepository tahunAjaranRepository,
        IUnitOfWork unitOfWork,
        IToastrNotificationService toastrNotificationService,
        IKelasRepository kelasRepository)
    {
        _tahunAjaranRepository = tahunAjaranRepository;
        _unitOfWork = unitOfWork;
        _toastrNotificationService = toastrNotificationService;
        _kelasRepository = kelasRepository;
    }

    public async Task<IActionResult> Index()
    {
        var daftarTahunAjaran = await _tahunAjaranRepository.GetAll();

        return View(daftarTahunAjaran);
    }

    public IActionResult Tambah()
    {
        return View(new TambahVM());
    }

    [HttpPost]
    public async Task<IActionResult> Tambah(TambahVM vm)
    {
        if(!ModelState.IsValid) return View(vm);

        var tahunAjaran = new TahunAjaran
        {
            Periode = vm.Periode,
            TahunPelaksaan = vm.TahunPelaksanaan,
            Semester = vm.Semester,
        };

        _tahunAjaranRepository.Add(tahunAjaran);

        var result = await _unitOfWork.SaveChangesAsync();
        if(result.IsFailure)
        {
            ModelState.AddModelError(string.Empty, "Simpan data gagal!");
            return View(vm);
        }

        _toastrNotificationService.AddSuccess("Tahun Ajaran Baru Berhasil Ditambahkan");

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var tahunAjaran = await _tahunAjaranRepository.Get(id);
        if (tahunAjaran is null) return NotFound();

        return View(new EditVM
        {
            Id = id,
            Periode = tahunAjaran.Periode,
            TahunPelaksanaan = tahunAjaran.TahunPelaksaan,
            Semester = tahunAjaran.Semester
        });
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EditVM vm)
    {
        if (!ModelState.IsValid) return View(vm);

        var tahunAjaran = await _tahunAjaranRepository.Get(vm.Id);
        if (tahunAjaran is null) return View(vm);

        tahunAjaran.Periode = vm.Periode;
        tahunAjaran.TahunPelaksaan = vm.TahunPelaksanaan;
        tahunAjaran.Semester = vm.Semester;

        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
        {
            ModelState.AddModelError(string.Empty, "Simpan data gagal!");
            return View(vm);
        }

        _toastrNotificationService.AddSuccess("Data Tahun Ajaran Berhasil Diubah");

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> GenerateKelas(int id)
    {
        var tahunAjaran = await _tahunAjaranRepository.Get(id);
        if (tahunAjaran is null) return NotFound();

        if (tahunAjaran.DaftarKelas.Count != 0)
        {
            _toastrNotificationService.AddWarning($"Tahun ajaran {tahunAjaran.Periode} {tahunAjaran.Semester.Humanize()} sudah memiliki kelas");
            return RedirectToAction(nameof(Index));
        }


        //Kelas 10
        tahunAjaran.DaftarKelas.Add(new Kelas { Jenjang = Jenjang.X, Peminatan = Peminatan.Umum, TahunAjaran = tahunAjaran });

        //Kelas 11-12
        foreach (var jenjang in Enum.GetValues<Jenjang>().SkipWhile(j => j == Jenjang.X))
            foreach (var peminatan in Enum.GetValues<Peminatan>().SkipWhile(p => p == Peminatan.Umum))
                tahunAjaran.DaftarKelas.Add(new Kelas { Jenjang = jenjang, Peminatan = peminatan, TahunAjaran = tahunAjaran });

        foreach(var kelas in tahunAjaran.DaftarKelas)
            _kelasRepository.Add(kelas);

        var result = await _unitOfWork.SaveChangesAsync();
        if(result.IsFailure)
            _toastrNotificationService
                .AddError($"Gagal generate kelas untuk tahun ajaran {tahunAjaran.Periode} {tahunAjaran.Semester.Humanize()}");
        else
            _toastrNotificationService
                .AddSuccess($"Sukses generate kelas untuk tahun ajaran {tahunAjaran.Periode} {tahunAjaran.Semester.Humanize()}");

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Hapus(int id)
    {
        var tahunAjaran = await _tahunAjaranRepository.Get(id);
        if(tahunAjaran is null) return NotFound();

        _tahunAjaranRepository.Delete(tahunAjaran);

        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
            _toastrNotificationService
                .AddError($"Gagal hapus tahun ajaran {tahunAjaran.Periode} {tahunAjaran.Semester.Humanize()}");
        else
            _toastrNotificationService
                .AddSuccess($"Sukses hapus tahun ajaran {tahunAjaran.Periode} {tahunAjaran.Semester.Humanize()}");

        return RedirectToAction(nameof(Index));
    }
}
