using System.ComponentModel.DataAnnotations;

namespace SIAkademik.Web.Areas.DashboardAdmin.Models.JadwalMengajarModels;

public class EditVM
{
    [Display(Name = "Id")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required int Id { get; set; }

    [Display(Name = "Durasi (Menit)")]
    [Required(ErrorMessage = "{0} harus diisi")]
    [Range(0, int.MaxValue, MaximumIsExclusive = false, ErrorMessage = "{0} minimail {1} menit")]
    public required int DurasiMenit { get; set; }

    [Display(Name = "Mata Pelajaran")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required int IdMataPelajaran { get; set; }

    [Display(Name = "Rombel")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required int IdRombel { get; set; }

    [Display(Name = "Guru")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string NIPPegawai { get; set; }

    [Display(Name = "Tahun Ajaran")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required int IdTahunAjaran { get; set; }

    public required string ReturnUrl { get; set; }
}
