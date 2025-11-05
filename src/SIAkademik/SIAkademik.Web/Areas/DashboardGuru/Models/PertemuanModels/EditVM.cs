using System.ComponentModel.DataAnnotations;

namespace SIAkademik.Web.Areas.DashboardGuru.Models.PertemuanModels;

public class EditVM
{
    [Display(Name = "Id")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required int IdPertemuan { get; set; }

    [Display(Name = "Nomor")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required int Nomor { get; set; }

    [Display(Name = "Tanggal Pelaksanaan")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required DateTime TanggalPelaksanaan { get; set; }

    [Display(Name = "Keterangan")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string Keterangan { get; set; }
}
