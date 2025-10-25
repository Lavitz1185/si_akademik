using Microsoft.EntityFrameworkCore;
using SIAkademik.Domain.ModulProfil.Entities;
using SIAkademik.Domain.ModulProfil.Repositories;
using SIAkademik.Infrastructure.Database;

namespace SIAkademik.Infrastructure.ModulProfil.Repositories;

internal class FasilitasRepository : IFasilitasRepository
{
    private readonly AppDbContext _appDbContext;

    public FasilitasRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public void Add(Fasilitas fasilitas) => _appDbContext.TblFasilitas.Add(fasilitas);

    public void Delete(Fasilitas fasilitas) => _appDbContext.TblFasilitas.Remove(fasilitas);

    public async Task<Fasilitas?> Get(int id) => await _appDbContext
        .TblFasilitas
        .FirstOrDefaultAsync(a => a.Id == id);

    public async Task<List<Fasilitas>> GetAll() => await _appDbContext
        .TblFasilitas
        .ToListAsync();

    public async Task<bool> IsExist(string nama, int? id = null) => await _appDbContext
        .TblFasilitas
        .AnyAsync(a => a.Id != id && a.Nama.ToLower() == nama.ToLower());
}
