using SIAkademik.Domain.Abstracts;
using SIAkademik.Domain.Enums;
using System.Linq;

namespace SIAkademik.Domain.ModulSiakad.Entities;

public class AnggotaRombel : Entity<int>
{
    public required int IdSiswa { get; set; }
    public required int IdRombel { get; set; }
    public required DateOnly TanggalMasuk { get; set; }
    public DateOnly? TanggalKeluar { get; set; }

    public Rombel Rombel { get; set; }
    public Siswa Siswa { get; set; }
    public List<Absen> DaftarAbsen { get; set; } = [];
    public List<AbsenKelas> DaftarAbsenKelas { get; set; } = [];
    public List<Raport> DaftarRaport { get; set; } = [];

    public List<EvaluasiSiswa> DaftarEvaluasiSiswa { get; set; } = [];
    public List<NilaiEvaluasiSiswa> DaftarNilaiEvaluasiSiswa { get; set; } = [];

    public List<JadwalMengajar> DaftarJadwalMengajar { get; set; } = [];
    public List<AsesmenSumatifAkhirSemester> DaftarAsesmenSumatifAkhirSemester { get; set; } = [];

    public double NilaiAkhir(JadwalMengajar jadwalMengajar)
    {
        var asesmenSumatif = DaftarNilaiEvaluasiSiswa
            .GroupBy(n => n.EvaluasiSiswa.AsesmenSumatif)
            .Where(g => g.Key.JadwalMengajar == jadwalMengajar)
            .Select(g => g.Count() == 0 ? 0 : g.Average(n => n.Nilai)).Average();

        var asesmenSumatifAkhirSemester = DaftarAsesmenSumatifAkhirSemester.FirstOrDefault(a => a.JadwalMengajar == jadwalMengajar)?.Nilai ?? 0;

        return (asesmenSumatif + asesmenSumatifAkhirSemester) / 2;
    }
}
