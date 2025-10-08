using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Web.Areas.DashboardGuru.Models.Home;

public class IndexVM
{
    public required DateOnly Tanggal { get; set; }
    public required Pegawai Pegawai { get; set; }

    public TahunAjaran? TahunAjaran { get; set; }

    public List<HariMengajar> JadwalHariIni { get; set; } = [];
    public List<Rombel> RombelWali { get; set; } = [];
}
