using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Infrastructure.ModulSiakad.EntityConfigurations;

internal class PertemuanEntityConfiguration : IEntityTypeConfiguration<Pertemuan>
{
    public void Configure(EntityTypeBuilder<Pertemuan> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.TanggalPelaksanaan).HasColumnType("timestamp without time zone");
        builder.HasOne(x => x.JadwalMengajar).WithMany(y => y.DaftarPertemuan);
        builder.HasMany(x => x.DaftarAbsen).WithOne(y => y.Pertemuan);

        var nomor = 1;
        var id = 1;
        for(var date = new DateTime(new DateOnly(2025, 7, 7), new TimeOnly(7, 30), DateTimeKind.Unspecified); 
            date <= new DateTime(new DateOnly(2025, 12, 31), new TimeOnly(7, 30), DateTimeKind.Unspecified);
            date = date.AddDays(7))
        {
            builder.HasData(
                new
                {
                    Id = id++,
                    Nomor = nomor,
                    StatusPertemuan = StatusPertemuan.BelumMulai,
                    TanggalPelaksanaan = date,
                    JadwalMengajarId = 17
                },
                new
                {
                    Id = id++,
                    Nomor = nomor + 1,
                    StatusPertemuan = StatusPertemuan.BelumMulai,
                    TanggalPelaksanaan = new DateTime(DateOnly.FromDateTime(date), new TimeOnly(8, 20), DateTimeKind.Unspecified),
                    JadwalMengajarId = 17
                },
                new
                {
                    Id = id++,
                    Nomor = nomor,
                    StatusPertemuan = StatusPertemuan.BelumMulai,
                    TanggalPelaksanaan = new DateTime(DateOnly.FromDateTime(date), new TimeOnly(9, 10), DateTimeKind.Unspecified),
                    JadwalMengajarId = 18
                },
                new
                {
                    Id = id++,
                    Nomor = nomor + 1,
                    StatusPertemuan = StatusPertemuan.BelumMulai,
                    TanggalPelaksanaan = new DateTime(DateOnly.FromDateTime(date), new TimeOnly(10, 0), DateTimeKind.Unspecified),
                    JadwalMengajarId = 18
                },
                new
                {
                    Id = id++,
                    Nomor = nomor,
                    StatusPertemuan = StatusPertemuan.BelumMulai,
                    TanggalPelaksanaan = new DateTime(DateOnly.FromDateTime(date), new TimeOnly(10, 50), DateTimeKind.Unspecified),
                    JadwalMengajarId = 19
                },
                new
                {
                    Id = id++,
                    Nomor = nomor + 1,
                    StatusPertemuan = StatusPertemuan.BelumMulai,
                    TanggalPelaksanaan = new DateTime(DateOnly.FromDateTime(date), new TimeOnly(11, 40), DateTimeKind.Unspecified),
                    JadwalMengajarId = 19
                },
                new
                {
                    Id = id++,
                    Nomor = nomor,
                    StatusPertemuan = StatusPertemuan.BelumMulai,
                    TanggalPelaksanaan = new DateTime(DateOnly.FromDateTime(date), new TimeOnly(13, 50), DateTimeKind.Unspecified),
                    JadwalMengajarId = 20
                },
                new
                {
                    Id = id++,
                    Nomor = nomor + 1,
                    StatusPertemuan = StatusPertemuan.BelumMulai,
                    TanggalPelaksanaan = new DateTime(DateOnly.FromDateTime(date), new TimeOnly(13, 50), DateTimeKind.Unspecified),
                    JadwalMengajarId = 20
                }
            );

            nomor += 2;
        }
    }
}
