using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIAkademik.Domain.Enums;
using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Infrastructure.ModulSiakad.EntityConfigurations;

internal class HariMengajarEntityTypeConfiguration : IEntityTypeConfiguration<HariMengajar>
{
    public void Configure(EntityTypeBuilder<HariMengajar> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.JadwalMengajar).WithMany(x => x.DaftarHariMengajar);
    }
}
