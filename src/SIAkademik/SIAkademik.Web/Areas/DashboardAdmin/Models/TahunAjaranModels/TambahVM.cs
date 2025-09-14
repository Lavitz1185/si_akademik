using SIAkademik.Domain.Enums;

namespace SIAkademik.Web.Areas.DashboardAdmin.Models.TahunAjaranModels;

public class TambahVM
{
    public string Periode { get; set; } = string.Empty;
    public Semester Semester { get; set; }
}
