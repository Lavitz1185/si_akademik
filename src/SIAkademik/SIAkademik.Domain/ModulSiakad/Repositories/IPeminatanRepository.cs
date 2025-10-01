using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Domain.ModulSiakad.Repositories;

public interface IPeminatanRepository
{
    Task<Peminatan?> Get(int id);
    Task<List<Peminatan>> GetAll();
    Task<bool> IsExist(string nama, int? id = null);

    void Add(Peminatan peminatan);
    void Delete(Peminatan peminatan);
}
