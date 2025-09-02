using SIAkademik.Domain.Abstracts;

namespace SIAkademik.Domain.Master;

public class PendidikanGuru : Entity<int>
{
    public required string Gelar { get; set; }
    public required string SekolahUniversitas { get; set; }
    public required int Tahun { get; set; }

    public Guru Guru { get; set; }
}