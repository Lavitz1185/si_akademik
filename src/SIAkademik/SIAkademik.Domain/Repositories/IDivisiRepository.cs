using SIAkademik.Domain.Entities;

namespace SIAkademik.Domain.Repositories;

public interface IDivisiRepository
{
    Task<Divisi?> Get(int id);
    Task<List<Divisi>> GetAll();

    Task Add(Divisi divisi);
    Task Delete(Divisi divisi);
}
