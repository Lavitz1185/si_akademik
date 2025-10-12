using SIAkademik.Domain.Abstracts;

namespace SIAkademik.Domain.ModulSiakad.Entities;

public class AsesmenSumatif : Entity<int>
{
    public required int IdTujuanPembelajaran { get; set; }
    public required int IdJadwalMengajar { get; set; }
    public required double BatasBawahCukup { get; set; }
    public required double BatasBawahBaik { get; set; }
    public required double BatasBawahSangatBaik { get; set; }

    public TujuanPembelajaran TujuanPembelajaran { get; set; }
    public JadwalMengajar JadwalMengajar { get; set; }
    public List<EvaluasiSiswa> DaftarEvaluasiSiswa { get; set; } = [];
}