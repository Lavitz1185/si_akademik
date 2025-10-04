using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Web.Areas.DashboardSiswa.Models.Home;

public class IndexVM
{
    public required DateOnly Tanggal { get; set; }
    public AnggotaRombel? AnggotaRombel { get; set; }
    public TahunAjaran? TahunAjaran { get; set; }
    public List<HariMengajar> DaftarHariMengajar { get; set; } = [];
}
