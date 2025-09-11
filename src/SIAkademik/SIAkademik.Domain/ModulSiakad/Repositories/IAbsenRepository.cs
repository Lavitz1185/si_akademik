using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Domain.ModulSiakad.Repositories;

public interface IAbsenRepository
{
    Task<Absen?> Get(int id);
    Task<List<Absen>> GetAll();

    void Add(Absen absen);
    void Delete(Absen absen);
}
