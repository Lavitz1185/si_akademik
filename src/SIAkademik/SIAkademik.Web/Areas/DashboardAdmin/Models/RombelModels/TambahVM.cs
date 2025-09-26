using System.ComponentModel.DataAnnotations;

namespace SIAkademik.Web.Areas.DashboardAdmin.Models.RombelModels;

public class TambahVM
{
    [Display(Name = "Nama")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public string Nama { get; set; } = string.Empty;

    [Display(Name = "Tahun Ajaran")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public int IdTahunAjaran { get; set; }

    [Display(Name = "Kelas")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public int IdKelas { get; set; }

    [Display(Name = "Guru Wali")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public string NIPWali { get; set; } = string.Empty;
}
