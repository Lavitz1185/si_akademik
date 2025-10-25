using SIAkademik.Domain.ModulProfil.Entities;
using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Web.Areas.Profil.Models.Home;

public class IndexVM
{
    public required InformasiUmum InformasiUmum { get; set; }
    public List<Pegawai> DaftarPegawai { get; set; } = [];
    public List<Siswa> DaftarSiswa { get; set; } = [];
}
