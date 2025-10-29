using SIAkademik.Web.Models;
using System.ComponentModel.DataAnnotations;

namespace SIAkademik.Web.Areas.DashboardAdmin.Models.BeritaModels;

public class TambahVM
{
    [Display(Name = "Judul")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public string Judul { get; set; } = string.Empty;

    [Display(Name = "Isi")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public string Isi { get; set; } = string.Empty;

    [Display(Name = "Kategori")]
    [Required(ErrorMessage = "{0} harus dipilih")]
    public int IdKategoriBerita { get; set; }

    [Display(Name = "Tanggal")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public DateOnly Tanggal { get; set; } = DateOnly.FromDateTime(CultureInfos.DateTimeNow);

    [Display(Name = "Foto")]
    [Required(ErrorMessage = "{0} harus diupload")]
    public IFormFile? Foto { get; set; }
}
