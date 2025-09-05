using SIAkademik.Domain.Entities;

namespace SIAkademik.Domain.Repositories;

public interface IJabatanRepository
{
    Task<Jabatan?> Get(int id);
    Task<List<Jabatan>> GetAll();

    void Add(Jabatan jabatan);
    void Delete(Jabatan jabatan);
}
