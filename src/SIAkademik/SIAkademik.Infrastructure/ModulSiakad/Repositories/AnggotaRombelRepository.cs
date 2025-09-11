using SIAkademik.Domain.ModulSiakad.Entities;
using SIAkademik.Domain.ModulSiakad.Repositories;
using SIAkademik.Infrastructure.Database;

namespace SIAkademik.Infrastructure.ModulSiakad.Repositories;

internal class AnggotaRombelRepository : IAnggotaRombelRepository
{
    private readonly AppDbContext _appDbContext;

    public AnggotaRombelRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public void Add(AnggotaRombel anggotaRombel) => _appDbContext.TblAnggotaRombel.Add(anggotaRombel);

    public void Delete(AnggotaRombel anggotaRombel) => _appDbContext.TblAnggotaRombel.Remove(anggotaRombel);
}
