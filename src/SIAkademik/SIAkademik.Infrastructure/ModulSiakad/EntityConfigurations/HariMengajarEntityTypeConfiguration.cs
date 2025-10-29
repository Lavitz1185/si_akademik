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
                JadwalMengajarId = 17,
                JamMulai = new TimeOnly(7, 30),
                JamAkhir = new TimeOnly(9, 5),
            },
            new
            {
                Id = 2,
                Hari = Hari.Senin,
                JadwalMengajarId = 18,
                JamMulai = new TimeOnly(9, 10),
                JamAkhir = new TimeOnly(10, 45),
            },
            new
            {
                Id = 3,
                Hari = Hari.Senin,
                JadwalMengajarId = 19,
                JamMulai = new TimeOnly(10, 50),
                JamAkhir = new TimeOnly(12, 25),
            },
            new
            {
                Id = 4,
                Hari = Hari.Senin,
                JadwalMengajarId = 20,
                JamMulai = new TimeOnly(13, 0),
                JamAkhir = new TimeOnly(14, 35),
            },
            new
            {
                Id = 5,
                Hari = Hari.Selasa,
                JadwalMengajarId = 20,
                JamMulai = new TimeOnly(13, 0),
                JamAkhir = new TimeOnly(14, 35),
            },
            new
            {
                Id = 6,
                Hari = Hari.Selasa,
                JadwalMengajarId = 21,
                JamMulai = new TimeOnly(7, 30),
                JamAkhir = new TimeOnly(9, 5),
            },
            new
            {
                Id = 7,
                Hari = Hari.Selasa,
                JadwalMengajarId = 22,
                JamMulai = new TimeOnly(9, 10),
                JamAkhir = new TimeOnly(10, 45),
            },
            new
            {
                Id = 8,
                Hari = Hari.Selasa,
                JadwalMengajarId = 23,
                JamMulai = new TimeOnly(10, 50),
                JamAkhir = new TimeOnly(12, 25),
            },
            new
            {
                Id = 9,
                Hari = Hari.Selasa,
                JadwalMengajarId = 24,
                JamMulai = new TimeOnly(20, 0),
                JamAkhir = new TimeOnly(21, 0),
            },
            new
            {
                Id = 10,
                Hari = Hari.Rabu,
                JadwalMengajarId = 25,
                JamMulai = new TimeOnly(7, 30),
                JamAkhir = new TimeOnly(9, 55),
            },
            new
            {
                Id = 11,
                Hari = Hari.Rabu,
                JadwalMengajarId = 26,
                JamMulai = new TimeOnly(10, 0),
                JamAkhir = new TimeOnly(12, 25),
            },
            new
            {
                Id = 12,
                Hari = Hari.Rabu,
                JadwalMengajarId = 27,
                JamMulai = new TimeOnly(13, 0),
                JamAkhir = new TimeOnly(14, 35),
            },
            new
            {
                Id = 13,
                Hari = Hari.Kamis,
                JadwalMengajarId = 28,
                JamMulai = new TimeOnly(7, 30),
                JamAkhir = new TimeOnly(9, 5),
            },
            new
            {
                Id = 14,
                Hari = Hari.Kamis,
                JadwalMengajarId = 29,
                JamMulai = new TimeOnly(9, 10),
                JamAkhir = new TimeOnly(10, 45),
            },
            new
            {
                Id = 15,
                Hari = Hari.Kamis,
                JadwalMengajarId = 30,
                JamMulai = new TimeOnly(10, 50),
                JamAkhir = new TimeOnly(12, 25),
            },
            new
            {
                Id = 16,
                Hari = Hari.Jumat,
                JadwalMengajarId = 31,
                JamMulai = new TimeOnly(7, 30),
                JamAkhir = new TimeOnly(9, 55),
            },
            new
            {
                Id = 17,
                Hari = Hari.Jumat,
                JadwalMengajarId = 32,
                JamMulai = new TimeOnly(10, 0),
                JamAkhir = new TimeOnly(12, 25),
            },
            new
            {
                Id = 18,
                Hari = Hari.Jumat,
                JadwalMengajarId = 33,
                JamMulai = new TimeOnly(12, 30),
                JamAkhir = new TimeOnly(14, 35),
            }
        );
    }
}
