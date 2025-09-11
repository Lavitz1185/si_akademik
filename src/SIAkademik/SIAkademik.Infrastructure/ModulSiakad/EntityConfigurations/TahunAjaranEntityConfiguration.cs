using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Infrastructure.ModulSiakad.EntityConfigurations;

internal class TahunAjaranEntityConfiguration : IEntityTypeConfiguration<TahunAjaran>
{
    public void Configure(EntityTypeBuilder<TahunAjaran> builder)
    {
        builder.HasMany(x => x.DaftarKelas).WithOne(x => x.TahunAjaran);
    }
}
