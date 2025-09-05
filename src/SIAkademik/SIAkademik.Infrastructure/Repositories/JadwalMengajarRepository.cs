using SIAkademik.Domain.Entities;
using SIAkademik.Domain.Repositories;
using SIAkademik.Infrastructure.Database;

namespace SIAkademik.Infrastructure.Repositories;

internal class JadwalMengajarRepository : IJadwalMengajarRepository
{
    private readonly AppDbContext _appDbContext;

    public JadwalMengajarRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public void Add(JadwalMengajar jadwalMengajar) => _appDbContext.TblJadwalMengajar.Add(jadwalMengajar);

    public void Delete(JadwalMengajar jadwalMengajar) => _appDbContext.TblJadwalMengajar.Remove(jadwalMengajar);
}
