using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Infrastructure.ModulSiakad.EntityConfigurations;

internal class JadwalMengajarEntityConfiguration : IEntityTypeConfiguration<JadwalMengajar>
{
    public void Configure(EntityTypeBuilder<JadwalMengajar> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasIndex("MataPelajaranId", "RombelId", "PegawaiId").IsUnique();

        builder.HasOne(x => x.Pegawai).WithMany(y => y.DaftarJadwalMengajar);
        builder.HasOne(x => x.MataPelajaran).WithMany(y => y.DaftarJadwalMengajar);
        builder.HasOne(x => x.Rombel).WithMany(y => y.DaftarJadwalMengajar);
        builder.HasMany(x => x.DaftarHariMengajar).WithOne(x => x.JadwalMengajar);
        builder.HasMany(x => x.DaftarPertemuan).WithOne(x => x.JadwalMengajar);
        builder.HasMany(x => x.DaftarRaport).WithOne(x => x.JadwalMengajar);

        builder.HasMany(x => x.DaftarTujuanPembelajaran)
            .WithMany(y => y.DaftarJadwalMengajar)
            .UsingEntity<AsesmenSumatif>(
                l => l.HasOne(x => x.TujuanPembelajaran).WithMany(t => t.DaftarAsesmenSumatif).HasForeignKey(y => y.IdTujuanPembelajaran),
                l => l.HasOne(x => x.JadwalMengajar).WithMany(t => t.DaftarAsesmenSumatif).HasForeignKey(y => y.IdJadwalMengajar)
            );

        builder.HasMany(x => x.DaftarAnggotaRombel).WithMany(y => y.DaftarJadwalMengajar)
            .UsingEntity<AsesmenSumatifAkhirSemester>(
                l => l.HasOne(x => x.AnggotaRombel).WithMany(y => y.DaftarAsesmenSumatifAkhirSemester).HasForeignKey(a => a.AnggotaRombelId),
                r => r.HasOne(x => x.JadwalMengajar).WithMany(y => y.DaftarAsesmenSumatifAkhirSemester).HasForeignKey(a => a.JadwalMengajarId)
            );

        for (int i = 0; i < 15; i++)
        {
            builder.HasData(
                new
                {
                    Id = 1 + i,
                    MataPelajaranId = 1 + i,
                    PegawaiId = "PJ17-010",
                    RombelId = 1
                }    
            );
        }
    }
}
