using System.ComponentModel.DataAnnotations;

namespace SIAkademik.Web.Areas.DashboardGuru.Models.Home;

public class EditFotoProfilVM
{
    public Uri? FotoProfilLama { get; set; }

    [Display(Name = "Foto Profil")]
    public IFormFile? FotoProfil { get; set; }
}
