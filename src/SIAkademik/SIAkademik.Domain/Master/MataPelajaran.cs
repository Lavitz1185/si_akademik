using SIAkademik.Domain.Abstracts;
using SIAkademik.Domain.Enums;

namespace SIAkademik.Domain.Master;

public class MataPelajaran : Entity<int>
{
    public required string Nama { get; set; }
    public required Jenjang Jenjang { get; set; } 
    public required Peminatan Peminatan { get; set; }
}
