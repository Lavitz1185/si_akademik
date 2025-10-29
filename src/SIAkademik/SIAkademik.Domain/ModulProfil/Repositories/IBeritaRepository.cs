using SIAkademik.Domain.ModulProfil.Entities;

namespace SIAkademik.Domain.ModulProfil.Repositories;

public interface IBeritaRepository
{
    Task<Berita?> Get(int id);
    Task<List<Berita>> GetAll();
    Task<List<Berita>> GetAll(int idKategoriBerita);

    void Add(Berita berita);
    void Update(Berita berita);
    void Delete(Berita berita);
}
