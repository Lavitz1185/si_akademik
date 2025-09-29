using SIAkademik.Domain.ModulSiakad.Entities;
using System.ComponentModel.DataAnnotations;

namespace SIAkademik.Web.Areas.DashboardGuru.Models.RaportModels;

public class TambahVM
{
    [Display(Name = "Siswa")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required int IdSiswa { get; set; }

    [Display(Name = "Rombel")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required int IdRombel { get; set; }

    [Display(Name = "Kategori")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required KategoriNilaiRaport Kategori { get; set; }

    
    public int? IdJadwalMengajar { get; set; }
}
