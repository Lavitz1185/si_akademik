using Microsoft.EntityFrameworkCore;
using SIAkademik.Domain.ModulSiakad.Entities;
using SIAkademik.Domain.ModulSiakad.Repositories;
using SIAkademik.Infrastructure.Database;

namespace SIAkademik.Infrastructure.ModulSiakad.Repositories;

internal class RombelRepository : IRombelRepository
{
    private readonly AppDbContext _appDbContext;

    public RombelRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public void Add(Rombel rombel) => _appDbContext.TblRombel.Add(rombel);

    public void Delete(Rombel rombel) => _appDbContext.TblRombel.Remove(rombel);

    public async Task<Rombel?> Get(int id) => await _appDbContext
        .TblRombel
        .Include(r => r.Kelas)
        .Include(r => r.Wali)
        .Include(r => r.DaftarJadwalMengajar).ThenInclude(j => j.Pegawai)
        .Include(r => r.DaftarJadwalMengajar).ThenInclude(j => j.MataPelajaran)
        .Include(r => r.DaftarJadwalMengajar).ThenInclude(j => j.DaftarNilai)
        .Include(r => r.DaftarAnggotaRombel).ThenInclude(a => a.Siswa)
        .Include(r => r.DaftarAnggotaRombel).ThenInclude(a => a.DaftarNilai)
        .Include(r => r.DaftarAnggotaRombel).ThenInclude(a => a.DaftarAbsen)
        .FirstOrDefaultAsync(r => r.Id == id);

    public async Task<List<Rombel>> GetAll() => await _appDbContext
        .TblRombel
        .Include(r => r.Kelas)
        .Include(r => r.Wali)
        .Include(r => r.DaftarJadwalMengajar).ThenInclude(j => j.Pegawai)
        .Include(r => r.DaftarJadwalMengajar).ThenInclude(j => j.MataPelajaran)
        .Include(r => r.DaftarJadwalMengajar).ThenInclude(j => j.DaftarNilai)
        .Include(r => r.DaftarAnggotaRombel).ThenInclude(a => a.Siswa)
        .Include(r => r.DaftarAnggotaRombel).ThenInclude(a => a.DaftarNilai)
        .Include(r => r.DaftarAnggotaRombel).ThenInclude(a => a.DaftarAbsen)
        .ToListAsync();

    public async Task<List<Rombel>> GetAllByKelas(int idKelas) => await _appDbContext
        .TblRombel
        .Include(r => r.Kelas)
        .Include(r => r.Wali)
        .Include(r => r.DaftarJadwalMengajar).ThenInclude(j => j.Pegawai)
        .Include(r => r.DaftarJadwalMengajar).ThenInclude(j => j.MataPelajaran)
        .Include(r => r.DaftarJadwalMengajar).ThenInclude(j => j.DaftarNilai)
        .Include(r => r.DaftarAnggotaRombel).ThenInclude(a => a.Siswa)
        .Include(r => r.DaftarAnggotaRombel).ThenInclude(a => a.DaftarNilai)
        .Include(r => r.DaftarAnggotaRombel).ThenInclude(a => a.DaftarAbsen)
        .Where(r => r.Kelas.Id == idKelas)
        .ToListAsync();
}
