using SIAkademik.Domain.ModulProfil.Entities;

namespace SIAkademik.Domain.ModulProfil.Repositories;

public interface IKategoriBeritaRepository
{
    Task<KategoriBerita?> Get(int idKategoriBerita);
    Task<List<KategoriBerita>> GetAll();
    Task<bool> IsExist(string nama, int? id = null);

    void Add(KategoriBerita kategoriBerita);
    void Delete(KategoriBerita kategoriBerita);
    void Update(KategoriBerita kategoriBerita);
}
