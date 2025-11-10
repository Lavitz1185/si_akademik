using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SIAkademik.Domain.Abstracts;
using SIAkademik.Domain.Authentication;
using SIAkademik.Domain.Enums;
using SIAkademik.Domain.ModulSiakad.Entities;
using SIAkademik.Domain.ModulSiakad.Repositories;
using SIAkademik.Domain.ValueObjects;
using SIAkademik.Infrastructure.Services.FileServices;
using SIAkademik.Web.Areas.DashboardGuru.Models.Import;
using SIAkademik.Web.Authentication;
using SIAkademik.Web.Models;
using SIAkademik.Web.Services.Toastr;
using System.Threading.Tasks;

namespace SIAkademik.Web.Areas.DashboardGuru.Controllers;

[Area(AreaNames.DashboardGuru)]
[Authorize(Roles = AppUserRoles.Guru)]
public class ImportController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IFileService _fileService;
    private readonly ITujuanPembelajaranRepository _tujuanPembelajaranRepository;
    private readonly IJadwalMengajarRepository _jadwalMengajarRepository;
    private readonly ITahunAjaranRepository _tahunAjaranRepository;
    private readonly IAsesmenSumatifRepository _asesmenSumatifRepository;
    private readonly IEvaluasiSiswaRepository _evaluasiSiswaRepository;
    private readonly IRombelRepository _rombelRepository;
    private readonly ISignInManager _signInManager;
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly IToastrNotificationService _toastrNotificationService;
    private readonly INilaiEvaluasiSiswaRepository _nilaiEvaluasiSiswaRepository;
    private readonly IAsesmenSumatifAkhirSemesterRepository _asesmenSumatifAkhirSemesterRepository;

    public ImportController(
        IUnitOfWork unitOfWork,
        IFileService fileService,
        ITujuanPembelajaranRepository tujuanPembelajaranRepository,
        IJadwalMengajarRepository jadwalMengajarRepository,
        ITahunAjaranRepository tahunAjaranRepository,
        IAsesmenSumatifRepository asesmenSumatifRepository,
        IEvaluasiSiswaRepository evaluasiSiswaRepository,
        IRombelRepository rombelRepository,
        ISignInManager signInManager,
        IWebHostEnvironment webHostEnvironment,
        IToastrNotificationService toastrNotificationService,
        INilaiEvaluasiSiswaRepository nilaiEvaluasiSiswaRepository,
        IAsesmenSumatifAkhirSemesterRepository asesmenSumatifAkhirSemesterRepository)
    {
        _unitOfWork = unitOfWork;
        _fileService = fileService;
        _tujuanPembelajaranRepository = tujuanPembelajaranRepository;
        _jadwalMengajarRepository = jadwalMengajarRepository;
        _tahunAjaranRepository = tahunAjaranRepository;
        _asesmenSumatifRepository = asesmenSumatifRepository;
        _evaluasiSiswaRepository = evaluasiSiswaRepository;
        _rombelRepository = rombelRepository;
        _signInManager = signInManager;
        _webHostEnvironment = webHostEnvironment;
        _toastrNotificationService = toastrNotificationService;
        _nilaiEvaluasiSiswaRepository = nilaiEvaluasiSiswaRepository;
        _asesmenSumatifAkhirSemesterRepository = asesmenSumatifAkhirSemesterRepository;
    }

    public async Task<IActionResult> DownloadFormatAsesmenSumatif(int idJadwalMengajar)
    {
        var pegawai = await _signInManager.GetPegawai();
        if (pegawai is null) return Forbid();

        var jadwalMengajar = await _jadwalMengajarRepository.Get(idJadwalMengajar);
        if (jadwalMengajar is null || jadwalMengajar.Pegawai != pegawai) return NotFound();

        var rombel = (await _rombelRepository.Get(jadwalMengajar.Rombel.Id))!;

        var fileBytes = System.IO.File.ReadAllBytes(
            Path.Combine(_webHostEnvironment.WebRootPath, "file/importTemplate/Template Import Data Asesmen Sumatif.xlsx"));

        using var memoryStream = new MemoryStream();
        memoryStream.Write(fileBytes, 0, fileBytes.Length);

        using var spreadSheet = SpreadsheetDocument.Open(
            memoryStream,
            isEditable: true);

        var workBookPart = spreadSheet.WorkbookPart!;

        var sheet = workBookPart.Workbook.Sheets!.Elements<Sheet>().First();
        var workSheetPart = (WorksheetPart)workBookPart.GetPartById(sheet.Id!);
        var sheetData = workSheetPart.Worksheet.Elements<SheetData>().First();

        uint rowNumber = 12;
        var orderedAsesmenSumatif = jadwalMengajar.DaftarAsesmenSumatif.OrderBy(a => a.TujuanPembelajaran.Nomor).ToList();

        #region DataUmum
        var tahunAjaranCell = sheetData.Descendants<Cell>().First(c => c.CellReference == "C1");
        tahunAjaranCell.CellValue = new CellValue(jadwalMengajar.Rombel.TahunAjaran.Periode);

        var semesterCell = sheetData.Descendants<Cell>().First(c => c.CellReference == "C2");
        semesterCell.CellValue = new CellValue(jadwalMengajar.Rombel.TahunAjaran.Semester.Humanize());

        var kelasCell = sheetData.Descendants<Cell>().First(c => c.CellReference == "C3");
        kelasCell.CellValue = new CellValue($"{jadwalMengajar.Rombel.Kelas.Jenjang} " +
            $"{jadwalMengajar.Rombel.Kelas.Peminatan.Nama} {jadwalMengajar.Rombel.Nama}");

        var mataPelajaranCell = sheetData.Descendants<Cell>().First(c => c.CellReference == "C4");
        mataPelajaranCell.CellValue = new CellValue($"{jadwalMengajar.MataPelajaran.Nama} ({jadwalMengajar.MataPelajaran.Peminatan.Nama})");

        var guruCell = sheetData.Descendants<Cell>().First(c => c.CellReference == "C5");
        guruCell.CellValue = new CellValue(jadwalMengajar.Pegawai.Nama);
        #endregion

        #region DataSiswa
        for (int i = 0; i < rombel.DaftarAnggotaRombel.Count; i++)
        {
            var anggotaRombel = rombel.DaftarAnggotaRombel[i];
            var row = new Row { RowIndex = rowNumber++ };

            row.Append(
                new Cell
                {
                    CellReference = $"A{row.RowIndex}",
                    CellValue = new CellValue($"{i + 1}"),
                    StyleIndex = 4
                },
                new Cell
                {
                    CellReference = $"B{row.RowIndex}",
                    CellValue = new CellValue($"{anggotaRombel.Siswa.Nama}"),
                    StyleIndex = 4
                },
                new Cell
                {
                    CellReference = $"C{row.RowIndex}",
                    CellValue = new CellValue($"{anggotaRombel.Siswa.NIS}"),
                    StyleIndex = 4
                },
                new Cell
                {
                    CellReference = $"D{row.RowIndex}",
                    CellValue = new CellValue($"{anggotaRombel.Siswa.NISN}"),
                    StyleIndex = 4
                }
            );

            for (int j = 0; j < orderedAsesmenSumatif.Count; j++)
                row.Append(new Cell
                {
                    CellReference = $"{(char)((byte)'E' + j)}{row.RowIndex}",
                    DataType = null,
                    CellValue = new CellValue(orderedAsesmenSumatif[j].RataNilai(anggotaRombel)),
                    StyleIndex = 4
                });

            sheetData.Append(row);
        }
        #endregion

        #region AsesmenSumatif
        rowNumber++;
        var keteranganRow = new Row { RowIndex = rowNumber++ };
        keteranganRow.Append(new Cell { CellValue = new CellValue("KETERANGAN") });
        sheetData.Append(keteranganRow);

        var rowAsesmen = sheetData.Descendants<Row>().First(r => r.RowIndex is not null && r.RowIndex == 10);
        var rowAsesmenNilai = sheetData.Descendants<Row>().First(r => r.RowIndex is not null && r.RowIndex == 11);
        var rowBatasBawahSB = sheetData.Descendants<Row>().First(r => r.RowIndex is not null && r.RowIndex == 6);
        var rowBatasBawahB = sheetData.Descendants<Row>().First(r => r.RowIndex is not null && r.RowIndex == 7);
        var rowBatasBawahC = sheetData.Descendants<Row>().First(r => r.RowIndex is not null && r.RowIndex == 8);

        if (jadwalMengajar.DaftarAsesmenSumatif.Count > 1)
            workSheetPart.Worksheet.Elements<MergeCells>().First().Append(new MergeCell
            {
                Reference = $"E9:{(char)((byte)('E') + jadwalMengajar.DaftarAsesmenSumatif.Count - 1)}9"
            });

        for (int i = 0; i < orderedAsesmenSumatif.Count; i++)
        {
            var asesmenSumatif = orderedAsesmenSumatif[i];
            var row = new Row { RowIndex = rowNumber++ };
            row.Append(new Cell
            {
                CellValue = new CellValue($"Sum{i + 1}:{asesmenSumatif.TujuanPembelajaran.Nomor} = {asesmenSumatif.TujuanPembelajaran.Deskripsi}")
            });

            rowAsesmen.Append(new Cell
            {
                CellReference = $"{(char)((byte)('E') + i)}{rowAsesmen.RowIndex}",
                CellValue = new CellValue($"Sum{i + 1}:{asesmenSumatif.TujuanPembelajaran.Nomor}"),
                StyleIndex = 4
            });

            rowAsesmenNilai.Append(new Cell
            {
                CellReference = $"{(char)((byte)('E') + i)}{rowAsesmenNilai.RowIndex}",
                CellValue = new CellValue("Nilai"),
                StyleIndex = 4
            });

            rowBatasBawahSB.Append(new Cell
            {
                CellReference = $"{(char)((byte)('E') + i)}{rowBatasBawahSB.RowIndex}",
                CellValue = new CellValue(asesmenSumatif.BatasBawahSangatBaik)
            });

            rowBatasBawahB.Append(new Cell
            {
                CellReference = $"{(char)((byte)('E') + i)}{rowBatasBawahB.RowIndex}",
                CellValue = new CellValue(asesmenSumatif.BatasBawahBaik)
            });

            rowBatasBawahC.Append(new Cell
            {
                CellReference = $"{(char)((byte)('E') + i)}{rowBatasBawahC.RowIndex}",
                CellValue = new CellValue(asesmenSumatif.BatasBawahCukup)
            });

            sheetData.Append(row);
        }

        var rowNilaiKetercapaian = new Row { RowIndex = rowNumber++ };
        rowNilaiKetercapaian.Append(new Cell { CellValue = new CellValue("Nilai Ketercapaian :") });
        sheetData.Append(rowNilaiKetercapaian);

        var rowNilaiKetercapaianKurang = new Row { RowIndex = rowNumber++ };
        rowNilaiKetercapaianKurang.Append(new Cell
        {
            CellValue = new CellValue("K = Kurang / belum mencapai standar/ Perlu Pendampingan dalam menguasai target capaian yang ditetapkan")
        });
        sheetData.Append(rowNilaiKetercapaianKurang);

        var rowNilaiKetercapaianCukup = new Row { RowIndex = rowNumber++ };
        rowNilaiKetercapaianCukup.Append(new Cell
        {
            CellValue = new CellValue("C = Cukup / cukup mencapai standar/ Perlu Penguatan dalam menguasai target capaian yang ditetapkan")
        });
        sheetData.Append(rowNilaiKetercapaianCukup);

        var rowNilaiKetercapaianBaik = new Row { RowIndex = rowNumber++ };
        rowNilaiKetercapaianBaik.Append(new Cell
        {
            CellValue = new CellValue("B = Baik / Menguasai target capaian dengan baik")
        });
        sheetData.Append(rowNilaiKetercapaianBaik);

        var rowNilaiKetercapaianSangatBaik = new Row { RowIndex = rowNumber++ };
        rowNilaiKetercapaianSangatBaik.Append(new Cell
        {
            CellValue = new CellValue("SB = Sangat Baik / Sangat Menguasai target capaian dengan")
        });
        sheetData.Append(rowNilaiKetercapaianSangatBaik);
        #endregion

        spreadSheet.Save();

        return File(
            memoryStream.ToArray(),
            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            fileDownloadName: "Template Import Data Asesmen Sumatif.xlsx");
    }

    public async Task<IActionResult> AsesmenSumatif(int? idTahunAjaran = null, int? idJadwalMengajar = null)
    {
        var pegawai = await _signInManager.GetPegawai();
        if (pegawai is null) return Forbid();

        var tahunAjaran = idTahunAjaran is null ?
            await _tahunAjaranRepository.Get(CultureInfos.DateOnlyNow) :
            await _tahunAjaranRepository.Get(idTahunAjaran.Value) ?? await _tahunAjaranRepository.GetNewest();

        if (tahunAjaran is null) return View(new AsesmenSumatifVM { Pegawai = pegawai });

        var daftarJadwalMengajar = await _jadwalMengajarRepository.GetAllByTahunAjaranAndPegawai(tahunAjaran.Id, pegawai.Id);

        var jadwalMengajar = idJadwalMengajar is null ?
            daftarJadwalMengajar.FirstOrDefault() :
            daftarJadwalMengajar.FirstOrDefault(j => j.Id == idJadwalMengajar.Value);

        jadwalMengajar ??= daftarJadwalMengajar.FirstOrDefault();

        if (jadwalMengajar is null)

            if (jadwalMengajar is null) return View(new AsesmenSumatifVM
        {
            Pegawai = pegawai,
            TahunAjaran = tahunAjaran,
            IdTahunAjaran = tahunAjaran.Id
        });

        if (jadwalMengajar.DaftarAsesmenSumatif.Count == 0)
            _toastrNotificationService.AddError("Belum ada capaian TP yang dipilih untuk mata pelajaran ini. " +
                "Silahkan pilih melalui menu Akademik > Jadwal Mengajar > Detail");

        return View(new AsesmenSumatifVM
        {
            Pegawai = pegawai,
            TahunAjaran = tahunAjaran,
            IdTahunAjaran = tahunAjaran.Id,
            JadwalMengajar = jadwalMengajar,
            IdJadwalMengajar = jadwalMengajar.Id
        });
    }

    [HttpPost]
    public async Task<IActionResult> AsesmenSumatif(AsesmenSumatifVM vm)
    {
        var pegawai = await _signInManager.GetPegawai();
        if (pegawai is null) return Forbid();

        vm.Pegawai = pegawai;

        if (vm.IdTahunAjaran is null)
        {
            _toastrNotificationService.AddError("Tahun ajaran harus dipilih");
            return RedirectToAction(nameof(AsesmenSumatif));
        }

        var tahunAjaran = await _tahunAjaranRepository.Get(vm.IdTahunAjaran.Value);
        if (tahunAjaran is null)
        {
            _toastrNotificationService.AddError("Tahun Ajaran tidak ditemukan");
            return RedirectToAction(nameof(AsesmenSumatif));
        }
        vm.TahunAjaran = tahunAjaran;

        if (vm.IdJadwalMengajar is null)
        {
            _toastrNotificationService.AddError("Jadwal Mengajar harus dipilih");
            return RedirectToAction(nameof(AsesmenSumatif), new { vm.IdTahunAjaran });
        }

        var jadwalMengajar = await _jadwalMengajarRepository.Get(vm.IdJadwalMengajar.Value);
        if (jadwalMengajar is null)
        {
            _toastrNotificationService.AddError("Jadwal Mengajar tidak ditemukan");
            return RedirectToAction(nameof(AsesmenSumatif), new { vm.IdTahunAjaran });
        }
        vm.JadwalMengajar = jadwalMengajar;

        if (vm.FormFile is null)
        {
            ModelState.AddModelError(nameof(vm.FormFile), "File harus diupload");
            return View(vm);
        }

        var file = await _fileService.ProcessFormFile<AsesmenSumatifVM>(
            vm.FormFile,
            [".xlsx"],
            0,
            long.MaxValue);

        if (file.IsFailure)
        {
            ModelState.AddModelError(nameof(AsesmenSumatifVM.FormFile), file.Error.Message);
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

        var rombel = (await _rombelRepository.Get(jadwalMengajar.Rombel.Id))!;
        var orderedAsesmenSumatif = jadwalMengajar.DaftarAsesmenSumatif.OrderBy(a => a.TujuanPembelajaran.Nomor).ToList();
        var daftarEvaluasiSiswa = new List<EvaluasiSiswa>();

        foreach (var asesmen in orderedAsesmenSumatif)
        {
            if (asesmen.DaftarEvaluasiSiswa.Count > 0)
                foreach (var evaluasiSiswa in asesmen.DaftarEvaluasiSiswa)
                    _evaluasiSiswaRepository.Delete(evaluasiSiswa);

            var evaluasi = new EvaluasiSiswa
            {
                Deskripsi = "Ulangan Harian",
                Jenis = JenisNilai.UlanganHarian,
                AsesmenSumatif = asesmen,
            };

            _evaluasiSiswaRepository.Add(evaluasi);
            daftarEvaluasiSiswa.Add(evaluasi);
        }

        const int startRowIndex = 12;
        const char startCollumnIndex = 'E';
        for (int i = 0; i < rombel.DaftarAnggotaRombel.Count; i++)
        {
            var anggotaRombel = rombel.DaftarAnggotaRombel[i];

            for (int j = 0; j < orderedAsesmenSumatif.Count; j++)
            {
                var asesmenSumatif = orderedAsesmenSumatif[j];
                var nilaiEvaluasiSiswa = new NilaiEvaluasiSiswa
                {
                    Nilai = 0,
                    AnggotaRombel = anggotaRombel,
                    EvaluasiSiswa = daftarEvaluasiSiswa[j]
                };

                var cell = sheetData.Descendants<Cell>()
                    .FirstOrDefault(c => c.CellReference == $"{(char)((byte)startCollumnIndex + j)}{startRowIndex + i}");


                if (cell is not null)
                {
                    var nilaiStr = GetCellValues(cell, sharedStrings);
                    if (!string.IsNullOrEmpty(nilaiStr) && double.TryParse(nilaiStr, out var nilai))
                        nilaiEvaluasiSiswa.Nilai = nilai;
                }

                _nilaiEvaluasiSiswaRepository.Add(nilaiEvaluasiSiswa);
            }
        }

        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
        {
            _toastrNotificationService.AddError("Simpan Gagal");
            return RedirectToAction(nameof(AsesmenSumatif), new { vm.IdTahunAjaran, vm.IdJadwalMengajar });
        }

        _toastrNotificationService.AddSuccess($"Simpan Berhasil");

        vm.FileName = vm.FormFile.FileName;
        vm.NewData = orderedAsesmenSumatif;
        return View(vm);
    }

    public async Task<IActionResult> DownloadFormatNilaiSAS(int idJadwalMengajar)
    {
        var pegawai = await _signInManager.GetPegawai();
        if (pegawai is null) return Forbid();

        var jadwalMengajar = await _jadwalMengajarRepository.Get(idJadwalMengajar);
        if (jadwalMengajar is null || jadwalMengajar.Pegawai != pegawai) return NotFound();

        var rombel = (await _rombelRepository.Get(jadwalMengajar.Rombel.Id))!;

        var fileBytes = System.IO.File.ReadAllBytes(
            Path.Combine(_webHostEnvironment.WebRootPath, "file/importTemplate/Template Import Data Nilai SAS.xlsx"));

        using var memoryStream = new MemoryStream();
        memoryStream.Write(fileBytes, 0, fileBytes.Length);

        using var spreadSheet = SpreadsheetDocument.Open(
            memoryStream,
            isEditable: true);

        var workBookPart = spreadSheet.WorkbookPart!;

        var sheet = workBookPart.Workbook.Sheets!.Elements<Sheet>().First();
        var workSheetPart = (WorksheetPart)workBookPart.GetPartById(sheet.Id!);
        var sheetData = workSheetPart.Worksheet.Elements<SheetData>().First();

        var rowIndex = 7u;

        #region DataUmum
        var tahunAjaranCell = sheetData.Descendants<Cell>().First(c => c.CellReference == "C1");
        tahunAjaranCell.CellValue = new CellValue(jadwalMengajar.Rombel.TahunAjaran.Periode);

        var semesterCell = sheetData.Descendants<Cell>().First(c => c.CellReference == "C2");
        semesterCell.CellValue = new CellValue(jadwalMengajar.Rombel.TahunAjaran.Semester.Humanize());

        var kelasCell = sheetData.Descendants<Cell>().First(c => c.CellReference == "C3");
        kelasCell.CellValue = new CellValue($"{jadwalMengajar.Rombel.Kelas.Jenjang} " +
            $"{jadwalMengajar.Rombel.Kelas.Peminatan.Nama} {jadwalMengajar.Rombel.Nama}");

        var mataPelajaranCell = sheetData.Descendants<Cell>().First(c => c.CellReference == "C4");
        mataPelajaranCell.CellValue = new CellValue($"{jadwalMengajar.MataPelajaran.Nama} ({jadwalMengajar.MataPelajaran.Peminatan.Nama})");

        var guruCell = sheetData.Descendants<Cell>().First(c => c.CellReference == "C5");
        guruCell.CellValue = new CellValue(jadwalMengajar.Pegawai.Nama);
        #endregion

        #region DataSiswa
        for (int i = 0; i < rombel.DaftarAnggotaRombel.Count; i++)
        {
            var anggotaRombel = rombel.DaftarAnggotaRombel[i];

            var row = new Row() { RowIndex = rowIndex++ };
            row.Append(
                new Cell { CellValue = new CellValue(i + 1) },
                new Cell { CellValue = new CellValue(anggotaRombel.Siswa.Nama) },
                new Cell { CellValue = new CellValue(anggotaRombel.Siswa.NIS) },
                new Cell { CellValue = new CellValue(anggotaRombel.Siswa.NISN) },
                new Cell { DataType = null }
            );

            sheetData.Append(row);
        }
        #endregion

        spreadSheet.Save();

        return File(
            memoryStream.ToArray(),
            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            fileDownloadName: "Template Import Data Nilai SAS.xlsx");
    }

    public async Task<IActionResult> NilaiSAS(int? idTahunAjaran = null, int? idJadwalMengajar = null)
    {
        var pegawai = await _signInManager.GetPegawai();
        if (pegawai is null) return Forbid();

        var tahunAjaran = idTahunAjaran is null ?
            await _tahunAjaranRepository.Get(CultureInfos.DateOnlyNow) :
            await _tahunAjaranRepository.Get(idTahunAjaran.Value) ?? await _tahunAjaranRepository.GetNewest();

        if (tahunAjaran is null) return View(new NilaiSASVM { Pegawai = pegawai });

        var daftarJadwalMengajar = await _jadwalMengajarRepository.GetAllByTahunAjaranAndPegawai(tahunAjaran.Id, pegawai.Id);

        var jadwalMengajar = idJadwalMengajar is null ?
            daftarJadwalMengajar.FirstOrDefault() :
            daftarJadwalMengajar.FirstOrDefault(j => j.Id == idJadwalMengajar.Value);

        jadwalMengajar ??= daftarJadwalMengajar.FirstOrDefault();

        if (jadwalMengajar is null)

            if (jadwalMengajar is null) return View(new NilaiSASVM
        {
            Pegawai = pegawai,
            TahunAjaran = tahunAjaran,
            IdTahunAjaran = tahunAjaran.Id
        });

        return View(new NilaiSASVM
        {
            Pegawai = pegawai,
            TahunAjaran = tahunAjaran,
            IdTahunAjaran = tahunAjaran.Id,
            JadwalMengajar = jadwalMengajar,
            IdJadwalMengajar = jadwalMengajar.Id
        });
    }

    [HttpPost]
    public async Task<IActionResult> NilaiSAS(NilaiSASVM vm)
    {
        var pegawai = await _signInManager.GetPegawai();
        if (pegawai is null) return Forbid();

        vm.Pegawai = pegawai;

        if (vm.IdTahunAjaran is null)
        {
            _toastrNotificationService.AddError("Tahun ajaran harus dipilih");
            return RedirectToAction(nameof(NilaiSAS));
        }

        var tahunAjaran = await _tahunAjaranRepository.Get(vm.IdTahunAjaran.Value);
        if (tahunAjaran is null)
        {
            _toastrNotificationService.AddError("Tahun Ajaran tidak ditemukan");
            return RedirectToAction(nameof(NilaiSAS));
        }
        vm.TahunAjaran = tahunAjaran;

        if (vm.IdJadwalMengajar is null)
        {
            _toastrNotificationService.AddError("Jadwal Mengajar harus dipilih");
            return RedirectToAction(nameof(NilaiSAS), new { vm.IdTahunAjaran });
        }

        var jadwalMengajar = await _jadwalMengajarRepository.Get(vm.IdJadwalMengajar.Value);
        if (jadwalMengajar is null)
        {
            _toastrNotificationService.AddError("Jadwal Mengajar tidak ditemukan");
            return RedirectToAction(nameof(NilaiSAS), new { vm.IdTahunAjaran });
        }
        vm.JadwalMengajar = jadwalMengajar;

        if (vm.FormFile is null)
        {
            ModelState.AddModelError(nameof(vm.FormFile), "File harus diupload");
            return View(vm);
        }

        var file = await _fileService.ProcessFormFile<NilaiSASVM>(
            vm.FormFile,
            [".xlsx"],
            0,
            long.MaxValue);

        if (file.IsFailure)
        {
            ModelState.AddModelError(nameof(NilaiSASVM.FormFile), file.Error.Message);
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

        var rombel = (await _rombelRepository.Get(jadwalMengajar.Rombel.Id))!;
        var dataBaru = new List<AsesmenSumatifAkhirSemester>();

        const int startRowIndex = 7;
        for (int i = 0; i < rombel.DaftarAnggotaRombel.Count; i++)
        {
            var anggotaRombel = rombel.DaftarAnggotaRombel[i];

            var asesmenAkhirSemester = anggotaRombel
                .DaftarAsesmenSumatifAkhirSemester
                .FirstOrDefault(a => a.JadwalMengajar == jadwalMengajar);

            if (asesmenAkhirSemester is null)
            {
                asesmenAkhirSemester = new AsesmenSumatifAkhirSemester
                {
                    AnggotaRombel = anggotaRombel,
                    JadwalMengajar = jadwalMengajar,
                    Nilai = 0,
                };
                _asesmenSumatifAkhirSemesterRepository.Add(asesmenAkhirSemester);
            }

            var cellNilai = sheetData.Descendants<Cell>().FirstOrDefault(c => c.CellReference == $"E{startRowIndex + i}");
            if (cellNilai is null) continue;

            var nilaiStr = GetCellValues(cellNilai, sharedStrings);
            if (string.IsNullOrEmpty(nilaiStr) || !double.TryParse(nilaiStr, out var nilai) || nilai < 0 || nilai > 100)
                continue;

            asesmenAkhirSemester.Nilai = nilai;
            dataBaru.Add(asesmenAkhirSemester);
        }

        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
        {
            _toastrNotificationService.AddError("Simpan Gagal");
            return RedirectToAction(nameof(NilaiSAS), new { vm.IdTahunAjaran, vm.IdJadwalMengajar });
        }

        _toastrNotificationService.AddSuccess($"Simpan Berhasil");

        vm.FileName = vm.FormFile.FileName;
        vm.NewData = dataBaru;
        return View(vm);
    }

    private string GetCellValues(Cell cell, List<string> sharedStrings)
    {
        if (cell.DataType is null) return cell.InnerText;
        return sharedStrings[int.Parse(cell.InnerText)];
    }
}
