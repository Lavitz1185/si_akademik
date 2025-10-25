using SIAkademik.Domain.ModulProfil.Entities;

namespace SIAkademik.Domain.ModulProfil.Repositories;

public interface IEkstrakurikulerRepository
{
    Task<Ekstrakurikuler?> Get(int id);
    Task<List<Ekstrakurikuler>> GetAll();

    void Add(Ekstrakurikuler ekstrakurikuler);
    void Delete(Ekstrakurikuler ekstrakurikuler);
}
