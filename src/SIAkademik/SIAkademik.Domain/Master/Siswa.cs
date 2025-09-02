using SIAkademik.Domain.Abstracts;
using SIAkademik.Domain.Enums;
using SIAkademik.Domain.ValueObjects;

namespace SIAkademik.Domain.Master;

public class Siswa : Entity<string>
{
    public string NISN => Id;

    // Biodata Siswa
    public required string Nama { get; set; }
    public required JenisKelamin JenisKelamin { get; set; }
    public required DateOnly TanggalLahir { get; set; }
    public required string TempatLahir { get; set; }
    public required string Agama { get; set; }
    public required string Suku { get; set; }
    public required string AsalSekolah { get; set; }
    public required Alamat AlamatLengkap { get; set; }
    public required GolonganDarah GolonganDarah { get; set; }
    public required double TinggiBadan { get; set; }
    public required double BeratBadan { get; set; }
    public required string Hobi { get; set; }
    public required NoHP NoHP { get; set; }
    public required int JumlahSaudara { get; set; }
    public required int AnakKe { get; set; }
    public required Uri AktaKelahiran { get; set; }
    public required string NomorKartuKeluarga { get; set; }
    public required Peminatan Peminatan { get; set; }

    // Biodata Ayah
    public required string NamaAyah { get; set; }
    public required string PekerjaanAyah { get; set; }
    public required string AgamaAyah { get; set; }
    public required NoHP NoHPAyah { get; set; }
    public required DateOnly TanggalLahirAyah { get; set; }
    public required StatusHidup StatusHidupAyah { get; set; }
    public required string PendidikanTerakhirAyah { get; set; }

    // Biodata Ibu
    public required string NamaIbu { get; set; }
    public required string PekerjaanIbu { get; set; }
    public required string AgamaIbu { get; set; }
    public required NoHP NoHPIbu { get; set; }
    public required DateOnly TanggalLahirIbu { get; set; }
    public required StatusHidup StatusHidupIbu { get; set; }
    public required string PendidikanTerakhirIbu { get; set; }

    // Biodata Wali
    public string? NamaWali { get; set; }
    public string? PekerjaanWali { get; set; }
    public string? AgamaWali { get; set; }
    public NoHP? NoHPWali { get; set; }
    public required DateOnly TanggalLahirWali { get; set; }
    public required StatusHidup StatusHidupWali { get; set; }
    public required string PendidikanTerakhirWali { get; set; }
    public string? HubunganDenganWali { get; set; }

    public Rombel Rombel { get; set; }
}