using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIAkademik.Domain.Entities;

namespace SIAkademik.Infrastructure.Database.EntityConfigurations;

internal class JabatanEntityConfiguration : IEntityTypeConfiguration<Jabatan>
{
    public void Configure(EntityTypeBuilder<Jabatan> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.DaftarPegawai).WithOne(x => x.Jabatan);

        builder.HasData(
            new Jabatan
            {
                Id = 1,
                Nama = "Guru Matematika"
            }
        );
    }
}
