using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Infrastructure.ModulSiakad.EntityConfigurations;

internal class AbsenKelasEntityConfiguration : IEntityTypeConfiguration<AbsenKelas>
{
    public void Configure(EntityTypeBuilder<AbsenKelas> builder)
    {
        builder.HasKey(a => a.Id);
        builder.HasOne(a => a.AnggotaRombel).WithMany(a => a.DaftarAbsenKelas);
    }
}
