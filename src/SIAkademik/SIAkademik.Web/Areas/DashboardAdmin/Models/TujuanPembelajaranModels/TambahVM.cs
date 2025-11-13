using SIAkademik.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace SIAkademik.Web.Areas.DashboardAdmin.Models.TujuanPembelajaranModels;

public class TambahVM
{
    [Display(Name = "Nomor")]
    [Required(ErrorMessage = "{0} harus diisi")]
    [Range(1, int.MaxValue, ErrorMessage = "{0} harus 1 ke atas")]
    public int Nomor { get; set; }

    [Display(Name = "Deskripsi")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public string Deskripsi { get; set; } = string.Empty;

    [Display(Name = "Fase")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public Fase Fase { get; set; }

    [Display(Name = "Mata Pelajaran")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public int IdMataPelajaran { get; set; }

    public int? idMataPelajaran { get; set; }
    public Fase? fase { get; set; }

    public required string ReturnUrl { get; set; }
}
