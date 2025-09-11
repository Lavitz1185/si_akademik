using SIAkademik.Domain.Abstracts;

namespace SIAkademik.Domain.ModulSiakad.Entities;

public class AnggotaRombel : IEquatable<AnggotaRombel>
{
    public required string NISN { get; set; }
    public required int IdRombel { get; set; }
    public required DateOnly TanggalMasuk { get; set; }
    public DateOnly? TanggalKeluar { get; set; }

    public Rombel Rombel { get; set; }
    public Siswa Siswa { get; set; }
    public List<Nilai> DaftarNilai { get; set; } = [];
    public List<Absen> DaftarAbsen { get; set; } = [];

    public bool Equals(AnggotaRombel? other) =>
        other is not null &&
        other.NISN == NISN &&
        other.IdRombel == IdRombel;

    public override bool Equals(object? obj) => obj is AnggotaRombel a && Equals(a);

    public override int GetHashCode() => HashCode.Combine(NISN, IdRombel);

    public static bool operator==(AnggotaRombel? left, AnggotaRombel? right) => left is not null && left.Equals(right);

    public static bool operator!=(AnggotaRombel? left, AnggotaRombel? right) => !(left == right);
}
