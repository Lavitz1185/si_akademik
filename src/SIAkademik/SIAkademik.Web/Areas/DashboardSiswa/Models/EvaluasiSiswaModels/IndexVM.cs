using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Web.Areas.DashboardSiswa.Models.NilaiModels;

public class IndexVM
{
    public required Siswa Siswa { get; set; }

    public AnggotaRombel? AnggotaRombel { get; set; }
    public int? IdTahunAjaran { get; set; }
    public TahunAjaran? TahunAjaran { get; set; }
    public List<JadwalMengajar> DaftarJadwalMengajar { get; set; } = [];
}
