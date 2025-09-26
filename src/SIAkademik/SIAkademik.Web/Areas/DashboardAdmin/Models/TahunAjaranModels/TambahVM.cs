using SIAkademik.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace SIAkademik.Web.Areas.DashboardAdmin.Models.TahunAjaranModels;

public class TambahVM
{
    [Display(Name = "Periode")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public string Periode { get; set; } = string.Empty;

    [Display(Name = "Tahun Pelaksanaan")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public int TahunPelaksanaan { get; set; }

    [Display(Name = "Periode")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public Semester Semester { get; set; }
}