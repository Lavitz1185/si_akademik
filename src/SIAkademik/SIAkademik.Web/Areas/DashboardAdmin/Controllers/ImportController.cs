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
using SIAkademik.Domain.ValueObjects;
using SIAkademik.Infrastructure.Services.FileServices;
using SIAkademik.Web.Areas.DashboardAdmin.Models.ImportModels;
using SIAkademik.Web.Services.Toastr;

namespace SIAkademik.Web.Areas.DashboardAdmin.Controllers;

[Area(AreaNames.DashboardAdmin)]
[Authorize(Roles = AppUserRoles.Admin)]
public class ImportController : Controller
{
    private readonly IFileService _fileService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISiswaRepository _siswaRepository;
    private readonly IAppUserRepository _appUserRepository;
    private readonly IPasswordHasher<AppUser> _passwordHasher;
    private readonly IToastrNotificationService _toastrNotificationService;
    private readonly IPegawaiRepository _pegawaiRepository;
    private readonly IDivisiRepository _divisiRepository;
    private readonly IJabatanRepository _jabatanRepository;

    public ImportController(
        IFileService fileService,
        IUnitOfWork unitOfWork,
        ISiswaRepository siswaRepository,
        IAppUserRepository appUserRepository,
        IPasswordHasher<AppUser> passwordHasher,
        IToastrNotificationService toastrNotificationService,
        IPegawaiRepository pegawaiRepository,
        IDivisiRepository divisiRepository,
        IJabatanRepository jabatanRepository)
    {
        _fileService = fileService;
        _unitOfWork = unitOfWork;
        _siswaRepository = siswaRepository;
        _appUserRepository = appUserRepository;
        _passwordHasher = passwordHasher;
        _toastrNotificationService = toastrNotificationService;
        _pegawaiRepository = pegawaiRepository;
        _divisiRepository = divisiRepository;
        _jabatanRepository = jabatanRepository;
    }

    public IActionResult Siswa() => View(new ImportVM<Siswa>());

    [HttpPost]
    public async Task<IActionResult> Siswa(ImportVM<Siswa> vm)
    {
        if (!ModelState.IsValid) return View(vm);

        if (vm.FormFile is null)
        {
            ModelState.AddModelError(nameof(ImportVM<Siswa>.FormFile), "File harus diisi");
            return View(vm);
        }

        var file = await _fileService.ProcessFormFile<ImportVM<Siswa>>(
            vm.FormFile,
            [".xlsx"],
            0,
            long.MaxValue);

        if (file.IsFailure)
        {
            ModelState.AddModelError(nameof(ImportVM<Siswa>.FormFile), file.Error.Message);
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
            }
        }

        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
            _toastrNotificationService.AddError("Simpan Gagal");
        else
            _toastrNotificationService.AddSuccess($"Simpan Berhasil. {dataBaru.Count} ditambahkan");

