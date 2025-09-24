using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Web.Areas.DashboardAdmin.Models.JadwalMengajarModels;

public class IndexVM
{
    public List<JadwalMengajar> DaftarJadwalMengajar { get; set; } = [];
    public TahunAjaran? TahunAjaran { get; set; }
}
