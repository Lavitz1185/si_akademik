using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Infrastructure.ModulSiakad.EntityConfigurations;

internal class AnggotaRombelEntityConfiguration : IEntityTypeConfiguration<AnggotaRombel>
{
    public void Configure(EntityTypeBuilder<AnggotaRombel> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.Siswa).WithMany(s => s.DaftarAnggotaRombel).HasForeignKey(x => x.IdSiswa);
        builder.HasOne(x => x.Rombel).WithMany(s => s.DaftarAnggotaRombel).HasForeignKey(x => x.IdRombel);
        builder.HasMany(x => x.DaftarEvaluasiSiswa).WithMany(e => e.DaftarAnggotaRombel).UsingEntity<NilaiEvaluasiSiswa>();
        builder.HasMany(x => x.DaftarAbsen).WithOne(s => s.AnggotaRombel);
        builder.HasMany(x => x.DaftarRaport).WithOne(s => s.AnggotaRombel);
        builder.HasMany(x => x.DaftarJadwalMengajar).WithMany(y => y.DaftarAnggotaRombel)
            .UsingEntity<AsesmenSumatifAkhirSemester>(
                l => l.HasOne(x => x.JadwalMengajar).WithMany(y => y.DaftarAsesmenSumatifAkhirSemester).HasForeignKey(a => a.JadwalMengajarId),
                r => r.HasOne(x => x.AnggotaRombel).WithMany(y => y.DaftarAsesmenSumatifAkhirSemester).HasForeignKey(a => a.AnggotaRombelId)
            );

        builder.HasData(
            new AnggotaRombel
            {
                Id = 1,
                IdRombel = 1,
                IdSiswa = 1,
                TanggalMasuk = new DateOnly(2021, 08, 01)
            }
        );

        for (int i = 0; i < 28; i++)
        {
            builder.HasData(
                new AnggotaRombel
                {
                    Id = 2 + i,
                    IdRombel = 2,
                    IdSiswa = 2 + i,
                    TanggalMasuk = new DateOnly(2025, 08, 01)
                }
            );
        }
    }
}
