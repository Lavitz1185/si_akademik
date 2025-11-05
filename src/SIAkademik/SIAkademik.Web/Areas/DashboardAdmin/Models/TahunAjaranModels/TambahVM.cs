using SIAkademik.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace SIAkademik.Web.Areas.DashboardAdmin.Models.TahunAjaranModels;

public class TambahVM
{
    [Display(Name = "Tahun")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public int Tahun { get; set; }

    [Display(Name = "Semester")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public Semester Semester { get; set; }

    [Display(Name = "Tanggal Mulai")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public DateOnly TanggalMulai { get; set; }

    [Display(Name = "Tanggal Selesai")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public DateOnly TanggalSelesai { get; set; }

    public string? ReturnUrl { get; set; }
}