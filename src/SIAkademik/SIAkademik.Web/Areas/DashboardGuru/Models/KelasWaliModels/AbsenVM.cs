using SIAkademik.Domain.Enums;
using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Web.Areas.DashboardGuru.Models.KelasWaliModels;

public class AbsenVM
{
    public required int Id { get; set; }
    public required Rombel Rombel { get; set; }
    public DateOnly Tanggal { get; set; }
    public List<AbsenEntryVM> DaftarAbsenEntry { get; set; } = [];
}

public class AbsenEntryVM
{
    public required int IdAbsen { get; set; }
    public required string NISSiswa { get; set; }
    public required string NISNSiswa { get; set; }
    public required string NamaSiswa { get; set; }
    public required string Catatan { get; set; }
    public required Absensi Absensi { get; set; }
}
