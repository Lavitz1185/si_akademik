using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Web.Areas.DashboardSiswa.Models.JadwalMengajarModels;

public class IndexVM
{
    public TahunAjaran? TahunAjaran { get; set; }
    public int? IdTahunAjaran { get; set; }
    public AnggotaRombel? AnggotaRombel { get; set; }
    public List<JadwalMengajar> DaftarJadwalMengajar { get; set; } = [];
}
