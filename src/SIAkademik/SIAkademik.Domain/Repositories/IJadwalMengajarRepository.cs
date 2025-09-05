using SIAkademik.Domain.Entities;

namespace SIAkademik.Domain.Repositories;

public interface IJadwalMengajarRepository
{
    void Add(JadwalMengajar jadwalMengajar);
    void Delete(JadwalMengajar jadwalMengajar);
}
