using Microsoft.EntityFrameworkCore;
using SIAkademik.Domain.ModulSiakad.Entities;
using SIAkademik.Domain.ModulSiakad.Repositories;
using SIAkademik.Infrastructure.Database;

namespace SIAkademik.Infrastructure.ModulSiakad.Repositories;

internal class RaportRepository : IRaportRepository
{
    private readonly AppDbContext _appDbContext;

    public RaportRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public void Add(Raport raport) => _appDbContext.TblRaport.Add(raport);

    public void Delete(Raport raport) => _appDbContext.TblRaport.Remove(raport);

    public async Task<Raport?> Get(int id) => await _appDbContext
        .TblRaport
        .Include(r => r.AnggotaRombel).ThenInclude(a => a.Siswa)
        .Include(r => r.AnggotaRombel).ThenInclude(a => a.Rombel).ThenInclude(r => r.Kelas).ThenInclude(k => k.TahunAjaran)
        .Include(r => r.AnggotaRombel).ThenInclude(a => a.Rombel).ThenInclude(r => r.Kelas).ThenInclude(k => k.Peminatan)
        .Include(r => r.AnggotaRombel).ThenInclude(a => a.Rombel).ThenInclude(r => r.DaftarJadwalMengajar)
            .ThenInclude(j => j.MataPelajaran).ThenInclude(m => m.Peminatan)
        .Include(r => r.AnggotaRombel).ThenInclude(a => a.Rombel).ThenInclude(r => r.DaftarJadwalMengajar)
            .ThenInclude(j => j.Pegawai)
        .Include(r => r.AnggotaRombel).ThenInclude(a => a.DaftarNilai).ThenInclude(n => n.JadwalMengajar)
        .Include(r => r.AnggotaRombel).ThenInclude(a => a.DaftarAbsen).ThenInclude(a => a.Pertemuan)
        .Include(r => r.AnggotaRombel).ThenInclude(a => a.DaftarAbsenKelas)
        .Include(r => r.AnggotaRombel).ThenInclude(a => a.DaftarRaport)
        .FirstOrDefaultAsync(r => r.Id == id);

    public async Task<List<Raport>> GetAll() => await _appDbContext
        .TblRaport
        .Include(r => r.AnggotaRombel).ThenInclude(a => a.Siswa)
        .Include(r => r.AnggotaRombel).ThenInclude(a => a.Rombel).ThenInclude(r => r.Kelas).ThenInclude(k => k.TahunAjaran)
        .Include(r => r.AnggotaRombel).ThenInclude(a => a.Rombel).ThenInclude(r => r.Kelas).ThenInclude(k => k.Peminatan)
        .Include(r => r.AnggotaRombel).ThenInclude(a => a.Rombel).ThenInclude(r => r.DaftarJadwalMengajar)
            .ThenInclude(j => j.MataPelajaran).ThenInclude(m => m.Peminatan)
        .Include(r => r.AnggotaRombel).ThenInclude(a => a.Rombel).ThenInclude(r => r.DaftarJadwalMengajar)
            .ThenInclude(j => j.Pegawai)
        .Include(r => r.AnggotaRombel).ThenInclude(a => a.DaftarNilai).ThenInclude(n => n.JadwalMengajar)
        .Include(r => r.AnggotaRombel).ThenInclude(a => a.DaftarAbsen).ThenInclude(a => a.Pertemuan)
        .Include(r => r.AnggotaRombel).ThenInclude(a => a.DaftarAbsenKelas)
        .ToListAsync();

    public async Task<List<Raport>> GetAllBy(int idSiswa, int idRombel) => await _appDbContext
        .TblRaport
        .Include(r => r.AnggotaRombel).ThenInclude(a => a.Siswa)
        .Include(r => r.AnggotaRombel).ThenInclude(a => a.Rombel).ThenInclude(r => r.Kelas).ThenInclude(k => k.TahunAjaran)
        .Include(r => r.AnggotaRombel).ThenInclude(a => a.Rombel).ThenInclude(r => r.Kelas).ThenInclude(k => k.Peminatan)
        .Include(r => r.AnggotaRombel).ThenInclude(a => a.Rombel).ThenInclude(r => r.DaftarJadwalMengajar)
            .ThenInclude(j => j.MataPelajaran).ThenInclude(m => m.Peminatan)
        .Include(r => r.AnggotaRombel).ThenInclude(a => a.Rombel).ThenInclude(r => r.DaftarJadwalMengajar)
            .ThenInclude(j => j.Pegawai)
        .Include(r => r.AnggotaRombel).ThenInclude(a => a.DaftarNilai).ThenInclude(n => n.JadwalMengajar)
        .Include(r => r.AnggotaRombel).ThenInclude(a => a.DaftarAbsen).ThenInclude(a => a.Pertemuan)
        .Include(r => r.AnggotaRombel).ThenInclude(a => a.DaftarAbsenKelas)
        .Where(r => r.AnggotaRombel.IdSiswa == idSiswa && r.AnggotaRombel.IdRombel == idRombel)
        .ToListAsync();
}
