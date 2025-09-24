using System.ComponentModel.DataAnnotations;

namespace SIAkademik.Web.Areas.DashboardAdmin.Models.JadwalMengajarModels;

public class EditVM
{
    [Display(Name = "Id")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required int Id { get; set; }

    [Display(Name = "Mata Pelajaran")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required int IdMataPelajaran { get; set; }

    [Display(Name = "Rombel")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required int IdRombel { get; set; }

    [Display(Name = "Guru")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string NIPPegawai { get; set; }

    [Display(Name = "Tahun Ajaran")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required int IdTahunAjaran { get; set; }
}
