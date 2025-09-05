using SIAkademik.Domain.Entities;

namespace SIAkademik.Domain.Repositories;

public interface IJadwalMengajarRepository
{
    Task Add(JadwalMengajar jadwalMengajar);
    Task Delete(JadwalMengajar jadwalMengajar);
}
