using SIAkademik.Domain.Enums;
using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Domain.ModulSiakad.Repositories;

public interface ITujuanPembelajaranRepository
{
    Task<TujuanPembelajaran?> Get(int id);
    Task<List<TujuanPembelajaran>> GetAll();
    Task<List<TujuanPembelajaran>> GetAll(int idMataPelajaran);
    Task<List<TujuanPembelajaran>> GetAll(int idMataPelajaran, Fase fase);
    Task<List<TujuanPembelajaran>> GetAll(int idMataPelajaran, Jenjang jenjang);

    void Add(TujuanPembelajaran tujuanPembelajaran);
    void Delete(TujuanPembelajaran tujuanPembelajaran);
}
