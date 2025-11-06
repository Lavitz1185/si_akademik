using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Domain.ModulSiakad.Repositories;

public interface IRombelRepository
{
    Task<Rombel?> Get(int id);
    Task<List<Rombel>> GetAll();
    Task<List<Rombel>> GetAllByKelas(int idKelas);
    Task<List<Rombel>> GetAllByTahunAjaran(int idTahunAjaran);
    Task<List<Rombel>> GetAll(int idKelas, int idTahunAjaran);
    Task<List<Rombel>> GetAll(int idTahunAjaran, string nipPegawai);

    void Add(Rombel rombel);
    void Delete(Rombel rombel);
}
