using SIAkademik.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace SIAkademik.Web.Areas.DashboardAdmin.Models.JadwalMengajarModels;

public class TambahHariVM
{
    [Display(Name = "Jadwal Mengajar")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required int IdJadwalMengajar { get; set; }

    [Display(Name = "Hari")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public Hari Hari { get; set; }

    [Display(Name = "Jam Mulai")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public TimeOnly JamMulai { get; set; }

    public required string ReturnUrl { get; set; }
}
