using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Web.Areas.DashboardGuru.Models.RaportModels;

public class DetailVM
{
    public required AnggotaRombel AnggotaRombel { get; set; }
    public required List<Raport> DaftarRaport { get; set; }
}
