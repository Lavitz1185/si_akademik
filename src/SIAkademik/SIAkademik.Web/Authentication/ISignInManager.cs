using SIAkademik.Domain.Authentication;
using SIAkademik.Domain.Shared;

namespace SIAkademik.Web.Authentication;

public interface ISignInManager
{
    Task<Result<string>> Login(string username, string password, bool rememberMe);
    Task Logout();
    Task<AppUser?> GetUser();
}
