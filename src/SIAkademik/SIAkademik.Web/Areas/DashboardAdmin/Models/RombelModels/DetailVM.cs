using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Web.Areas.DashboardAdmin.Models.RombelModels;

public class DetailVM
{
    public required int Id { get; set; }
    public required Rombel Rombel { get; set; }

    public required List<DetailEntryVM> DaftarSiswaTambah { get; set; }
    public required List<DetailEntryVM> DaftarSiswaHapus { get; set; }

    public required string ReturnUrl { get; set; }
}

public class DetailEntryVM
{
    public required Siswa Siswa { get; set; }
    public required int IdSiswa { get; set; }
    public bool Selected { get; set; }
}
