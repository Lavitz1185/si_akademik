using SIAkademik.Domain.Abstracts;
using SIAkademik.Domain.Authentication;
using SIAkademik.Domain.Enums;
using SIAkademik.Domain.ValueObjects;
using System.Globalization;

namespace SIAkademik.Domain.ModulSiakad.Entities;

public class Siswa : Entity<int>
{
    public string TTL
    {
        get
        {
            var cu = new CultureInfo("id-ID");

            return $"{TempatLahir}, {TanggalLahir.ToString(cu.DateTimeFormat.LongDatePattern, cu)}";
        }
    }

    public bool IsBiodataComplete() =>
        Suku is not null &&
        AlamatLengkap.KodePos != Alamat.Empty.KodePos &&
        AlamatLengkap.Jalan != Alamat.Empty.Jalan &&
        AlamatLengkap.KelurahanDesa != Alamat.Empty.KelurahanDesa &&
        AlamatLengkap.Kecamatan != Alamat.Empty.Kecamatan &&
        AlamatLengkap.KotaKabupaten != Alamat.Empty.KotaKabupaten &&
        AlamatLengkap.Provinsi != Alamat.Empty.Provinsi &&
        GolonganDarah is not null &&
        TinggiBadan is not null &&
        BeratBadan is not null &&
        Hobi is not null &&
        NoHP is not null &&
        JumlahSaudara is not null &&
        AnakKe is not null &&
        AnakKe is not null &&
        AktaKelahiran is not null &&
        NomorKartuKeluarga is not null &&
        NomorKartuPelajar is not null &&
        Email is not null &&
        AsalSekolah is not null &&
        NamaAyah is not null &&
        NIKAyah is not null &&
        PekerjaanAyah is not null &&
        AgamaAyah is not null &&
        NoHPAyah is not null &&
        TanggalLahirAyah is not null &&
        StatusHidupAyah is not null &&
        PendidikanTerakhirAyah is not null &&
        NamaIbu is not null &&
        NIKIbu is not null &&
        PekerjaanIbu is not null &&
        AgamaIbu is not null &&
        NoHPIbu is not null &&
        TanggalLahirIbu is not null &&
        StatusHidupIbu is not null &&
        PendidikanTerakhirIbu is not null &&
        IjazahSMP is not null &&
        FotoProfil is not null;

    //Data Penting
    public required string Nama { get; set; }
    public required string NISN { get; set; }
    public required string NIS { get; set; }
    public required JenisKelamin JenisKelamin { get; set; }
    public required DateOnly TanggalLahir { get; set; }
    public required string TempatLahir { get; set; }
    public required Agama Agama { get; set; }
    public required DateOnly TanggalMasuk { get; set; }
    public required StatusAktifMahasiswa StatusAktif { get; set; }
    public required Jenjang Jenjang { get; set; }

    // Biodata Siswa
    public string? Suku { get; set; }
    public Alamat AlamatLengkap { get; set; } = new();
    public GolonganDarah? GolonganDarah { get; set; }
    public double? TinggiBadan { get; set; }
    public double? BeratBadan { get; set; }
    public string? Hobi { get; set; }
    public NoHP? NoHP { get; set; }
    public int? JumlahSaudara { get; set; }
    public int? AnakKe { get; set; }
    public string? NomorKartuKeluarga { get; set; }
    public string? NomorKartuPelajar { get; set; }
    public string? Email { get; set; }
    public string? AsalSekolah { get; set; }
    public Uri? AktaKelahiran { get; set; }
    public Uri? IjazahSMP { get; set; }
    public Uri? FotoProfil { get; set; }

    // Biodata Ayah
    public string? NamaAyah { get; set; }
    public string? NIKAyah { get; set; }
    public string? PekerjaanAyah { get; set; }
    public Agama? AgamaAyah { get; set; }
    public NoHP? NoHPAyah { get; set; }
    public DateOnly? TanggalLahirAyah { get; set; }
    public StatusHidup? StatusHidupAyah { get; set; }
    public string? PendidikanTerakhirAyah { get; set; }

    // Biodata Ibu
    public string? NamaIbu { get; set; }
    public string? NIKIbu { get; set; }
    public string? PekerjaanIbu { get; set; }
    public Agama? AgamaIbu { get; set; }
    public NoHP? NoHPIbu { get; set; }
    public DateOnly? TanggalLahirIbu { get; set; }
    public StatusHidup? StatusHidupIbu { get; set; }
    public string? PendidikanTerakhirIbu { get; set; }

    // Biodata Wali
    public string? NamaWali { get; set; }
    public string? NIKWali { get; set; }
    public string? PekerjaanWali { get; set; }
    public Agama? AgamaWali { get; set; }
    public NoHP? NoHPWali { get; set; }
    public DateOnly? TanggalLahirWali { get; set; }
    public StatusHidup? StatusHidupWali { get; set; }
    public string? PendidikanTerakhirWali { get; set; }
    public string? HubunganDenganWali { get; set; }

    public List<Rombel> DaftarRombel { get; set; }
    public List<AnggotaRombel> DaftarAnggotaRombel { get; set; } = [];
    public AppUser Account { get; set; }
}