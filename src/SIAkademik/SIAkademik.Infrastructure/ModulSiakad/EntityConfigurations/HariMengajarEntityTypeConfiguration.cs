using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIAkademik.Domain.Enums;
using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Infrastructure.ModulSiakad.EntityConfigurations;

internal class HariMengajarEntityTypeConfiguration : IEntityTypeConfiguration<HariMengajar>
{
    public void Configure(EntityTypeBuilder<HariMengajar> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.JadwalMengajar).WithMany(x => x.DaftarHariMengajar);

        builder.HasData(
            new
            {
                Id = 1,
                Hari = Hari.Senin,
                JamMulai = new TimeOnly(7, 00),
                JamAkhir = new TimeOnly(12, 00),
                JadwalMengajarId = 1
            },
            new
            {
                Id = 2,
                Hari = Hari.Selasa,
                JamMulai = new TimeOnly(7, 00),
                JamAkhir = new TimeOnly(12, 00),
                JadwalMengajarId = 1
            },
            new
            {
                Id = 3,
                Hari = Hari.Rabu,
                JamMulai = new TimeOnly(7, 00),
                JamAkhir = new TimeOnly(12, 00),
                JadwalMengajarId = 1
            },
            new
            {
                Id = 4,
                Hari = Hari.Kamis,
                JamMulai = new TimeOnly(7, 00),
                JamAkhir = new TimeOnly(12, 00),
                JadwalMengajarId = 1
            },
            new
            {
                Id = 5,
                Hari = Hari.Jumat,
                JamMulai = new TimeOnly(7, 00),
                JamAkhir = new TimeOnly(12, 00),
                JadwalMengajarId = 1
            },
            new
            {
                Id = 6,
                Hari = Hari.Senin,
                JamMulai = new TimeOnly(13, 00),
                JamAkhir = new TimeOnly(16, 00),
                JadwalMengajarId = 2
            },
            new
            {
                Id = 7,
                Hari = Hari.Selasa,
                JamMulai = new TimeOnly(13, 00),
                JamAkhir = new TimeOnly(16, 00),
                JadwalMengajarId = 2
            },
            new
            {
                Id = 8,
                Hari = Hari.Rabu,
                JamMulai = new TimeOnly(13, 00),
                JamAkhir = new TimeOnly(16, 00),
                JadwalMengajarId = 2
            },
            new
            {
                Id = 9,
                Hari = Hari.Kamis,
                JamMulai = new TimeOnly(13, 00),
                JamAkhir = new TimeOnly(16, 00),
                JadwalMengajarId = 2
            },
            new
            {
                Id = 10,
                Hari = Hari.Jumat,
                JamMulai = new TimeOnly(13, 00),
                JamAkhir = new TimeOnly(16, 00),
                JadwalMengajarId = 2
            }
        );
    }
}
