using Microsoft.EntityFrameworkCore;
using SIAkademik.Domain.ModulSiakad.Entities;
using SIAkademik.Domain.ModulSiakad.Repositories;
using SIAkademik.Infrastructure.Database;

namespace SIAkademik.Infrastructure.ModulSiakad.Repositories;

internal class JabatanRepository : IJabatanRepository
{
    private readonly AppDbContext _appDbContext;

    public JabatanRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public void Add(Jabatan jabatan) => _appDbContext.TblJabatan.Add(jabatan);

    public void Delete(Jabatan jabatan) => _appDbContext.TblJabatan.Remove(jabatan);

    public async Task<Jabatan?> Get(int id) => await _appDbContext
        .TblJabatan
        .Include(j => j.DaftarPegawai)
        .FirstOrDefaultAsync(j => j.Id == id);

    public async Task<List<Jabatan>> GetAll() => await _appDbContext
        .TblJabatan
        .Include(j => j.DaftarPegawai)
        .ToListAsync();
}
