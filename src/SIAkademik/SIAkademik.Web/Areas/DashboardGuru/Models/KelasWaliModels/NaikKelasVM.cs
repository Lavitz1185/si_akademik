using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Web.Areas.DashboardGuru.Models.KelasWaliModels;

public class NaikKelasVM
{
    public required Pegawai Pegawai { get; set; }

    public int? IdTahunAjaran { get; set; }
    public TahunAjaran? TahunAjaran { get; set; }

    public int? IdRombel { get; set; }
    public Rombel? Rombel { get; set; }

    public int? IdRombelTinggal { get; set; }
    public Rombel? RombelTinggal { get; set; }

    public int? IdRombelNaikKelas { get; set; }
    public Rombel? RombelNaikKelas { get; set; }

    public List<NaikKelasEntryVM> DaftarEntry { get; set; } = [];
}

public class NaikKelasEntryVM
{
    public required int IdAnggotaRombel { get; set; }
    public required AnggotaRombel AnggotaRombel { get; set; }
    public bool Selected { get; set; }
}
