using SIAkademik.Domain.Enums;
using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Domain.ModulSiakad.Repositories;

public interface ITahunAjaranRepository
{
    Task<TahunAjaran?> Get(int id);
    Task<TahunAjaran?> Get(int tahun, Semester semester);
    Task<TahunAjaran?> GetNewest();
    Task<TahunAjaran?> Get(DateOnly tanggal);
    Task<List<TahunAjaran>> GetAll();
    Task<List<TahunAjaran>> GetAll(Semester semester);

    void Add(TahunAjaran tahunAjaran);
    void Delete(TahunAjaran tahunAjaran);
}
