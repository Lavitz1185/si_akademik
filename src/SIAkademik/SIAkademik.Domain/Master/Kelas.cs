using SIAkademik.Domain.Abstracts;
using SIAkademik.Domain.Enums;

namespace SIAkademik.Domain.Master;

public class Kelas : Entity<int>
{
    public required Jenjang Jenjang { get; set; }
    public required Peminatan Peminatan { get; set; }
       
    public TahunAjaran TahunAjaran { get; set; }
    public List<Rombel> DaftarRombel { get; set; } = [];
}