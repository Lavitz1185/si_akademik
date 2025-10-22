using SIAkademik.Domain.Enums;
using SIAkademik.Domain.ModulSiakad.Entities;
using SIAkademik.Web.Models;

namespace SIAkademik.Web.Areas.DashboardAdmin.Models.SiswaModels;

public class IndexVM
{
    public List<FilterEntryVM<JenisKelamin>> JenisKelamin { get; set; } = [];
    public List<FilterEntryVM<Agama>> Agama { get; set; } = [];
    public List<FilterEntryVM<StatusAktifMahasiswa>> StatusAktif { get; set; } = [];
    public List<FilterEntryVM<int>> TahunMasuk { get; set; } = [];
    public List<FilterEntryVM<int>> TahunLahir { get; set; } = [];
    public List<FilterEntryVM<Jenjang>> Jenjang { get; set; } = [];

    public List<Siswa> DaftarSiswa { get; set; } = [];
}
