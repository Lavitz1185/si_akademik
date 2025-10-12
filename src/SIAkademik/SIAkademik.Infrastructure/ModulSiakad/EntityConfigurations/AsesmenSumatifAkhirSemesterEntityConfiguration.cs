using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Infrastructure.ModulSiakad.EntityConfigurations;

internal class AsesmenSumatifAkhirSemesterEntityConfiguration : IEntityTypeConfiguration<AsesmenSumatifAkhirSemester>
{
    public void Configure(EntityTypeBuilder<AsesmenSumatifAkhirSemester> builder)
    {
        builder.HasData(
            new AsesmenSumatifAkhirSemester
            {
                AnggotaRombelId = 1,
                JadwalMengajarId = 1,
                Nilai = 100,
            },
            new AsesmenSumatifAkhirSemester
            {
                AnggotaRombelId = 1,
                JadwalMengajarId = 2,
                Nilai = 91,
            },
            new AsesmenSumatifAkhirSemester
            {
                AnggotaRombelId = 1,
                JadwalMengajarId = 3,
                Nilai = 90,
            },
            new AsesmenSumatifAkhirSemester
            {
                AnggotaRombelId = 1,
                JadwalMengajarId = 4,
                Nilai = 90,
            },
            new AsesmenSumatifAkhirSemester
            {
                AnggotaRombelId = 1,
                JadwalMengajarId = 5,
                Nilai = 89,
            },
            new AsesmenSumatifAkhirSemester
            {
                AnggotaRombelId = 1,
                JadwalMengajarId = 6,
                Nilai = 87,
            },
            new AsesmenSumatifAkhirSemester
            {
                AnggotaRombelId = 1,
                JadwalMengajarId = 7,
                Nilai = 93,
            },
            new AsesmenSumatifAkhirSemester
            {
                AnggotaRombelId = 1,
                JadwalMengajarId = 8,
                Nilai = 86,
            },
            new AsesmenSumatifAkhirSemester
            {
                AnggotaRombelId = 1,
                JadwalMengajarId = 9,
                Nilai = 90,
            },
            new AsesmenSumatifAkhirSemester
            {
                AnggotaRombelId = 1,
                JadwalMengajarId = 10,
                Nilai = 92,
            },
            new AsesmenSumatifAkhirSemester
            {
                AnggotaRombelId = 1,
                JadwalMengajarId = 11,
                Nilai = 86,
            },
            new AsesmenSumatifAkhirSemester
            {
                AnggotaRombelId = 1,
                JadwalMengajarId = 12,
                Nilai = 95,
            },
            new AsesmenSumatifAkhirSemester
            {
                AnggotaRombelId = 1,
                JadwalMengajarId = 13,
                Nilai = 97,
            },
            new AsesmenSumatifAkhirSemester
            {
                AnggotaRombelId = 1,
                JadwalMengajarId = 14,
                Nilai = 90,
            },
            new AsesmenSumatifAkhirSemester
            {
                AnggotaRombelId = 1,
                JadwalMengajarId = 15,
                Nilai = 87,
            }
        );
    }
}
