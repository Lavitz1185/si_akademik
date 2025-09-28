using SIAkademik.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace SIAkademik.Web.Areas.DashboardGuru.Models.NilaiModels;

public class TambahVM
{
    public required int IdSiswa { get; set; }
    public required int IdJadwalMengajar { get; set; }

    [Display(Name = "Deskripsi")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public string Deskripsi { get; set; } = string.Empty;

    [Display(Name = "Jenis")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public JenisNilai Jenis { get; set; }

    [Display(Name = "Skor")]
    [Required(ErrorMessage = "{0} harus diisi")]
    [Range(0d, double.MaxValue, ErrorMessage = "{0} harus antara {1} dan {2}")]
    public double Skor { get; set; }
}