using Microsoft.EntityFrameworkCore;
using SIAkademik.Domain.ModulProfil.Entities;
using SIAkademik.Domain.ModulProfil.Repositories;
using SIAkademik.Infrastructure.Database;
using System.Threading.Tasks;

namespace SIAkademik.Infrastructure.ModulProfil.Repositories;

internal class BeritaRepository : IBeritaRepository
{
    private readonly AppDbContext _appDbContext;

    public BeritaRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public void Add(Berita berita) => _appDbContext.TblBerita.Add(berita);

    public void Delete(Berita berita) => _appDbContext.TblBerita.Remove(berita);

    public async Task<Berita?> Get(int id) => await _appDbContext
        .TblBerita
        .Include(b => b.KategoriBerita)
        .FirstOrDefaultAsync(b => b.Id == id);

    public async Task<List<Berita>> GetAll() => await _appDbContext
        .TblBerita
        .Include(b => b.KategoriBerita)
        .OrderBy(b => b.Tanggal)
        .ToListAsync();

    public async Task<List<Berita>> GetAll(int idKategoriBerita) => await _appDbContext
        .TblBerita
        .Include(b => b.KategoriBerita)
        .Where(b => b.KategoriBerita.Id == idKategoriBerita)
        .OrderBy(b => b.Tanggal)
        .ToListAsync();

    public void Update(Berita berita) => _appDbContext.Update(berita);
}
