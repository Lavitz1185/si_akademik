using Microsoft.EntityFrameworkCore;
using SIAkademik.Domain.Enums;
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
        .Include(k => k.DaftarRombel).ThenInclude(r => r.DaftarAnggotaRombel)
        .Include(k => k.DaftarRombel).ThenInclude(r => r.Kelas).ThenInclude(k => k.Peminatan)
        .FirstOrDefaultAsync(t => t.Id == id);

    public async Task<TahunAjaran?> Get(DateOnly tanggal) => await _appDbContext
        .TblTahunAjaran
        .Include(k => k.DaftarRombel).ThenInclude(r => r.DaftarAnggotaRombel)
        .Include(k => k.DaftarRombel).ThenInclude(r => r.Kelas).ThenInclude(k => k.Peminatan)
        .FirstOrDefaultAsync(t => tanggal <= t.TanggalSelesai && tanggal >= t.TanggalMulai);

    public async Task<TahunAjaran?> Get(int tahun, Semester semester) => await _appDbContext
        .TblTahunAjaran
        .Include(k => k.DaftarRombel).ThenInclude(r => r.DaftarAnggotaRombel)
        .Include(k => k.DaftarRombel).ThenInclude(r => r.Kelas).ThenInclude(k => k.Peminatan)
        .FirstOrDefaultAsync(t => t.Tahun == tahun && t.Semester == semester);

    public async Task<List<TahunAjaran>> GetAll() => await _appDbContext
        .TblTahunAjaran
        .Include(k => k.DaftarRombel).ThenInclude(r => r.Kelas).ThenInclude(k => k.Peminatan)
        .OrderBy(t => t.Tahun).ThenBy(t => t.Semester)
        .ToListAsync();

    public async Task<List<TahunAjaran>> GetAll(Semester semester) => await _appDbContext
        .TblTahunAjaran
        .Include(k => k.DaftarRombel).ThenInclude(r => r.Kelas).ThenInclude(k => k.Peminatan)
        .Where(t => t.Semester == semester)
        .OrderBy(t => t.Tahun).ThenBy(t => t.Semester)
        .ToListAsync();

    public async Task<TahunAjaran?> GetNewest() => await _appDbContext
        .TblTahunAjaran
        .Include(k => k.DaftarRombel).ThenInclude(r => r.Kelas).ThenInclude(k => k.Peminatan)
        .OrderBy(t => t.Tahun).ThenBy(t => t.Semester)
        .LastOrDefaultAsync();
}
