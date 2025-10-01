using SIAkademik.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace SIAkademik.Web.Areas.DashboardAdmin.Models.MataPelajaranModels;

public class EditVM
{
    [Display(Name = "Id")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required int Id { get; set; }

    [Display(Name = "Nama")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string Nama { get; set; }

    [Display(Name = "Jenjang")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required Jenjang Jenjang { get; set; }

    [Display(Name = "Peminatan")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required int PeminatanId { get; set; }

    [Display(Name = "KKM")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required double KKM { get; set; }
}
