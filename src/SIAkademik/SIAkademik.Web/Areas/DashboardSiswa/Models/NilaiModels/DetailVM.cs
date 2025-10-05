using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Web.Areas.DashboardSiswa.Models.NilaiModels;

public class DetailVM
{
    public required AnggotaRombel AnggotaRombel { get; set; }
    public required JadwalMengajar JadwalMengajar { get; set; }
}
