using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Infrastructure.ModulSiakad.EntityConfigurations;

internal class RaportEntityConfiguration : IEntityTypeConfiguration<Raport>
{
    public void Configure(EntityTypeBuilder<Raport> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.AnggotaRombel).WithMany(y => y.DaftarRaport);
        builder.HasOne(x => x.JadwalMengajar).WithMany(y => y.DaftarRaport);
    }
}
