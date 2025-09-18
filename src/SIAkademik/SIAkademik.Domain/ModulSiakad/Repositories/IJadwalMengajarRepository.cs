using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Domain.ModulSiakad.Repositories;

public interface IJadwalMengajarRepository
{
    Task<JadwalMengajar?> Get(int id);
    Task<List<JadwalMengajar>> GetAll();
    void Add(JadwalMengajar jadwalMengajar);
    void Delete(JadwalMengajar jadwalMengajar);
}
