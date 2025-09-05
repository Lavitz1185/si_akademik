using Microsoft.EntityFrameworkCore;
using SIAkademik.Domain.Authentication;
using SIAkademik.Infrastructure.Database;

namespace SIAkademik.Infrastructure.Authentication;

internal class AppUserRepository : IAppUserRepository
{
    private readonly AppDbContext _appDbContext;

    public AppUserRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public void Add(AppUser user) => _appDbContext.AppUser.Add(user);

    public void Delete(AppUser user) => _appDbContext.AppUser.Remove(user);

    public async Task<AppUser?> Get(int id) => await _appDbContext
        .AppUser
        .Include(x => x.Guru)
        .Include(x => x.Siswa)
        .FirstOrDefaultAsync(x => x.Id == id);

    public async Task<List<AppUser>> GetAll() => await _appDbContext
        .AppUser
        .Include(x => x.Guru)
        .Include(x => x.Siswa)
        .ToListAsync();

    public async Task<AppUser?> GetByUserName(string userName) => await _appDbContext
        .AppUser
        .Include(x => x.Guru)
        .Include(x => x.Siswa)
        .FirstOrDefaultAsync(x => x.UserName == userName);
}
