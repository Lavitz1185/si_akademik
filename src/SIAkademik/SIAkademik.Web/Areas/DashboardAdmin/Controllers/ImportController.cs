using DocumentFormat.OpenXml;
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
using SIAkademik.Web.Models;
using SIAkademik.Web.Services.Toastr;
using System.Text.RegularExpressions;

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
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly ITahunAjaranRepository _tahunAjaranRepository;
    private readonly IPeminatanRepository _peminatanRepository;
    private readonly IKelasRepository _kelasRepository;
    private readonly IRombelRepository _rombelRepository;
    private readonly IMataPelajaranRepository _mataPelajaranRepository;
    private readonly ITujuanPembelajaranRepository _tujuanPembelajaranRepository;

    public ImportController(
        IFileService fileService,
        IUnitOfWork unitOfWork,
        ISiswaRepository siswaRepository,
        IAppUserRepository appUserRepository,
        IPasswordHasher<AppUser> passwordHasher,
        IToastrNotificationService toastrNotificationService,
        IPegawaiRepository pegawaiRepository,
        IDivisiRepository divisiRepository,
        IJabatanRepository jabatanRepository,
        IWebHostEnvironment webHostEnvironment,
        ITahunAjaranRepository tahunAjaranRepository,
        IPeminatanRepository peminatanRepository,
        IKelasRepository kelasRepository,
        IRombelRepository rombelRepository,
        IMataPelajaranRepository mataPelajaranRepository,
        ITujuanPembelajaranRepository tujuanPembelajaranRepository)
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
        _webHostEnvironment = webHostEnvironment;
        _tahunAjaranRepository = tahunAjaranRepository;
        _peminatanRepository = peminatanRepository;
        _kelasRepository = kelasRepository;
        _rombelRepository = rombelRepository;
        _mataPelajaranRepository = mataPelajaranRepository;
        _tujuanPembelajaranRepository = tujuanPembelajaranRepository;
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
                var tanggalMasuk = DateOnly.FromDateTime(DateTime.FromOADate(tanggalMasukDouble));

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
            ModelState.AddModelError(nameof(ImportVM<Pegawai>.FormFile), "File harus diisi");
            return View(vm);
        }

        var file = await _fileService.ProcessFormFile<ImportVM<Pegawai>>(
            vm.FormFile,
            [".xlsx"],
            0,
            long.MaxValue);

        if (file.IsFailure)
        {
            ModelState.AddModelError(nameof(ImportVM<Pegawai>.FormFile), file.Error.Message);
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
                PasswordHash = _passwordHasher.HashPassword(null, pegawai.Id),
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

    public async Task<IActionResult> DownloadTemplateRombel()
    {
        var daftarWali = await _pegawaiRepository.GetAll();

        var fileBytes = System.IO.File.ReadAllBytes(
            Path.Combine(_webHostEnvironment.WebRootPath, "file/importTemplate/Template Import Data Rombel.xlsx"));

        using var memoryStream = new MemoryStream();
        memoryStream.Write(fileBytes, 0, fileBytes.Length);

        using var spreadSheet = SpreadsheetDocument.Open(
            memoryStream, 
            isEditable: true);

        var workBookPart = spreadSheet.WorkbookPart!;
        
        var sheet = workBookPart.Workbook.Sheets!.Elements<Sheet>().First(a => a.Name == "Sheet2");
        var workSheetPart = (WorksheetPart)workBookPart.GetPartById(sheet.Id!);
        var sheetData = workSheetPart.Worksheet.Elements<SheetData>().First();

        foreach (var wali in daftarWali)
        {
            var row = new Row();
            var cell = new Cell
            {
                CellValue = new CellValue($"{wali.Id} - {wali.Nama}")
            };
            row.Append(cell);
            sheetData.Append(row);
        }

        sheet = workBookPart.Workbook.Sheets!.Elements<Sheet>().First()!;
        workSheetPart = (WorksheetPart)workBookPart.GetPartById(sheet.Id!);
        sheetData = workSheetPart.Worksheet.Elements<SheetData>().First();

        var dataValidation = new DataValidation
        {
            Type = DataValidationValues.List,
            AllowBlank = true,
            SequenceOfReferences = new ListValue<StringValue> { InnerText = "F2:F5" },
            Formula1 = new Formula1($"Sheet2!$A$1:$A${daftarWali.Count}")
        };

        var dvs = workSheetPart.Worksheet.GetFirstChild<DataValidations>();
        if (dvs is not null)
        {
            dvs.Count = (dvs?.Count ?? 0) + 1;
            dvs!.Append(dataValidation);
        }
        else
        {
            var newDvs = new DataValidations();
            newDvs.AppendChild(dataValidation);
            newDvs.Count = (dvs?.Count ?? 0) + 1;
            workSheetPart.Worksheet.Append(newDvs);
        }

        workBookPart.Workbook.Descendants<WorkbookView>().First().ActiveTab = Convert
            .ToUInt32(workBookPart.Workbook.Descendants<Sheet>().ToList().IndexOf(sheet));

        spreadSheet.Save();

        return File(
            memoryStream.ToArray(), 
            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", 
            fileDownloadName: "Template Import Data Rombel.xlsx");
    }

    public IActionResult Rombel() => View(new ImportVM<Rombel>());

    [HttpPost]
    public async Task<IActionResult> Rombel(ImportVM<Rombel> vm)
    {
        if (!ModelState.IsValid) return View(vm);

        if (vm.FormFile is null)
        {
            ModelState.AddModelError(nameof(ImportVM<Rombel>.FormFile), "File harus diisi");
            return View(vm);
        }

        var file = await _fileService.ProcessFormFile<ImportVM<Rombel>>(
            vm.FormFile,
            [".xlsx"],
            0,
            long.MaxValue);

        if (file.IsFailure)
        {
            ModelState.AddModelError(nameof(ImportVM<Rombel>.FormFile), file.Error.Message);
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

        var daftarTahunAjaran = await _tahunAjaranRepository.GetAll();
        var daftarPeminatan = await _peminatanRepository.GetAll();
        var daftarKelas = await _kelasRepository.GetAll();

        var dataBaru = new List<Rombel>();

        foreach (var row in sheetData.Elements<Row>().Skip(1))
        {
            var cells = row.Elements<Cell>().ToList();

            if (cells.Count != 6) continue;

            var nama = GetCellValues(cells[0], sharedStrings);
            if (string.IsNullOrEmpty(nama)) continue;

            var tahunStr = GetCellValues(cells[1], sharedStrings);
            if (string.IsNullOrEmpty(tahunStr)) continue;
            var match = Regex.Match(tahunStr, @"^(?<tahun>\d{4})/\d{4}$");
            if (!match.Success || !match.Groups.TryGetValue("tahun", out var tahunGroup))
                continue;
            var tahun = int.Parse(tahunGroup.Value);

            var semesterStr = GetCellValues(cells[2], sharedStrings);
            if (string.IsNullOrEmpty(semesterStr) || !Enum.TryParse<Semester>(semesterStr, out var semester)) continue;

            var tahunAjaran = daftarTahunAjaran.FirstOrDefault(t => t.Tahun == tahun && t.Semester == semester);
            if (tahunAjaran is null)
            {
                tahunAjaran = new TahunAjaran
                {
                    Tahun = tahun,
                    Semester = semester,
                    TanggalMulai = semester == Semester.Ganjil ? new DateOnly(tahun, 7, 1) : new DateOnly(tahun + 1, 1, 1),
                    TanggalSelesai = semester == Semester.Ganjil ? new DateOnly(tahun, 12, 31) : new DateOnly(tahun + 1, 6, 30),
                };

                _tahunAjaranRepository.Add(tahunAjaran);
                daftarTahunAjaran.Add(tahunAjaran);
            }

            var jenjangStr = GetCellValues(cells[3], sharedStrings);
            if (string.IsNullOrEmpty(jenjangStr) || !Enum.TryParse<Jenjang>(jenjangStr, out var jenjang))
                continue;

            var namaPeminatan = GetCellValues(cells[4], sharedStrings);
            if (string.IsNullOrEmpty(namaPeminatan)) continue;
            var peminatan = daftarPeminatan.FirstOrDefault(p => p.Nama.Trim().ToLower() == namaPeminatan.Trim().ToLower());
            if (peminatan is null)
            {
                peminatan = new Peminatan
                {
                    Nama = namaPeminatan.Trim().ApplyCase(LetterCasing.Title),
                    Jenis = namaPeminatan.Trim().ToLower() == "umum" ? JenisPeminatan.Umum : JenisPeminatan.Peminatan
                };

                _peminatanRepository.Add(peminatan);
                daftarPeminatan.Add(peminatan);
            }

            var kelas = daftarKelas.FirstOrDefault(k => k.Jenjang == jenjang && k.Peminatan.Nama.ToLower() == peminatan.Nama.ToLower());
            if (kelas is null)
            {
                kelas = new Kelas
                {
                    Jenjang = jenjang,
                    Peminatan = peminatan
                };

                _kelasRepository.Add(kelas);
                daftarKelas.Add(kelas);
            }

            var nipNamaWali = GetCellValues(cells[5], sharedStrings);
            if (string.IsNullOrEmpty(nipNamaWali)) continue;
            match = Regex.Match(nipNamaWali, @"(?<nip>PJ\d{2}-\d{3}) - .+");
            if (!match.Success || !match.Groups.TryGetValue("nip", out var nipGroup)) continue;

            var wali = await _pegawaiRepository.Get(nipGroup.Value);
            if (wali is null) continue;

            if (kelas.DaftarRombel.Any(r => r.TahunAjaran == tahunAjaran && r.Nama.ToLower() == nama.ToLower()))
                continue;

            var rombel = new Rombel
            {
                Nama = nama.Trim().ApplyCase(LetterCasing.Title),
                Kelas = kelas,
                TahunAjaran = tahunAjaran,
                Wali = wali
            };

            _rombelRepository.Add(rombel);
            dataBaru.Add(rombel);
        }

        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
        {
            _toastrNotificationService.AddError("Simpan Gagal");
            return RedirectToAction(nameof(Rombel));
        }

        _toastrNotificationService.AddSuccess($"Simpan Berhasil. Berhasil menambahkan {dataBaru.Count} data");

        return View(new ImportVM<Rombel>
        {
            FileName = vm.FormFile.FileName,
            NewData = dataBaru
        });
    }

    public async Task<IActionResult> DownloadTemplateTP()
    {
        var daftarMataPelajaran = await _mataPelajaranRepository.GetAll();
        var fileBytes = System.IO.File.ReadAllBytes(
            Path.Combine(_webHostEnvironment.WebRootPath, "file/importTemplate/Template Import Data Tujuan Pembelajaran.xlsx"));

        using var memoryStream = new MemoryStream();
        memoryStream.Write(fileBytes, 0, fileBytes.Length);

        using var spreadSheet = SpreadsheetDocument.Open(
            memoryStream,
            isEditable: true);

        var workBookPart = spreadSheet.WorkbookPart!;

        var sheet = workBookPart.Workbook.Sheets!.Elements<Sheet>().First(a => a.Name == "Sheet2");
        var workSheetPart = (WorksheetPart)workBookPart.GetPartById(sheet.Id!);
        var sheetData = workSheetPart.Worksheet.Elements<SheetData>().First();

        foreach (var mataPelajaran in daftarMataPelajaran)
        {
            var row = new Row();
            var cell = new Cell
            {
                CellValue = new CellValue($"{mataPelajaran.Id} - {mataPelajaran.Nama} ({mataPelajaran.Peminatan.Nama})")
            };
            row.Append(cell);
            sheetData.Append(row);
        }

        sheet = workBookPart.Workbook.Sheets!.Elements<Sheet>().First()!;
        workSheetPart = (WorksheetPart)workBookPart.GetPartById(sheet.Id!);
        sheetData = workSheetPart.Worksheet.Elements<SheetData>().First();

        var dataValidation = new DataValidation
        {
            Type = DataValidationValues.List,
            AllowBlank = true,
            SequenceOfReferences = new ListValue<StringValue> { InnerText = "A2:A5" },
            Formula1 = new Formula1($"Sheet2!$A$1:$A${daftarMataPelajaran.Count}")
        };

        var dvs = workSheetPart.Worksheet.GetFirstChild<DataValidations>();
        if (dvs is not null)
        {
            dvs.Count = (dvs?.Count ?? 0) + 1;
            dvs!.Append(dataValidation);
        }
        else
        {
            var newDvs = new DataValidations();
            newDvs.AppendChild(dataValidation);
            newDvs.Count = (dvs?.Count ?? 0) + 1;
            workSheetPart.Worksheet.Append(newDvs);
        }

        workBookPart.Workbook.Descendants<WorkbookView>().First().ActiveTab = Convert
            .ToUInt32(workBookPart.Workbook.Descendants<Sheet>().ToList().IndexOf(sheet));

        spreadSheet.Save();

        return File(
            memoryStream.ToArray(),
            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            fileDownloadName: "Template Import Data Tujuan Pembelajaran.xlsx");
    }

    public IActionResult TujuanPembelajaran() => View(new ImportVM<TujuanPembelajaran>());

    [HttpPost]
    public async Task<IActionResult> TujuanPembelajaran(ImportVM<TujuanPembelajaran> vm)
    {
        if (!ModelState.IsValid) return View(vm);

        if (vm.FormFile is null)
        {
            ModelState.AddModelError(nameof(ImportVM<TujuanPembelajaran>.FormFile), "File harus diisi");
            return View(vm);
        }

        var file = await _fileService.ProcessFormFile<ImportVM<TujuanPembelajaran>>(
            vm.FormFile,
            [".xlsx"],
            0,
            long.MaxValue);

        if (file.IsFailure)
        {
            ModelState.AddModelError(nameof(ImportVM<TujuanPembelajaran>.FormFile), file.Error.Message);
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

        var daftarMataPelajaran = await _mataPelajaranRepository.GetAll();

        var dataBaru = new List<TujuanPembelajaran>();

        foreach (var row in sheetData.Elements<Row>().Skip(1))
        {
            var cells = row.Elements<Cell>().ToList();

            if (cells.Count != 4) continue;

            var mataPelajaranStr = GetCellValues(cells[0], sharedStrings);
            if (string.IsNullOrEmpty(mataPelajaranStr)) continue;
            var match = Regex.Match(mataPelajaranStr, @"(?<id>\d+) - (?:\w+\s*)+ \((?:\w+\s*)+\)");
            if (!match.Success || !match.Groups.TryGetValue("id", out var groupId))
                continue;
            var mataPelajaran = daftarMataPelajaran.FirstOrDefault(a => a.Id == int.Parse(groupId.Value));
            if (mataPelajaran is null) continue;

            var faseStr = GetCellValues(cells[1], sharedStrings);
            if (string.IsNullOrEmpty(faseStr) || !Enum.TryParse<Fase>(faseStr, out var fase))
                continue;

            var nomorStr = GetCellValues(cells[2], sharedStrings);
            if (string.IsNullOrEmpty(nomorStr) || 
                !int.TryParse(nomorStr, out var nomor) || 
                await _tujuanPembelajaranRepository.IsExist(nomor, mataPelajaran.Id, fase))
                continue;

            var deskripsi = GetCellValues(cells[3], sharedStrings);
            if (string.IsNullOrEmpty(deskripsi) || await _tujuanPembelajaranRepository.IsExist(deskripsi, mataPelajaran.Id, fase)) 
                continue;

            var tujuanPembelajaran = new TujuanPembelajaran
            {
                Fase = fase,
                Deskripsi = deskripsi,
                Nomor = nomor,
                MataPelajaran = mataPelajaran
            };

            _tujuanPembelajaranRepository.Add(tujuanPembelajaran);
            dataBaru.Add(tujuanPembelajaran);
        }

        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
        {
            _toastrNotificationService.AddError("Simpan Gagal");
            return RedirectToAction(nameof(TujuanPembelajaran));
        }

        _toastrNotificationService.AddSuccess($"Simpan Berhasil. Berhasil menambahkan {dataBaru.Count} data");

        return View(new ImportVM<TujuanPembelajaran>
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
