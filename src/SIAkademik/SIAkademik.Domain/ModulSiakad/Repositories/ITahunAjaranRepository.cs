using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Domain.ModulSiakad.Repositories;

public interface ITahunAjaranRepository
{
    Task<TahunAjaran?> Get(int id);
    Task<TahunAjaran?> GetNewest();
    Task<List<TahunAjaran>> GetAll();

    void Add(TahunAjaran tahunAjaran);
    void Delete(TahunAjaran tahunAjaran);
}
