using Microsoft.EntityFrameworkCore;
using SIAkademik.Domain.Entities;
using SIAkademik.Domain.Repositories;
using SIAkademik.Infrastructure.Database;
using System.Threading.Tasks;

namespace SIAkademik.Infrastructure.Repositories;

internal class SiswaRepository : ISiswaRepository
{
    private readonly AppDbContext _appDbContext;

    public SiswaRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public void Add(Siswa siswa) => _appDbContext.TblSiswa.Add(siswa);

    public void Delete(Siswa siswa) => _appDbContext.TblSiswa.Remove(siswa);

    public async Task<Siswa?> Get(string nisn) => await _appDbContext
        .TblSiswa
        .Include(s => s.DaftarAnggotaRombel).ThenInclude(a => a.Rombel).ThenInclude(r => r.Wali)
        .Include(s => s.DaftarAnggotaRombel).ThenInclude(a => a.DaftarAbsen)
        .Include(s => s.DaftarAnggotaRombel).ThenInclude(a => a.DaftarNilai)
        .Include(s => s.Account)
        .FirstOrDefaultAsync(s => s.Id == nisn);

    public async Task<List<Siswa>> GetAll() => await _appDbContext
        .TblSiswa
        .Include(s => s.DaftarAnggotaRombel).ThenInclude(a => a.Rombel).ThenInclude(r => r.Wali)
        .Include(s => s.DaftarAnggotaRombel).ThenInclude(a => a.DaftarAbsen)
        .Include(s => s.DaftarAnggotaRombel).ThenInclude(a => a.DaftarNilai)
        .Include(s => s.Account)
        .ToListAsync();
}
