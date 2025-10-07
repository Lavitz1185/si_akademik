using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Domain.ModulSiakad.Repositories;

public interface IEvaluasiSiswaRepository
{
    Task<EvaluasiSiswa?> Get(int id);
    Task<List<EvaluasiSiswa>> GetAll();

    void Add(EvaluasiSiswa nilai);
    void Delete(EvaluasiSiswa nilai);
}
