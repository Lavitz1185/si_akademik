using SIAkademik.Domain.ModulSiakad.Entities;
using System.ComponentModel.DataAnnotations;

namespace SIAkademik.Web.Areas.DashboardGuru.Models.AsesmenSumatifModels;

public class DetailVM
{
    public required EvaluasiSiswa EvaluasiSiswa { get; set; }
    public required AsesmenSumatif AsesmenSumatif { get; set; }
    public required int IdEvaluasiSiswa { get; set; }

    public required List<DetailEntryVM> DaftarDetailEntryVM { get; set; }
}

public class DetailEntryVM
{
    public required int IdAnggotaRombel { get; set; } 
    public required string Nama { get; set; }

    [Display(Name = "Nilai")]
    [Required(ErrorMessage = "{0} harus diisi")]
    [Range(0d, 100d, ErrorMessage = "{0} harus antara {1}-{2}")]
    public required double Nilai { get; set; }
}
