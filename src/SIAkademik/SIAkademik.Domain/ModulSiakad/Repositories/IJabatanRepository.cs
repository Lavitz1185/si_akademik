using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Domain.ModulSiakad.Repositories;

public interface IJabatanRepository
{
    Task<Jabatan?> Get(int id);
    Task<List<Jabatan>> GetAll();
    Task<bool> IsExistByNama(string nama, int? id = null);

    void Add(Jabatan jabatan);
    void Delete(Jabatan jabatan);
}
