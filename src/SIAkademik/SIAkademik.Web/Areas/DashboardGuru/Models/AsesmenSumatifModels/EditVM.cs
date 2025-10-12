using System.ComponentModel.DataAnnotations;

namespace SIAkademik.Web.Areas.DashboardGuru.Models.AsesmenSumatifModels;

public class EditVM
{
    [Display(Name = "Id")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public int Id { get; set; }

    [Display(Name = "JadwalMengajar")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public int IdJadwalMengajar { get; set; }

    [Display(Name = "Batas Bawah Cukup")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public double BatasBawahCukup { get; set; }

    [Display(Name = "Batas Bawah Baik")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public double BatasBawahBaik { get; set; }

    [Display(Name = "Batas Bawah Sangat Baik")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public double BatasBawahSangatBaik { get; set; }
}
