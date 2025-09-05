using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIAkademik.Domain.Entities;

namespace SIAkademik.Infrastructure.Database.EntityConfigurations;

internal class KelasEntityConfiguration : IEntityTypeConfiguration<Kelas>
{
    public void Configure(EntityTypeBuilder<Kelas> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.TahunAjaran).WithMany(x => x.DaftarKelas);
        builder.HasMany(x => x.DaftarRombel).WithOne(x => x.Kelas);
    }
}
