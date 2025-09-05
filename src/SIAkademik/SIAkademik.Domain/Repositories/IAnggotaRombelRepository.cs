using SIAkademik.Domain.Entities;

namespace SIAkademik.Domain.Repositories;

public interface IAnggotaRombelRepository
{
    Task Add(AnggotaRombel anggotaRombel);
    Task Delete(AnggotaRombel nggotaRombel);
}
