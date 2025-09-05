using SIAkademik.Domain.Entities;

namespace SIAkademik.Domain.Repositories;

public interface IAnggotaRombelRepository
{
    void Add(AnggotaRombel anggotaRombel);
    void Delete(AnggotaRombel nggotaRombel);
}
