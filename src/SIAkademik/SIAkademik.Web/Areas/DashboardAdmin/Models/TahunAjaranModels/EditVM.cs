using SIAkademik.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace SIAkademik.Web.Areas.DashboardAdmin.Models.TahunAjaranModels;

public class EditVM
{
    [Display(Name = "Id")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required int Id { get; init; }

    [Display(Name = "Periode")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required int Tahun1 { get; set; }

    [Display(Name = "Periode")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required int Tahun2 { get; set; }

    [Display(Name = "Tahun Pelaksanaan")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required int TahunPelaksanaan { get; set; }

    [Display(Name = "Semetser")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required Semester Semester { get; set; }

    [Display(Name = "Tanggal Mulai")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required DateOnly TanggalMulai { get; set; }

    [Display(Name = "Tanggal Selesai")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required DateOnly TanggalSelesai { get; set; }
}