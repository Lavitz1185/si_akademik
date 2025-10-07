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

    public double RataTugas(JadwalMengajar jadwalMengajar)
    {
        var daftarNilai = DaftarEvaluasiSiswa
            .Where(e => e.JadwalMengajar == jadwalMengajar && e.Jenis == JenisNilai.Tugas)
            .SelectMany(e => e.DaftarNilaiEvaluasiSiswa)
            .Where(f => f.AnggotaRombel == this)
            .Select(f => f.Nilai);

        return daftarNilai.Count() == 0 ? 0 : daftarNilai.Average();
    }

    public double RataUH(JadwalMengajar jadwalMengajar)
    {
        var daftarNilai = DaftarEvaluasiSiswa
            .Where(e => e.JadwalMengajar == jadwalMengajar && e.Jenis == JenisNilai.UH)
            .SelectMany(e => e.DaftarNilaiEvaluasiSiswa)
            .Where(f => f.AnggotaRombel == this)
            .Select(f => f.Nilai);

        return daftarNilai.Count() == 0 ? 0 : daftarNilai.Average();
    }

    public double NilaiAkhir(JadwalMengajar jadwalMengajar)
    {
        var rataTugas = RataTugas(jadwalMengajar);
        var rataUH = RataUH(jadwalMengajar);
        var nilaiUTS = NilaiUTS(jadwalMengajar);
        var nilaiUAS = NilaiUAS(jadwalMengajar);

        return (rataTugas + rataUH + nilaiUTS + nilaiUAS) / 4;
    }

    public double NilaiUTS(JadwalMengajar jadwalMengajar) => DaftarEvaluasiSiswa
            .Where(e => e.JadwalMengajar == jadwalMengajar && e.Jenis == JenisNilai.UTS)
            .SelectMany(e => e.DaftarNilaiEvaluasiSiswa)
            .FirstOrDefault(e => e.AnggotaRombel == this)?.Nilai ?? 0;

    public double NilaiUAS(JadwalMengajar jadwalMengajar) => DaftarEvaluasiSiswa
            .Where(e => e.JadwalMengajar == jadwalMengajar && e.Jenis == JenisNilai.UTS)
            .SelectMany(e => e.DaftarNilaiEvaluasiSiswa)
            .FirstOrDefault(e => e.AnggotaRombel == this)?.Nilai ?? 0;
}
