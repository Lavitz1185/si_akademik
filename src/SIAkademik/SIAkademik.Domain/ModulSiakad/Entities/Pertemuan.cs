using SIAkademik.Domain.Abstracts;

namespace SIAkademik.Domain.ModulSiakad.Entities;

public class Pertemuan : Entity<int>
{
    public string? Keterangan { get; set; }
    public required int Nomor { get; set; }
    public required DateTime TanggalPelaksanaan { get; set; }
    public required StatusPertemuan StatusPertemuan { get; set; }

    public TimeOnly JamSelesai => TimeOnly.FromDateTime(TanggalPelaksanaan).AddMinutes(JadwalMengajar.DurasiMenit);

    public List<Absen> DaftarAbsen { get; set; } = [];
    public JadwalMengajar JadwalMengajar { get; set; }
}
