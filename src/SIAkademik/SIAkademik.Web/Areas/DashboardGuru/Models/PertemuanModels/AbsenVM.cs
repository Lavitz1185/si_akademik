using SIAkademik.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace SIAkademik.Web.Areas.DashboardGuru.Models.PertemuanModels;

public class AbsenVM
{
    public required int IdPertemuan { get; set; }

    public required List<AbsenEntryVM> DaftarAbsen { get; set; }
}

public class AbsenEntryVM
{
    [Display(Name = "Id")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required int IdSiswa { get; set; }

    [Display(Name = "Siswa")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string NamaSiswa { get; set; }

    [Display(Name = "Absensi")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required Absensi Absensi { get; set; }
}
