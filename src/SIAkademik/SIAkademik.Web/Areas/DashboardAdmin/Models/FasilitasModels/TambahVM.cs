using System.ComponentModel.DataAnnotations;

namespace SIAkademik.Web.Areas.DashboardAdmin.Models.FasilitasModels;

public class TambahVM
{
    [Display(Name = "Nama")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public string Nama { get; set; } = string.Empty;

    [Display(Name = "Deskripsi")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public string Deskripsi { get; set; } = string.Empty;

    [Display(Name = "Foto (.jpeg, .jpg, .png. Max 100KB)")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public IFormFile? Foto { get; set; }
}
