using SIAkademik.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace SIAkademik.Web.Areas.DashboardAdmin.Models.SiswaModels;

public class EditVM
{
    [Display(Name = "Id")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required int Id { get; set; }

    [Display(Name = "NISN")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string NISN { get; set; }

    [Display(Name = "Nama")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string Nama { get; set; }

    [Display(Name = "NIS")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string NIS { get; set; }

    [Display(Name = "Jenis Kelamin")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required JenisKelamin JenisKelamin { get; set; }

    [Display(Name = "Tanggal Lahir")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required DateOnly TanggalLahir { get; set; }

    [Display(Name = "Tempat Lahir")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string TempatLahir { get; set; }

    [Display(Name = "Agama")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required Agama Agama { get; set; }

    [Display(Name = "Tanggal Masuk")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required DateOnly TanggalMasuk { get; set; }

    [Display(Name = "Status Aktif")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required StatusAktifMahasiswa StatusAktif { get; set; }

    [Display(Name = "Jenjang")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required Jenjang Jenjang { get; set; }
}
