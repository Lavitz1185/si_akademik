using SIAkademik.Domain.Entities;

namespace SIAkademik.Domain.Repositories;

public interface ISiswaRepository
{
    Task<Siswa?> Get(string nisn);
    Task<List<Siswa>> GetAll();

    Task Add(Siswa siswa);
    Task Delete(Siswa siswa);
}
