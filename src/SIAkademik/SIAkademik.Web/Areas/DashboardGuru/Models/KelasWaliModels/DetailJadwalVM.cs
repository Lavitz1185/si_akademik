using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Web.Areas.DashboardGuru.Models.KelasWaliModels;

public class DetailJadwalVM
{
    public required Rombel Rombel { get; set; }
    public required JadwalMengajar JadwalMengajar { get; set; }
    public Pertemuan? Pertemuan { get; set; }
}
