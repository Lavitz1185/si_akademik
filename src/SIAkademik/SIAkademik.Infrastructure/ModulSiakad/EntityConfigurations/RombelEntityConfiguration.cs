using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Infrastructure.ModulSiakad.EntityConfigurations;

internal class RombelEntityConfiguration : IEntityTypeConfiguration<Rombel>
{
    public void Configure(EntityTypeBuilder<Rombel> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.Kelas).WithMany(y => y.DaftarRombel);
        builder.HasOne(x => x.Wali).WithMany(y => y.DaftarRombelWali);
        builder.HasMany(x => x.DaftarSiswa).WithMany(y => y.DaftarRombel).UsingEntity<AnggotaRombel>();

        builder.HasData(
            new
            {
                Id = 1,
                Nama = "A",
                KelasId = 1,
                WaliId = "PJ23-030"
            },
            new
            {
                Id = 2,
                Nama = "A",
                KelasId = 2,
                WaliId = "PJ17-010"
            }
        );
    }
}
