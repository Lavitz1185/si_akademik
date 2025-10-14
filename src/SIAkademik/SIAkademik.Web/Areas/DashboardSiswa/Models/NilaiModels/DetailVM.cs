using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Web.Areas.DashboardSiswa.Models.NilaiModels;

public class DetailVM
{
    public required Siswa Siswa { get; set; }
    public required TahunAjaran TahunAjaran { get; set; }
    public required AnggotaRombel AnggotaRombel { get; set; }
    public required AsesmenSumatif AsesmenSumatif { get; set; }
}
