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
        .Include(j => j.MataPelajaran).ThenInclude(m => m.Peminatan)
        .Include(j => j.Rombel).ThenInclude(r => r.Wali)
        .Include(j => j.Rombel).ThenInclude(k => k.TahunAjaran)
        .Include(j => j.Rombel).ThenInclude(r => r.Kelas).ThenInclude(k => k.Peminatan)
        .Include(j => j.Rombel).ThenInclude(r => r.DaftarAnggotaRombel).ThenInclude(a => a.Siswa)
        .Include(j => j.Rombel).ThenInclude(r => r.DaftarAnggotaRombel).ThenInclude(a => a.DaftarEvaluasiSiswa)
        .Include(j => j.Pegawai)
        .Include(j => j.DaftarHariMengajar)
        .Include(j => j.DaftarPertemuan)
        .Include(j => j.DaftarEvaluasiSiswa).ThenInclude(n => n.DaftarAnggotaRombel).ThenInclude(a => a.Siswa)
        .Include(j => j.DaftarEvaluasiSiswa).ThenInclude(n => n.DaftarAnggotaRombel).ThenInclude(a => a.Rombel)
        .Include(j => j.DaftarEvaluasiSiswa).ThenInclude(n => n.DaftarNilaiEvaluasiSiswa)
        .Include(j => j.DaftarAsesmenSumatifAkhirSemester).ThenInclude(a => a.AnggotaRombel)
        .Include(j => j.DaftarTujuanPembelajaran)
        .Include(j => j.DaftarAsesmenSumatif).ThenInclude(a => a.DaftarEvaluasiSiswa).ThenInclude(e => e.DaftarNilaiEvaluasiSiswa)
        .Include(j => j.DaftarAsesmenSumatif).ThenInclude(a => a.TujuanPembelajaran)
        .FirstOrDefaultAsync(j => j.Id == id);

    public async Task<List<JadwalMengajar>> GetAll() => await _appDbContext
        .TblJadwalMengajar
        .Include(j => j.MataPelajaran).ThenInclude(m => m.Peminatan)
        .Include(j => j.Rombel).ThenInclude(k => k.TahunAjaran)
        .Include(j => j.Rombel).ThenInclude(r => r.Kelas).ThenInclude(k => k.Peminatan)
        .Include(j => j.Rombel).ThenInclude(r => r.DaftarAnggotaRombel).ThenInclude(a => a.Siswa)
        .Include(j => j.Rombel).ThenInclude(r => r.DaftarAnggotaRombel).ThenInclude(a => a.DaftarEvaluasiSiswa)
        .Include(j => j.Pegawai)
        .Include(j => j.DaftarHariMengajar)
        .Include(j => j.DaftarPertemuan)
        .Include(j => j.DaftarEvaluasiSiswa).ThenInclude(n => n.DaftarAnggotaRombel).ThenInclude(a => a.Siswa)
        .Include(j => j.DaftarEvaluasiSiswa).ThenInclude(n => n.DaftarAnggotaRombel).ThenInclude(a => a.Rombel)
        .Include(j => j.DaftarEvaluasiSiswa).ThenInclude(n => n.DaftarNilaiEvaluasiSiswa)
        .Include(j => j.DaftarAsesmenSumatifAkhirSemester).ThenInclude(a => a.AnggotaRombel)
        .Include(j => j.DaftarAsesmenSumatif).ThenInclude(a => a.DaftarEvaluasiSiswa).ThenInclude(e => e.DaftarNilaiEvaluasiSiswa)
        .Include(j => j.DaftarAsesmenSumatif).ThenInclude(a => a.TujuanPembelajaran)
        .ToListAsync();

    public async Task<List<JadwalMengajar>> GetAllByTahunAjaranAndPegawai(int idTahunAjaran, string nipPegawai) => await _appDbContext
        .TblJadwalMengajar
        .Include(j => j.MataPelajaran).ThenInclude(m => m.Peminatan)
        .Include(j => j.Rombel).ThenInclude(r => r.Wali)
        .Include(j => j.Rombel).ThenInclude(k => k.TahunAjaran)
        .Include(j => j.Rombel).ThenInclude(r => r.Kelas).ThenInclude(k => k.Peminatan)
        .Include(j => j.Rombel).ThenInclude(r => r.DaftarAnggotaRombel).ThenInclude(a => a.Siswa)
        .Include(j => j.Rombel).ThenInclude(r => r.DaftarAnggotaRombel).ThenInclude(a => a.DaftarEvaluasiSiswa)
        .Include(j => j.Pegawai)
        .Include(j => j.DaftarHariMengajar)
        .Include(j => j.DaftarPertemuan)
        .Include(j => j.DaftarEvaluasiSiswa).ThenInclude(n => n.DaftarAnggotaRombel).ThenInclude(a => a.Siswa)
        .Include(j => j.DaftarEvaluasiSiswa).ThenInclude(n => n.DaftarAnggotaRombel).ThenInclude(a => a.Rombel)
        .Include(j => j.DaftarEvaluasiSiswa).ThenInclude(n => n.DaftarNilaiEvaluasiSiswa)
        .Include(j => j.DaftarAsesmenSumatifAkhirSemester).ThenInclude(a => a.AnggotaRombel)
        .Include(j => j.DaftarTujuanPembelajaran)
        .Include(j => j.DaftarAsesmenSumatif).ThenInclude(a => a.DaftarEvaluasiSiswa).ThenInclude(e => e.DaftarNilaiEvaluasiSiswa)
        .Include(j => j.DaftarAsesmenSumatif).ThenInclude(a => a.TujuanPembelajaran)
        .Where(j => j.Rombel.TahunAjaran.Id == idTahunAjaran && j.Pegawai.Id == nipPegawai)
        .ToListAsync();

    public async Task<List<JadwalMengajar>> GetAllByTahunAjaran(int idTahunAjaran) => await _appDbContext
        .TblJadwalMengajar
        .Include(j => j.MataPelajaran).ThenInclude(m => m.Peminatan)
        .Include(j => j.Rombel).ThenInclude(k => k.TahunAjaran)
        .Include(j => j.Rombel).ThenInclude(r => r.Kelas).ThenInclude(k => k.Peminatan)
        .Include(j => j.Rombel).ThenInclude(r => r.DaftarAnggotaRombel).ThenInclude(a => a.Siswa)
        .Include(j => j.Rombel).ThenInclude(r => r.DaftarAnggotaRombel).ThenInclude(a => a.DaftarEvaluasiSiswa)
        .Include(j => j.Pegawai)
        .Include(j => j.DaftarHariMengajar)
        .Include(j => j.DaftarPertemuan)
        .Include(j => j.DaftarEvaluasiSiswa).ThenInclude(n => n.DaftarAnggotaRombel).ThenInclude(a => a.Siswa)
        .Include(j => j.DaftarEvaluasiSiswa).ThenInclude(n => n.DaftarAnggotaRombel).ThenInclude(a => a.Rombel)
        .Include(j => j.DaftarEvaluasiSiswa).ThenInclude(n => n.DaftarNilaiEvaluasiSiswa)
        .Include(j => j.DaftarAsesmenSumatifAkhirSemester).ThenInclude(a => a.AnggotaRombel)
        .Include(j => j.DaftarAsesmenSumatif).ThenInclude(a => a.DaftarEvaluasiSiswa).ThenInclude(e => e.DaftarNilaiEvaluasiSiswa)
        .Include(j => j.DaftarAsesmenSumatif).ThenInclude(a => a.TujuanPembelajaran)
        .Where(j => j.Rombel.TahunAjaran.Id == idTahunAjaran)
        .ToListAsync();

    public async Task<List<JadwalMengajar>> GetAllByTahunAjaranAndRombel(int idTahunAjaran, int idRombel) => await _appDbContext
         .TblJadwalMengajar
        .Include(j => j.MataPelajaran).ThenInclude(m => m.Peminatan)
        .Include(j => j.Rombel).ThenInclude(r => r.Wali)
        .Include(j => j.Rombel).ThenInclude(k => k.TahunAjaran)
        .Include(j => j.Rombel).ThenInclude(r => r.Kelas).ThenInclude(k => k.Peminatan)
        .Include(j => j.Rombel).ThenInclude(r => r.DaftarAnggotaRombel).ThenInclude(a => a.Siswa)
        .Include(j => j.Rombel).ThenInclude(r => r.DaftarAnggotaRombel).ThenInclude(a => a.DaftarEvaluasiSiswa)
        .Include(j => j.Pegawai)
        .Include(j => j.DaftarHariMengajar)
        .Include(j => j.DaftarPertemuan)
        .Include(j => j.DaftarEvaluasiSiswa).ThenInclude(n => n.DaftarAnggotaRombel).ThenInclude(a => a.Siswa)
        .Include(j => j.DaftarEvaluasiSiswa).ThenInclude(n => n.DaftarAnggotaRombel).ThenInclude(a => a.Rombel)
        .Include(j => j.DaftarEvaluasiSiswa).ThenInclude(n => n.DaftarNilaiEvaluasiSiswa)
        .Include(j => j.DaftarAsesmenSumatifAkhirSemester).ThenInclude(a => a.AnggotaRombel)
        .Include(j => j.DaftarTujuanPembelajaran)
        .Include(j => j.DaftarAsesmenSumatif).ThenInclude(a => a.DaftarEvaluasiSiswa).ThenInclude(e => e.DaftarNilaiEvaluasiSiswa)
        .Include(j => j.DaftarAsesmenSumatif).ThenInclude(a => a.TujuanPembelajaran)
        .Where(j => j.Rombel.TahunAjaran.Id == idTahunAjaran && j.Rombel.Id == idRombel)
        .ToListAsync();

    public async Task<bool> IsExist(int idMataPelajaran, int idRombel, string nipPegawai, int? id = null) => await _appDbContext
        .TblJadwalMengajar
        .Include(j => j.MataPelajaran)
        .Include(j => j.Pegawai)
        .AnyAsync(j => j.Id != id && j.MataPelajaran.Id == idMataPelajaran && j.Rombel.Id == idRombel && j.Pegawai.Id == nipPegawai);
}
