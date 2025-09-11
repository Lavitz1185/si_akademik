using Microsoft.EntityFrameworkCore;
using SIAkademik.Domain.ModulSiakad.Entities;
using SIAkademik.Domain.ModulSiakad.Repositories;
using SIAkademik.Infrastructure.Database;

namespace SIAkademik.Infrastructure.ModulSiakad.Repositories;

internal class NilaiRepository : INilaiRepository
{
    private readonly AppDbContext _appDbContext;

    public NilaiRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public void Add(Nilai nilai) => _appDbContext.TblNilai.Add(nilai);

    public void Delete(Nilai nilai) => _appDbContext.TblNilai.Remove(nilai);

    public async Task<Nilai?> Get(int id) => await _appDbContext
        .TblNilai
        .Include(a => a.AnggotaRombel).ThenInclude(r => r.Rombel)
        .Include(a => a.AnggotaRombel).ThenInclude(r => r.Siswa)
        .Include(a => a.JadwalMengajar).ThenInclude(j => j.Rombel)
        .Include(a => a.JadwalMengajar).ThenInclude(j => j.MataPelajaran)
        .Include(a => a.JadwalMengajar).ThenInclude(j => j.Pegawai)
        .FirstOrDefaultAsync(a => a.Id == id);

    public async Task<List<Nilai>> GetAll() => await _appDbContext
        .TblNilai
        .Include(a => a.AnggotaRombel).ThenInclude(r => r.Rombel)
        .Include(a => a.AnggotaRombel).ThenInclude(r => r.Siswa)
        .Include(a => a.JadwalMengajar).ThenInclude(j => j.Rombel)
        .Include(a => a.JadwalMengajar).ThenInclude(j => j.MataPelajaran)
        .Include(a => a.JadwalMengajar).ThenInclude(j => j.Pegawai)
        .ToListAsync();
}
