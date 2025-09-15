using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Web.Areas.DashboardAdmin.Models.RombelModels;

public class IndexVM
{
    public TahunAjaran? TahunAjaran { get; set; }
    public Kelas? Kelas { get; set; }
    public List<Rombel> DaftarRombel { get; set; } = [];
}
