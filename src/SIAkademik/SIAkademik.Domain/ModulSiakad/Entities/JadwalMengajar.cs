using SIAkademik.Domain.Abstracts;

namespace SIAkademik.Domain.ModulSiakad.Entities;

public class JadwalMengajar : Entity<int>
{
    public Pegawai Pegawai { get; set; }
    public MataPelajaran MataPelajaran { get; set; } 
    public Rombel Rombel { get; set; }
    public List<Raport> DaftarRaport { get; set; } = [];
    public List<HariMengajar> DaftarHariMengajar { get; set; } = [];
    public List<EvaluasiSiswa> DaftarEvaluasiSiswa { get; set; } = [];
    public List<Pertemuan> DaftarPertemuan { get; set; } = [];

    public List<TujuanPembelajaran> DaftarTujuanPembelajaran { get; set; } = [];
    public List<AsesmenSumatif> DaftarAsesmenSumatif { get; set; } = [];

    public List<AnggotaRombel> DaftarAnggotaRombel { get; set; } = [];
    public List<AsesmenSumatifAkhirSemester> DaftarAsesmenSumatifAkhirSemester { get; set; } = [];
}
