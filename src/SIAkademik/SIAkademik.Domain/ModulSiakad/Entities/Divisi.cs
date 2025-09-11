using SIAkademik.Domain.Abstracts;

namespace SIAkademik.Domain.ModulSiakad.Entities;

public class Divisi : Entity<int>
{
    public required string Nama { get; set; }

    public List<Pegawai> DaftarPegawai { get; set; } = [];
}
