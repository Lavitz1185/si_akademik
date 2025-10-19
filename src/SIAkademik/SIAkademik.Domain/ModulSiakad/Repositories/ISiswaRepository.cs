using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Domain.ModulSiakad.Repositories;

public interface ISiswaRepository
{
    Task<Siswa?> Get(int id);
    Task<Siswa?> GetByNISN(string nisn);
    Task<Siswa?> GetByNIS(string nis);
    Task<List<Siswa>> GetAll();
    Task<List<Siswa>> GetAllAktif();
    Task<bool> IsExistByNISN(string nisn, int? id = null);
    Task<bool> IsExistByNIS(string nis, int? id = null);

    void Add(Siswa siswa);
    void Delete(Siswa siswa);
}
