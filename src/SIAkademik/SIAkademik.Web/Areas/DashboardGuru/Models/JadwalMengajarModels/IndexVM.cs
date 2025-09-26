using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Web.Areas.DashboardGuru.Models.JadwalMengajarModels;

public class IndexVM
{
    public TahunAjaran? TahunAjaran { get; set; }
    public List<JadwalMengajar> DaftarJadwalMengajar { get; set; } = [];
}
