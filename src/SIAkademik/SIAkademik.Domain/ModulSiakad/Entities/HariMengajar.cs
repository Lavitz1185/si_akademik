using SIAkademik.Domain.Abstracts;
using SIAkademik.Domain.Enums;

namespace SIAkademik.Domain.ModulSiakad.Entities;

public class HariMengajar : Entity<int>
{
    public required Hari Hari { get; set; }
    public required TimeOnly JamMulai { get; set; }
    public required TimeOnly JamAkhir { get; set; }

    public JadwalMengajar JadwalMengajar { get; set; }
}
