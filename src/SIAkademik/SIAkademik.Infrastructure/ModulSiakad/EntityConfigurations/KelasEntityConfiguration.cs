using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Infrastructure.ModulSiakad.EntityConfigurations;

internal class KelasEntityConfiguration : IEntityTypeConfiguration<Kelas>
{
    public void Configure(EntityTypeBuilder<Kelas> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.TahunAjaran).WithMany(x => x.DaftarKelas);
        builder.HasMany(x => x.DaftarRombel).WithOne(x => x.Kelas);
    }
}
