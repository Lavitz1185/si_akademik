using Microsoft.EntityFrameworkCore;
using SIAkademik.Domain.ModulSiakad.Entities;
using SIAkademik.Domain.ModulSiakad.Repositories;
using SIAkademik.Infrastructure.Database;

namespace SIAkademik.Infrastructure.ModulSiakad.Repositories;

internal class MataPelajaranRepository : IMataPelajaranRepository
{
    private readonly AppDbContext _appDbContext;

    public MataPelajaranRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public void Add(MataPelajaran mataPelajaran) => _appDbContext.TblMataPelajaran.Add(mataPelajaran);

    public void Delete(MataPelajaran mataPelajaran) => _appDbContext.TblMataPelajaran.Remove(mataPelajaran);

    public async Task<MataPelajaran?> Get(int id) => await _appDbContext
        .TblMataPelajaran
        .Include(m => m.DaftarJadwalMengajar).ThenInclude(j => j.Pegawai)
        .Include(m => m.DaftarJadwalMengajar).ThenInclude(j => j.Rombel)
        .Include(m => m.DaftarJadwalMengajar).ThenInclude(j => j.DaftarHariMengajar)
        .FirstOrDefaultAsync(m => m.Id == id);

    public async Task<List<MataPelajaran>> GetAll() => await _appDbContext
        .TblMataPelajaran
        .Include(m => m.DaftarJadwalMengajar).ThenInclude(j => j.Pegawai)
        .Include(m => m.DaftarJadwalMengajar).ThenInclude(j => j.Rombel)
        .Include(m => m.DaftarJadwalMengajar).ThenInclude(j => j.DaftarHariMengajar)
        .ToListAsync();
}
