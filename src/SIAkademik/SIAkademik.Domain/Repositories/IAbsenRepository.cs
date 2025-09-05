using SIAkademik.Domain.Entities;

namespace SIAkademik.Domain.Repositories;

public interface IAbsenRepository
{
    Task<Absen?> Get(int id);
    Task<List<Absen>> GetAll();

    Task Add(Absen absen);
    Task Delete(Absen absen);
}
