using SIAkademik.Domain.Abstracts;

namespace SIAkademik.Domain.ValueObjects;

public class Alamat : IEquatable<Alamat>
{
    public int RT { get; set; }
    public int RW { get; set; }
    public string Jalan { get; set; } = string.Empty;
    public string KelurahanDesa { get; set; } = string.Empty;
    public string Kecamatan { get; set; } = string.Empty;
    public string KotaKabupaten { get; set; } = string.Empty;
    public string Provinsi { get; set; } = string.Empty;
    public string KodePos { get; set; } = string.Empty;

    public static readonly Alamat Empty = new Alamat();

    public bool Equals(Alamat? other) => 
        other is not null &&
        other.RT == RT &&
        other.RW == RW &&
        other.Jalan == Jalan &&
        other.KelurahanDesa == KelurahanDesa &&
        other.Kecamatan == Kecamatan &&
        other.KotaKabupaten == KotaKabupaten &&
        other.Provinsi == Provinsi &&
        other.KodePos == KodePos;

    public override bool Equals(object? obj) => obj is not null && obj is Alamat a && Equals(a);

    public override int GetHashCode() =>
        (new object[] { RT, RW, Jalan, KelurahanDesa, Kecamatan, KotaKabupaten, Provinsi, KodePos })
        .Aggregate(default(int), HashCode.Combine);

    public override string ToString() => 
        $"{Jalan}, RT/RW {RT}/{RW}, {KelurahanDesa}, {Kecamatan}, {KotaKabupaten}, {Provinsi}, Kode Pos : {KodePos}";

    public static bool operator==(Alamat? left, Alamat? right) => left is not null && left.Equals(right);

    public static bool operator!=(Alamat? left, Alamat? right) => !(left == right);
}