        return View(new ImportVM<Siswa>{ FileName = vm.FormFile.FileName, NewData = dataBaru });
    }

    public IActionResult Pegawai() => View(new ImportVM<Pegawai>());

    [HttpPost]
    public async Task<IActionResult> Pegawai(ImportVM<Pegawai> vm)
    {
        if (!ModelState.IsValid) return View(vm);

        if (vm.FormFile is null)
        {
            ModelState.AddModelError(nameof(ImportVM<Siswa>.FormFile), "File harus diisi");
            return View(vm);
        }

        var file = await _fileService.ProcessFormFile<ImportVM<Siswa>>(
            vm.FormFile,
            [".xlsx"],
            0,
            long.MaxValue);

        if (file.IsFailure)
        {
            ModelState.AddModelError(nameof(ImportVM<Siswa>.FormFile), file.Error.Message);
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

        var dataBaru = new List<Pegawai>();

        var daftarDivisi = await _divisiRepository.GetAll();
        var daftarJabatan = await _jabatanRepository.GetAll();

        foreach (var row in sheetData.Elements<Row>().Skip(1))
        {
            var cells = row.Elements<Cell>().ToList();

            if (cells.Count != 17) continue;

            var nip = GetCellValues(cells[0], sharedStrings);
            if (string.IsNullOrEmpty(nip) || await _pegawaiRepository.IsExist(nip))
                continue;

            var tanggalMasukStr = GetCellValues(cells[1], sharedStrings);
            if (string.IsNullOrEmpty(tanggalMasukStr) || !double.TryParse(tanggalMasukStr, out var tanggalMasukDouble))
                continue;
            var tanggalMasuk = DateOnly.FromDateTime(DateTime.FromOADate(tanggalMasukDouble));

            var namaDivisi = GetCellValues(cells[2], sharedStrings);
            if (string.IsNullOrEmpty(namaDivisi)) continue;
            var divisi = daftarDivisi.FirstOrDefault(d => d.Nama.Trim().ToLower() == namaDivisi.Trim().ToLower());
            if (divisi is null)
            {
                divisi = new Divisi
                {
                    Nama = namaDivisi.Trim().ToLower().ApplyCase(LetterCasing.Title)
                };

                _divisiRepository.Add(divisi);
                daftarDivisi.Add(divisi);
            }

            var namaJabatan = GetCellValues(cells[3], sharedStrings);
            if (string.IsNullOrEmpty(namaJabatan)) continue;
            var jabatan = daftarJabatan.FirstOrDefault(j => j.Nama.Trim().ToLower() == namaJabatan.Trim().ToLower());
            if (jabatan is null)
            {
                jabatan = new Jabatan
                {
                    Nama = namaJabatan.Trim().ToLower().ApplyCase(LetterCasing.Title),
                    Jenis = JenisJabatan.Guru,
                };

                _jabatanRepository.Add(jabatan);
                daftarJabatan.Add(jabatan);
            }

            var nama = GetCellValues(cells[4], sharedStrings);
            if (string.IsNullOrEmpty(nama)) continue;

            var jenisKelaminStr = GetCellValues(cells[5], sharedStrings);
            if (string.IsNullOrEmpty(jenisKelaminStr) || !Enum.TryParse<JenisKelamin>(jenisKelaminStr, out var jenisKelamin))
                continue;

            var agamaStr = GetCellValues(cells[6], sharedStrings);
            if (string.IsNullOrEmpty(agamaStr) || !Enum.TryParse<Agama>(agamaStr, out var agama))
                continue;

            var tempatLahir = GetCellValues(cells[7], sharedStrings);
            if (string.IsNullOrEmpty(tempatLahir)) continue;

            var tanggalLahirStr = GetCellValues(cells[8], sharedStrings);
            if (string.IsNullOrEmpty(tanggalLahirStr) || !double.TryParse(tanggalLahirStr, out var tanggalLahirDouble))
                continue;
            var tanggalLahir = DateOnly.FromDateTime(DateTime.FromOADate(tanggalLahirDouble));

            var statusKawinStr = GetCellValues(cells[9], sharedStrings);
            if (string.IsNullOrEmpty(statusKawinStr) || !Enum.TryParse<StatusPerkawinan>(statusKawinStr, out var statusKawin))
                continue;

            var golDarahStr = GetCellValues(cells[10], sharedStrings);
            if (string.IsNullOrEmpty(golDarahStr) || !Enum.TryParse<GolonganDarah>(golDarahStr, out var golDarah))
                continue;

            var nik = GetCellValues(cells[11], sharedStrings);
            if (string.IsNullOrEmpty(nik)) continue;

            var noRek = GetCellValues(cells[12], sharedStrings);
            if (string.IsNullOrEmpty(noRek)) continue;

            var alamatStr = GetCellValues(cells[13], sharedStrings);
            if (string.IsNullOrEmpty(alamatStr) || !Alamat.TryParse(alamatStr, out var alamat))
                continue;

            var noHPStr = GetCellValues(cells[14], sharedStrings);
            if (string.IsNullOrEmpty(noHPStr)) continue;
            var noHP = NoHP.Create(noHPStr);
            if (noHP.IsFailure) continue;

            var email = GetCellValues(cells[15], sharedStrings);
            if (string.IsNullOrEmpty(email)) continue;

            var instagram = GetCellValues(cells[16], sharedStrings);

            var pegawai = new Pegawai
            {
                Id = nip,
                TanggalMasuk = tanggalMasuk,
                Divisi = divisi,
                Jabatan = jabatan,
                Agama = agama,
                AlamatKTP = alamat,
                Email = email,
                GolonganDarah = golDarah,
                JenisKelamin = jenisKelamin,
                Nama = nama,
                NamaInstagram = instagram,
                NIK = nik,
                NoHP = noHP.Value,
                NoRekening = noRek,
                StatusPerkawinan = statusKawin,
                TanggalLahir = tanggalLahir,
                TempatLahir = tempatLahir
            };

            var account = new AppUser
            {
                Role = AppUserRoles.Guru,
                UserName = pegawai.Email,
                PasswordHash = _passwordHasher.HashPassword(null, pegawai.NIK),
                Guru = pegawai
            };

            pegawai.Account = account;
            _pegawaiRepository.Add(pegawai);
            _appUserRepository.Add(account);

            dataBaru.Add(pegawai);
        }

        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
        {
            _toastrNotificationService.AddError("Simpan Gagal");
            return RedirectToAction(nameof(Pegawai));
        }
        
        _toastrNotificationService.AddSuccess($"Simpan Berhasil. Berhasil menambahkan {dataBaru.Count} data");

        return View(new ImportVM<Pegawai>
        {
            FileName = vm.FormFile.FileName,
            NewData = dataBaru
        });
    }

    private string GetCellValues(Cell cell, List<string> sharedStrings)
    {
        if (cell.DataType is null) return cell.InnerText;

        return sharedStrings[int.Parse(cell.InnerText)];
    }
}
