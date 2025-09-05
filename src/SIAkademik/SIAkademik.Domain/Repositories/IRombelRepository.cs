using SIAkademik.Domain.Entities;

namespace SIAkademik.Domain.Repositories;

public interface IRombelRepository
{
    Task<Rombel?> Get(int id);
    Task<List<Rombel>> GetAll();
    Task<List<Rombel>> GetAllByKelas(int idKelas);

    Task Add(Rombel rombel);
    Task Delete(Rombel rombel);
}
