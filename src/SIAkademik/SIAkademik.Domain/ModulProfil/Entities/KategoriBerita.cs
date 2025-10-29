using SIAkademik.Domain.Abstracts;

namespace SIAkademik.Domain.ModulProfil.Entities;

public class KategoriBerita : Entity<int>
{
    public required string Nama { get; set; }

    public List<Berita> DaftarBerita { get; set; } = [];
}
