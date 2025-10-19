using SIAkademik.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace SIAkademik.Web.Areas.DashboardAdmin.Models.Home;

public class UbahPasswordVM
{
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
