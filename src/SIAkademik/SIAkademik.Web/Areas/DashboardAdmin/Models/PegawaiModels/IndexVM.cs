using SIAkademik.Domain.Enums;
using SIAkademik.Domain.ModulSiakad.Entities;
using SIAkademik.Web.Models;

namespace SIAkademik.Web.Areas.DashboardAdmin.Models.PegawaiModels;

public class IndexVM
{
    public List<FilterEntryVM<JenisKelamin>> JenisKelamin { get; set; } = [];
    public List<FilterEntryVM<Agama>> Agama { get; set; } = [];
    public List<FilterEntryVM<StatusPerkawinan>> StatusPerkawinan { get; set; } = [];
    public List<FilterEntryVM<int>> Divisi { get; set; } = [];
    public List<FilterEntryVM<int>> TahunMasuk { get; set; } = [];
    public List<FilterEntryVM<int>> TahunLahir { get; set; } = [];
    public List<FilterEntryVM<GolonganDarah>> GolonganDarah { get; set; } = [];
    public List<FilterEntryVM<int>> Jabatan { get; set; } = [];

    public List<Pegawai> DaftarPegawai { get; set; } = [];
}
