using SIAkademik.Domain.Abstracts;
using SIAkademik.Domain.Enums;

namespace SIAkademik.Domain.Entities;

public class Nilai : Entity<int>
{
    public required double Skor { get; set; }
    public required string Deskripsi { get; set; }
    public required JenisNilai Jenis { get; set; }

    public AnggotaRombel AnggotaRombel { get; set; }
    public JadwalMengajar JadwalMengajar { get; set; }
}
