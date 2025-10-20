using SIAkademik.Domain.ModulSiakad.Entities;
using System.ComponentModel.DataAnnotations;

namespace SIAkademik.Web.Areas.DashboardAdmin.Models.SiswaModels;

public class ImportVM
{
    [Display(Name = "File (Excel : .xlsx)")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public IFormFile? FormFile { get; set; }

    public string? FileName { get; set; }
    public List<Siswa> DaftarSiswa { get; set; } = [];
}
