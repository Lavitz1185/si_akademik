using SIAkademik.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace SIAkademik.Web.Areas.DashboardAdmin.Models.InformasiUmumModels;

public class EditVM
{
    [Display(Name = "Nama Sekolah")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string NamaSekolah { get; set; }

    [Display(Name = "Profil Singkat Sekolah")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string ProfilSingkatSekolah { get; set; }

    [Display(Name = "Slogan Sekolah")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string SloganSekolah { get; set; }

    [Display(Name = "Alamat Sekolah")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string AlamatSekolah { get; set; }

    [Display(Name = "Nomor Telepon Sekolah")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string NoHPSekolah { get; set; }

    [Display(Name = "Email Sekolah")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string EmailSekolah { get; set; }

    [Display(Name = "Facebook Sekolah")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required Uri FacebookSekolah { get; set; }

    [Display(Name = "Instagram Sekolah")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required Uri InstagramSekolah { get; set; }

    [Display(Name = "Lirik Mars Sekolah")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string LirikMarsSekolah { get; set; }

    [Display(Name = "Visi Sekolah")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string VisiSekolah { get; set; }

    [Display(Name = "Misi Sekolah")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string MisiSekolah { get; set; }

    [Display(Name = "Logo Sekolah")]
    public IFormFile? LogoSekolahBaru { get; set; }
    public required Uri LogoSekolahLama { get; set; }

    [Display(Name = "Video Sambutan Halaman Beranda")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required Uri VideoHalamanBeranda { get; set; }

    [Display(Name = "Video Sambutan Halaman Tentang Kami")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required Uri VideoHalamanTentangKami { get; set; }

    [Display(Name = "Nama Yayasan")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string NamaYayasan { get; set; }

    [Display(Name = "Sambutan Pimpinan Yayasan")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string SambutanPimpinanYayasan { get; set; }

    [Display(Name = "Dewan Pembina Yayasan")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string DewanPembinaYayasan { get; set; }

    [Display(Name = "Ketua Umum Yayasan")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string KetuaUmumYayasan { get; set; }

    [Display(Name = "Ketua Umum II Yayasan")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string KetuaUmum2Yayasan { get; set; }
}
