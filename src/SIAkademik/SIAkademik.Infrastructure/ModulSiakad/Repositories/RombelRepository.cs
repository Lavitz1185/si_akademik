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
        .Include(r => r.Kelas).ThenInclude(k => k.TahunAjaran)
        .Include(r => r.Kelas).ThenInclude(k => k.Peminatan)
        .Include(r => r.Wali)
        .Include(r => r.DaftarJadwalMengajar).ThenInclude(j => j.Pegawai)
        .Include(r => r.DaftarJadwalMengajar).ThenInclude(j => j.MataPelajaran)
        .Include(r => r.DaftarJadwalMengajar).ThenInclude(j => j.DaftarEvaluasiSiswa).ThenInclude(e => e.DaftarAnggotaRombel)
        .Include(r => r.DaftarJadwalMengajar).ThenInclude(j => j.DaftarHariMengajar)
        .Include(r => r.DaftarAnggotaRombel).ThenInclude(a => a.Siswa)
        .Include(r => r.DaftarAnggotaRombel).ThenInclude(a => a.DaftarEvaluasiSiswa).ThenInclude(e => e.DaftarNilaiEvaluasiSiswa)
        .Include(r => r.DaftarAnggotaRombel).ThenInclude(a => a.DaftarAbsen)
        .Include(r => r.DaftarAnggotaRombel).ThenInclude(a => a.DaftarAbsenKelas)
        .Include(r => r.DaftarAnggotaRombel).ThenInclude(a => a.DaftarRaport).ThenInclude(r => r.JadwalMengajar).ThenInclude(j => j.MataPelajaran).ThenInclude(m => m.Peminatan)
        .FirstOrDefaultAsync(r => r.Id == id);

    public async Task<List<Rombel>> GetAll() => await _appDbContext
        .TblRombel
        .Include(r => r.Kelas).ThenInclude(k => k.TahunAjaran)
        .Include(r => r.Kelas).ThenInclude(k => k.Peminatan)
        .Include(r => r.Wali)
        .Include(r => r.DaftarJadwalMengajar).ThenInclude(j => j.Pegawai)
        .Include(r => r.DaftarJadwalMengajar).ThenInclude(j => j.MataPelajaran)
        .Include(r => r.DaftarJadwalMengajar).ThenInclude(j => j.DaftarEvaluasiSiswa).ThenInclude(e => e.DaftarAnggotaRombel)
        .Include(r => r.DaftarAnggotaRombel).ThenInclude(a => a.Siswa)
        .Include(r => r.DaftarAnggotaRombel).ThenInclude(a => a.DaftarEvaluasiSiswa).ThenInclude(e => e.DaftarNilaiEvaluasiSiswa)
        .Include(r => r.DaftarAnggotaRombel).ThenInclude(a => a.DaftarAbsen)
        .Include(r => r.DaftarAnggotaRombel).ThenInclude(a => a.DaftarAbsenKelas)
        .Include(r => r.DaftarAnggotaRombel).ThenInclude(a => a.DaftarRaport).ThenInclude(r => r.JadwalMengajar)
        .ToListAsync();

    public async Task<List<Rombel>> GetAllByKelas(int idKelas) => await _appDbContext
        .TblRombel
        .Include(r => r.Kelas).ThenInclude(k => k.TahunAjaran)
        .Include(r => r.Kelas).ThenInclude(k => k.Peminatan)
        .Include(r => r.Wali)
        .Include(r => r.DaftarJadwalMengajar).ThenInclude(j => j.Pegawai)
        .Include(r => r.DaftarJadwalMengajar).ThenInclude(j => j.MataPelajaran)
        .Include(r => r.DaftarJadwalMengajar).ThenInclude(j => j.DaftarEvaluasiSiswa).ThenInclude(e => e.DaftarAnggotaRombel)
        .Include(r => r.DaftarAnggotaRombel).ThenInclude(a => a.Siswa)
        .Include(r => r.DaftarAnggotaRombel).ThenInclude(a => a.DaftarEvaluasiSiswa).ThenInclude(e => e.DaftarNilaiEvaluasiSiswa)
        .Include(r => r.DaftarAnggotaRombel).ThenInclude(a => a.DaftarAbsen)
        .Include(r => r.DaftarAnggotaRombel).ThenInclude(a => a.DaftarAbsenKelas)
        .Include(r => r.DaftarAnggotaRombel).ThenInclude(a => a.DaftarRaport).ThenInclude(r => r.JadwalMengajar)
        .Where(r => r.Kelas.Id == idKelas)
        .ToListAsync();

    public async Task<List<Rombel>> GetAllByTahunAjaran(int idTahunAjaran) => await _appDbContext
        .TblRombel
        .Include(r => r.Kelas).ThenInclude(r => r.TahunAjaran)
        .Include(r => r.Kelas).ThenInclude(k => k.Peminatan)
        .Include(r => r.Wali)
        .Include(r => r.DaftarJadwalMengajar).ThenInclude(j => j.Pegawai)
        .Include(r => r.DaftarJadwalMengajar).ThenInclude(j => j.MataPelajaran)
        .Include(r => r.DaftarJadwalMengajar).ThenInclude(j => j.DaftarEvaluasiSiswa).ThenInclude(e => e.DaftarAnggotaRombel)
        .Include(r => r.DaftarAnggotaRombel).ThenInclude(a => a.Siswa)
        .Include(r => r.DaftarAnggotaRombel).ThenInclude(a => a.DaftarEvaluasiSiswa).ThenInclude(e => e.DaftarNilaiEvaluasiSiswa)
        .Include(r => r.DaftarAnggotaRombel).ThenInclude(a => a.DaftarAbsen)
        .Include(r => r.DaftarAnggotaRombel).ThenInclude(a => a.DaftarAbsenKelas)
        .Include(r => r.DaftarAnggotaRombel).ThenInclude(a => a.DaftarRaport).ThenInclude(r => r.JadwalMengajar)
        .Where(r => r.Kelas.TahunAjaran.Id == idTahunAjaran)
        .ToListAsync();
}
