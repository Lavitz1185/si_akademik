using System.ComponentModel.DataAnnotations;

namespace SIAkademik.Web.Areas.DashboardGuru.Models.JadwalMengajarModels;

public class MulaiVM
{
    [Display(Name = "Id")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required int Id { get; set; }

    [Display(Name = "Tanggal")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public DateTime TanggalPelaksanaan { get; set; }

    [Display(Name = "Keterangan")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public string Keterangan { get; set; } = string.Empty;
}
