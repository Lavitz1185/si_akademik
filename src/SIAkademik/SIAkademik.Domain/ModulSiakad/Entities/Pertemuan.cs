using SIAkademik.Domain.Abstracts;

namespace SIAkademik.Domain.ModulSiakad.Entities;

public class Pertemuan : Entity<int>
{
    public int Nomor { get; set; }
    public DateTime? TanggalPelaksanaan { get; set; }
    public string? Keterangan { get; set; }
    public required StatusPertemuan StatusPertemuan { get; set; }

    public List<Absen> DaftarAbsen { get; set; } = [];
    public JadwalMengajar JadwalMengajar { get; set; }
}
