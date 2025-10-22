using Microsoft.EntityFrameworkCore;
using SIAkademik.Domain.ModulSiakad.Entities;
using SIAkademik.Domain.ModulSiakad.Repositories;
using SIAkademik.Infrastructure.Database;

namespace SIAkademik.Infrastructure.ModulSiakad.Repositories;

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
        .Include(a => a.AnggotaRombel).ThenInclude(a => a.Siswa)
        .Include(a => a.AnggotaRombel).ThenInclude(a => a.Rombel).ThenInclude(k => k.TahunAjaran)
        .Include(a => a.AnggotaRombel).ThenInclude(a => a.Rombel).ThenInclude(r => r.Kelas).ThenInclude(k => k.Peminatan)
        .Include(a => a.Pertemuan)
        .FirstOrDefaultAsync(a => a.Id == id);

    public async Task<List<Absen>> GetAll() => await _appDbContext
        .TblAbsen
        .Include(a => a.AnggotaRombel).ThenInclude(a => a.Siswa)
        .Include(a => a.AnggotaRombel).ThenInclude(a => a.Rombel).ThenInclude(k => k.TahunAjaran)
        .Include(a => a.AnggotaRombel).ThenInclude(a => a.Rombel).ThenInclude(r => r.Kelas).ThenInclude(k => k.Peminatan)
        .Include(a => a.Pertemuan)
        .ToListAsync();
}
