using SIAkademik.Domain.ModulProfil.Entities;

namespace SIAkademik.Web.Areas.Profil.Models.BeritaModels;

public class DetailVM
{
    public required Berita Berita { get; set; }
    public Berita? Sebelumnya { get; set; }
    public Berita? Selanjutnya { get; set; }
}
