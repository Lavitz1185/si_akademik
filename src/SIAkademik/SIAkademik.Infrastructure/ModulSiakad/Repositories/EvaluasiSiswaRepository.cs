using Microsoft.EntityFrameworkCore;
using SIAkademik.Domain.ModulSiakad.Entities;
using SIAkademik.Domain.ModulSiakad.Repositories;
using SIAkademik.Infrastructure.Database;

namespace SIAkademik.Infrastructure.ModulSiakad.Repositories;

internal class EvaluasiSiswaRepository : IEvaluasiSiswaRepository
{
    private readonly AppDbContext _appDbContext;

    public EvaluasiSiswaRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public void Add(EvaluasiSiswa nilai) => _appDbContext.TblEvaluasiSiswa.Add(nilai);

    public void Delete(EvaluasiSiswa nilai) => _appDbContext.TblEvaluasiSiswa.Remove(nilai);

    public async Task<EvaluasiSiswa?> Get(int id) => await _appDbContext
        .TblEvaluasiSiswa
        .Include(a => a.DaftarAnggotaRombel).ThenInclude(r => r.Rombel)
        .Include(a => a.DaftarAnggotaRombel).ThenInclude(r => r.Siswa)
        .Include(a => a.AsesmenSumatif).ThenInclude(a => a.JadwalMengajar).ThenInclude(j => j.Rombel).ThenInclude(k => k.TahunAjaran)
        .Include(a => a.AsesmenSumatif).ThenInclude(a => a.JadwalMengajar).ThenInclude(j => j.Rombel).ThenInclude(r => r.Kelas).ThenInclude(k => k.Peminatan)
        .Include(a => a.AsesmenSumatif).ThenInclude(a => a.JadwalMengajar).ThenInclude(j => j.MataPelajaran).ThenInclude(m => m.Peminatan)
        .Include(a => a.AsesmenSumatif).ThenInclude(a => a.JadwalMengajar).ThenInclude(j => j.Pegawai)
        .Include(a => a.AsesmenSumatif).ThenInclude(a => a.TujuanPembelajaran).ThenInclude(t => t.MataPelajaran).ThenInclude(m => m.Peminatan)
        .Include(a => a.DaftarNilaiEvaluasiSiswa)
        .FirstOrDefaultAsync(a => a.Id == id);

    public async Task<List<EvaluasiSiswa>> GetAll() => await _appDbContext
        .TblEvaluasiSiswa
        .Include(a => a.DaftarAnggotaRombel).ThenInclude(r => r.Rombel)
        .Include(a => a.DaftarAnggotaRombel).ThenInclude(r => r.Siswa)
        .Include(a => a.AsesmenSumatif).ThenInclude(a => a.JadwalMengajar).ThenInclude(j => j.Rombel).ThenInclude(k => k.TahunAjaran)
        .Include(a => a.AsesmenSumatif).ThenInclude(a => a.JadwalMengajar).ThenInclude(j => j.Rombel).ThenInclude(r => r.Kelas).ThenInclude(k => k.Peminatan)
        .Include(a => a.AsesmenSumatif).ThenInclude(a => a.JadwalMengajar).ThenInclude(j => j.MataPelajaran).ThenInclude(m => m.Peminatan)
        .Include(a => a.AsesmenSumatif).ThenInclude(a => a.JadwalMengajar).ThenInclude(j => j.Pegawai)
        .Include(a => a.AsesmenSumatif).ThenInclude(a => a.TujuanPembelajaran).ThenInclude(t => t.MataPelajaran).ThenInclude(m => m.Peminatan)
        .Include(a => a.DaftarNilaiEvaluasiSiswa)
        .ToListAsync();
}
