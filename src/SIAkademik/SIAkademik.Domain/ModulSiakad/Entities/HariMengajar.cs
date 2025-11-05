using SIAkademik.Domain.Abstracts;
using SIAkademik.Domain.Enums;

namespace SIAkademik.Domain.ModulSiakad.Entities;

public class HariMengajar : Entity<int>
{
    public required Hari Hari { get; set; }
    public required TimeOnly JamMulai { get; set; }

    public TimeOnly JamSelesai => JamMulai.AddMinutes(JadwalMengajar.DurasiMenit);

    public JadwalMengajar JadwalMengajar { get; set; }
}
