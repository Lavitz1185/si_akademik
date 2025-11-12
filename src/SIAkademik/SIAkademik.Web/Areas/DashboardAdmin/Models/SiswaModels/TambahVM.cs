using SIAkademik.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace SIAkademik.Web.Areas.DashboardAdmin.Models.SiswaModels;

public class TambahVM
{
    [Display(Name = "NISN")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public string NISN { get; set; } = string.Empty;

    [Display(Name = "Nama")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public string Nama { get; set; } = string.Empty;

    [Display(Name = "NIS")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public string NIS { get; set; } = string.Empty;

    [Display(Name = "Jenis Kelamin")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public JenisKelamin JenisKelamin { get; set; }

    [Display(Name = "Tanggal Lahir")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public DateOnly TanggalLahir { get; set; }

    [Display(Name = "Tempat Lahir")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public string TempatLahir { get; set; } = string.Empty;

    [Display(Name = "Agama")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public Agama Agama { get; set; }

    [Display(Name = "Tanggal Masuk")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public DateOnly TanggalMasuk { get; set; }

    [Display(Name = "Status Aktif")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public StatusAktifMahasiswa StatusAktif { get; set; }

    [Display(Name = "Jenjang")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public Jenjang Jenjang { get; set; }

    public required string ReturnUrl { get; set; }
}
