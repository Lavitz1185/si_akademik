using Microsoft.EntityFrameworkCore;
using SIAkademik.Domain.Enums;
using SIAkademik.Domain.ModulSiakad.Entities;
using SIAkademik.Domain.ModulSiakad.Repositories;
using SIAkademik.Infrastructure.Database;

namespace SIAkademik.Infrastructure.ModulSiakad.Repositories;

internal class KelasRepository : IKelasRepository
{
    private readonly AppDbContext _appDbContext;

    public KelasRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public void Add(Kelas kelas) => _appDbContext.TblKelas.Add(kelas);

    public void Delete(Kelas kelas) => _appDbContext.TblKelas.Remove(kelas);

    public async Task<Kelas?> Get(int id) => await _appDbContext
        .TblKelas
        .Include(k => k.Peminatan)
        .Include(k => k.DaftarRombel).ThenInclude(r => r.DaftarAnggotaRombel)
        .Include(k => k.DaftarRombel).ThenInclude(r => r.DaftarJadwalMengajar)
        .Include(k => k.DaftarRombel).ThenInclude(r => r.Wali)
        .FirstOrDefaultAsync(k => k.Id == id);

    public async Task<List<Kelas>> GetAll() => await _appDbContext
        .TblKelas
        .Include(k => k.Peminatan)
        .Include(k => k.DaftarRombel).ThenInclude(r => r.DaftarAnggotaRombel)
        .Include(k => k.DaftarRombel).ThenInclude(r => r.DaftarJadwalMengajar)
        .Include(k => k.DaftarRombel).ThenInclude(r => r.Wali)
        .Include(k => k.DaftarRombel).ThenInclude(r => r.TahunAjaran)
        .ToListAsync();

    public async Task<List<Kelas>> GetAllByPeminatan(Peminatan peminatan) => await _appDbContext
        .TblKelas
        .Include(k => k.Peminatan)
        .Include(k => k.DaftarRombel).ThenInclude(r => r.DaftarAnggotaRombel)
        .Include(k => k.DaftarRombel).ThenInclude(r => r.DaftarJadwalMengajar)
        .Include(k => k.DaftarRombel).ThenInclude(r => r.Wali)
        .Include(k => k.DaftarRombel).ThenInclude(r => r.TahunAjaran)
        .Where(k => k.Peminatan == peminatan)
        .ToListAsync();
}
