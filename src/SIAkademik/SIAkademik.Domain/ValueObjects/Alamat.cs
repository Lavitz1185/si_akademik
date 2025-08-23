using SIAkademik.Domain.Abstracts;

namespace SIAkademik.Domain.ValueObjects;

public class Alamat : ValueObject
{
    public int RT { get; }
    public int RW { get; }
    public string Jalan { get; }
    public string KelurahanDesa { get; }
    public string Kecamatan { get; }
    public string KotaKabupaten { get; }
    public string Provinsi { get; }
    public string KodePos { get; }

    private Alamat(
        int rT,
        int rW,
        string jalan,
        string kelurahanDesa,
        string kecamatan,
        string kotaKabupaten,
        string provinsi,
        string kodePos)
    {
        RT = rT;
        RW = rW;
        Jalan = jalan;
        KelurahanDesa = kelurahanDesa;
        Kecamatan = kecamatan;
        KotaKabupaten = kotaKabupaten;
        Provinsi = provinsi;
        KodePos = kodePos;
    }

    public static Alamat Create(
        int rT,
        int rW,
        string jalan,
        string kelurahanDesa,
        string kecamatan,
        string kotaKabupaten,
        string provinsi,
        string kodePos)
    {
        return new(rT, rW, jalan, kelurahanDesa, kecamatan, kotaKabupaten, provinsi, kodePos);
    }

    protected override IEnumerable<object> GetAtomicValues() => [RT, RW, Jalan, KelurahanDesa, Kecamatan, KotaKabupaten, Provinsi];
}
