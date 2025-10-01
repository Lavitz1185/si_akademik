using SIAkademik.Domain.Abstracts;
using SIAkademik.Domain.Enums;

namespace SIAkademik.Domain.ModulSiakad.Entities;

public class Kelas : Entity<int>
{
    public required Jenjang Jenjang { get; set; }
       
    public TahunAjaran TahunAjaran { get; set; }
    public Peminatan Peminatan { get; set; }
    public List<Rombel> DaftarRombel { get; set; } = [];
}