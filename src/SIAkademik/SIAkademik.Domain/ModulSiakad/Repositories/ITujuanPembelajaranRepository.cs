using SIAkademik.Domain.Enums;
using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Domain.ModulSiakad.Repositories;

public interface ITujuanPembelajaranRepository
{
    Task<TujuanPembelajaran?> Get(int id);
    Task<List<TujuanPembelajaran>> GetAll();
    Task<List<TujuanPembelajaran>> GetAll(int idMataPelajaran);
    Task<List<TujuanPembelajaran>> GetAll(Fase fase);
    Task<List<TujuanPembelajaran>> GetAll(int idMataPelajaran, Fase fase);
    Task<List<TujuanPembelajaran>> GetAll(int idMataPelajaran, Jenjang jenjang);
    Task<bool> IsExist(int nomor, int idMataPelajaran, Fase fase, int? id = null);
    Task<bool> IsExist(string deskripsi, int idMataPelajaran, Fase fase, int? id = null);

    void Add(TujuanPembelajaran tujuanPembelajaran);
    void Delete(TujuanPembelajaran tujuanPembelajaran);
}
