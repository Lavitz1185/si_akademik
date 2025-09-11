using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Infrastructure.ModulSiakad.EntityConfigurations;

internal class AbsenEntityConfiguration : IEntityTypeConfiguration<Absen>
{
    public void Configure(EntityTypeBuilder<Absen> builder)
    {
        builder.HasKey(a => a.Id);
        builder.HasOne(a => a.AnggotaRombel).WithMany(x => x.DaftarAbsen);
    }
}
