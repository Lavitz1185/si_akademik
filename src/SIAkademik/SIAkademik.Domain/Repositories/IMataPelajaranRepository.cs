using SIAkademik.Domain.Entities;

namespace SIAkademik.Domain.Repositories;

public interface IMataPelajaranRepository
{
    Task<MataPelajaran?> Get(int id);
    Task<List<MataPelajaran>> GetAll();

    Task Add(MataPelajaran mataPelajaran);
    Task Delete(MataPelajaran mataPelajaran);
}
