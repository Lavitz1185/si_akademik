using SIAkademik.Domain.Abstracts;

namespace SIAkademik.Domain.ModulProfil.Entities;

public class Ekstrakurikuler : Entity<int>
{
    public required string Nama { get; set; }
    public required string Deskripsi { get; set; }
    public required Uri Foto { get; set; }
}
