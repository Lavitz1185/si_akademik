using SIAkademik.Domain.Enums;
using SIAkademik.Domain.ModulSiakad.Entities;
using System.ComponentModel.DataAnnotations;

namespace SIAkademik.Web.Areas.DashboardAdmin.Models.SiswaModels;

public class NaikKelasVM
{
    public List<Siswa> DaftarSiswa { get; set; } = [];

    [Display(Name = "Jenjang")]
    public required Jenjang jenjang { get; set;}

    [Display(Name = "Jenjang Tujuan")]
    public Jenjang JenjangTujuan { get; set; }
    public required List<NaikKelasEntryVM> DaftarEntry { get; set; } = [];
}

public class NaikKelasEntryVM
{
    public required int IdSiswa { get; set; }
    public bool NaikKelas { get; set; }
}
