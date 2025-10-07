using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Domain.ModulSiakad.Repositories;

public interface INilaiEvaluasiSiswaRepository
{
    void Add(NilaiEvaluasiSiswa nilaiEvaluasiSiswa);
    void Delete(NilaiEvaluasiSiswa nilaiEvaluasiSiswa);
    void Update(NilaiEvaluasiSiswa nilaiEvaluasiSiswa);
}
