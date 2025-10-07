using SIAkademik.Domain.Abstracts;
using SIAkademik.Domain.Enums;

namespace SIAkademik.Domain.ModulSiakad.Entities;

public class EvaluasiSiswa : Entity<int>
{
    public required string Deskripsi { get; set; }
    public required JenisNilai Jenis { get; set; }

    public JadwalMengajar JadwalMengajar { get; set; }
    public List<AnggotaRombel> DaftarAnggotaRombel { get; set; } = [];
    public List<NilaiEvaluasiSiswa> DaftarNilaiEvaluasiSiswa { get; set; } = [];
}
