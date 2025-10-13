using SIAkademik.Domain.ModulSiakad.Entities;
using System.ComponentModel.DataAnnotations;

namespace SIAkademik.Web.Areas.DashboardGuru.Models.NilaiAkhirSemesterModels;

public class IndexVM
{
    public required Pegawai Pegawai { get; set; }

    public TahunAjaran? TahunAjaran { get; set; }
    public JadwalMengajar? JadwalMengajar { get; set; }
    public int? IdTahunAjaran { get; set; }
    public int? IdJadwalMengajar { get; set; }

    public List<NilaiEntryVM> DaftarNilaiEntryVM { get; set; } = [];
}

public class NilaiEntryVM
{
    public required int IdAnggotaRombel { get; set; }
    public required string Nama { get; set; }

    [Display(Name = "Nilai")]
    [Required(ErrorMessage = "{0} harus diisi")]
    [Range(0, 100, MinimumIsExclusive = true, MaximumIsExclusive = true, ErrorMessage = "{0} harus antara {1}-{2}")]
    public required double Nilai { get; set; }
}
