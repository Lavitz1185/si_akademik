namespace SIAkademik.Domain.ModulSiakad.Entities;

public class NilaiEvaluasiSiswa
{
    public int IdAnggotaRombel { get; set; }
    public int IdEvaluasiSiswa { get; set; }
    public required double Nilai { get; set; }

    public EvaluasiSiswa EvaluasiSiswa { get; set; }
    public AnggotaRombel AnggotaRombel { get; set; }
}