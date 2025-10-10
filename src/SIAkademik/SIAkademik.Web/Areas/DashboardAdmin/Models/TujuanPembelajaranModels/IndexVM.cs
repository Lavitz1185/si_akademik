using SIAkademik.Domain.Enums;
using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Web.Areas.DashboardAdmin.Models.TujuanPembelajaranModels;

public class IndexVM
{
    public int? IdMataPelajaran { get; set; }
    public Fase? Fase { get; set; }
    public List<TujuanPembelajaran> DaftarTujuanPembelajaran { get; set; } = []; 
}
