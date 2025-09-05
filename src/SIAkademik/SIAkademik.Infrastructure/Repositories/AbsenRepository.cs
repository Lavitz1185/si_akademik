using Microsoft.EntityFrameworkCore;
using SIAkademik.Domain.Entities;
using SIAkademik.Domain.Repositories;
using SIAkademik.Infrastructure.Database;

namespace SIAkademik.Infrastructure.Repositories;

internal class AbsenRepository : IAbsenRepository
{
    private readonly AppDbContext _appDbContext;

    public AbsenRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public void Add(Absen absen) => _appDbContext.TblAbsen.Add(absen);

    public void Delete(Absen absen) => _appDbContext.TblAbsen.Remove(absen);

    public async Task<Absen?> Get(int id) => await _appDbContext
        .TblAbsen
        .Include(a => a.AnggotaRombel)
        .FirstOrDefaultAsync(a => a.Id == id);

    public async Task<List<Absen>> GetAll() => await _appDbContext
        .TblAbsen
        .Include(a => a.AnggotaRombel)
        .ToListAsync();
}
