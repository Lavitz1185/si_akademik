using System.ComponentModel.DataAnnotations;

namespace SIAkademik.Web.Areas.DashboardAdmin.Models.MataPelajaranModels;

public class TambahJadwalVM
{
    [Display(Name = "Mata Pelajaran")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public int IdMataPelajaran { get; set; } = string.Empty;

    [Display(Name = "Rombel")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public int IdaRombel { get; set; } = string.Empty;
}
