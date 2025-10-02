using SIAkademik.Domain.ModulSiakad.Entities;
using System.ComponentModel.DataAnnotations;

namespace SIAkademik.Web.Areas.DashboardGuru.Models.RaportModels;

public class EditVM
{
    [Display(Name = "Id")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required int Id { get; set; }

    [Display(Name = "Kategori")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required KategoriNilaiRaport Kategori { get; set; }

    [Display(Name = "Predikat")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string Predikat { get; set; }

    [Display(Name = "Keterangan")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string Dekripsi { get; set; }

    [Display(Name = "Nama")]
    public string? Nama { get; set; }

    [Display(Name = "Jadwal Mengajar")]
    public int? IdJadwalMengajar { get; set; }
}
