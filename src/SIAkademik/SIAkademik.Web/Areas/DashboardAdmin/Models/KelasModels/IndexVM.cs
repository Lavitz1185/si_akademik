using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Web.Areas.DashboardAdmin.Models.KelasModels;

public class IndexVM
{
    public required TahunAjaran? TahunAjaran { get; set; }
    public required List<Kelas> DaftarKelas { get; set; }
}
