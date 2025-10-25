using Microsoft.EntityFrameworkCore;
using SIAkademik.Domain.ModulProfil.Entities;
using SIAkademik.Domain.ModulProfil.Repositories;
using SIAkademik.Infrastructure.Database;

namespace SIAkademik.Infrastructure.ModulProfil.Repositories;

internal class KategoriBeritaRepository : IKategoriBeritaRepository
{
    private readonly AppDbContext _appDbContext;

    public KategoriBeritaRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public void Add(KategoriBerita kategoriBerita) => _appDbContext.TblKategoriBerita.Add(kategoriBerita);

    public void Delete(KategoriBerita kategoriBerita) => _appDbContext.TblKategoriBerita.Remove(kategoriBerita);

    public async Task<KategoriBerita?> Get(int idKategoriBerita) => await _appDbContext
        .TblKategoriBerita
        .Include(k => k.DaftarBerita)
        .FirstOrDefaultAsync(a => a.Id == idKategoriBerita);

    public async Task<List<KategoriBerita>> GetAll() => await _appDbContext
        .TblKategoriBerita
        .Include(k => k.DaftarBerita)
        .ToListAsync();

    public async Task<bool> IsExist(string nama, int? id = null) => await _appDbContext
        .TblKategoriBerita
        .AnyAsync(k => k.Id != id && k.Nama.ToLower() == nama.ToLower());

    public void Update(KategoriBerita kategoriBerita) => _appDbContext.TblKategoriBerita.Update(kategoriBerita);
}
