using System.ComponentModel.DataAnnotations;

namespace SIAkademik.Web.Areas.DashboardAdmin.Models.JadwalMengajarModels;

public class TambahVM
{
    [Display(Name = "Mata Pelajaran")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public int IdMataPelajaran { get; set; }

    [Display(Name = "Rombel")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public int IdRombel { get; set; }

    [Display(Name = "Guru")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public string NIPPegawai { get; set; } = string.Empty;

    public required int IdTahunAjaran { get; set; }
}
