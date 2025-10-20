using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SIAkademik.Domain.Abstracts;
using SIAkademik.Domain.Authentication;
using SIAkademik.Domain.Enums;
using SIAkademik.Domain.ModulSiakad.Entities;
using SIAkademik.Domain.ModulSiakad.Repositories;
using SIAkademik.Infrastructure.Services.FileServices;
using SIAkademik.Web.Areas.DashboardAdmin.Models.SiswaModels;
using SIAkademik.Web.Models;
using SIAkademik.Web.Services.Toastr;

namespace SIAkademik.Web.Areas.DashboardAdmin.Controllers;

[Area(AreaNames.DashboardAdmin)]
[Authorize(Roles = AppUserRoles.Admin)]
public class SiswaController : Controller
{
    private readonly ISiswaRepository _siswaRepository;
    private readonly IAppUserRepository _appUserRepository;
    private readonly ITahunAjaranRepository _tahunAjaranRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IToastrNotificationService _toastrNotificationService;
    private readonly IPasswordHasher<AppUser> _passwordHasher;
    private readonly IFileService _fileService;

    public SiswaController(
        ISiswaRepository siswaRepository,
        IAppUserRepository appUserRepository,
        IUnitOfWork unitOfWork,
        IToastrNotificationService toastrNotificationService,
        IPasswordHasher<AppUser> passwordHasher,
        ITahunAjaranRepository tahunAjaranRepository,
        IFileService fileService)
    {
        _siswaRepository = siswaRepository;
        _appUserRepository = appUserRepository;
        _unitOfWork = unitOfWork;
        _toastrNotificationService = toastrNotificationService;
        _passwordHasher = passwordHasher;
        _tahunAjaranRepository = tahunAjaranRepository;
        _fileService = fileService;
    }

    public async Task<IActionResult> Index(bool showTidakAktif = false)
    {
        ViewData[nameof(showTidakAktif)] = showTidakAktif;

        if (showTidakAktif)
            return View(await _siswaRepository.GetAll());

        return View(await _siswaRepository.GetAllAktif());
    }

    public IActionResult Tambah() => View(new TambahVM());

