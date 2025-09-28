using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Web.Areas.DashboardGuru.Models.KelasWaliModels;

public class IndexVM
{
    public TahunAjaran? TahunAjaran { get; set; }
    public List<Rombel> DaftarRombelWali { get; set; } = [];
}
