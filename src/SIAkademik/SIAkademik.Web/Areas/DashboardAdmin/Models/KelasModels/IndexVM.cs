using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Web.Areas.DashboardAdmin.Models.KelasModels;

public class IndexVM
{
    public required List<Kelas> DaftarKelas { get; set; }
}
