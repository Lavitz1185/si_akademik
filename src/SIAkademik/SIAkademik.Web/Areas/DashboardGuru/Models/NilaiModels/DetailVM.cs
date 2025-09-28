using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Web.Areas.DashboardGuru.Models.NilaiModels;

public class DetailVM
{
    public required Siswa Siswa { get; set; }
    public required JadwalMengajar JadwalMengajar { get; set; }
    public List<Nilai> DaftarNilai { get; set; } = [];
}
