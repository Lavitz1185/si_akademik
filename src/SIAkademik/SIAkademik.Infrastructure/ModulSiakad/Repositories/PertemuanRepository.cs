using Microsoft.EntityFrameworkCore;
using SIAkademik.Domain.ModulSiakad.Entities;
using SIAkademik.Domain.ModulSiakad.Repositories;
using SIAkademik.Infrastructure.Database;

namespace SIAkademik.Infrastructure.ModulSiakad.Repositories;

internal class PertemuanRepository : IPertemuanRepository
{
    private readonly AppDbContext _appDbContext;

    public PertemuanRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public void Add(Pertemuan pertemuan) => _appDbContext.TblPertemuan.Add(pertemuan);

    public void Delete(Pertemuan pertemuan) => _appDbContext.TblPertemuan.Remove(pertemuan);

    public async Task<Pertemuan?> Get(int id) => await _appDbContext.TblPertemuan
        .Include(p => p.JadwalMengajar).ThenInclude(j => j.Pegawai)
        .Include(p => p.JadwalMengajar).ThenInclude(j => j.MataPelajaran).ThenInclude(m => m.Peminatan)
        .Include(p => p.JadwalMengajar).ThenInclude(j => j.Rombel).ThenInclude(r => r.Kelas).ThenInclude(k => k.TahunAjaran)
        .Include(p => p.JadwalMengajar).ThenInclude(j => j.Rombel).ThenInclude(r => r.Kelas).ThenInclude(k => k.Peminatan)
        .Include(p => p.JadwalMengajar).ThenInclude(j => j.Rombel).ThenInclude(r => r.DaftarAnggotaRombel).ThenInclude(a => a.Siswa)
        .Include(p => p.DaftarAbsen).ThenInclude(a => a.AnggotaRombel).ThenInclude(a => a.Siswa)
        .Include(p => p.DaftarAbsen).ThenInclude(a => a.AnggotaRombel).ThenInclude(a => a.Rombel)
        .FirstOrDefaultAsync(p => p.Id == id);

    public async Task<List<Pertemuan>> GetAll() => await _appDbContext.TblPertemuan
        .Include(p => p.JadwalMengajar).ThenInclude(j => j.Pegawai)
        .Include(p => p.JadwalMengajar).ThenInclude(j => j.MataPelajaran).ThenInclude(m => m.Peminatan)
        .Include(p => p.JadwalMengajar).ThenInclude(j => j.Rombel).ThenInclude(r => r.Kelas).ThenInclude(k => k.TahunAjaran)
        .Include(p => p.JadwalMengajar).ThenInclude(j => j.Rombel).ThenInclude(r => r.Kelas).ThenInclude(k => k.Peminatan)
        .Include(p => p.JadwalMengajar).ThenInclude(j => j.Rombel).ThenInclude(r => r.DaftarAnggotaRombel).ThenInclude(a => a.Siswa)
        .Include(p => p.DaftarAbsen).ThenInclude(a => a.AnggotaRombel).ThenInclude(a => a.Siswa)
        .Include(p => p.DaftarAbsen).ThenInclude(a => a.AnggotaRombel).ThenInclude(a => a.Rombel)
        .ToListAsync();

    public async Task<List<Pertemuan>> GetAllByJadwalMengajar(int idJadwalMengajar) => await _appDbContext.TblPertemuan
        .Include(p => p.JadwalMengajar).ThenInclude(j => j.Pegawai)
        .Include(p => p.JadwalMengajar).ThenInclude(j => j.MataPelajaran).ThenInclude(m => m.Peminatan)
        .Include(p => p.JadwalMengajar).ThenInclude(j => j.Rombel).ThenInclude(r => r.Kelas).ThenInclude(k => k.TahunAjaran)
        .Include(p => p.JadwalMengajar).ThenInclude(j => j.Rombel).ThenInclude(r => r.Kelas).ThenInclude(k => k.Peminatan)
        .Include(p => p.JadwalMengajar).ThenInclude(j => j.Rombel).ThenInclude(r => r.DaftarAnggotaRombel).ThenInclude(a => a.Siswa)
        .Include(p => p.DaftarAbsen).ThenInclude(a => a.AnggotaRombel).ThenInclude(a => a.Siswa)
        .Include(p => p.DaftarAbsen).ThenInclude(a => a.AnggotaRombel).ThenInclude(a => a.Rombel)
        .Where(p => p.JadwalMengajar.Id == idJadwalMengajar)
        .ToListAsync();
}
