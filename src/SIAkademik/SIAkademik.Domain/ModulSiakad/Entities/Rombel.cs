using SIAkademik.Domain.Abstracts;

namespace SIAkademik.Domain.ModulSiakad.Entities;

public class Rombel : Entity<int>
{
    public required string Nama { get; set; }

    public Kelas Kelas { get; set; }
    public Pegawai Wali { get; set; }
    public List<Siswa> DaftarSiswa { get; set; }
    public List<AnggotaRombel> DaftarAnggotaRombel { get; set; } = [];
    public List<JadwalMengajar> DaftarJadwalMengajar { get; set; } = [];
}