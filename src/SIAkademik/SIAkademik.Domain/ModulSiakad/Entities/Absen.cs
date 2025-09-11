using SIAkademik.Domain.Abstracts;
using SIAkademik.Domain.Enums;

namespace SIAkademik.Domain.ModulSiakad.Entities;

public class Absen : Entity<int>
{
    public required DateOnly Tanggal { get; set; }
    public required Absensi Absensi { get; set; }
    public string? Keterangan { get; set; }

    public AnggotaRombel AnggotaRombel { get; set; }
}
