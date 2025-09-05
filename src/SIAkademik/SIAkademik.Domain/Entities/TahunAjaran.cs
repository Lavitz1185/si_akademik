using SIAkademik.Domain.Abstracts;
using SIAkademik.Domain.Enums;

namespace SIAkademik.Domain.Entities;

public class TahunAjaran : Entity<int>
{
    public required string Periode { get;set; }
    public required Semester Semester { get;set; }

    public List<Kelas> DaftarKelas { get; set; } = [];
}
