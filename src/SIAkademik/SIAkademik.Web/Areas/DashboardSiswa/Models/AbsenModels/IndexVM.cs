using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Web.Areas.DashboardSiswa.Models.AbsenModels;

public class IndexVM
{
    public required Siswa Siswa { get; set; }
    public AnggotaRombel? AnggotaRombel { get; set; }
    public TahunAjaran? TahunAjaran { get; set; }
    public int? IdTahunAjaran { get; set; }
    public List<AbsenKelas> DaftarAbsenKelas { get; set; } = [];
}
