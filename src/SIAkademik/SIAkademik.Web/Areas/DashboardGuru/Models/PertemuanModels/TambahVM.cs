using System.ComponentModel.DataAnnotations;

namespace SIAkademik.Web.Areas.DashboardGuru.Models.PertemuanModels;

public class TambahVM
{
    [Display(Name = "Jadwal Mengajar")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required int IdJadwalMengajar { get; set; }

    [Display(Name = "Nomor")]
    [Required(ErrorMessage = "{0} harus diisi")]
    [Range(1, int.MaxValue, ErrorMessage = "{0} harus lebih besar dari 0")]
    public int Nomor { get; set; }

    [Display(Name = "Tanggal Pelaksanaan")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public DateOnly TanggalPelaksanaan { get; set; }

    [Display(Name = "Waktu Pelaksanaan")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public TimeOnly WaktuPelaksanaan { get; set; }
}
