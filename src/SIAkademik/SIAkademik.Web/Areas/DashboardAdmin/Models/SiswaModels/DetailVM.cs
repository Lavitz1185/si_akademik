using SIAkademik.Domain.Enums;
using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Web.Areas.DashboardAdmin.Models.SiswaModels;

public class DetailVM
{
    public required Siswa Siswa { get; set; }

    public List<JenisKelamin> JenisKelamin { get; set; } = [];
    public List<Agama> Agama { get; set; } = [];
    public List<StatusAktifMahasiswa> StatusAktif { get; set; } = [];
    public List<int> TahunMasuk { get; set; } = [];
    public List<int> TahunLahir { get; set; } = [];
    public List<Jenjang> Jenjang { get; set; } = [];
}
