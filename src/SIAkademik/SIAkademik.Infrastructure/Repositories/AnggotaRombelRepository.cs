using SIAkademik.Domain.Entities;
using SIAkademik.Domain.Repositories;
using SIAkademik.Infrastructure.Database;

namespace SIAkademik.Infrastructure.Repositories;

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
