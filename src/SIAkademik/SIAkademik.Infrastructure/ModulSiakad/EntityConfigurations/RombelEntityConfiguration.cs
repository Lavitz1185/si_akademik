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
                WaliId = "PJ22-024"
            },
            new
            {
                Id = 2,
                Nama = "A",
                KelasId = 2,
                WaliId = "PJ17-010"
            },
            new
            {
                Id = 3,
                Nama = "A",
                KelasId = 3,
                WaliId = "PJ24-004"
            },
            new
            {
                Id = 4,
                Nama = "B",
                KelasId = 3,
                WaliId = "PJ18-013"
            },
            new
            {
                Id = 5,
                Nama = "A",
                KelasId = 4,
                WaliId = "PJ19-017"
            },
            new
            {
                Id = 6,
                Nama = "B",
                KelasId = 4,
                WaliId = "PJ23-031"
            }
        );
    }
}
