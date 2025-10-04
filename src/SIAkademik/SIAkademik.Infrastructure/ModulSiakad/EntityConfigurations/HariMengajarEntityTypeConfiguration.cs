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
                JamMulai = new TimeOnly(7, 30),
                JamAkhir = new TimeOnly(8, 15),
                JadwalMengajarId = 17,
            },
            new
            {
                Id = 2,
                Hari = Hari.Senin,
                JamMulai = new TimeOnly(8, 20),
                JamAkhir = new TimeOnly(9, 5),
                JadwalMengajarId = 17,
            },
            new
            {
                Id = 3,
                Hari = Hari.Senin,
                JamMulai = new TimeOnly(9, 10),
                JamAkhir = new TimeOnly(9, 55),
                JadwalMengajarId = 18,
            },
            new
            {
                Id = 4,
                Hari = Hari.Senin,
                JamMulai = new TimeOnly(10, 0),
                JamAkhir = new TimeOnly(10, 45),
                JadwalMengajarId = 18,
            },
            new
            {
                Id = 5,
                Hari = Hari.Senin,
                JamMulai = new TimeOnly(10, 50),
                JamAkhir = new TimeOnly(11, 35),
                JadwalMengajarId = 19,
            },
            new
            {
                Id = 6,
                Hari = Hari.Senin,
                JamMulai = new TimeOnly(11, 40),
                JamAkhir = new TimeOnly(12, 25),
                JadwalMengajarId = 19,
            },
            new
            {
                Id = 7,
                Hari = Hari.Selasa,
                JamMulai = new TimeOnly(9, 10),
                JamAkhir = new TimeOnly(9, 55),
                JadwalMengajarId = 20,
            },
            new
            {
                Id = 8,
                Hari = Hari.Selasa,
                JamMulai = new TimeOnly(10, 0),
                JamAkhir = new TimeOnly(10, 45),
                JadwalMengajarId = 20,
            },
            new
            {
                Id = 9,
                Hari = Hari.Selasa,
                JamMulai = new TimeOnly(10, 50),
                JamAkhir = new TimeOnly(11, 35),
                JadwalMengajarId = 21,
            },
            new
            {
                Id = 10,
                Hari = Hari.Selasa,
                JamMulai = new TimeOnly(11, 40),
                JamAkhir = new TimeOnly(12, 25),
                JadwalMengajarId = 21,
            },
            new
            {
                Id = 11,
                Hari = Hari.Rabu,
                JamMulai = new TimeOnly(7, 30),
                JamAkhir = new TimeOnly(8, 15),
                JadwalMengajarId = 22,
            },
            new
            {
                Id = 12,
                Hari = Hari.Rabu,
                JamMulai = new TimeOnly(8, 20),
                JamAkhir = new TimeOnly(9, 5),
                JadwalMengajarId = 22,
            },
            new
            {
                Id = 13,
                Hari = Hari.Rabu,
                JamMulai = new TimeOnly(9, 10),
                JamAkhir = new TimeOnly(9, 55),
                JadwalMengajarId = 22,
            },
            new
            {
                Id = 14,
                Hari = Hari.Rabu,
                JamMulai = new TimeOnly(10, 0),
                JamAkhir = new TimeOnly(10, 45),
                JadwalMengajarId = 23,
            },
            new
            {
                Id = 15,
                Hari = Hari.Rabu,
                JamMulai = new TimeOnly(10, 50),
                JamAkhir = new TimeOnly(11, 35),
                JadwalMengajarId = 23,
            },
            new
            {
                Id = 16,
                Hari = Hari.Rabu,
                JamMulai = new TimeOnly(11, 45),
                JamAkhir = new TimeOnly(12, 25),
                JadwalMengajarId = 23,
            },
            new
            {
                Id = 17,
                Hari = Hari.Rabu,
                JamMulai = new TimeOnly(13, 0),
                JamAkhir = new TimeOnly(13, 45),
                JadwalMengajarId = 24,
            },
            new
            {
                Id = 18,
                Hari = Hari.Rabu,
                JamMulai = new TimeOnly(13, 50),
                JamAkhir = new TimeOnly(14, 35),
                JadwalMengajarId = 24,
            },
            new
            {
                Id = 19,
                Hari = Hari.Kamis,
                JamMulai = new TimeOnly(7, 30),
                JamAkhir = new TimeOnly(8, 15),
                JadwalMengajarId = 25,
            },
            new
            {
                Id = 20,
                Hari = Hari.Kamis,
                JamMulai = new TimeOnly(8, 20),
                JamAkhir = new TimeOnly(9, 5),
                JadwalMengajarId = 25,
            },
            new
            {
                Id = 21,
                Hari = Hari.Kamis,
                JamMulai = new TimeOnly(9, 10),
                JamAkhir = new TimeOnly(9, 55),
                JadwalMengajarId = 26,
            },
            new
            {
                Id = 22,
                Hari = Hari.Kamis,
                JamMulai = new TimeOnly(10, 0),
                JamAkhir = new TimeOnly(10, 45),
                JadwalMengajarId = 26,
            },
            new
            {
                Id = 23,
                Hari = Hari.Jumat,
                JamMulai = new TimeOnly(7, 30),
                JamAkhir = new TimeOnly(8, 15),
                JadwalMengajarId = 27,
            },
            new
            {
                Id = 24,
                Hari = Hari.Jumat,
                JamMulai = new TimeOnly(8, 20),
                JamAkhir = new TimeOnly(9, 5),
                JadwalMengajarId = 27,
            },
            new
            {
                Id = 25,
                Hari = Hari.Selasa,
                JamMulai = new TimeOnly(20, 0),
                JamAkhir = new TimeOnly(21, 0),
                JadwalMengajarId = 28,
            },
            new
            {
                Id = 26,
                Hari = Hari.Jumat,
                JamMulai = new TimeOnly(10, 0),
                JamAkhir = new TimeOnly(10, 45),
                JadwalMengajarId = 29,
            },
            new
            {
                Id = 27,
                Hari = Hari.Jumat,
                JamMulai = new TimeOnly(10, 50),
                JamAkhir = new TimeOnly(11, 35),
                JadwalMengajarId = 29,
            },
            new
            {
                Id = 28,
                Hari = Hari.Kamis,
                JamMulai = new TimeOnly(10, 50),
                JamAkhir = new TimeOnly(11, 35),
                JadwalMengajarId = 30,
            },
            new
            {
                Id = 29,
                Hari = Hari.Kamis,
                JamMulai = new TimeOnly(11, 40),
                JamAkhir = new TimeOnly(12, 25),
                JadwalMengajarId = 30,
            }
        );
    }
}
