namespace SIAkademik.Domain.Authentication;

public interface IAppUserRepository
{
    Task<AppUser?> Get(int id);
    Task<AppUser?> GetByUserName(string userName);
    Task<List<AppUser>> GetAll();

    void Add(AppUser user);
    void Delete(AppUser user);
}
