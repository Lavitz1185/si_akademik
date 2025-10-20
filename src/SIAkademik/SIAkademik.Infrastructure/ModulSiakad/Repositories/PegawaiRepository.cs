using Microsoft.EntityFrameworkCore;
using SIAkademik.Domain.ModulSiakad.Entities;
using SIAkademik.Domain.ModulSiakad.Repositories;
using SIAkademik.Infrastructure.Database;

namespace SIAkademik.Infrastructure.ModulSiakad.Repositories;

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
        .Include(p => p.DaftarRombelWali).ThenInclude(r => r.Kelas).ThenInclude(k => k.TahunAjaran)
        .Include(p => p.DaftarRombelWali).ThenInclude(r => r.DaftarAnggotaRombel)
        .Include(p => p.DaftarJadwalMengajar).ThenInclude(j => j.MataPelajaran).ThenInclude(m => m.Peminatan)
        .Include(p => p.DaftarJadwalMengajar).ThenInclude(j => j.DaftarHariMengajar)
        .Include(p => p.DaftarJadwalMengajar).ThenInclude(j => j.Rombel).ThenInclude(r => r.Kelas).ThenInclude(k => k.TahunAjaran)
        .Include(p => p.DaftarJadwalMengajar).ThenInclude(j => j.Rombel).ThenInclude(r => r.Kelas).ThenInclude(k => k.Peminatan)
        .Include(p => p.Account)
        .Include(p => p.Jabatan)
        .Include(p => p.Divisi)
        .FirstOrDefaultAsync(p => p.Id == nip);

    public async Task<List<Pegawai>> GetAll() => await _appDbContext
        .TblPegawai
        .Include(p => p.DaftarRombelWali).ThenInclude(r => r.Kelas).ThenInclude(k => k.TahunAjaran)
        .Include(p => p.DaftarJadwalMengajar).ThenInclude(j => j.MataPelajaran).ThenInclude(m => m.Peminatan)
        .Include(p => p.DaftarJadwalMengajar).ThenInclude(j => j.DaftarHariMengajar)
        .Include(p => p.DaftarJadwalMengajar).ThenInclude(j => j.Rombel).ThenInclude(r => r.Kelas).ThenInclude(k => k.TahunAjaran)
        .Include(p => p.DaftarJadwalMengajar).ThenInclude(j => j.Rombel).ThenInclude(r => r.Kelas).ThenInclude(k => k.Peminatan)
        .Include(p => p.Account)
        .Include(p => p.Jabatan)
        .Include(p => p.Divisi)
        .ToListAsync();

    public async Task<bool> IsExist(string nip) => await _appDbContext
        .TblPegawai
        .AnyAsync(p => p.Id == nip);

    public async Task<bool> IsExistByEmail(string email, string? nip = null) => await _appDbContext
        .TblPegawai
        .AnyAsync(p => p.Id != nip && p.Email == email);
}
