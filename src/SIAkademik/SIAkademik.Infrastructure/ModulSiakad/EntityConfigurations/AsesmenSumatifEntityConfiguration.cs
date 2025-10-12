using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Infrastructure.ModulSiakad.EntityConfigurations;

internal class AsesmenSumatifEntityConfiguration : IEntityTypeConfiguration<AsesmenSumatif>
{
    public void Configure(EntityTypeBuilder<AsesmenSumatif> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasData(
            new AsesmenSumatif
            {
                Id = 1,
                IdJadwalMengajar = 1,
                IdTujuanPembelajaran = 2
            },
            new AsesmenSumatif
            {
                Id = 2,
                IdJadwalMengajar = 2,
                IdTujuanPembelajaran = 4
            },
            new AsesmenSumatif
            {
                Id = 3,
                IdJadwalMengajar = 3,
                IdTujuanPembelajaran = 6
            },
            new AsesmenSumatif
            {
                Id = 4,
                IdJadwalMengajar = 4,
                IdTujuanPembelajaran = 8
            },
            new AsesmenSumatif
            {
                Id = 5,
                IdJadwalMengajar = 5,
                IdTujuanPembelajaran = 10
            },
            new AsesmenSumatif
            {
                Id = 6,
                IdJadwalMengajar = 6,
                IdTujuanPembelajaran = 12
            },
            new AsesmenSumatif
            {
                Id = 7,
                IdJadwalMengajar = 7,
                IdTujuanPembelajaran = 14
            },
            new AsesmenSumatif
            {
                Id = 8,
                IdJadwalMengajar = 8,
                IdTujuanPembelajaran = 16
            },
            new AsesmenSumatif
            {
                Id = 9,
                IdJadwalMengajar = 9,
                IdTujuanPembelajaran = 18
            },
            new AsesmenSumatif
            {
                Id = 10,
                IdJadwalMengajar = 10,
                IdTujuanPembelajaran = 19
            },
            new AsesmenSumatif
            {
                Id = 11,
                IdJadwalMengajar = 11,
                IdTujuanPembelajaran = 21
            },
            new AsesmenSumatif
            {
                Id = 12,
                IdJadwalMengajar = 12,
                IdTujuanPembelajaran = 23
            },
            new AsesmenSumatif
            {
                Id = 13,
                IdJadwalMengajar = 13,
                IdTujuanPembelajaran = 25
            },
            new AsesmenSumatif
            {
                Id = 14,
                IdJadwalMengajar = 14,
                IdTujuanPembelajaran = 26
            },
            new AsesmenSumatif
            {
                Id = 15,
                IdJadwalMengajar = 15,
                IdTujuanPembelajaran = 27
            }
        );
    }
}
