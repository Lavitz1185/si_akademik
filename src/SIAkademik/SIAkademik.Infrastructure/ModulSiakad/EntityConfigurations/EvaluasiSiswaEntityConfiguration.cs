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
        builder.HasOne(x => x.JadwalMengajar).WithMany(y => y.DaftarEvaluasiSiswa);
        builder.HasMany(x => x.DaftarAnggotaRombel)
            .WithMany(a => a.DaftarEvaluasiSiswa)
            .UsingEntity<NilaiEvaluasiSiswa>(
                l => l.HasOne(x => x.AnggotaRombel).WithMany(y => y.DaftarNilaiEvaluasiSiswa).HasForeignKey(x => x.IdAnggotaRombel),
                r => r.HasOne(x => x.EvaluasiSiswa).WithMany(y => y.DaftarNilaiEvaluasiSiswa).HasForeignKey(x => x.IdEvaluasiSiswa)
            );

        for(int i = 0; i < 14; i++)
        {
            builder.HasData(
                new
                {
                    Id = 1 + i * 4,
                    Deskripsi = "Tugas 1",
                    Jenis = JenisNilai.Tugas,
                    JadwalMengajarId = 3 + i
                },
                new
                {
                    Id = 2 + i * 4,
                    Deskripsi = "UH 1",
                    Jenis = JenisNilai.UH,
                    JadwalMengajarId = 3 + i
                },
                new
                {
                    Id = 3 + i * 4,
                    Deskripsi = "UTS",
                    Jenis = JenisNilai.UTS,
                    JadwalMengajarId = 3 + i
                },
                new
                {
                    Id = 4 + i * 4,
                    Deskripsi = "UAS",
                    Jenis = JenisNilai.UAS,
                    JadwalMengajarId = 3 + i
                }
            );
        }
    }
}
