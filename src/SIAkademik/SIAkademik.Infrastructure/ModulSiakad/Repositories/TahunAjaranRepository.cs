using Microsoft.EntityFrameworkCore;
using SIAkademik.Domain.ModulSiakad.Entities;
using SIAkademik.Domain.ModulSiakad.Repositories;
using SIAkademik.Infrastructure.Database;

namespace SIAkademik.Infrastructure.ModulSiakad.Repositories;

internal class TahunAjaranRepository : ITahunAjaranRepository
{
    private readonly AppDbContext _appDbContext;

    public TahunAjaranRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public void Add(TahunAjaran tahunAjaran) => _appDbContext.TblTahunAjaran.Add(tahunAjaran);

    public void Delete(TahunAjaran tahunAjaran) => _appDbContext.TblTahunAjaran.Remove(tahunAjaran);

    public async Task<TahunAjaran?> Get(int id) => await _appDbContext
        .TblTahunAjaran
        .Include(t => t.DaftarKelas).ThenInclude(k => k.DaftarRombel).ThenInclude(r => r.DaftarAnggotaRombel)
        .Include(t => t.DaftarKelas).ThenInclude(k => k.Peminatan)
        .FirstOrDefaultAsync(t => t.Id == id);

    public async Task<List<TahunAjaran>> GetAll() => await _appDbContext
        .TblTahunAjaran
        .Include(t => t.DaftarKelas).ThenInclude(k => k.DaftarRombel)
        .Include(t => t.DaftarKelas).ThenInclude(k => k.Peminatan)
        .OrderBy(t => t.TahunPelaksaan).ThenBy(t => t.Semester)
        .ToListAsync();

    public async Task<TahunAjaran?> GetNewest() => await _appDbContext
        .TblTahunAjaran
        .Include(t => t.DaftarKelas).ThenInclude(k => k.DaftarRombel).ThenInclude(r => r.DaftarAnggotaRombel)
        .Include(t => t.DaftarKelas).ThenInclude(k => k.Peminatan)
        .OrderBy(t => t.TahunPelaksaan).ThenBy(t => t.Semester)
        .LastOrDefaultAsync();
}
