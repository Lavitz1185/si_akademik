using Microsoft.EntityFrameworkCore;
using SIAkademik.Domain.ModulSiakad.Entities;
using SIAkademik.Domain.ModulSiakad.Repositories;
using SIAkademik.Infrastructure.Database;

namespace SIAkademik.Infrastructure.ModulSiakad.Repositories;

internal class DivisiRepository : IDivisiRepository
{
    private readonly AppDbContext _appDbContext;

    public DivisiRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public void Add(Divisi divisi) => _appDbContext.TblDivisi.Add(divisi);

    public void Delete(Divisi divisi) => _appDbContext.TblDivisi.Remove(divisi);

    public async Task<Divisi?> Get(int id) => await _appDbContext
        .TblDivisi
        .Include(d => d.DaftarPegawai)
        .FirstOrDefaultAsync(d => d.Id == id);

    public async Task<List<Divisi>> GetAll() => await _appDbContext
        .TblDivisi
        .Include(d => d.DaftarPegawai)
        .ToListAsync();

    public async Task<bool> IsExistByNama(string nama, int? id = null) => await _appDbContext.TblDivisi
        .AnyAsync(d => d.Id != id && d.Nama.ToLower() == nama.ToLower());
}
