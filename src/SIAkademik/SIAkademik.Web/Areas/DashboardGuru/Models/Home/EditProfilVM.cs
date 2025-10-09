using SIAkademik.Domain.Enums;
using SIAkademik.Web.Models;
using System.ComponentModel.DataAnnotations;

namespace SIAkademik.Web.Areas.DashboardGuru.Models.Home;

public class EditProfilVM : IHaveAlamat
{
    [Display(Name = "Nama")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string Nama { get; set; }

    [Display(Name = "Jenis Kelamin")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required JenisKelamin JenisKelamin { get; set; }

    [Display(Name = "Agama")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required Agama Agama { get; set; }

    [Display(Name = "Tanggal Lahir")]
    [Required(ErrorMessage = "{0} harus diisi")]
    [DataType(DataType.Date)]
    public required DateOnly TanggalLahir { get; set; }

    [Display(Name = "Tempat Lahir")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string TempatLahir { get; set; }

    [Display(Name = "Status Perkawinan")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required StatusPerkawinan StatusPerkawinan { get; set; }

    [Display(Name = "Alamat (KTP)")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required AlamatVM Alamat { get; set; }

    [Display(Name = "No. HP")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string NoHP { get; set; }

    [Display(Name = "Golongan Darah")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required GolonganDarah GolonganDarah { get; set; }

    [Display(Name = "Email")]
    [Required(ErrorMessage = "{0} harus diisi")]
    [DataType(DataType.EmailAddress)]
    public required string Email { get; set; }

    [Display(Name = "NIK")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string NIK { get; set; }

    [Display(Name = "Instagram")]
    public required string NamaInstagram { get; set; }

    [Display(Name = "No. Rekening")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string NoRekening { get; set; }
}
