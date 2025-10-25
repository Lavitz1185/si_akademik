using System.ComponentModel.DataAnnotations;

namespace SIAkademik.Web.Areas.DashboardAdmin.Models.FasilitasModels;

public class EditVM
{
    [Display(Name = "Id")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required int Id { get; set; }

    [Display(Name = "Nama")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string Nama { get; set; }

    [Display(Name = "Deskripsi")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string Deskripsi { get; set; }

    [Display(Name = "Foto (.jpeg, .jpg, .png. Max 100KB)")]
    public required Uri FotoLama { get; set; }
    public IFormFile? FotoBaru { get; set; }
}
