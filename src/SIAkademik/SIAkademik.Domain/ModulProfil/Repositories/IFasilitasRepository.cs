using SIAkademik.Domain.ModulProfil.Entities;

namespace SIAkademik.Domain.ModulProfil.Repositories;

public interface IFasilitasRepository
{
    Task<Fasilitas?> Get(int id);
    Task<List<Fasilitas>> GetAll();
    Task<bool> IsExist(string nama, int? id = null);

    void Add(Fasilitas fasilitas);
    void Delete(Fasilitas fasilitas);
}
