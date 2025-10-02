using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Infrastructure.ModulSiakad.EntityConfigurations;

internal class AnggotaRombelEntityConfiguration : IEntityTypeConfiguration<AnggotaRombel>
{
    public void Configure(EntityTypeBuilder<AnggotaRombel> builder)
    {
        builder.HasKey(x => new { x.IdSiswa, x.IdRombel });
        builder.HasOne(x => x.Siswa).WithMany(s => s.DaftarAnggotaRombel).HasForeignKey(x => x.IdSiswa);
        builder.HasOne(x => x.Rombel).WithMany(s => s.DaftarAnggotaRombel).HasForeignKey(x => x.IdRombel);
        builder.HasMany(x => x.DaftarNilai).WithOne(s => s.AnggotaRombel);
        builder.HasMany(x => x.DaftarAbsen).WithOne(s => s.AnggotaRombel);
        builder.HasMany(x => x.DaftarRaport).WithOne(s => s.AnggotaRombel);

        builder.HasData(
            new AnggotaRombel
            {
                IdRombel = 1,
                IdSiswa = 1,
                TanggalMasuk = new DateOnly(2025, 07, 01)
            },
            new AnggotaRombel
            {
                IdRombel = 2,
                IdSiswa = 2,
                TanggalMasuk = new DateOnly(2021, 08, 01)
            }
        );
    }
}
