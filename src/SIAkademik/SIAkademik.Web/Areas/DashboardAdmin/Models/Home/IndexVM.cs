using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Web.Areas.DashboardAdmin.Models.Home;

public class IndexVM
{
    public TahunAjaran? TahunAjaran { get; set; }
    public List<Siswa> DaftarSiswa { get; set; } = [];
    public List<Rombel> DaftarRombel { get; set; } = [];
    public List<Pegawai> DaftarPegawai { get; set; } = [];
}
