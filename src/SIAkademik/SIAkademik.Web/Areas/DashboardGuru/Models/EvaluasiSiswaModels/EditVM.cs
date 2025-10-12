using SIAkademik.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace SIAkademik.Web.Areas.DashboardGuru.Models.EvaluasiSiswaModels;

public class EditVM
{
    public required int Id { get; set; }
    public required JenisNilai Jenis { get; set; }

    [Display(Name = "Dekripsi")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string Deskripsi { get; set; }
}
