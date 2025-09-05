using SIAkademik.Domain.Entities;

namespace SIAkademik.Domain.Repositories;

public interface IMataPelajaranRepository
{
    Task<MataPelajaran?> Get(int id);
    Task<List<MataPelajaran>> GetAll();

    void Add(MataPelajaran mataPelajaran);
    void Delete(MataPelajaran mataPelajaran);
}
