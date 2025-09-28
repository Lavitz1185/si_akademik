using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Domain.ModulSiakad.Repositories;

public interface IRaportRepository
{
    Task<Raport?> Get(int id);
    Task<List<Raport>> GetAll();
    Task<List<Raport>> GetAllBy(int idSiswa, int idRombel);

    void Add(Raport raport);
    void Delete(Raport raport);
}
 