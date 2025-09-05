using SIAkademik.Domain.Abstracts;

namespace SIAkademik.Domain.Entities;

public class Jabatan : Entity<int>
{
    public required string Nama { get; set; }

    public List<Pegawai> DaftarPegawai { get; set; } = [];
}
