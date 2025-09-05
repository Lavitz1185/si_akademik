using SIAkademik.Domain.Entities;

namespace SIAkademik.Domain.Repositories;

public interface IRombelRepository
{
    Task<Rombel?> Get(int id);
    Task<List<Rombel>> GetAll();
    Task<List<Rombel>> GetAllByKelas(int idKelas);

    void Add(Rombel rombel);
    void Delete(Rombel rombel);
}
