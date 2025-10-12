using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIAkademik.Domain.Enums;
using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Infrastructure.ModulSiakad.EntityConfigurations;

internal class EvaluasiSiswaEntityConfiguration : IEntityTypeConfiguration<EvaluasiSiswa>
{
    public void Configure(EntityTypeBuilder<EvaluasiSiswa> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.AsesmenSumatif).WithMany(y => y.DaftarEvaluasiSiswa);
        builder.HasMany(x => x.DaftarAnggotaRombel)
            .WithMany(a => a.DaftarEvaluasiSiswa)
            .UsingEntity<NilaiEvaluasiSiswa>(
                l => l.HasOne(x => x.AnggotaRombel).WithMany(y => y.DaftarNilaiEvaluasiSiswa).HasForeignKey(x => x.IdAnggotaRombel),
                r => r.HasOne(x => x.EvaluasiSiswa).WithMany(y => y.DaftarNilaiEvaluasiSiswa).HasForeignKey(x => x.IdEvaluasiSiswa)
            );

        for(int i = 0; i < 15; i++)
        {
            builder.HasData(
                new
                {
                    Id = 1 + i * 2,
                    Deskripsi = "Tugas",
                    Jenis = JenisNilai.Tugas,
                    AsesmenSumatifId = 1 + i
                },
                new
                {
                    Id = 2 + i * 2,
                    Deskripsi = "Ulangan Harian",
                    Jenis = JenisNilai.UH,
                    AsesmenSumatifId = 1 + i
                }
            );
        }
    }
}
