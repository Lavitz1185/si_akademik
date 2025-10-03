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
        builder.HasOne(x => x.TahunAjaran).WithMany(x => x.DaftarKelas);
        builder.HasMany(x => x.DaftarRombel).WithOne(x => x.Kelas);

        builder.HasData
        (
            new
            {
                Id = 2,
                Jenjang = Jenjang.XII,
                PeminatanId = 5,
                TahunAjaranId = 3,
            },
            new
            {
                Id = 1,
                Jenjang = Jenjang.X,
                PeminatanId = 1,
                TahunAjaranId = 2
            },
            new
            {
                Id = 3,
                Jenjang = Jenjang.XI,
                PeminatanId = 1,
                TahunAjaranId = 2
            },
            new
            {
                Id = 4,
                Jenjang = Jenjang.XII,
                PeminatanId = 1,
                TahunAjaranId = 2
            }
        );
    }
}
