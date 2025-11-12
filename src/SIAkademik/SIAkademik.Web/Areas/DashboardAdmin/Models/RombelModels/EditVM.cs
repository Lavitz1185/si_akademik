using System.ComponentModel.DataAnnotations;

namespace SIAkademik.Web.Areas.DashboardAdmin.Models.RombelModels;

public class EditVM
{
    [Display(Name = "Id")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required int Id{ get; set; }

    [Display(Name = "Nama")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string Nama { get; set; }

    [Display(Name = "Kelas")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required int IdKelas { get; set; }

    [Display(Name = "Guru Wali")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string NIPWali { get; set; }

    public required int IdTahunAjaran { get; set; }

    public required string ReturnUrl { get; set; }
}
