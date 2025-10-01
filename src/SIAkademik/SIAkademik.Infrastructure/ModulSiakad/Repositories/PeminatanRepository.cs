using Microsoft.EntityFrameworkCore;
using SIAkademik.Domain.ModulSiakad.Entities;
using SIAkademik.Domain.ModulSiakad.Repositories;
using SIAkademik.Infrastructure.Database;

namespace SIAkademik.Infrastructure.ModulSiakad.Repositories;

internal class PeminatanRepository : IPeminatanRepository
{
    private readonly AppDbContext _appDbContext;

    public PeminatanRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public void Add(Peminatan peminatan) => _appDbContext.TblPeminatan.Add(peminatan);

    public void Delete(Peminatan peminatan) => _appDbContext.TblPeminatan.Remove(peminatan);

    public async Task<Peminatan?> Get(int id) => await _appDbContext.TblPeminatan
        .Include(p => p.DaftarMataPelajaran)
        .Include(p => p.DaftarKelas).ThenInclude(p => p.DaftarRombel)
        .Include(p => p.DaftarKelas).ThenInclude(p => p.TahunAjaran)
        .FirstOrDefaultAsync(p => p.Id == id);

    public async Task<List<Peminatan>> GetAll() => await _appDbContext.TblPeminatan
        .Include(p => p.DaftarMataPelajaran)
        .Include(p => p.DaftarKelas).ThenInclude(p => p.DaftarRombel)
        .Include(p => p.DaftarKelas).ThenInclude(p => p.TahunAjaran)
        .ToListAsync();

    public async Task<bool> IsExist(string nama, int? id = null) => await _appDbContext.TblPeminatan
        .AnyAsync(p => p.Id != id && p.Nama.ToLower() == nama.ToLower());
}
