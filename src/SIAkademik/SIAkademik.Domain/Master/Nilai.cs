namespace SIAkademik.Domain.Master;

public class Nilai
{
    public required string NISN { get; set; }
    public required string NIP { get; set; }

    public Siswa Siswa { get; set; }
    public Guru Guru { get; set; }
    public MataPelajaran MataPelajaran { get; set; }
    public Rombel Rombel { get; set; }
}
