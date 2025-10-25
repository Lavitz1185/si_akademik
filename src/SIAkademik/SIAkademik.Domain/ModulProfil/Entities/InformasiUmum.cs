using SIAkademik.Domain.Abstracts;
using SIAkademik.Domain.ValueObjects;

namespace SIAkademik.Domain.ModulProfil.Entities;

public class InformasiUmum : Entity<int>
{
    public required string NamaSekolah { get; set; }
    public required string ProfilSingkatSekolah { get; set; }
    public required string SloganSekolah { get; set; }
    public required string AlamatSekolah { get; set; }
    public required NoHP NoHPSekolah { get; set; }
    public required string EmailSekolah { get; set; }
    public required Uri FacebookSekolah { get; set; }
    public required Uri InstagramSekolah { get; set; }
    public required string LirikMarsSekolah { get; set; }
    public required string VisiSekolah { get; set; }
    public required string MisiSekolah { get; set; }
    public required Uri LogoSekolah { get; set; }
    public required Uri VideoHalamanBeranda { get; set;}
    public required Uri VideoHalamanTentangKami { get; set; }

    public required string NamaYayasan { get; set; }
    public required string SambutanPimpinanYayasan { get; set; }
    public required string DewanPembinaYayasan { get; set; }
    public required string KetuaUmumYayasan { get; set; }
    public required string KetuaUmum2Yayasan { get; set; }
}
