using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Web.Areas.DashboardGuru.Models.RaportModels;

public class IndexVM
{
    public required Pegawai Pegawai { get; set; }

    public TahunAjaran? TahunAjaran { get; set; }
    public int? IdTahunAjaran { get; set; }
    public Rombel? Rombel { get; set; }
    public int? IdRombel { get; set; }

    public List<IndexEntryVM> DaftarEntryVM { get; set; } = [];
}

public class IndexEntryVM
{
    public required int IdAnggotaRombel { get; set; }
    public required AnggotaRombel AnggotaRombel { get; set; }
    public required bool Aktif { get; set; }

    public bool Selected { get; set; } = false;
}
