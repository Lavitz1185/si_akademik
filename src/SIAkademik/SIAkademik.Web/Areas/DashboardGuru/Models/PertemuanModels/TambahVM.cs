using System.ComponentModel.DataAnnotations;

namespace SIAkademik.Web.Areas.DashboardGuru.Models.PertemuanModels;

public class TambahVM
{
    [Display(Name = "Jadwal Mengajar")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required int IdJadwalMengajar { get; set; }

    [Display(Name = "Nomor")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public int Nomor { get; set; }
}
