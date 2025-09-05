using SIAkademik.Domain.Entities;

namespace SIAkademik.Domain.Repositories;

public interface INilaiRepository
{
    Task<Nilai?> Get(int id);
    Task<List<Nilai>> GetAll();

    void Add(Nilai nilai);
    void Delete(Nilai nilai);
}
