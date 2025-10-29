using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIAkademik.Domain.Abstracts;
using SIAkademik.Domain.Authentication;
using SIAkademik.Domain.ModulProfil.Entities;
using SIAkademik.Domain.ModulProfil.Repositories;
using SIAkademik.Infrastructure.Services.FileServices;
using SIAkademik.Web.Areas.DashboardAdmin.Models.BeritaModels;
using SIAkademik.Web.Models;
using SIAkademik.Web.Services.Toastr;

namespace SIAkademik.Web.Areas.DashboardAdmin.Controllers;

[Area(AreaNames.DashboardAdmin)]
[Authorize(Roles = AppUserRoles.Admin)]
public class BeritaController : Controller
{
    private readonly IBeritaRepository _beritaRepository;
    private readonly IKategoriBeritaRepository _kategoriBeritaRepository;
    private readonly IFileService _fileService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IToastrNotificationService _toastrNotificationService;

    public BeritaController(
        IBeritaRepository beritaRepository,
        IKategoriBeritaRepository kategoriBeritaRepository,
        IFileService fileService,
        IUnitOfWork unitOfWork,
        IToastrNotificationService toastrNotificationService)
    {
        _beritaRepository = beritaRepository;
        _kategoriBeritaRepository = kategoriBeritaRepository;
        _fileService = fileService;
        _unitOfWork = unitOfWork;
        _toastrNotificationService = toastrNotificationService;
    }

    public async Task<IActionResult> Index(
        List<int> kategoriBerita,
        List<int> bulan,
        List<int> tahun)
    {
        var daftarBerita = await _beritaRepository.GetAll();
        var daftarKategoriBerita = await _kategoriBeritaRepository.GetAll();

        return View(new IndexVM
        {
            KategoriBerita = [
                .. daftarKategoriBerita
                .Select(k => new FilterEntryVM<int>{ Value = k.Id, Selected = kategoriBerita.Contains(k.Id) })
            ],
            Bulan = [
                .. Enumerable.Range(1, 12)
                .Select(b => new FilterEntryVM<int>{ Value = b, Selected = bulan.Contains(b) })
            ],
            Tahun = [
                .. daftarBerita
                .Select(b => b.Tanggal.Year)
                .Distinct()
                .Order()
                .Select(y =>  new FilterEntryVM<int> { Value = y, Selected = tahun.Contains(y)})
            ],
            DaftarBerita = [
                .. daftarBerita
                .Where(b => 
                    (kategoriBerita.Count == 0 || kategoriBerita.Contains(b.KategoriBerita.Id)) &&
                    (bulan.Count == 0 || bulan.Contains(b.Tanggal.Month)) &&
                    (tahun.Count == 0 || tahun.Contains(b.Tanggal.Year)))
            ]
        });
    }

    [HttpPost]
    public IActionResult Index(IndexVM vm) => RedirectToAction(nameof(Index), new
    {
        kategoriBerita = vm.KategoriBerita.Where(k => k.Selected).Select(k => k.Value).ToList(),
        bulan = vm.Bulan.Where(b => b.Selected).Select(k => k.Value).ToList(),
        tahun = vm.Tahun.Where(t => t.Selected).Select(t => t.Value).ToList()
    });

    public IActionResult Tambah() => View(new TambahVM());

    [HttpPost]
    public async Task<IActionResult> Tambah(TambahVM vm)
    {
        if (!ModelState.IsValid) return View(vm);

        if (vm.Foto is null)
        {
            ModelState.AddModelError(nameof(TambahVM.Foto), "Fotoharus diupload");
            return View(vm);
        }

        var foto = await _fileService.UploadFile<TambahVM>(
            vm.Foto,
            "/berita",
            [".jpg", ".jpeg"],
            0,
            104858);

        if (foto.IsFailure)
        {
            ModelState.AddModelError(nameof(TambahVM.Foto), foto.Error.Message);
            return View(vm);
        }

        var kategori = await _kategoriBeritaRepository.Get(vm.IdKategoriBerita);
        if (kategori is null)
        {
            ModelState.AddModelError(nameof(TambahVM.IdKategoriBerita), "Kategori harus dipilih");
            return View(vm);
        }

        var berita = new Berita
        {
            Judul = vm.Judul,
            Isi = vm.Isi,
            Tanggal = vm.Tanggal,
            KategoriBerita = kategori,
            Foto = foto.Value
        };

        _beritaRepository.Add(berita);
        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
        {
            ModelState.AddModelError(string.Empty, "Simpan Gagal!");

            _fileService.Delete(foto.Value);

            return View(vm);
        }

        _toastrNotificationService.AddSuccess("Simpan Berhasil!");

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var berita = await _beritaRepository.Get(id);
        if (berita is null) return NotFound();

        return View(new EditVM
        {
            FotoLama = berita.Foto,
            Judul = berita.Judul,
            Id = berita.Id,
            IdKategoriBerita = berita.KategoriBerita.Id,
            Isi = berita.Isi,
            Tanggal = berita.Tanggal
        });
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EditVM vm)
    {
        if (!ModelState.IsValid) return View(vm);

        var kategori = await _kategoriBeritaRepository.Get(vm.IdKategoriBerita);
        if (kategori is null)
        {
            ModelState.AddModelError(nameof(EditVM.IdKategoriBerita), "Kategori harus dipilih");
            return View(vm);
        }

        var berita = await _beritaRepository.Get(vm.Id);
        if (berita is null) return NotFound();

        berita.KategoriBerita = kategori;
        berita.Judul = vm.Judul;
        berita.Isi = vm.Isi;
        berita.Tanggal = vm.Tanggal;

        if (vm.FotoBaru is not null)
        {
            var foto = await _fileService.UploadFile<EditVM>(
            vm.FotoBaru,
            "/berita",
            [".jpg", ".jpeg"],
            0,
            104858);

            if (foto.IsFailure)
            {
                ModelState.AddModelError(nameof(EditVM.FotoBaru), foto.Error.Message);
                return View(vm);
            }

            berita.Foto = foto.Value;
        }

        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
        {
            ModelState.AddModelError(string.Empty, "Simpan Gagal!");

            if (vm.FotoBaru is not null) _fileService.Delete(berita.Foto);

            return View(vm);
        }

        if (vm.FotoBaru is not null) _fileService.Delete(vm.FotoLama);

        _toastrNotificationService.AddSuccess("Simpan Berhasil!");

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Hapus(int id)
    {
        var berita = await _beritaRepository.Get(id);
        if (berita is null) return NotFound();

        var foto = berita.Foto;

        _beritaRepository.Delete(berita);
        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsSuccess)
        {
            _toastrNotificationService.AddSuccess("Hapus berhasil!");
            _fileService.Delete(berita.Foto);
        }
        else
            _toastrNotificationService.AddError("Hapus Gagal!");

        return RedirectToAction(nameof(Index));
    }
}
