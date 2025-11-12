using SIAkademik.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace SIAkademik.Web.Areas.DashboardAdmin.Models.JadwalMengajarModels;

public class EditHariVM
{
    [Display(Name = "Id Hari Mengajar")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required int IdHariMengajar { get; set; }

    [Display(Name = "Jadwal Mengajar")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required int IdJadwalMengajar { get; set; }

    [Display(Name = "Hari")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required Hari Hari { get; set; }

    [Display(Name = "Jam Mulai")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required TimeOnly JamMulai { get; set; }

    public required string ReturnUrl { get; set; }
}
