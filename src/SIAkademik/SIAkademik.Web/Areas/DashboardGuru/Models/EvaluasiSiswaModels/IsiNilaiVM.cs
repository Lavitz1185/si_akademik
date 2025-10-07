using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Web.Areas.DashboardGuru.Models.EvaluasiSiswaModels;

public class IsiNilaiVM
{
    public required int Id { get; set; }
    public required EvaluasiSiswa EvaluasiSiswa { get; set; }
    public List<IsiNilaiEntryVM> DaftarIsiNilaiEntry { get; set; } = [];
}

public class IsiNilaiEntryVM
{
    public required int IdAnggotaRombel { get; set; }
    public required string NamaSiswa { get; set; }
    public required double Nilai { get; set; }
}
