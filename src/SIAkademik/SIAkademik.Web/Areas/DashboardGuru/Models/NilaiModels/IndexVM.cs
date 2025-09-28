using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Web.Areas.DashboardGuru.Models.NilaiModels;

public class IndexVM
{
    public TahunAjaran? TahunAjaran { get; set; }
    public JadwalMengajar? JadwalMengajar { get; set; }
    public List<JadwalMengajar> DaftarJadwalMengajar { get; set; } = [];
}
