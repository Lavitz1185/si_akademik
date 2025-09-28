using SIAkademik.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace SIAkademik.Web.Areas.DashboardGuru.Models.NilaiModels;

public class EditVM
{
    [Display(Name = "Id")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required int Id { get; set; }

    [Display(Name = "Deskripsi")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string Deskripsi { get; set; }

    [Display(Name = "Jenis")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required JenisNilai Jenis { get; set; }

    [Display(Name = "Skor")]
    [Required(ErrorMessage = "{0} harus diisi")]
    [Range(0d, double.MaxValue, ErrorMessage = "{0} harus antara {1} dan {2}")]
    public required double Skor { get; set; }
}