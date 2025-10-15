using System.ComponentModel.DataAnnotations;

namespace SIAkademik.Web.Areas.DashboardGuru.Models.RaportModels;

public class TambahEkstrakulikulerVM
{
    [Display(Name = "Tahun Ajaran")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required int IdTahunAjaran { get; set; }

    [Display(Name = "Rombel")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required int IdRombel { get; set; }

    [Display(Name = "Anggota Rombel")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required int IdAnggotaRombel { get; set; }

    [Display(Name = "Nama")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public string Nama { get; set; } = string.Empty;

    [Display(Name = "Keterangan")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public string Keterangan { get; set; } = string.Empty;

    [Display(Name = "Predikat")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public string Predikat { get; set; } = string.Empty;
}
