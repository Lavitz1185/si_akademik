using SIAkademik.Domain.Enums;
using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Domain.ModulSiakad.Repositories;

public interface IKelasRepository
{
    Task<Kelas?> Get(int id);
    Task<List<Kelas>> GetAll();
    Task<List<Kelas>> GetAllByTahunAjaran(int idTahunAjaran);
    Task<List<Kelas>> GetAllByPeminatan(int idTahunAjaran, Peminatan peminatan);

    void Add(Kelas kelas);
    void Delete(Kelas kelas);
}
