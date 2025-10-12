using SIAkademik.Domain.Abstracts;
using SIAkademik.Domain.Enums;

namespace SIAkademik.Domain.ModulSiakad.Entities;

public class TujuanPembelajaran : Entity<int>
{
    public required int Nomor { get; set; }
    public required string Deskripsi { get; set; }
    public required Fase Fase { get; set; }

    public MataPelajaran MataPelajaran { get; set; }
    public List<JadwalMengajar> DaftarJadwalMengajar { get; set; } = [];
    public List<AsesmenSumatif> DaftarAsesmenSumatif { get; set; } = [];

    public static Fase FaseFromJenjang(Jenjang jenjang) => jenjang switch
    {
        Jenjang.X => Fase.E,
        Jenjang.XI => Fase.F,
        Jenjang.XII => Fase.F,
        _ => throw new ArgumentOutOfRangeException(nameof(jenjang), $"Not expected Jenjang value: {jenjang}")
    };
}
