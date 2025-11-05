using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Web.Areas.DashboardAdmin.Models.RombelModels;

public class PindahSemesterVM
{
    public int? IdTahunAjaranAsal { get; set; }
    public TahunAjaran? TahunAjaranAsal { get; set; }

    public int? IdTahunAjaranTujuan { get; set; }
    public TahunAjaran? TahunAjaranTujuan { get; set; }
}
