using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Domain.ModulSiakad.Repositories;

public interface IJadwalMengajarRepository
{
    void Add(JadwalMengajar jadwalMengajar);
    void Delete(JadwalMengajar jadwalMengajar);
}
