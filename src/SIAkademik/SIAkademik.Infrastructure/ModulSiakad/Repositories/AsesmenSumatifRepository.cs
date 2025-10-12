using Microsoft.EntityFrameworkCore;
using SIAkademik.Domain.ModulSiakad.Entities;
using SIAkademik.Domain.ModulSiakad.Repositories;
using SIAkademik.Infrastructure.Database;

namespace SIAkademik.Infrastructure.ModulSiakad.Repositories;

internal class AsesmenSumatifRepository : IAsesmenSumatifRepository
{
    private readonly AppDbContext _appDbContext;

    public AsesmenSumatifRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public void Add(AsesmenSumatif asesmenSumatif) => _appDbContext.TblAsesmenSumatif.Add(asesmenSumatif);

    public void Delete(AsesmenSumatif asesmenSumatif) => _appDbContext.TblAsesmenSumatif.Remove(asesmenSumatif);

    public async Task<AsesmenSumatif?> Get(int id) => await _appDbContext.TblAsesmenSumatif
        .Include(a => a.JadwalMengajar)
        .Include(a => a.TujuanPembelajaran)
        .Include(a => a.DaftarEvaluasiSiswa)
        .FirstOrDefaultAsync(a => a.Id == id);

    public async Task<List<AsesmenSumatif>> GetAll() => await _appDbContext.TblAsesmenSumatif
        .Include(a => a.JadwalMengajar)
        .Include(a => a.TujuanPembelajaran)
        .Include(a => a.DaftarEvaluasiSiswa)
        .ToListAsync();

    public async Task<List<AsesmenSumatif>> GetAll(int idTujuanPembelajaran, int idJadwalMengajar) => await _appDbContext.TblAsesmenSumatif
        .Include(a => a.JadwalMengajar)
        .Include(a => a.TujuanPembelajaran)
        .Include(a => a.DaftarEvaluasiSiswa)
        .Where(a => a.IdTujuanPembelajaran == idTujuanPembelajaran && a.IdJadwalMengajar == idJadwalMengajar)
        .ToListAsync();
}
