using SIAkademik.Domain.Abstracts;

namespace SIAkademik.Domain.ModulSiakad.Entities;

public class Raport : Entity<int>
{
    public required string Predikat { get; set; }
    public required string Deskripsi { get; set; }
    public required KategoriNilaiRaport KategoriNilai { get; set; }

    public AnggotaRombel AnggotaRombel { get; set; }
    public JadwalMengajar? JadwalMengajar { get; set; }
}

public enum KategoriNilaiRaport
{
    Sikap, Pengetahuan, Keterampilan, Ekstrakulikuler
}
