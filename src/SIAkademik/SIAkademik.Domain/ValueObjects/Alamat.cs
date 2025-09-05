using SIAkademik.Domain.Abstracts;

namespace SIAkademik.Domain.ValueObjects;

public class Alamat
{
    public required int RT { get; set; }
    public required int RW { get; set; }
    public required string Jalan { get; set;}
    public required string KelurahanDesa { get; set; }
    public required string Kecamatan { get; set; }
    public required string KotaKabupaten { get; set; }
    public required string Provinsi { get; set; }
    public required string KodePos { get; set; }
}
