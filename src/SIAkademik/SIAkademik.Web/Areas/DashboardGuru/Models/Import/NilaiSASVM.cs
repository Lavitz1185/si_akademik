using SIAkademik.Domain.ModulSiakad.Entities;
using SIAkademik.Web.Models;

namespace SIAkademik.Web.Areas.DashboardGuru.Models.Import;

public class NilaiSASVM : ImportVM<AsesmenSumatifAkhirSemester>
{
    public int? IdTahunAjaran {  get; set; }
    public int? IdJadwalMengajar { get; set; }
    public TahunAjaran? TahunAjaran { get; set; }
    public JadwalMengajar? JadwalMengajar { get; set; }

    public required Pegawai Pegawai { get; set; }
}
