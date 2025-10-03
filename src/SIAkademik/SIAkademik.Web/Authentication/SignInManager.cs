using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using SIAkademik.Domain.Authentication;
using SIAkademik.Domain.ModulSiakad.Entities;
using SIAkademik.Domain.ModulSiakad.Repositories;
using SIAkademik.Domain.Shared;
using System.Security.Claims;

namespace SIAkademik.Web.Authentication;

public class SignInManager : ISignInManager
{
    private readonly IAppUserRepository _appUserRepository;
    private readonly IPasswordHasher<AppUser> _passwordHasher;
    private readonly IPegawaiRepository _pegawaiRepository;
    private readonly ISiswaRepository _siswaRepository;
    private readonly ILogger<SignInManager> _logger;
    private readonly IHttpContextAccessor _contextAccessor;

    public SignInManager(
        IAppUserRepository appUserRepository,
        IPasswordHasher<AppUser> passwordHasher,
        ILogger<SignInManager> logger,
        IHttpContextAccessor contextAccessor,
        IPegawaiRepository pegawaiRepository,
        ISiswaRepository siswaRepository)
    {
        _appUserRepository = appUserRepository;
        _passwordHasher = passwordHasher;
        _logger = logger;
        _contextAccessor = contextAccessor;
        _pegawaiRepository = pegawaiRepository;
        _siswaRepository = siswaRepository;
    }

    public async Task<Pegawai?> GetPegawai()
    {
        var guru = (await GetUser())?.Guru;

        if (guru is null) return null;

        guru = await _pegawaiRepository.Get(guru.Id);
        return guru;
    }

    public async Task<Siswa?> GetSiswa()
    {
        var siswa = (await GetUser())?.Siswa;
        if (siswa is null) return null;

        return await _siswaRepository.Get(siswa.Id);
    }

    public async Task<AppUser?> GetUser()
    {
        var httpContext = _contextAccessor.HttpContext;
        if (httpContext is null) return null;

        var userName = httpContext.User.Identity?.Name;
        if (userName is null) return null;

        var appUser = await _appUserRepository.GetByUserName(userName);

        return appUser; 
    }

    public async Task<Result<string>> Login(string username, string password, bool rememberMe)
    {
        var httpContext = _contextAccessor.HttpContext;
        if (httpContext is null)
            return new Error("Login.Gagal", "Tidak ada HttpContext aktif");

        var appUser = await _appUserRepository.GetByUserName(username);
        if (appUser is null)
            return new Error("Login.AkunTidakDitemukan", $"Akun '{username}' tidak ditemukan");

        if (_passwordHasher.VerifyHashedPassword(appUser, appUser.PasswordHash, password) == PasswordVerificationResult.Failed)
            return new Error("Login.PasswordSalah", "Password yang dimasukan salah!");

        List<Claim> claims = [
            new Claim(ClaimTypes.Name, appUser.UserName),
            new Claim(ClaimTypes.Role, appUser.Role)
        ];

        var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var claimPrincipal = new ClaimsPrincipal(claimIdentity);
        var authProperties = new AuthenticationProperties { IsPersistent = rememberMe };

        await httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimPrincipal, authProperties);

        _logger.LogInformation("{@userName} logged in at {@time}", username, DateTime.Now);

        return appUser.Role;
    }

    public async Task Logout()
    {
        var httpContext = _contextAccessor.HttpContext;

        if (httpContext is not null)
            await httpContext.SignOutAsync();
    }
}
