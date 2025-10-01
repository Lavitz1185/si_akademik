using SIAkademik.Domain.Abstracts;
using SIAkademik.Domain.Enums;

namespace SIAkademik.Domain.ModulSiakad.Entities;

public class Peminatan : Entity<int>
{
    public required string Nama { get; set; }
    public required JenisPeminatan Jenis { get; set; }

    public List<Kelas> DaftarKelas { get; set; } = [];
    public List<MataPelajaran> DaftarMataPelajaran { get; set; } = [];
}