using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Domain.ModulSiakad.Repositories;

public interface IRombelRepository
{
    Task<Rombel?> Get(int id);
    Task<List<Rombel>> GetAll();
    Task<List<Rombel>> GetAllByKelas(int idKelas);
    Task<List<Rombel>> GetAllByTahunAjaran(int idTahunAjaran);

    void Add(Rombel rombel);
    void Delete(Rombel rombel);
}
