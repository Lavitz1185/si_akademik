using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Web.Areas.DashboardGuru.Models.RaportModels;

public class IndexVM
{
    public required Pegawai Pegawai { get; set; }

    public TahunAjaran? TahunAjaran { get; set; }
    public int? IdTahunAjaran { get; set; }
    public Rombel? Rombel { get; set; }
    public int? IdRombel { get; set; }
}
