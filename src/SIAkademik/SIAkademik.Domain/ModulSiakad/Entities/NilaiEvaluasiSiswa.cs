using SIAkademik.Domain.Abstracts;

namespace SIAkademik.Domain.ModulSiakad.Entities;

public class NilaiEvaluasiSiswa : JoinEntity
{
    public int IdAnggotaRombel { get; set; }
    public int IdEvaluasiSiswa { get; set; }
    public required double Nilai { get; set; }

    public EvaluasiSiswa EvaluasiSiswa { get; set; }
    public AnggotaRombel AnggotaRombel { get; set; }

    protected override IEnumerable<object> GetJoinKeys() => [IdAnggotaRombel, IdEvaluasiSiswa];
}