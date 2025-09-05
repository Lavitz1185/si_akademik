using SIAkademik.Domain.Entities;

namespace SIAkademik.Domain.Repositories;

public interface ITahunAjaranRepository
{
    Task<TahunAjaran?> Get(int id);
    Task<List<TahunAjaran>> GetAll();

    void Add(TahunAjaran tahunAjaran);
    void Delete(TahunAjaran tahunAjaran);
}
