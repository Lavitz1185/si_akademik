using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIAkademik.Domain.Entities;

namespace SIAkademik.Infrastructure.Database.EntityConfigurations;

internal class TahunAjaranEntityConfiguration : IEntityTypeConfiguration<TahunAjaran>
{
    public void Configure(EntityTypeBuilder<TahunAjaran> builder)
    {
        builder.HasMany(x => x.DaftarKelas).WithOne(x => x.TahunAjaran);
    }
}
