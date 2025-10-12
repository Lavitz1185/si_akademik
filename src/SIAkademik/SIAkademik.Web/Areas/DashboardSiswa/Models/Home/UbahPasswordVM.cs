using SIAkademik.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace SIAkademik.Web.Areas.DashboardSiswa.Models.Home;

public class UbahPasswordVM
{
    public string Nama { get; set; }
    public string NISN { get; set; }
    public string NIS { get; set; }
    public JenisKelamin JenisKelamin { get; set; }
    public DateOnly TanggalLahir { get; set; }
    public string TempatLahir { get; set; }
    public Agama Agama { get; set; }
    public DateOnly TanggalMasuk { get; set; }
    public StatusAktifMahasiswa StatusAktif { get; set; }
    public Jenjang Jenjang { get; set; }
    public Uri? FotoProfil { get; set; }

    [Display(Name = "Password Lama")]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "{0} harus diisi")]
    public string PasswordLama { get; set; } = string.Empty;

    [Display(Name = "Password Baru")]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "{0} harus diisi")]
    [MinLength(8, ErrorMessage = "Panjang minimal 8")]
    [RegularExpression(
        pattern: "^.*(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[\\W]).*$", 
        ErrorMessage = "Password harus berisi huruf besar, huruf kecil, angka, dan karakter khusus")]
    public string PasswordBaru { get; set; } = string.Empty;

    [Display(Name = "Konfirmasi Password Baru")]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "{0} harus diisi")]
    [Compare(nameof(PasswordBaru), ErrorMessage = "{0} harus sama dengan {1}")]
    public string KonfirmasiPasswordBaru { get; set; } = string.Empty;
}