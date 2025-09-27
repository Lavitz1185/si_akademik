using System.ComponentModel.DataAnnotations;

namespace SIAkademik.Web.Areas.DashboardAdmin.Models.JadwalMengajarModels;

public class TambahVM
{
    [Display(Name = "Mata Pelajaran")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public int IdMataPelajaran { get; set; }

    [Display(Name = "Rombel")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public int IdRombel { get; set; }

    [Display(Name = "Guru")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public string NIPPegawai { get; set; } = string.Empty;

    [Display(Name = "Jumlah Pertemuan")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public int JumlahPertemuan { get; set; }

    [Display(Name = "Tahun Ajaran")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required int IdTahunAjaran { get; set; }
}
