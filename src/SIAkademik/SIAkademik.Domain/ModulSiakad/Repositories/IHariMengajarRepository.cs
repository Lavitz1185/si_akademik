using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Domain.ModulSiakad.Repositories;

public interface IHariMengajarRepository
{
    Task<HariMengajar?> Get(int id);
    Task<List<HariMengajar>> GetAll();
    void Add(HariMengajar hariMengajar);
    void Delete(HariMengajar hariMengajar);
    void Update(HariMengajar hariMengajar);
}
