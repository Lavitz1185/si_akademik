using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIAkademik.Domain.Enums;
using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Infrastructure.ModulSiakad.EntityConfigurations;

internal class KelasEntityConfiguration : IEntityTypeConfiguration<Kelas>
{
    public void Configure(EntityTypeBuilder<Kelas> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.Peminatan).WithMany(y => y.DaftarKelas);
        builder.HasMany(x => x.DaftarRombel).WithOne(x => x.Kelas);

        builder.HasData
        (
            new
            {
                Id = 1,
                Jenjang = Jenjang.XII,
                PeminatanId = 5
            },
            new
            {
                Id = 2,
                Jenjang = Jenjang.X,
                PeminatanId = 1
            },
            new
            {
                Id = 3,
                Jenjang = Jenjang.XI,
                PeminatanId = 1
            },
            new
            {
                Id = 4,
                Jenjang = Jenjang.XII,
                PeminatanId = 1,
            }
        );
    }
}
