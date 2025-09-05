using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIAkademik.Domain.Entities;

namespace SIAkademik.Infrastructure.Database.EntityConfigurations;

internal class DivisiEntityConfiguration : IEntityTypeConfiguration<Divisi>
{
    public void Configure(EntityTypeBuilder<Divisi> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.DaftarPegawai).WithOne(y => y.Divisi);
    }
}
