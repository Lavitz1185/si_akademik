using Microsoft.EntityFrameworkCore;
using SIAkademik.Domain.ModulSiakad.Entities;
using SIAkademik.Domain.ModulSiakad.Repositories;
using SIAkademik.Infrastructure.Database;

namespace SIAkademik.Infrastructure.ModulSiakad.Repositories;

internal class JadwalMengajarRepository : IJadwalMengajarRepository
{
    private readonly AppDbContext _appDbContext;

    public JadwalMengajarRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public void Add(JadwalMengajar jadwalMengajar) => _appDbContext.TblJadwalMengajar.Add(jadwalMengajar);

    public void Delete(JadwalMengajar jadwalMengajar) => _appDbContext.TblJadwalMengajar.Remove(jadwalMengajar);

    public async Task<JadwalMengajar?> Get(int id) => await _appDbContext
        .TblJadwalMengajar
        .Include(j => j.MataPelajaran)
        .Include(j => j.Rombel).ThenInclude(r => r.Kelas).ThenInclude(k => k.TahunAjaran)
        .Include(j => j.Pegawai)
        .Include(j => j.DaftarHariMengajar)
        .FirstOrDefaultAsync(j => j.Id == id);

    public async Task<List<JadwalMengajar>> GetAll() => await _appDbContext
        .TblJadwalMengajar
        .Include(j => j.MataPelajaran)
        .Include(j => j.Rombel).ThenInclude(r => r.Kelas).ThenInclude(k => k.TahunAjaran)
        .Include(j => j.Pegawai)
        .Include(j => j.DaftarHariMengajar)
        .ToListAsync();

    public async Task<List<JadwalMengajar>> GetAllByTahunAjaran(int idTahunAjaran) => await _appDbContext
        .TblJadwalMengajar
        .Include(j => j.MataPelajaran)
        .Include(j => j.Rombel).ThenInclude(r => r.Kelas).ThenInclude(k => k.TahunAjaran)
        .Include(j => j.Pegawai)
        .Include(j => j.DaftarHariMengajar)
        .Where(j => j.Rombel.Kelas.TahunAjaran.Id == idTahunAjaran)
        .ToListAsync();
}
