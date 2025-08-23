using SIAkademik.Domain.Abstracts;
using SIAkademik.Domain.Enums;
using SIAkademik.Domain.ValueObjects;

namespace SIAkademik.Domain.Master;

public class Pegawai : Entity<string>
{
    public string NIP => Id;

    public required string Nama { get; set; }
    public required JenisKelamin JenisKelamin { get; set; }
    public required string Agama { get; set; }
    public required DateOnly TanggalLahir { get; set; }
    public required string TempatLahir { get; set; }
    public required StatusPerkawinan StatusPerkawinan { get; set; }
    public required Alamat Alamat { get; set; }
    public required NoHP NoHP { get; set; }
    public required string Jabatan { get; set; }
}
