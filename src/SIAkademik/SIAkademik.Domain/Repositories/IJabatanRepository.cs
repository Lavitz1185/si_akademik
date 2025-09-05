using SIAkademik.Domain.Entities;

namespace SIAkademik.Domain.Repositories;

public interface IJabatanRepository
{
    Task<Jabatan?> Get(int id);
    Task<List<Jabatan>> GetAll();

    Task Add(Jabatan jabatan);
    Task Delete(Jabatan jabatan);
}
