using SIAkademik.Domain.Enums;
using SIAkademik.Web.Models;
using System.ComponentModel.DataAnnotations;

namespace SIAkademik.Web.Areas.DashboardSiswa.Models.Home;

public class EditProfilVM : IHaveAlamat
{
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
    public required Uri? FotoProfil { get; set; }

    // Biodata Siswa
    [Display(Name = "Suku")]
    public required string? Suku { get; set; }

    [Display(Name = "Alamat")]
    public required AlamatVM? Alamat { get; set; }

    [Display(Name = "Golongan Darah")]
    public required GolonganDarah? GolonganDarah { get; set; }

    [Display(Name = "Tinggi Badan")]
    public required double? TinggiBadan { get; set; }

    [Display(Name = "Berat Badan")]
    public required double? BeratBadan { get; set; }

    [Display(Name = "Hobi")]
    public required string? Hobi { get; set; }

    [Display(Name = "No. HP/WA")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string? NoHP { get; set; }

    [Display(Name = "Jumlah Saudara")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required int? JumlahSaudara { get; set; }

    [Display(Name = "Anak Ke")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required int? AnakKe { get; set; }

    [Display(Name = "No. KK")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string? NomorKartuKeluarga { get; set; }

    [Display(Name = "No. Kartu Pelajar")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string? NomorKartuPelajar { get; set; }

    [Display(Name = "Email")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string? Email { get; set; }

    [Display(Name = "Asal Sekolah")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string? AsalSekolah { get; set; }

    [Display(Name = "Akta Kelahiran (PDF, JPG, JPEG) Ukuran Max 100Kb")]
    public IFormFile? AktaKelahiran { get; set; }
    public required Uri? AktaKelahiranLama { get; set; }

    [Display(Name = "Ijazah SMP (PDF, JPG, JPEG)  Ukuran Max 100Kb")]
    public IFormFile? IjazahSMP { get; set; }
    public required Uri? IjazahSMPLama { get; set; }

    // Biodata Ayah
    [Display(Name = "Nama")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string? NamaAyah { get; set; }

    [Display(Name = "NIK")]
    public required string? NIKAyah { get; set; }

    [Display(Name = "Pekerjaan")]
    public required string? PekerjaanAyah { get; set; }

    [Display(Name = "Agama")]
    public required Agama? AgamaAyah { get; set; }

    [Display(Name = "No. HP/WA")]
    public required string? NoHPAyah { get; set; }

    [Display(Name = "Tanggal Lahir")]
    public required DateOnly? TanggalLahirAyah { get; set; }

    [Display(Name = "Status Hidup")]
    public required StatusHidup? StatusHidupAyah { get; set; }

    [Display(Name = "Pendidikan Terakhir")]
    public required string? PendidikanTerakhirAyah { get; set; }

    // Biodata Ibu
    [Display(Name = "Nama")]
    public required string? NamaIbu { get; set; }

    [Display(Name = "NIK")]
    public required string? NIKIbu { get; set; }

    [Display(Name = "Pekerjaan")]
    public required string? PekerjaanIbu { get; set; }

    [Display(Name = "Agama")]
    public required Agama? AgamaIbu { get; set; }

    [Display(Name = "No. HP/WA")]
    public required string? NoHPIbu { get; set; }

    [Display(Name = "Tanggal Lahir")]
    public required DateOnly? TanggalLahirIbu { get; set; }

    [Display(Name = "Status Hidup")]
    public required StatusHidup? StatusHidupIbu { get; set; }

    [Display(Name = "Pendidikan Terakhir")]
    public required string? PendidikanTerakhirIbu { get; set; }

    // Biodata Wali
    [Display(Name = "Nama")]
    public required string? NamaWali { get; set; }

    [Display(Name = "NIK")]
    public required string? NIKWali { get; set; }

    [Display(Name = "Pekerjaan")]
    public required string? PekerjaanWali { get; set; }

    [Display(Name = "Agama")]
    public required Agama? AgamaWali { get; set; }

    [Display(Name = "No. HP/WA")]
    public required string? NoHPWali { get; set; }

    [Display(Name = "Tanggal Lahir")]
    public required DateOnly? TanggalLahirWali { get; set; }

    [Display(Name = "Status Hidup")]
    public required StatusHidup? StatusHidupWali { get; set; }

    [Display(Name = "Pendidikan Terakhir")]
    public required string? PendidikanTerakhirWali { get; set; }

    [Display(Name = "Hubungan Dengan Wali")]
    public required string? HubunganDenganWali { get; set; }
}
