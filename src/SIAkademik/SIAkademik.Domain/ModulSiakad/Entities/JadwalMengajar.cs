namespace SIAkademik.Domain.ModulSiakad.Entities;

public class JadwalMengajar : IEquatable<JadwalMengajar>
{
    public required string NIP { get; set; }
    public required int IdMataPelajaran { get; set; }
    public required int IdRombel { get; set; }

    public required DayOfWeek Hari { get; set; }
    public required TimeOnly JamMulai { get; set; }

    public Pegawai Pegawai { get; set; }
    public MataPelajaran MataPelajaran { get; set; } 
    public Rombel Rombel { get; set; }
    public List<Nilai> DaftarNilai { get; set; }

    public bool Equals(JadwalMengajar? other) =>
        other is not null &&
        other.NIP == NIP &&
        other.IdMataPelajaran == IdMataPelajaran &&
        other.IdRombel == IdRombel;

    public override bool Equals(object? obj) => obj is not null && obj is JadwalMengajar j && Equals(j);

    public override int GetHashCode() => HashCode.Combine(NIP, IdMataPelajaran, IdRombel);

    public static bool operator==(JadwalMengajar? left, JadwalMengajar? right) => left is not null && left.Equals(right);
    public static bool operator!=(JadwalMengajar? left, JadwalMengajar? right) => !(left == right);
}
