using SIAkademik.Domain.Entities;

namespace SIAkademik.Domain.Repositories;

public interface INilaiRepository
{
    Task<Nilai?> Get(int id);
    Task<List<Nilai>> GetAll();

    Task Add(Nilai nilai);
    Task Delete(Nilai nilai);
}
