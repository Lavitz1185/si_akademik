using SIAkademik.Domain.Abstracts;
using SIAkademik.Domain.Enums;

namespace SIAkademik.Domain.ModulSiakad.Entities;

public class MataPelajaran : Entity<int>
{
    public required string Nama { get; set; }
    public required double KKM { get; set; }

    public Peminatan Peminatan { get; set; }
    public List<JadwalMengajar> DaftarJadwalMengajar { get; set; } = [];
    public List<TujuanPembelajaran> DaftarTujuanPembelajaran { get; set; } = [];
}
