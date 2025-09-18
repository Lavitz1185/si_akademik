using Microsoft.EntityFrameworkCore;
using SIAkademik.Domain.ModulSiakad.Entities;
using SIAkademik.Domain.ModulSiakad.Repositories;
using SIAkademik.Infrastructure.Database;

namespace SIAkademik.Infrastructure.ModulSiakad.Repositories;

internal class HariMengajarRepository : IHariMengajarRepository
{
    private readonly AppDbContext _appDbContext;

    public HariMengajarRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public void Add(HariMengajar hariMengajar) => _appDbContext.TblHariMengajar.Add(hariMengajar);

    public void Delete(HariMengajar hariMengajar) => _appDbContext.TblHariMengajar.Remove(hariMengajar);

    public async Task<HariMengajar?> Get(int id) => await _appDbContext
        .TblHariMengajar
        .Include(h => h.JadwalMengajar).ThenInclude(j => j.MataPelajaran)
        .Include(h => h.JadwalMengajar).ThenInclude(j => j.Rombel)
        .Include(h => h.JadwalMengajar).ThenInclude(j => j.Pegawai)
        .FirstOrDefaultAsync(h => h.Id == id);

    public async Task<List<HariMengajar>> GetAll() => await _appDbContext
        .TblHariMengajar
        .Include(h => h.JadwalMengajar).ThenInclude(j => j.MataPelajaran)
        .Include(h => h.JadwalMengajar).ThenInclude(j => j.Rombel)
        .Include(h => h.JadwalMengajar).ThenInclude(j => j.Pegawai)
        .ToListAsync();

    public void Update(HariMengajar hariMengajar) => _appDbContext.TblHariMengajar.Update(hariMengajar);
}
