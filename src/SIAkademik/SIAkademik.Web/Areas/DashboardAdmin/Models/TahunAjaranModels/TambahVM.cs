using SIAkademik.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace SIAkademik.Web.Areas.DashboardAdmin.Models.TahunAjaranModels;

public class TambahVM
{
    [Display(Name = "Periode")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public int Tahun1 { get; set; }

    [Display(Name = "Periode")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public int Tahun2 { get; set; }

    [Display(Name = "Tahun Pelaksanaan")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public int TahunPelaksanaan { get; set; }

    [Display(Name = "Semester")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public Semester Semester { get; set; }

    [Display(Name = "Tanggal Mulai")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public DateOnly TanggalMulai { get; set; }

    [Display(Name = "Tanggal Selesai")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public DateOnly TanggalSelesai { get; set; }
}