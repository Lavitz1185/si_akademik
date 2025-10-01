using SIAkademik.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace SIAkademik.Web.Areas.DashboardAdmin.Models.KelasModels;

public class EditVM
{
    [Display(Name = "Id")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required int Id { get; set; }

    [Display(Name = "Jenjang")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required Jenjang Jenjang { get; set; }

    [Display(Name = "Peminatan")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required int PeminatanId { get; set; }

    [Display(Name = "Tahun Ajaran")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required int IdTahunAjaran { get; set; }
}
