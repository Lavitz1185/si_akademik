using SIAkademik.Domain.Abstracts;
using SIAkademik.Domain.Entities;

namespace SIAkademik.Domain.Authentication;

public class AppUser : Entity<int>
{
    public required string UserName { get; set; }
    public required string PasswordHash { get; set; }
    public required string Role { get; set; }

    public Pegawai? Guru { get; set; }
    public Siswa? Siswa { get; set; }
}

public static class AppUserRoles
{
    public const string Admin = "ADMIN";
    public const string Guru = "GURU";
    public const string Siswa = "Siswa";
}