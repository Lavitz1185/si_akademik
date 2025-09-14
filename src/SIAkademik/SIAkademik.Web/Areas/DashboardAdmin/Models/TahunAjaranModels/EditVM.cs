using SIAkademik.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace SIAkademik.Web.Areas.DashboardAdmin.Models.TahunAjaranModels;

public class EditVM
{
    [Display(Name = "Id")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required int Id { get; init; }

    [Display(Name = "Periode")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string Periode { get; set; } = string.Empty;

    [Display(Name = "Periode")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required Semester Semester { get; set; }
}