using Microsoft.EntityFrameworkCore;
using SIAkademik.Domain.Enums;
using SIAkademik.Domain.ModulSiakad.Entities;
using SIAkademik.Domain.ModulSiakad.Repositories;
using SIAkademik.Infrastructure.Database;
using System.Drawing;

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
        .Include(t => t.DaftarJadwalMengajar)
        .FirstOrDefaultAsync(t => t.Id == id);

    public async Task<List<TujuanPembelajaran>> GetAll() => await _appDbContext.TblTujuanPembelajaran
        .Include(t => t.MataPelajaran).ThenInclude(m => m.Peminatan)
        .Include(t => t.DaftarJadwalMengajar)
        .ToListAsync();

    public async Task<List<TujuanPembelajaran>> GetAll(int idMataPelajaran) => await _appDbContext.TblTujuanPembelajaran
        .Include(t => t.MataPelajaran).ThenInclude(m => m.Peminatan)
        .Where(t => t.MataPelajaran.Id == idMataPelajaran)
        .Include(t => t.DaftarJadwalMengajar)
        .ToListAsync();

    public async Task<List<TujuanPembelajaran>> GetAll(int idMataPelajaran, Fase fase) => await _appDbContext.TblTujuanPembelajaran
        .Include(t => t.MataPelajaran).ThenInclude(m => m.Peminatan)
        .Where(t => t.MataPelajaran.Id == idMataPelajaran && t.Fase == fase)
        .Include(t => t.DaftarJadwalMengajar)
        .ToListAsync();

    public async Task<List<TujuanPembelajaran>> GetAll(int idMataPelajaran, Jenjang jenjang) => 
        await GetAll(idMataPelajaran, TujuanPembelajaran.FaseFromJenjang(jenjang));

    public async Task<List<TujuanPembelajaran>> GetAll(Fase fase) => await _appDbContext.TblTujuanPembelajaran
        .Include(t => t.MataPelajaran).ThenInclude(m => m.Peminatan)
        .Include(t => t.DaftarJadwalMengajar)
        .Where(t => t.Fase == fase)
        .ToListAsync();

    public async Task<bool> IsExist(int nomor, int idMataPelajaran, Fase fase, int? id = null) => await _appDbContext.TblTujuanPembelajaran
        .Include(t => t.MataPelajaran)
        .AnyAsync(t => t.Id != id && t.MataPelajaran.Id == idMataPelajaran && t.Fase == fase && t.Nomor == nomor);

    public async Task<bool> IsExist(string deskripsi, int idMataPelajaran, Fase fase, int? id = null) => await _appDbContext.TblTujuanPembelajaran
        .Include(t => t.MataPelajaran)
        .AnyAsync(t => t.Id != id && t.MataPelajaran.Id == idMataPelajaran && t.Fase == fase && t.Deskripsi.ToLower() == deskripsi.ToLower());
}
