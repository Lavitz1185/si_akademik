using SIAkademik.Domain.Abstracts;

namespace SIAkademik.Domain.ModulSiakad.Entities;

public class JadwalMengajar : Entity<int>
{
    public Pegawai Pegawai { get; set; }
    public MataPelajaran MataPelajaran { get; set; } 
    public Rombel Rombel { get; set; }
    public List<Raport> DaftarRaport { get; set; } = [];
    public List<HariMengajar> DaftarHariMengajar { get; set; } = [];
    public List<Nilai> DaftarNilai { get; set; } = [];
    public List<Pertemuan> DaftarPertemuan { get; set; } = [];
}
