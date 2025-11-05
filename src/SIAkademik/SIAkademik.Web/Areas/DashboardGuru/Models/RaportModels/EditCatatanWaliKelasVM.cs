using System.ComponentModel.DataAnnotations;

namespace SIAkademik.Web.Areas.DashboardGuru.Models.RaportModels;

public class EditCatatanWaliKelasVM
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

    [Display(Name = "Catatan Wali Kelas")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string CatatanWaliKelas { get; set; }
}
