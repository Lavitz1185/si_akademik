using SIAkademik.Domain.Abstracts;

namespace SIAkademik.Domain.ModulSiakad.Entities;

public class Pertemuan : Entity<int>
{
    public required int Nomor { get; set; }
    public required DateTime Tanggal { get; set; }
    public required string Keterangan { get; set; }
    public required StatusPertemuan StatusPertemuan { get; set; }

    public List<Absen> DaftarAbsen { get; set; } = [];
    public JadwalMengajar JadwalMengajar { get; set; }
}
