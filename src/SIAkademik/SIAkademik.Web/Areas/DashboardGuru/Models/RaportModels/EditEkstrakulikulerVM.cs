using System.ComponentModel.DataAnnotations;

namespace SIAkademik.Web.Areas.DashboardGuru.Models.RaportModels;

public class EditEkstrakulikulerVM
{
    [Display(Name = "Tahun Ajaran")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required int IdTahunAjaran { get; set; }

    [Display(Name = "Rombel")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required int IdRombel { get; set; }

    [Display(Name = "Anggota Rombel")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required int IdEkstrakulikuler { get; set; }

    [Display(Name = "Nama")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string Nama { get; set; }

    [Display(Name = "Keterangan")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string Keterangan { get; set; }

    [Display(Name = "Predikat")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string Predikat { get; set; }
}
