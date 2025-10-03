using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Web.Areas.DashboardAdmin.Models.SiswaModels;

public class ProsesKelulusanVM
{
    public List<Siswa> DaftarSiswa { get; set; } = [];

    public int? IdTahunAjaran { get; set; }
    public List<ProsesKelulusanEntryVM> DaftarEntry { get; set; } = [];
}

public class ProsesKelulusanEntryVM
{
    public required int IdSiswa { get; set; }
    public required bool Luluskan { get; set; }
}
