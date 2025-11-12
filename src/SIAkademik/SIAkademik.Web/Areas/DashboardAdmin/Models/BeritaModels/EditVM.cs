using SIAkademik.Web.Models;
using System.ComponentModel.DataAnnotations;

namespace SIAkademik.Web.Areas.DashboardAdmin.Models.BeritaModels;

public class EditVM
{
    [Display(Name = "Id")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required int Id { get; set; }

    [Display(Name = "Judul")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string Judul { get; set; }

    [Display(Name = "Isi")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string Isi { get; set; }

    [Display(Name = "Kategori")]
    [Required(ErrorMessage = "{0} harus dipilih")]
    public required int IdKategoriBerita { get; set; }

    [Display(Name = "Tanggal")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required DateOnly Tanggal { get; set; }

    [Display(Name = "Foto")]
    public IFormFile? FotoBaru { get; set; }
    public required Uri FotoLama { get; set; }

    public required string ReturnUrl { get; set; }
}
