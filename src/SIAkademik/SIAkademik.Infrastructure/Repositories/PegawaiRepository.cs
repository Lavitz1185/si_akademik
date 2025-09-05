using Microsoft.EntityFrameworkCore;
using SIAkademik.Domain.Entities;
using SIAkademik.Domain.Repositories;
using SIAkademik.Infrastructure.Database;

namespace SIAkademik.Infrastructure.Repositories;

internal class PegawaiRepository : IPegawaiRepository
{
    private readonly AppDbContext _appDbContext;

    public PegawaiRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public void Add(Pegawai pegawai) => _appDbContext.TblPegawai.Add(pegawai);

    public void Delete(Pegawai pegawai) => _appDbContext.TblPegawai.Remove(pegawai);

    public async Task<Pegawai?> Get(string nip) => await _appDbContext
        .TblPegawai
        .Include(p => p.DaftarRombelWali)
        .Include(p => p.DaftarJadwalMengajar).ThenInclude(j => j.MataPelajaran)
        .Include(p => p.DaftarJadwalMengajar).ThenInclude(j => j.Rombel)
        .Include(p => p.Account)
        .Include(p => p.Jabatan)
        .Include(p => p.Divisi)
        .FirstOrDefaultAsync(p => p.Id == nip);

    public async Task<List<Pegawai>> GetAll() => await _appDbContext
        .TblPegawai
        .Include(p => p.DaftarRombelWali)
        .Include(p => p.DaftarJadwalMengajar).ThenInclude(j => j.MataPelajaran)
        .Include(p => p.DaftarJadwalMengajar).ThenInclude(j => j.Rombel)
        .Include(p => p.Account)
        .Include(p => p.Jabatan)
        .Include(p => p.Divisi)
        .ToListAsync();
}
