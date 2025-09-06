using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIAkademik.Domain.Authentication;
using SIAkademik.Domain.Entities;

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
            }
        );
    }
}
