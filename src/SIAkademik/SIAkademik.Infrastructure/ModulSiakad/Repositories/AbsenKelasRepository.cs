using Microsoft.EntityFrameworkCore;
using SIAkademik.Domain.ModulSiakad.Entities;
using SIAkademik.Domain.ModulSiakad.Repositories;
using SIAkademik.Infrastructure.Database;

namespace SIAkademik.Infrastructure.ModulSiakad.Repositories;

internal class AbsenKelasRepository : IAbsenKelasRepository
{
    private readonly AppDbContext _appDbContext;

    public AbsenKelasRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public void Add(AbsenKelas absenKelas) => _appDbContext.TblAbsenKelas.Add(absenKelas);

    public void Delete(AbsenKelas absenKelas) => _appDbContext.TblAbsenKelas.Remove(absenKelas);

    public async Task<AbsenKelas?> Get(int id) => await _appDbContext.TblAbsenKelas
        .Include(a => a.AnggotaRombel).ThenInclude(a => a.Siswa)
        .Include(a => a.AnggotaRombel).ThenInclude(a => a.Rombel).ThenInclude(r => r.Kelas).ThenInclude(k => k.TahunAjaran)
        .FirstOrDefaultAsync(a => a.Id == id);

    public async Task<List<AbsenKelas>> GetAll() => await _appDbContext.TblAbsenKelas
        .Include(a => a.AnggotaRombel).ThenInclude(a => a.Siswa)
        .Include(a => a.AnggotaRombel).ThenInclude(a => a.Rombel).ThenInclude(r => r.Kelas).ThenInclude(k => k.TahunAjaran)
        .ToListAsync();

    public async Task<List<AbsenKelas>> GetAllByRombel(int idRombel) => await _appDbContext.TblAbsenKelas
        .Include(a => a.AnggotaRombel).ThenInclude(a => a.Siswa)
        .Include(a => a.AnggotaRombel).ThenInclude(a => a.Rombel).ThenInclude(r => r.Kelas).ThenInclude(k => k.TahunAjaran)
        .Where(a => a.AnggotaRombel.Rombel.Id == idRombel)
        .ToListAsync();

    public async Task<List<AbsenKelas>> GetAllBySiswa(int idSiswa) => await _appDbContext.TblAbsenKelas
        .Include(a => a.AnggotaRombel).ThenInclude(a => a.Siswa)
        .Include(a => a.AnggotaRombel).ThenInclude(a => a.Rombel).ThenInclude(r => r.Kelas).ThenInclude(k => k.TahunAjaran)
        .Where(a => a.AnggotaRombel.Siswa.Id == idSiswa)
        .ToListAsync();

    public void Update(AbsenKelas absenKelas) => _appDbContext.TblAbsenKelas.Update(absenKelas);
}
