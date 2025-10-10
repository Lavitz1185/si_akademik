using Microsoft.EntityFrameworkCore;
using SIAkademik.Domain.Enums;
using SIAkademik.Domain.ModulSiakad.Entities;
using SIAkademik.Domain.ModulSiakad.Repositories;
using SIAkademik.Infrastructure.Database;

namespace SIAkademik.Infrastructure.ModulSiakad.Repositories;

internal class TujuanPembelajaranRepository : ITujuanPembelajaranRepository
{
    private readonly AppDbContext _appDbContext;

    public TujuanPembelajaranRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public void Add(TujuanPembelajaran tujuanPembelajaran) => _appDbContext.TblTujuanPembelajaran.Add(tujuanPembelajaran);

    public void Delete(TujuanPembelajaran tujuanPembelajaran) => _appDbContext.TblTujuanPembelajaran.Remove(tujuanPembelajaran);

    public async Task<TujuanPembelajaran?> Get(int id) => await _appDbContext.TblTujuanPembelajaran
        .Include(t => t.MataPelajaran).ThenInclude(m => m.Peminatan)
        .FirstOrDefaultAsync(t => t.Id == id);

    public async Task<List<TujuanPembelajaran>> GetAll() => await _appDbContext.TblTujuanPembelajaran
        .Include(t => t.MataPelajaran).ThenInclude(m => m.Peminatan)
        .ToListAsync();

    public async Task<List<TujuanPembelajaran>> GetAll(int idMataPelajaran) => await _appDbContext.TblTujuanPembelajaran
        .Include(t => t.MataPelajaran).ThenInclude(m => m.Peminatan)
        .Where(t => t.MataPelajaran.Id == idMataPelajaran)
        .ToListAsync();

    public async Task<List<TujuanPembelajaran>> GetAll(int idMataPelajaran, Fase fase) => await _appDbContext.TblTujuanPembelajaran
        .Include(t => t.MataPelajaran).ThenInclude(m => m.Peminatan)
        .Where(t => t.MataPelajaran.Id == idMataPelajaran && t.Fase == fase)
        .ToListAsync();

    public async Task<List<TujuanPembelajaran>> GetAll(int idMataPelajaran, Jenjang jenjang) => 
        await GetAll(idMataPelajaran, TujuanPembelajaran.FaseFromJenjang(jenjang));
}
