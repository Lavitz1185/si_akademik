using SIAkademik.Domain.Entities;

namespace SIAkademik.Domain.Repositories;

public interface IAbsenRepository
{
    Task<Absen?> Get(int id);
    Task<List<Absen>> GetAll();

    void Add(Absen absen);
    void Delete(Absen absen);
}