    [HttpPost]
    public async Task<IActionResult> Tambah(TambahVM vm)
    {
        if (!ModelState.IsValid) return View(vm);

        if ((await _siswaRepository.GetByNISN(vm.NISN)) is not null)
        {
            ModelState.AddModelError(nameof(TambahVM.NISN), $"NISN '{vm.NISN}' sudah digunakan!");
            return View(vm);
        }

        if ((await _siswaRepository.GetByNIS(vm.NIS)) is not null)
        {
            ModelState.AddModelError(nameof(TambahVM.NIS), $"NIS '{vm.NIS}' sudah digunakan!");
            return View(vm);
        }

        //Tambah Data
        var siswa = new Siswa
        {
            NISN = vm.NISN,
            NIS = vm.NIS,
            Nama = vm.Nama,
            Agama = vm.Agama,
            TanggalLahir = vm.TanggalLahir,
            TanggalMasuk = vm.TanggalMasuk,
            JenisKelamin = vm.JenisKelamin,
            TempatLahir = vm.TempatLahir,
            StatusAktif = vm.StatusAktif,
            Jenjang = vm.Jenjang
        };

        var appUser = new AppUser
        {
            UserName = vm.NISN,
            PasswordHash = _passwordHasher.HashPassword(null, vm.NISN),
            Role = AppUserRoles.Siswa,
        };

        siswa.Account = appUser;

        _siswaRepository.Add(siswa);
        _appUserRepository.Add(appUser);
        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
        {
            ModelState.AddModelError(string.Empty, "Simpan data siswa baru gagal!");
            return View(vm);
        }

        _toastrNotificationService.AddSuccess("Tambah data siswa berhasil!");

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var siswa = await _siswaRepository.Get(id);
        if (siswa is null) return NotFound();

        return View(new EditVM
        {
            Id = id,
            NIS = siswa.NIS,
            NISN = siswa.NISN,
            Agama = siswa.Agama,
            JenisKelamin = siswa.JenisKelamin,
            TanggalLahir = siswa.TanggalLahir,
            Nama = siswa.Nama,
            TanggalMasuk = siswa.TanggalMasuk,
            TempatLahir = siswa.TempatLahir,
            StatusAktif = siswa.StatusAktif,
            Jenjang = siswa.Jenjang
        });
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EditVM vm)
    {
        if (!ModelState.IsValid) return View(vm);

        var siswa = await _siswaRepository.Get(vm.Id);
        if (siswa is null) return NotFound();

        var duplicateNISN = await _siswaRepository.GetByNISN(vm.NISN);
        if (duplicateNISN is not null & duplicateNISN != siswa)
        {
            ModelState.AddModelError(nameof(TambahVM.NISN), $"NISN '{vm.NISN}' sudah digunakan!");
            return View(vm);
        }

        var duplicateNIS = await _siswaRepository.GetByNIS(vm.NIS);
        if (duplicateNIS is not null & duplicateNIS != siswa)
        {
            ModelState.AddModelError(nameof(TambahVM.NIS), $"NIS '{vm.NIS}' sudah digunakan!");
            return View(vm);
        }

        if (siswa.NISN != vm.NISN && siswa.Account.UserName == siswa.NISN)
        {
            var appUser = (await _appUserRepository.Get(siswa.Account.Id))!;
            appUser.UserName = vm.NISN;
            appUser.PasswordHash = _passwordHasher.HashPassword(null, vm.NISN);
        }

        siswa.NIS = vm.NIS;
        siswa.NISN = vm.NISN;
        siswa.Nama = vm.Nama;
        siswa.Agama = vm.Agama;
        siswa.JenisKelamin = vm.JenisKelamin;
        siswa.TempatLahir = vm.TempatLahir;
        siswa.TanggalLahir = vm.TanggalLahir;
        siswa.TanggalMasuk = vm.TanggalMasuk;
        siswa.StatusAktif = vm.StatusAktif;
        siswa.Jenjang = vm.Jenjang;

        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
        {
            ModelState.AddModelError(string.Empty, "Ubah data siswa gagal!");
            return View(vm);
        }

        _toastrNotificationService.AddSuccess("Ubah data siswa berhasil!");

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Hapus(int id)
    {
        var siswa = await _siswaRepository.Get(id);
        if (siswa is null) return NotFound();

        _siswaRepository.Delete(siswa);
        _appUserRepository.Delete(siswa.Account);
        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
            _toastrNotificationService.AddError("Hapus data siswa gagal!");
        else
            _toastrNotificationService.AddSuccess("Hapus data siswa berhasil!");

        return RedirectToAction(nameof(Index));
    }

    [Route("[Area]/[Action]")]
    public async Task<IActionResult> ProsesKelulusan(int? idTahunAjaran)
    {
        var tahunAjaran = idTahunAjaran is null ?
            await _tahunAjaranRepository.GetNewest() :
            await _tahunAjaranRepository.Get(idTahunAjaran.Value);

        if (tahunAjaran is null) return View(new ProsesKelulusanVM());

        var daftarSiswa = await _siswaRepository.GetAllAktif();
        daftarSiswa = daftarSiswa.Where(s => s.Jenjang == Jenjang.XII).ToList();

        return View(new ProsesKelulusanVM
        {
            IdTahunAjaran = tahunAjaran.Id,
            DaftarEntry = [.. daftarSiswa.Select(s => new ProsesKelulusanEntryVM { IdSiswa = s.Id, Luluskan = false })],
            DaftarSiswa = daftarSiswa
        });
    }

    [HttpPost]
    [Route("[Area]/[Action]")]
    public async Task<IActionResult> ProsesKelulusan(ProsesKelulusanVM vm)
    {
        if (vm.IdTahunAjaran is null)
        {
            _toastrNotificationService.AddError("Tidak ada tahun ajaran aktif!");
            return RedirectToAction(nameof(ProsesKelulusan));
        }

        var daftarSiswa = await _siswaRepository.GetAllAktif();
        daftarSiswa = daftarSiswa.Where(s => s.Jenjang == Jenjang.XII).ToList();

        foreach (var entry in vm.DaftarEntry.Where(e => e.Luluskan))
        {
            var siswa = daftarSiswa.FirstOrDefault(s => s.Id == entry.IdSiswa);
            if (siswa is not null)
                siswa.StatusAktif = StatusAktifMahasiswa.TidakAktif;
        }

        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
            _toastrNotificationService.AddError("Simpan gagal!");
        else
            _toastrNotificationService.AddSuccess("Simpan sukses!");

        return RedirectToAction(nameof(ProsesKelulusan), new { idTahunAjaran = vm.IdTahunAjaran });
    }

    [Route("[Area]/[Action]")]
    public async Task<IActionResult> NaikKelas(Jenjang jenjang = Jenjang.X)
    {
        if (jenjang == Jenjang.XII) return BadRequest();

        var daftarSiswa = await _siswaRepository.GetAllAktif();
        daftarSiswa = daftarSiswa.Where(s => s.Jenjang == jenjang).ToList();

        return View(new NaikKelasVM
        {
            DaftarSiswa = daftarSiswa,
            jenjang = jenjang,
            DaftarEntry = daftarSiswa.Select(s => new NaikKelasEntryVM { IdSiswa = s.Id }).ToList()
        });
    }

    [Route("[Area]/[Action]")]
    [HttpPost]
    public async Task<IActionResult> NaikKelas(NaikKelasVM vm)
    {
        if (vm.jenjang == vm.JenjangTujuan)
            return RedirectToAction(nameof(NaikKelas), new { jenjang = vm.jenjang });

        var daftarSiswa = await _siswaRepository.GetAllAktif();
        daftarSiswa = daftarSiswa.Where(s => s.Jenjang == vm.jenjang).ToList();

        foreach (var entry in vm.DaftarEntry.Where(e => e.NaikKelas))
        {
            var siswa = daftarSiswa.FirstOrDefault(s => s.Id == entry.IdSiswa);
            if (siswa is not null)
                siswa.Jenjang = vm.JenjangTujuan;
        }

        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
            _toastrNotificationService.AddError("Simpan Gagal!");
        else
            _toastrNotificationService.AddSuccess("Simpan Berhasil!");

        return RedirectToAction(nameof(NaikKelas), new { vm.jenjang });
    }

    [Route("[Area]/[Action]")]
    public IActionResult Import() => View(new ImportVM());

    [Route("[Area]/[Action]")]
    [HttpPost]
    public async Task<IActionResult> Import(ImportVM vm) 
    {
        if (!ModelState.IsValid) return View(vm);

        if (vm.FormFile is null)
        {
            ModelState.AddModelError(nameof(ImportVM.FormFile), "File harus diisi");
            return View(vm);
        }

        var file = await _fileService.ProcessFormFile<ImportVM>(
            vm.FormFile,
            [".xlsx"],
            0,
            long.MaxValue);

        if (file.IsFailure)
        {
            ModelState.AddModelError(nameof(ImportVM.FormFile), file.Error.Message);
            return View(vm);
        }

        using var memoryStream = new MemoryStream(file.Value);
        using var spreadSheet = SpreadsheetDocument.Open(memoryStream, isEditable: false);

        var workBookPart = spreadSheet.WorkbookPart!;
        var sharedStrings = workBookPart
            .SharedStringTablePart?
            .SharedStringTable
            .Elements<SharedStringItem>()
            .Select(s => s.InnerText).ToList() ?? [];

        var sheet = workBookPart.Workbook.Sheets!.Elements<Sheet>().First()!;
        var workSheetPart = (WorksheetPart)workBookPart.GetPartById(sheet.Id!);
        var sheetData = workSheetPart.Worksheet.Elements<SheetData>().First();

        var numOfAdded = 0;
        var numOfNotAdded = 0;
        var dataBaru = new List<Siswa>();

        foreach (var row in sheetData.Elements<Row>().Skip(1))
        {
            var cells = row.Elements<Cell>().ToList();

            if (cells.Count == 10)
            {
                var nisn = GetCellValues(cells[0], sharedStrings);
                if (string.IsNullOrWhiteSpace(nisn)) continue;

                var nis = GetCellValues(cells[1], sharedStrings);
                if (string.IsNullOrWhiteSpace(nis)) continue;

                if (await _siswaRepository.IsExistByNISN(nisn) || await _siswaRepository.IsExistByNIS(nis))
                    continue;

                var nama = GetCellValues(cells[2], sharedStrings);
                if (string.IsNullOrWhiteSpace(nama)) continue;

                var agamaStr = GetCellValues(cells[3], sharedStrings);
                if (string.IsNullOrWhiteSpace(agamaStr) || !Enum.TryParse<Agama>(agamaStr, true, out var agama))
                    continue;

                var jkStr = GetCellValues(cells[4], sharedStrings);
                if (string.IsNullOrWhiteSpace(jkStr) || !Enum.TryParse<JenisKelamin>(jkStr, true, out var jk))
                    continue;

                var tempatLahir = GetCellValues(cells[5], sharedStrings);
                if (string.IsNullOrWhiteSpace(tempatLahir)) continue;

                var tanggalLahirStr = GetCellValues(cells[6], sharedStrings);
                if (string.IsNullOrWhiteSpace(tanggalLahirStr) ||
                    !double.TryParse(tanggalLahirStr, out var tanggaLahirDouble) ||
                    tanggaLahirDouble < 0)
                    continue;
                var tanggalLahir = DateOnly.FromDateTime(DateTime.FromOADate(tanggaLahirDouble));

                var tanggalMasukStr = GetCellValues(cells[7], sharedStrings);
                if (string.IsNullOrWhiteSpace(tanggalMasukStr) ||
                    !double.TryParse(tanggalMasukStr, out var tanggalMasukDouble) ||
                    tanggalMasukDouble < 0)
                    continue;
                var tanggalMasuk = DateOnly.FromDateTime(DateTime.FromOADate(tanggaLahirDouble));

                var statusAktifStr = GetCellValues(cells[8], sharedStrings);
                if (string.IsNullOrWhiteSpace(statusAktifStr) || !Enum.TryParse<StatusAktifMahasiswa>(statusAktifStr, out var statusAktif))
                    continue;

                var jenjangStr = GetCellValues(cells[9], sharedStrings);
                if (string.IsNullOrWhiteSpace(jenjangStr) || !Enum.TryParse<Jenjang>(jenjangStr, out var jenjang))
                    continue;

                var siswa = new Siswa
                {
                    NIS = nis,
                    NISN = nisn,
                    Nama = nama,
                    Agama = agama,
                    JenisKelamin = jk,
                    TempatLahir = tempatLahir,
                    TanggalLahir = tanggalLahir,
                    TanggalMasuk = tanggalMasuk,
                    Jenjang = jenjang,
                    StatusAktif = statusAktif,
                };

                var account = new AppUser
                {
                    Role = AppUserRoles.Siswa,
                    PasswordHash = _passwordHasher.HashPassword(null, siswa.NISN),
                    UserName = siswa.NISN,
                    Siswa = siswa
                };

                siswa.Account = account;

                _siswaRepository.Add(siswa);
                _appUserRepository.Add(account);
                dataBaru.Add(siswa);
                numOfAdded++;
            }
        }

        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
            _toastrNotificationService.AddError("Simpan Gagal");
        else
            _toastrNotificationService.AddSuccess($"Simpan Berhasil. {numOfAdded} ditambahkan, {numOfNotAdded} gagal ditambakan");

        return View(new ImportVM { FileName = vm.FormFile.FileName, DaftarSiswa = dataBaru });
    }

    private string GetCellValues(Cell cell, List<string> sharedStrings)
    {
        if (cell.DataType is null) return cell.InnerText;

        return sharedStrings[int.Parse(cell.InnerText)];
    }
}
