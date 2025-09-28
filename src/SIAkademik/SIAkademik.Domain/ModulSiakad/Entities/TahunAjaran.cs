using SIAkademik.Domain.Abstracts;
using SIAkademik.Domain.Enums;

namespace SIAkademik.Domain.ModulSiakad.Entities;

public class TahunAjaran : Entity<int>
{
    public required string Periode { get;set; }
    public required Semester Semester { get;set; }
    public required int TahunPelaksaan { get; set; }
    public required DateOnly TanggalMulai { get; set; }
    public required DateOnly TanggalSelesai { get; set; }

    public List<Kelas> DaftarKelas { get; set; } = [];
}
