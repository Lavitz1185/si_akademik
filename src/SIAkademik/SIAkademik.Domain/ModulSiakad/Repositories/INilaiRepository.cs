using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Domain.ModulSiakad.Repositories;

public interface INilaiRepository
{
    Task<Nilai?> Get(int id);
    Task<List<Nilai>> GetAll();

    void Add(Nilai nilai);
    void Delete(Nilai nilai);
}
