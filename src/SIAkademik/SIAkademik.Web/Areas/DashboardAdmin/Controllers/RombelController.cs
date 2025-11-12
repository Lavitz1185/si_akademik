using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIAkademik.Domain.Abstracts;
using SIAkademik.Domain.Authentication;
using SIAkademik.Domain.Enums;
using SIAkademik.Domain.ModulSiakad.Entities;
using SIAkademik.Domain.ModulSiakad.Repositories;
using SIAkademik.Web.Areas.DashboardAdmin.Models.RombelModels;
using SIAkademik.Web.Models;
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
    private readonly ISiswaRepository _siswaRepository;
    private readonly IAnggotaRombelRepository _anggotaRombelRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IToastrNotificationService _toastrNotificationService;

    public RombelController(
        IRombelRepository rombelRepository,
        IKelasRepository kelasRepository,
        ITahunAjaranRepository tahunAjaranRepository,
        IPegawaiRepository pegawaiRepository,
        ISiswaRepository siswaRepository,
        IAnggotaRombelRepository anggotaRombelRepository,
        IUnitOfWork unitOfWork,
        IToastrNotificationService toastrNotificationService)
    {
        _rombelRepository = rombelRepository;
        _kelasRepository = kelasRepository;
        _tahunAjaranRepository = tahunAjaranRepository;
        _pegawaiRepository = pegawaiRepository;
        _siswaRepository = siswaRepository;
        _anggotaRombelRepository = anggotaRombelRepository;
        _unitOfWork = unitOfWork;
        _toastrNotificationService = toastrNotificationService;
    }

    public async Task<IActionResult> Index(int? idKelas = null, int? idTahunAjaran = null)
    {
        var tahunAjaran = idTahunAjaran is null ? 
            null : 
            await _tahunAjaranRepository.Get(idTahunAjaran.Value);

        var kelas = idKelas is null ? null : await _kelasRepository.Get(idKelas.Value);

        var daftarRombel = await _rombelRepository.GetAll();

        return View(new IndexVM
        {
            TahunAjaran = tahunAjaran,
            IdTahunAjaran = tahunAjaran?.Id,
            Kelas = kelas,
            IdKelas = kelas?.Id,
            DaftarRombel = [.. daftarRombel.Where(r => (tahunAjaran is null || r.TahunAjaran == tahunAjaran) && (kelas is null || r.Kelas == kelas))]
        });
    }

    public IActionResult Tambah(int? idKelas = null, int? idTahunAjaran = null, string? returnUrl = null) => 
        View(new TambahVM
        {
            IdKelas = idKelas ?? default,
            IdTahunAjaran = idTahunAjaran ?? default,
            ReturnUrl = returnUrl ?? Url.ActionLink(nameof(Index))!
        });

    [HttpPost]
    public async Task<IActionResult> Tambah(TambahVM vm)
    {
        if (!ModelState.IsValid) return View(vm);

        var kelas = await _kelasRepository.Get(vm.IdKelas);
        if (kelas is null)
        {
            ModelState.AddModelError(nameof(TambahVM.IdKelas), $"Kelas dengan Id '{vm.IdKelas}' tidak ditemukan");
            return View(vm);
        }

        var tahunAjaran = await _tahunAjaranRepository.Get(vm.IdTahunAjaran);
        if (tahunAjaran is null)
        {
            ModelState.AddModelError(nameof(TambahVM.IdTahunAjaran), $"Tahun Ajaran dengan Id '{vm.IdTahunAjaran}' tidak ditemukan");
            return View(vm);
        }

        var wali = await _pegawaiRepository.Get(vm.NIPWali);
        if (wali is null)
        {
            ModelState.AddModelError(nameof(TambahVM.NIPWali), $"Pegawai dengan NIP '{vm.NIPWali}' tidak ditemukan");
            return View(vm);
        }

        if (kelas.DaftarRombel.Any(r => r.TahunAjaran == tahunAjaran && r.Nama.ToLower() == vm.Nama.ToLower()))
        {
            ModelState.AddModelError(nameof(TambahVM.Nama), $"Nama '{vm.Nama}' sudah digunakan");
            return View(vm);
        }

        // Tambah Data
        var rombel = new Rombel
        {
            Nama = vm.Nama,
            Kelas = kelas,
            Wali = wali,
            TahunAjaran = tahunAjaran
        };

        _rombelRepository.Add(rombel);
        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
        {
            ModelState.AddModelError(string.Empty, "Simpan data rombel baru gagal!");
            return View(vm);
        }

        _toastrNotificationService.AddSuccess("Simpan data rombel baru berhasil!");

        return Redirect(vm.ReturnUrl);
    }

    public async Task<IActionResult> Edit(int id, string? returnUrl = null)
    {
        var rombel = await _rombelRepository.Get(id);
        if (rombel is null) return NotFound();

        return View(new EditVM
        {
            Id = rombel.Id,
            Nama = rombel.Nama,
            IdKelas = rombel.Kelas.Id,
            NIPWali = rombel.Wali.Id,
            IdTahunAjaran = rombel.TahunAjaran.Id,
            ReturnUrl = returnUrl ?? Url.ActionLink(nameof(Index))!
        });
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EditVM vm)
    {
        if (!ModelState.IsValid) return View(vm);

        var tahunAjaran = await _tahunAjaranRepository.Get(vm.IdTahunAjaran);
        if (tahunAjaran is null)
        {
            ModelState.AddModelError(nameof(EditVM.IdTahunAjaran), $"Tahun Ajaran dengan Id '{vm.IdTahunAjaran}' tidak ditemukan");
            return View(vm);
        }

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

        if (kelas.DaftarRombel.Any(r => r.Id != vm.Id && r.TahunAjaran == tahunAjaran && r.Nama.ToLower() == vm.Nama.ToLower()))
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
        rombel.TahunAjaran = tahunAjaran;

        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
        {
            ModelState.AddModelError(string.Empty, "Ubah data rombel gagal!");
            return View(vm);
        }

        _toastrNotificationService.AddSuccess("Ubah data rombel berhasil!");

        return Redirect(vm.ReturnUrl);
    }

    [HttpPost]
    public async Task<IActionResult> Hapus(int id, string? returnUrl = null)
    {
        var rombel = await _rombelRepository.Get(id);
        if (rombel is null) return NotFound();

        var idKelas = rombel.Kelas.Id;
        var idTahunAjaran = rombel.TahunAjaran.Id;

        _rombelRepository.Delete(rombel);

        var result = await _unitOfWork.SaveChangesAsync();

        if (result.IsFailure) _toastrNotificationService.AddError("Hapus data rombel gagal!");
        else _toastrNotificationService.AddSuccess("Hapus data rombel berhasil!");

        return returnUrl is null ? RedirectToAction(nameof(Index), new { idKelas, idTahunAjaran }) : RedirectPermanent(returnUrl);
    }

    public async Task<IActionResult> Detail(int id, string? returnUrl = null)
    {
        var rombel = await _rombelRepository.Get(id);
        if (rombel is null) return NotFound();

        var daftarSiswa = await _siswaRepository.GetAllAktif();

        return View(new DetailVM
        {
            Id = id,
            Rombel = rombel,
            ReturnUrl = returnUrl ?? Url.ActionLink(nameof(Index))!,
            DaftarSiswaTambah = [.. daftarSiswa
                .Where(s => s.DaftarAnggotaRombel.All(a => a.Rombel.TahunAjaran != rombel.TahunAjaran) && s.Jenjang == rombel.Kelas.Jenjang)
                .OrderBy(s => s.Nama)
                .Select(s => new DetailEntryVM
                {
                    IdSiswa = s.Id,
                    Siswa = s,
                    Selected = false,
                })],
            DaftarSiswaHapus = [.. rombel.DaftarAnggotaRombel.OrderBy(a => a.Siswa.Nama).Select(a => new DetailEntryVM
            {
                IdSiswa = a.IdSiswa,
                Siswa = a.Siswa,
                Selected = false,
            })],
        });
    }

    public async Task<IActionResult> TambahSiswa(int id, int idSiswa)
    {
        var rombel = await _rombelRepository.Get(id);
        if (rombel is null) return NotFound();

        var siswa = await _siswaRepository.Get(idSiswa);
        if (siswa is null) return NotFound();

        var kelas = await _kelasRepository.Get(rombel.Kelas.Id);

        if (rombel.DaftarAnggotaRombel.Any(a => a.Siswa == siswa))
        {
            _toastrNotificationService.AddError($"Siswa dengan Id '{idSiswa}' sudah ada dalam rombel");
            return RedirectToAction(nameof(Detail), new { id });
        }

        if (kelas!.DaftarRombel.Any(r => r != rombel && r.DaftarAnggotaRombel.Any(a => a.Siswa == siswa)))
        {
            _toastrNotificationService.AddError($"Siswa dengan Id '{idSiswa}' sudah ada dalam rombel di kelas {kelas.Peminatan.Nama}" +
                $" {kelas.Jenjang.Humanize()} - {rombel.TahunAjaran.Periode} {rombel.TahunAjaran.Semester.Humanize()}");
            return RedirectToAction(nameof(Detail), new { id });
        }

        var anggotaRombel = new AnggotaRombel
        {
            IdRombel = rombel.Id,
            IdSiswa = siswa.Id,
            TanggalMasuk = DateOnly.FromDateTime(DateTime.Now),
            Rombel = rombel,
            Siswa = siswa
        };

        _anggotaRombelRepository.Add(anggotaRombel);
        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
            _toastrNotificationService.AddError("Siswa gagal ditambahkan ke rombel");
        else
            _toastrNotificationService.AddSuccess("Siswa berhasil ditambahkan ke rombel");

        return RedirectToAction(nameof(Detail), new { id });
    }

    public async Task<IActionResult> HapusSiswa(int id, int idSiswa)
    {
        var rombel = await _rombelRepository.Get(id);
        if (rombel is null) return NotFound();

        var siswa = await _siswaRepository.Get(idSiswa);
        if (siswa is null) return NotFound();

        var anggotaRombel = rombel.DaftarAnggotaRombel.FirstOrDefault(a => a.Siswa == siswa);
        if (anggotaRombel is null) return NotFound();

        _anggotaRombelRepository.Delete(anggotaRombel);
        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
            _toastrNotificationService.AddError("Siswa gagal dihapus dari rombel");
        else
            _toastrNotificationService.AddSuccess("Siswa berhasil dihapus dari rombel");

        return RedirectToAction(nameof(Detail), new { id });
    }

    [HttpPost]
    public async Task<IActionResult> TambahSiswaBanyak(DetailVM vm)
    {
        var rombel = await _rombelRepository.Get(vm.Id);
        if (rombel is null) return NotFound();

        foreach (var entry in vm.DaftarSiswaTambah.Where(e => e.Selected))
        {
            if (!rombel.DaftarAnggotaRombel.Any(a => a.IdSiswa == entry.IdSiswa))
            {
                var siswa = await _siswaRepository.Get(entry.IdSiswa);
                if (siswa is null) continue;

                var anggotaRombel = new AnggotaRombel
                {
                    IdRombel = rombel.Id,
                    IdSiswa = entry.IdSiswa,
                    Siswa = siswa,
                    TanggalMasuk = DateOnly.FromDateTime(CultureInfos.DateTimeNow)
                };

                _anggotaRombelRepository.Add(anggotaRombel);
            }
        }

        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsSuccess)
            _toastrNotificationService.AddSuccess("Simpan Berhasil!");
        else
            _toastrNotificationService.AddError("Simpan Gagal!");

        return RedirectToAction(nameof(Detail), new { vm.Id });
    }

    [HttpPost]
    public async Task<IActionResult> HapusSiswaBanyak(DetailVM vm)
    {
        var rombel = await _rombelRepository.Get(vm.Id);
        if (rombel is null) return NotFound();

        foreach (var entry in vm.DaftarSiswaHapus.Where(e => e.Selected))
        {
            var anggotaRombel = rombel.DaftarAnggotaRombel.FirstOrDefault(a => a.IdSiswa == entry.IdSiswa);
            if (anggotaRombel is not null)
            {
                _anggotaRombelRepository.Delete(anggotaRombel);
            }
        }

        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsSuccess)
            _toastrNotificationService.AddSuccess("Simpan Berhasil!");
        else
            _toastrNotificationService.AddError("Simpan Gagal!");

        return RedirectToAction(nameof(Detail), new { vm.Id });
    }

    [HttpGet]
    public async Task<IActionResult> DaftarRombel(int idTahunAjaran)
    {
        var daftarRombel = await _rombelRepository.GetAllByTahunAjaran(idTahunAjaran);

        return Json(daftarRombel.Select(r => new
        {
            r.Id,
            r.Nama,
            Kelas = new { Jenjang = r.Kelas.Jenjang.Humanize(), Peminatan = r.Kelas.Peminatan.Nama }
        }));
    }

    [Route("[Area]/[Action]")]
    public async Task<IActionResult> PindahSemester(int? idTahunAjaranAsal = null)
    {
        var daftarTahunAjaran = await _tahunAjaranRepository.GetAll();

        var tahunAjaran = idTahunAjaranAsal is null ?
            daftarTahunAjaran.Where(t => t.Semester == Semester.Ganjil).LastOrDefault() :
            daftarTahunAjaran.Where(t => t.Semester == Semester.Ganjil).FirstOrDefault(t => t.Id == idTahunAjaranAsal);

        if (tahunAjaran is null) return View(new PindahSemesterVM());

        var tahunAjaranTujuan = daftarTahunAjaran.FirstOrDefault(t => t.Tahun == tahunAjaran.Tahun && t.Semester == Semester.Genap);

        return View(new PindahSemesterVM
        {
            IdTahunAjaranAsal = tahunAjaran.Id,
            TahunAjaranAsal = tahunAjaran,
            IdTahunAjaranTujuan = tahunAjaranTujuan?.Id,
            TahunAjaranTujuan = tahunAjaranTujuan
        });
    }

    [HttpPost]
    [Route("[Area]/[Action]")]
    public async Task<IActionResult> PindahSemesterPOST(PindahSemesterVM vm)
    {
        if (vm.IdTahunAjaranAsal is null || vm.IdTahunAjaranTujuan is null)
        {
            _toastrNotificationService.AddError("Tahun Ajaran Asal dan Tujuan tidak ada");
            return RedirectToAction(nameof(PindahSemester));
        }

        var tahunAjaranAsal = await _tahunAjaranRepository.Get(vm.IdTahunAjaranAsal.Value);
        if (tahunAjaranAsal is null)
        {
            _toastrNotificationService.AddError("Tahun Ajaran Asal tidak ditemukan");
            return RedirectToAction(nameof(PindahSemester));
        }

        if (tahunAjaranAsal.Semester != Semester.Ganjil)
        {
            _toastrNotificationService.AddError("Tahun Ajaran harus semester Genap!");
            return RedirectToAction(nameof(PindahSemester));
        }

        var tahunAjaranTujuan = await _tahunAjaranRepository.Get(vm.IdTahunAjaranTujuan.Value);
        if (tahunAjaranTujuan is null)
        {
            _toastrNotificationService.AddError("Tahun Ajaran Tujuan tidak ditemukan");
            return RedirectToAction(nameof(PindahSemester), new { vm.IdTahunAjaranAsal });
        }

        if (tahunAjaranTujuan.Tahun != tahunAjaranAsal.Tahun)
        {
            _toastrNotificationService.AddError("Periode tahun ajaran tujuan harus sama dengan tahun ajaran asal");
            return RedirectToAction(nameof(PindahSemester), new { vm.IdTahunAjaranAsal });
        }

        if (tahunAjaranTujuan.Semester != Semester.Genap)
        {
            _toastrNotificationService.AddError("Tahun Ajaran Tujuan harus semester genap");
            return RedirectToAction(nameof(PindahSemester), new { vm.IdTahunAjaranAsal });
        }

        var daftarRombelAsal = await _rombelRepository.GetAllByTahunAjaran(tahunAjaranAsal.Id);
        var daftarRombelTujuan = await _rombelRepository.GetAllByTahunAjaran(tahunAjaranTujuan.Id);

        foreach (var rombelAsal in daftarRombelAsal)
        {
            var rombelTujuan = daftarRombelTujuan.FirstOrDefault(t => t.Kelas == rombelAsal.Kelas && t.Nama == rombelAsal.Nama);
            if (rombelTujuan is null)
            {
                rombelTujuan = new Rombel
                {
                    Nama = rombelAsal.Nama,
                    Kelas = rombelAsal.Kelas,
                    TahunAjaran = tahunAjaranTujuan,
                    Wali = rombelAsal.Wali,
                    DaftarSiswa = [],
                    DaftarAnggotaRombel = [],
                };

                _rombelRepository.Add(rombelTujuan);
                daftarRombelTujuan.Add(rombelTujuan);
            }

            foreach (var anggotaRombel in rombelAsal.DaftarAnggotaRombel)
            {
                anggotaRombel.Aktif = false;
                anggotaRombel.NaikKelasLulus = true;
                anggotaRombel.TanggalKeluar = CultureInfos.DateOnlyNow;

                if (!rombelTujuan.DaftarSiswa.Contains(anggotaRombel.Siswa))
                {
                    var anggotaRombelTujuan = new AnggotaRombel
                    {
                        Rombel = rombelTujuan,
                        Siswa = anggotaRombel.Siswa,
                        Aktif = true,
                        TanggalMasuk = CultureInfos.DateOnlyNow
                    };

                    _anggotaRombelRepository.Add(anggotaRombelTujuan);
                    rombelTujuan.DaftarAnggotaRombel.Add(anggotaRombelTujuan);
                }
            }
        }

        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
        {
            _toastrNotificationService.AddError("Simpan Gagal!");
            return RedirectToAction(nameof(PindahSemester), new { vm.IdTahunAjaranAsal });
        }

        _toastrNotificationService.AddSuccess("Simpan Sukses!");
        return RedirectToAction(nameof(PindahSemester), new { vm.IdTahunAjaranAsal });
    }
}
