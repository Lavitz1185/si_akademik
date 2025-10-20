using SIAkademik.Domain.Abstracts;
using System.Text.RegularExpressions;

namespace SIAkademik.Domain.ValueObjects;

public partial class Alamat : IEquatable<Alamat>
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

    public static bool TryParse(string value, out Alamat result)
    {
        result = new Alamat();

        var match = Regex().Match(value);
        if (!match.Success ||
            !match.Groups.TryGetValue("Jalan", out var groupJalan) ||
            !match.Groups.TryGetValue("RT", out var groupRT) ||
            !match.Groups.TryGetValue("RW", out var groupRW) ||
            !match.Groups.TryGetValue("KelurahanDesa", out var groupKelurahanDesa) ||
            !match.Groups.TryGetValue("Kecamatan", out var groupKecamatan) ||
            !match.Groups.TryGetValue("KotaKabupaten", out var groupKotaKabupaten) ||
            !match.Groups.TryGetValue("Provinsi", out var groupProvinsi))
            return false;

        result.Jalan = groupJalan.Value;
        result.RT = int.Parse(groupRT.Value);
        result.RW = int.Parse(groupRW.Value);
        result.KelurahanDesa = groupKelurahanDesa.Value;
        result.Kecamatan = groupKecamatan.Value;
        result.KotaKabupaten = groupKotaKabupaten.Value;
        result.Provinsi = groupProvinsi.Value;

        return true;
    }

    [GeneratedRegex(@"^(?<Jalan>(?:[\w.]+\s*)+),\s*RT\/RW\s+(?<RT>\d+)\/(?<RW>\d+),\s*(?<KelurahanDesa>(?:Kelurahan|Desa)\s+(?:\w+\s*)+),\s*Kecamatan\s+(?<Kecamatan>(?:\w+\s*)+),\s*(?<KotaKabupaten>(?:Kota|Kabupaten)\s+(?:\w+\s*)+),\s*(?:Provinsi)*\s+(?<Provinsi>(?:\w+\s*)+)$")]
    private static partial Regex Regex();
}
