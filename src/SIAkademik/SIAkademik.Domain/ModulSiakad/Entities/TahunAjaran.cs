using SIAkademik.Domain.Abstracts;
using SIAkademik.Domain.Enums;

namespace SIAkademik.Domain.ModulSiakad.Entities;

public class TahunAjaran : Entity<int>
{
    public required int Tahun { get; set; }
    public required Semester Semester { get;set; }
    public required DateOnly TanggalMulai { get; set; }
    public required DateOnly TanggalSelesai { get; set; }

    public string Periode => $"{Tahun}/{Tahun + 1}";

    public List<Rombel> DaftarRombel { get; set; } = [];
}
