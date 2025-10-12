using SIAkademik.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace SIAkademik.Web.Areas.DashboardGuru.Models.EvaluasiSiswaModels;

public class TambahVM
{
    public required int IdAsesmenSumatif { get; set; }
    public required JenisNilai Jenis { get; set; }

    [Display(Name = "Dekripsi")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public string Deskripsi { get; set; } = string.Empty;
}
