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
    }
}
