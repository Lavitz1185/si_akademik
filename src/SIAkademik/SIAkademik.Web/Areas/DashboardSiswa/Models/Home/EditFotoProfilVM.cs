using System.ComponentModel.DataAnnotations;

namespace SIAkademik.Web.Areas.DashboardSiswa.Models.Home;

public class EditFotoProfilVM
{
    public Uri? FotoProfilLama { get; set; }

    [Display(Name = "Foto Profil")]
    public IFormFile? FotoProfil { get; set; }
}
