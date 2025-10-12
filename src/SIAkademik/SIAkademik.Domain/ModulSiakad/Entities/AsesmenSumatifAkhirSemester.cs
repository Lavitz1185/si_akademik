using SIAkademik.Domain.Abstracts;

namespace SIAkademik.Domain.ModulSiakad.Entities;

public class AsesmenSumatifAkhirSemester : JoinEntity
{
    public int JadwalMengajarId { get; set; }
    public int AnggotaRombelId { get; set; }
    public required double Nilai { get; set; }

    public JadwalMengajar JadwalMengajar { get; set; }
    public AnggotaRombel AnggotaRombel { get; set; }

    protected override IEnumerable<object> GetJoinKeys() => [JadwalMengajarId, AnggotaRombelId];
}
