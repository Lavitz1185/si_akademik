using SIAkademik.Domain.ModulProfil.Entities;
using SIAkademik.Web.Models;

namespace SIAkademik.Web.Areas.Profil.Models.BeritaModels;

public class IndexVM
{
    public required PagedList<Berita> DaftarBerita { get; set; }

    public string? SearchString { get; set; }
    public int? IdKategoriBerita { get; set; }
}
