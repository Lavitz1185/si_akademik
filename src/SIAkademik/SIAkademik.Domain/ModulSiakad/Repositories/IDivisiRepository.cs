using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Domain.ModulSiakad.Repositories;

public interface IDivisiRepository
{
    Task<Divisi?> Get(int id);
    Task<List<Divisi>> GetAll();

    void Add(Divisi divisi);
    void Delete(Divisi divisi);
}
