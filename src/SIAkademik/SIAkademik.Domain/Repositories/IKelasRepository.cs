using SIAkademik.Domain.Entities;
using SIAkademik.Domain.Enums;

namespace SIAkademik.Domain.Repositories;

public interface IKelasRepository
{
    Task<Kelas?> Get(int id);
    Task<List<Kelas>> GetAll();
    Task<List<Kelas>> GetAllByTahunAjaran(int idTahunAjaran);
    Task<List<Kelas>> GetAllByPeminatan(int idTahunAjaran, Peminatan peminatan);

    Task Add(Kelas kelas);
    Task Delete(Kelas kelas);
}
