using SIAkademik.Domain.Authentication;
using SIAkademik.Domain.Shared;

namespace SIAkademik.Web.Authentication;

public interface ISignInManager
{
    Task<Result> Login(string username, string password, bool rememberMe, string role);
    Task Logout();
    Task<AppUser?> GetUser();
}
