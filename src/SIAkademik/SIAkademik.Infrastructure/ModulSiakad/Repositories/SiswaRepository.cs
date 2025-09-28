using Microsoft.EntityFrameworkCore;
using SIAkademik.Domain.ModulSiakad.Entities;
using SIAkademik.Domain.ModulSiakad.Repositories;
using SIAkademik.Infrastructure.Database;
using System.Threading.Tasks;

namespace SIAkademik.Infrastructure.ModulSiakad.Repositories;

internal class SiswaRepository : ISiswaRepository
{
    private readonly AppDbContext _appDbContext;

    public SiswaRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public void Add(Siswa siswa) => _appDbContext.TblSiswa.Add(siswa);

    public void Delete(Siswa siswa) => _appDbContext.TblSiswa.Remove(siswa);

    public async Task<Siswa?> Get(int id) => await _appDbContext
        .TblSiswa
        .Include(s => s.DaftarAnggotaRombel).ThenInclude(a => a.Rombel).ThenInclude(r => r.Wali)
        .Include(s => s.DaftarAnggotaRombel).ThenInclude(a => a.DaftarAbsen)
        .Include(s => s.DaftarAnggotaRombel).ThenInclude(a => a.DaftarNilai)
        .Include(s => s.DaftarAnggotaRombel).ThenInclude(a => a.DaftarAbsenKelas)
        .Include(s => s.DaftarAnggotaRombel).ThenInclude(a => a.DaftarRaport).ThenInclude(r => r.JadwalMengajar)
        .Include(s => s.Account)
        .FirstOrDefaultAsync(s => s.Id == id);

    public async Task<Siswa?> GetByNISN(string nisn) => await _appDbContext
        .TblSiswa
        .Include(s => s.DaftarAnggotaRombel).ThenInclude(a => a.Rombel).ThenInclude(r => r.Wali)
        .Include(s => s.DaftarAnggotaRombel).ThenInclude(a => a.DaftarAbsen)
        .Include(s => s.DaftarAnggotaRombel).ThenInclude(a => a.DaftarNilai)
        .Include(s => s.DaftarAnggotaRombel).ThenInclude(a => a.DaftarAbsenKelas)
        .Include(s => s.DaftarAnggotaRombel).ThenInclude(a => a.DaftarRaport).ThenInclude(r => r.JadwalMengajar)
        .Include(s => s.Account)
        .FirstOrDefaultAsync(s => s.NISN == nisn);

    public async Task<Siswa?> GetByNIS(string nis) => await _appDbContext
        .TblSiswa
        .Include(s => s.DaftarAnggotaRombel).ThenInclude(a => a.Rombel).ThenInclude(r => r.Wali)
        .Include(s => s.DaftarAnggotaRombel).ThenInclude(a => a.DaftarAbsen)
        .Include(s => s.DaftarAnggotaRombel).ThenInclude(a => a.DaftarNilai)
        .Include(s => s.DaftarAnggotaRombel).ThenInclude(a => a.DaftarAbsenKelas)
        .Include(s => s.DaftarAnggotaRombel).ThenInclude(a => a.DaftarRaport).ThenInclude(r => r.JadwalMengajar)
        .Include(s => s.Account)
        .FirstOrDefaultAsync(s => s.NIS == nis);

    public async Task<List<Siswa>> GetAll() => await _appDbContext
        .TblSiswa
        .Include(s => s.DaftarAnggotaRombel).ThenInclude(a => a.Rombel).ThenInclude(r => r.Wali)
        .Include(s => s.DaftarAnggotaRombel).ThenInclude(a => a.Rombel).ThenInclude(r => r.Kelas).ThenInclude(k => k.TahunAjaran)
        .Include(s => s.DaftarAnggotaRombel).ThenInclude(a => a.DaftarAbsen)
        .Include(s => s.DaftarAnggotaRombel).ThenInclude(a => a.DaftarNilai)
        .Include(s => s.DaftarAnggotaRombel).ThenInclude(a => a.DaftarAbsenKelas)
        .Include(s => s.DaftarAnggotaRombel).ThenInclude(a => a.DaftarRaport).ThenInclude(r => r.JadwalMengajar)
        .Include(s => s.Account)
        .ToListAsync();
}
