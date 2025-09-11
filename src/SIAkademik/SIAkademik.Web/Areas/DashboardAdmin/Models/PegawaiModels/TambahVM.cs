using SIAkademik.Domain.Enums;
using SIAkademik.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace SIAkademik.Web.Areas.DashboardAdmin.Models.PegawaiModels;

public class TambahVM
{
    [Display(Name = "NIP")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public string NIP { get; set; } = string.Empty;

    [Display(Name = "Nama")]
    [Required(ErrorMessage = "{0} harus diisi")]
	public string Nama { get; set; }  = string.Empty;

    [Display(Name = "Jenis Kelamin")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public JenisKelamin JenisKelamin { get; set; }

    [Display(Name = "Agama")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public string Agama { get; set; }  = string.Empty;

    [Display(Name = "Tanggal Lahir")]
    [Required(ErrorMessage = "{0} harus diisi")]
    [DataType(DataType.Date)]
    public DateOnly TanggalLahir { get; set; }

    [Display(Name = "Tempat Lahir")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public string TempatLahir { get; set; }   = string.Empty;

    [Display(Name = "Status Perkawinan")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public StatusPerkawinan StatusPerkawinan { get; set; }

    [Display(Name = "Alamat (KTP)")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public Alamat AlamatKTP { get; set; } = new();

    [Display(Name = "No. HP")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public string NoHP { get; set; }  = string.Empty;

    [Display(Name = "Golongan Darah")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public GolonganDarah GolonganDarah { get; set; }

    [Display(Name = "Email")]
    [Required(ErrorMessage = "{0} harus diisi")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }  = string.Empty;

    [Display(Name = "Tanggal Masuk")]
    [Required(ErrorMessage = "{0} harus diisi")]
    [DataType(DataType.Date)]
    public DateOnly TanggalMasuk { get; set; }

    [Display(Name = "NIK")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public string NIK { get; set; }  = string.Empty;

    [Display(Name = "Instagram")]
    public string? NamaInstagram { get; set; }

    [Display(Name = "No. Rekening")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public string NoRekening { get; set; }  = string.Empty;

    [Display(Name = "Divisi")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public int DivisiId { get; set; }

    [Display(Name = "Jabatan")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public int JabatanId { get; set; }

    [Display(Name = "Password")]
    [DataType(DataType.Password)]
    public string? Password { get; set; } = string.Empty;
}
