using SIAkademik.Domain.Abstracts;

namespace SIAkademik.Domain.Master;

public class Rombel : Entity<int>
{
    public required string Nama { get; set; }

    public Kelas Kelas { get; set; }
    public List<Siswa> DaftarSiswa { get; set; } = [];
}