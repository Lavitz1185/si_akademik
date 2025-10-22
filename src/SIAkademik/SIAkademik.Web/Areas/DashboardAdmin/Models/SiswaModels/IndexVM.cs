using SIAkademik.Domain.Enums;
using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Web.Areas.DashboardAdmin.Models.SiswaModels;

public class IndexVM
{
    public JenisKelamin? JenisKelamin { get; set; }
    public Agama? Agama { get; set; }
    public StatusAktifMahasiswa? StatusAktif { get; set; }
    public DateOnly? TanggalMasuk { get; set; }
    public Jenjang? Jenjang { get; set; }

    public List<Siswa> DaftarSiswa { get; set; } = [];
}
