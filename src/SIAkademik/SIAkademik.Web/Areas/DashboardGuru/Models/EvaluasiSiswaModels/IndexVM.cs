using SIAkademik.Domain.Enums;
using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Web.Areas.DashboardGuru.Models.EvaluasiSiswaModels;

public class IndexVM
{
    public required Pegawai Pegawai { get; set; }

    public TahunAjaran? TahunAjaran { get; set; }
    public int? IdTahunAjaran { get; set; }

    public JadwalMengajar? JadwalMengajar { get; set; }
    public int? IdJadwalMengajar { get; set; }

    public required JenisNilai Jenis { get; set; }

    public List<EvaluasiSiswa> DaftarEvaluasiSiswa { get; set; } = [];
    public List<JadwalMengajar> DaftarJadwalMengajar { get; set; } = [];
}
