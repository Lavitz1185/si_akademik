using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Domain.ModulSiakad.Repositories;

public interface ISiswaRepository
{
    Task<Siswa?> Get(string nisn);
    Task<List<Siswa>> GetAll();

    void Add(Siswa siswa);
    void Delete(Siswa siswa);
}
