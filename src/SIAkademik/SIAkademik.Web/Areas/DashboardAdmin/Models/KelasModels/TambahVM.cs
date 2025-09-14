using SIAkademik.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace SIAkademik.Web.Areas.DashboardAdmin.Models.KelasModels;

public class TambahVM
{
    [Display(Name = "Jenjang")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public Jenjang Jenjang { get; set; }

    [Display(Name = "Peminatan")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public Peminatan Peminatan { get; set; }

    [Display(Name = "Tahun Ajaran")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public int IdTahunAjaran { get; set; }
}
