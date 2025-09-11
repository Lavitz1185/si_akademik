using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Domain.ModulSiakad.Repositories;

public interface IAnggotaRombelRepository
{
    void Add(AnggotaRombel anggotaRombel);
    void Delete(AnggotaRombel nggotaRombel);
}
