using SIAkademik.Domain.Entities;

namespace SIAkademik.Domain.Repositories;

public interface ISiswaRepository
{
    Task<Siswa?> Get(string nisn);
    Task<List<Siswa>> GetAll();

    void Add(Siswa siswa);
    void Delete(Siswa siswa);
}
