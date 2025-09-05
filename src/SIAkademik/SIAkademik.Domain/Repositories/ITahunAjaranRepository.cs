using SIAkademik.Domain.Entities;

namespace SIAkademik.Domain.Repositories;

public interface ITahunAjaranRepository
{
    Task<TahunAjaran?> Get(int id);
    Task<List<TahunAjaran>> GetAll();

    Task Add(TahunAjaran tahunAjaran);
    Task Delete(TahunAjaran tahunAjaran);
}
