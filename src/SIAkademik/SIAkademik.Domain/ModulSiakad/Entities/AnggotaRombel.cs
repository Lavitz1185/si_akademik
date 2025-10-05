using SIAkademik.Domain.Abstracts;
using SIAkademik.Domain.Enums;
using System.Linq;

namespace SIAkademik.Domain.ModulSiakad.Entities;

public class AnggotaRombel : IEquatable<AnggotaRombel>
{
    public required int IdSiswa { get; set; }
    public required int IdRombel { get; set; }
    public required DateOnly TanggalMasuk { get; set; }
    public DateOnly? TanggalKeluar { get; set; }

    public Rombel Rombel { get; set; }
    public Siswa Siswa { get; set; }
    public List<Nilai> DaftarNilai { get; set; } = [];
    public List<Absen> DaftarAbsen { get; set; } = [];
    public List<AbsenKelas> DaftarAbsenKelas { get; set; } = [];
    public List<Raport> DaftarRaport { get; set; } = [];

    public bool Equals(AnggotaRombel? other) =>
        other is not null &&
        other.IdSiswa == IdSiswa &&
        other.IdRombel == IdRombel;

    public double RataTugas(JadwalMengajar jadwalMengajar)
    {
        var daftarNilai = DaftarNilai.Where(n => n.JadwalMengajar == jadwalMengajar && n.Jenis == JenisNilai.Tugas);

        if (daftarNilai.Count() == 0) return 0;
        else return daftarNilai.Average(n => n.Skor);
    }

    public double RataUH(JadwalMengajar jadwalMengajar)
    {
        var daftarNilai = DaftarNilai.Where(n => n.JadwalMengajar == jadwalMengajar && n.Jenis == JenisNilai.UH);

        if (daftarNilai.Count() == 0) return 0;
        else return daftarNilai.Average(n => n.Skor);
    }

    public double NilaiAkhir(JadwalMengajar jadwalMengajar)
    {
        var rataTugas = RataTugas(jadwalMengajar);
        var rataUH = RataUH(jadwalMengajar);
        var nilaiUTS = NilaiUTS(jadwalMengajar);
        var nilaiUAS = NilaiUAS(jadwalMengajar);

        return (rataTugas + rataUH + nilaiUTS + nilaiUAS) / 4;
    }

    public double NilaiUTS(JadwalMengajar jadwalMengajar) => DaftarNilai
        .Where(n => n.JadwalMengajar == jadwalMengajar && n.Jenis == JenisNilai.UTS)
        .FirstOrDefault()?.Skor ?? 0;

    public double NilaiUAS(JadwalMengajar jadwalMengajar) => DaftarNilai
        .Where(n => n.JadwalMengajar == jadwalMengajar && n.Jenis == JenisNilai.UAS)
        .FirstOrDefault()?.Skor ?? 0;

    public override bool Equals(object? obj) => obj is AnggotaRombel a && Equals(a);

    public override int GetHashCode() => HashCode.Combine(IdSiswa, IdRombel);

    public static bool operator ==(AnggotaRombel? left, AnggotaRombel? right) => left is not null && left.Equals(right);

    public static bool operator !=(AnggotaRombel? left, AnggotaRombel? right) => !(left == right);
}
