using SIAkademik.Domain.Abstracts;
using SIAkademik.Domain.Enums;

namespace SIAkademik.Domain.ModulSiakad.Entities;

public class Jabatan : Entity<int>
{
    public required string Nama { get; set; }
    public required JenisJabatan Jenis { get; set; }

    public List<Pegawai> DaftarPegawai { get; set; } = [];
}
