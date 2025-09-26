using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Domain.ModulSiakad.Repositories;

public interface IPertemuanRepository
{
    Task<Pertemuan?> Get(int id);
    Task<List<Pertemuan>> GetAll();
    Task<List<Pertemuan>> GetAllByJadwalMengajar(int idJadwalMengajar);

    void Add(Pertemuan pertemuan);
    void Delete(Pertemuan pertemuan);
}
