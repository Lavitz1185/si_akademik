using SIAkademik.Domain.ModulProfil.Entities;
using SIAkademik.Web.Models;

namespace SIAkademik.Web.Areas.DashboardAdmin.Models.BeritaModels;

public class IndexVM
{
    public List<FilterEntryVM<int>> KategoriBerita { get; set; } = [];
    public List<FilterEntryVM<int>> Bulan { get; set; } = [];
    public List<FilterEntryVM<int>> Tahun { get; set; } = [];

    public List<Berita> DaftarBerita { get; set; } = [];
}
