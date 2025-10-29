using SIAkademik.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace SIAkademik.Web.Areas.DashboardAdmin.Models.JadwalMengajarModels;

public class TambahVM
{
    [Display(Name = "Mata Pelajaran")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public int IdMataPelajaran { get; set; }

    [Display(Name = "Rombel")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public int IdRombel { get; set; }

    [Display(Name = "Guru")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public string NIPPegawai { get; set; } = string.Empty;

    [Display(Name = "Jumlah Pertemuan")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public int JumlahPertemuan { get; set; }

    [Display(Name = "Hari Mengajar")]
    [Required(ErrorMessage = "{0} harus diisi (min 1)")]
    public List<TambahEntryVM> DaftarTambahEntryVM { get; set; } = [];

    [Display(Name = "Tahun Ajaran")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required int IdTahunAjaran { get; set; }
}

public class TambahEntryVM
{
    [Display(Name = "Hari")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public Hari Hari { get; set; }

    [Display(Name = "Jam Mulai")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public TimeOnly JamMulai { get; set; }

    [Display(Name = "Jam Akhir")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public TimeOnly JamAkhir { get; set; }
}
