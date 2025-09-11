using SIAkademik.Domain.Abstracts;

namespace SIAkademik.Domain.ValueObjects;

public class Alamat
{
    public int RT { get; set; }
    public int RW { get; set; }
    public string Jalan { get; set; } = string.Empty;
    public string KelurahanDesa { get; set; } = string.Empty;
    public string Kecamatan { get; set; } = string.Empty;
    public string KotaKabupaten { get; set; } = string.Empty;
    public string Provinsi { get; set; } = string.Empty;
    public string KodePos { get; set; } = string.Empty;
}
