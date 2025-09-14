using SIAkademik.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace SIAkademik.Web.Models;

public class AlamatVM
{
    [Display(Name = "RT")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public int RT { get; set; }

    [Display(Name = "RW")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public int RW { get; set; }

    [Display(Name = "Jalan")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public string Jalan { get; set; } = string.Empty;

    [Display(Name = "Kelurahan/Desa")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public string KelurahanDesa { get; set; } = string.Empty;

    [Display(Name = "Kecamatan")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public string Kecamatan { get; set; } = string.Empty;

    [Display(Name = "Kota/Kabupaten")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public string KotaKabupaten { get; set; } = string.Empty;

    [Display(Name = "Provinsi")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public string Provinsi { get; set; } = string.Empty;

    [Display(Name = "Kode Pos")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public string KodePos { get; set; } = string.Empty;
}

public interface IHaveAlamat
{
    AlamatVM Alamat { get; set; }
}
