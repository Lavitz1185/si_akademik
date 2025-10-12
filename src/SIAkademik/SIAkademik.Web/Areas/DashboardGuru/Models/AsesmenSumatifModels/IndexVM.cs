using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Web.Areas.DashboardGuru.Models.AsesmenSumatifModels;

public class IndexVM
{
    public required Pegawai Pegawai { get; set; }

    public int? IdTahunAjaran { get; set; }
    public int? IdJadwalMengajar { get; set; }
    public int? IdAsesmenSumatif { get; set; }

    public TahunAjaran? TahunAjaran { get; set; }
    public JadwalMengajar? JadwalMengajar { get; set; }
    public AsesmenSumatif? AsesmenSumatif { get; set; }
}
