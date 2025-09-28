using SIAkademik.Domain.Abstracts;
using SIAkademik.Domain.Enums;

namespace SIAkademik.Domain.ModulSiakad.Entities;

public class AbsenKelas : Entity<int>
{
    public required DateOnly Tanggal { get; set; }
    public required Absensi Absensi { get; set; }
    public string Catatan { get; set; } = string.Empty;

    public AnggotaRombel AnggotaRombel { get; set; }
}
