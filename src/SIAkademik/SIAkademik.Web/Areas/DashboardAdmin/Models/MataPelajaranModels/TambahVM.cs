using SIAkademik.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace SIAkademik.Web.Areas.DashboardAdmin.Models.MataPelajaranModels;

public class TambahVM
{
    [Display(Name = "Nama")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public string Nama { get; set; } = string.Empty;

    [Display(Name = "Jenjang")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public Jenjang Jenjang { get; set; }

    [Display(Name = "Peminatan")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public Peminatan Peminatan { get; set; }

    [Display(Name = "KKM")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public double KKM { get; set; }
}
