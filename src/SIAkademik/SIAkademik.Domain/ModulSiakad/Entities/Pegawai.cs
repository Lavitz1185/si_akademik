using SIAkademik.Domain.Abstracts;
using SIAkademik.Domain.Authentication;
using SIAkademik.Domain.Enums;
using SIAkademik.Domain.ValueObjects;
using System.Globalization;

namespace SIAkademik.Domain.ModulSiakad.Entities;

public class Pegawai : Entity<string>
{
    public string TTL 
    { 
        get
        {
            var cu = new CultureInfo("id-ID");

            return $"{TempatLahir}, {TanggalLahir.ToString(cu.DateTimeFormat.LongDatePattern, cu)}";
        } 
    }

    public required string Nama { get; set; }
    public required JenisKelamin JenisKelamin { get; set; }
    public required Agama Agama { get; set; }
    public required DateOnly TanggalLahir { get; set; }
    public required string TempatLahir { get; set; }
    public required StatusPerkawinan StatusPerkawinan { get; set; }
    public required Alamat AlamatKTP { get; set; }
    public required NoHP NoHP { get; set; }
    public required GolonganDarah GolonganDarah { get; set; }
    public required string Email { get; set; }
    public required DateOnly TanggalMasuk { get; set; }
    public required string NIK { get; set; }
    public required string NamaInstagram { get; set; }
    public required string NoRekening { get; set; }
    public Uri? FotoProfil { get; set; }

    public List<Rombel> DaftarRombelWali { get; set; } = [];
    public List<JadwalMengajar> DaftarJadwalMengajar { get; set; } = [];
    public Divisi Divisi { get; set; }
    public Jabatan Jabatan { get; set; }
    
    public AppUser Account { get; set; }
}
