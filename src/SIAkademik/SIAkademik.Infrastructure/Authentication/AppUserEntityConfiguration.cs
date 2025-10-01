using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIAkademik.Domain.Authentication;
using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Infrastructure.Authentication;

internal class AppUserEntityConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Guru).WithOne(g => g.Account).HasForeignKey<Pegawai>("AppUserId");
        builder.HasOne(x => x.Siswa).WithOne(g => g.Account).HasForeignKey<Siswa>("AppUserId");

        builder.HasData(
            new
            {
                Id = 1,
                UserName = "Admin",
                PasswordHash = "AQAAAAIAAYagAAAAEKXsR8woVHO5DgmyBgmfe5b4I7jeJZYtk71JFY4HkDSCsimeHtIwzOueTyHo8gBH/A==",
                Role = AppUserRoles.Admin
            },
            new
            {
                Id = 2,
                UserName = "megalello99@gmail.com",
                PasswordHash = "AQAAAAIAAYagAAAAEKXsR8woVHO5DgmyBgmfe5b4I7jeJZYtk71JFY4HkDSCsimeHtIwzOueTyHo8gBH/A==",
                Role = AppUserRoles.Guru
            },
            new
            {
                Id = 3,
                UserName = "0044710570",
                PasswordHash = "AQAAAAIAAYagAAAAEKXsR8woVHO5DgmyBgmfe5b4I7jeJZYtk71JFY4HkDSCsimeHtIwzOueTyHo8gBH/A==",
                Role = AppUserRoles.Siswa
            },
            new
            {
                Id = 4,
                UserName = "johanis@pandhegajaya.sch.id",
                PasswordHash = "AQAAAAIAAYagAAAAEKXsR8woVHO5DgmyBgmfe5b4I7jeJZYtk71JFY4HkDSCsimeHtIwzOueTyHo8gBH/A==",
                Role = AppUserRoles.Guru
            },
            new
            {
                Id = 5,
                UserName = "jeheskia@pandhegajaya.sch.id",
                PasswordHash = "AQAAAAIAAYagAAAAEKXsR8woVHO5DgmyBgmfe5b4I7jeJZYtk71JFY4HkDSCsimeHtIwzOueTyHo8gBH/A==",
                Role = AppUserRoles.Guru
            },
            new
            {
                Id = 6,
                UserName = "umbujonas22@gmail.com",
                PasswordHash = "AQAAAAIAAYagAAAAEKXsR8woVHO5DgmyBgmfe5b4I7jeJZYtk71JFY4HkDSCsimeHtIwzOueTyHo8gBH/A==",
                Role = AppUserRoles.Guru
            },
            new
            {
                Id = 7,
                UserName = "nerlanemu@pandhegajaya.sch.id",
                PasswordHash = "AQAAAAIAAYagAAAAEKXsR8woVHO5DgmyBgmfe5b4I7jeJZYtk71JFY4HkDSCsimeHtIwzOueTyHo8gBH/A==",
                Role = AppUserRoles.Guru
            },
            new
            {
                Id = 8,
                UserName = "yefrykuafeu@gmail.com",
                PasswordHash = "AQAAAAIAAYagAAAAEKXsR8woVHO5DgmyBgmfe5b4I7jeJZYtk71JFY4HkDSCsimeHtIwzOueTyHo8gBH/A==",
                Role = AppUserRoles.Guru
            },
            new
            {
                Id = 9,
                UserName = "landoseran99@gmail.com",
                PasswordHash = "AQAAAAIAAYagAAAAEKXsR8woVHO5DgmyBgmfe5b4I7jeJZYtk71JFY4HkDSCsimeHtIwzOueTyHo8gBH/A==",
                Role = AppUserRoles.Guru
            },
            new
            {
                Id = 10,
                UserName = "ellapandie@gmail.com",
                PasswordHash = "AQAAAAIAAYagAAAAEKXsR8woVHO5DgmyBgmfe5b4I7jeJZYtk71JFY4HkDSCsimeHtIwzOueTyHo8gBH/A==",
                Role = AppUserRoles.Guru
            },
            new
            {
                Id = 11,
                UserName = "lindajanitaa@gmail.com",
                PasswordHash = "AQAAAAIAAYagAAAAEKXsR8woVHO5DgmyBgmfe5b4I7jeJZYtk71JFY4HkDSCsimeHtIwzOueTyHo8gBH/A==",
                Role = AppUserRoles.Guru
            },
            new
            {
                Id = 12,
                UserName = "sofiablegur14@gmail.com",
                PasswordHash = "AQAAAAIAAYagAAAAEKXsR8woVHO5DgmyBgmfe5b4I7jeJZYtk71JFY4HkDSCsimeHtIwzOueTyHo8gBH/A==",
                Role = AppUserRoles.Guru
            },
            new
            {
                Id = 13,
                UserName = "putrolas@gmail.com",
                PasswordHash = "AQAAAAIAAYagAAAAEKXsR8woVHO5DgmyBgmfe5b4I7jeJZYtk71JFY4HkDSCsimeHtIwzOueTyHo8gBH/A==",
                Role = AppUserRoles.Guru
            }
        );
    }
}
