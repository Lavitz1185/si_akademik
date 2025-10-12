using System.ComponentModel.DataAnnotations;

namespace SIAkademik.Web.Areas.DashboardGuru.Models.AsesmenSumatifModels;

public class TambahVM
{
    [Display(Name = "Jadwal Mengajar")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public int IdJadwalMengajar { get; set; }

    [Display(Name = "Tujuan Pembelajaran")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public int IdTujuanPembelajaran { get; set; }

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
