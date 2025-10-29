using SIAkademik.Domain.Abstracts;

namespace SIAkademik.Domain.ModulProfil.Entities;

public class Berita : Entity<int>
{
    public required string Judul { get; set; }
    public required string Isi { get; set; }
    public required DateOnly Tanggal { get; set; }
    public required Uri Foto { get; set; } 

    public KategoriBerita KategoriBerita { get; set; }
}
