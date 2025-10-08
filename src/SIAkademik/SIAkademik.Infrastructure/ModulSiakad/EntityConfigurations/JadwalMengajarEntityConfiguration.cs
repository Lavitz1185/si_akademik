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
        builder.HasMany(x => x.DaftarEvaluasiSiswa).WithOne(x => x.JadwalMengajar);
        builder.HasMany(x => x.DaftarHariMengajar).WithOne(x => x.JadwalMengajar);
        builder.HasMany(x => x.DaftarPertemuan).WithOne(x => x.JadwalMengajar);
        builder.HasMany(x => x.DaftarRaport).WithOne(x => x.JadwalMengajar);

        builder.HasData(
            new
            {
                Id = 3,
                MataPelajaranId = 3,
                RombelId = 2,
                PegawaiId = "PJ17-010"
            },
            new
            {
                Id = 4,
                MataPelajaranId = 4,
                RombelId = 2,
                PegawaiId = "PJ17-010"
            },
            new
            {
                Id = 5,
                MataPelajaranId = 5,
                RombelId = 2,
                PegawaiId = "PJ17-010"
            },
            new
            {
                Id = 6,
                MataPelajaranId = 6,
                RombelId = 2,
                PegawaiId = "PJ17-010"
            },
            new
            {
                Id = 7,
                MataPelajaranId = 7,
                RombelId = 2,
                PegawaiId = "PJ17-010"
            },
            new
            {
                Id = 8,
                MataPelajaranId = 8,
                RombelId = 2,
                PegawaiId = "PJ17-010"
            },
            new
            {
                Id = 9,
                MataPelajaranId = 9,
                RombelId = 2,
                PegawaiId = "PJ17-010"
            },
            new
            {
                Id = 10,
                MataPelajaranId = 10,
                RombelId = 2,
                PegawaiId = "PJ17-010"
            },
            new
            {
                Id = 11,
                MataPelajaranId = 11,
                RombelId = 2,
                PegawaiId = "PJ17-010"
            },
            new
            {
                Id = 12,
                MataPelajaranId = 12,
                RombelId = 2,
                PegawaiId = "PJ17-010"
            },
            new
            {
                Id = 13,
                MataPelajaranId = 13,
                RombelId = 2,
                PegawaiId = "PJ17-010"
            },
            new
            {
                Id = 14,
                MataPelajaranId = 14,
                RombelId = 2,
                PegawaiId = "PJ17-010"
            },
            new
            {
                Id = 15,
                MataPelajaranId = 15,
                RombelId = 2,
                PegawaiId = "PJ17-010"
            },
            new
            {
                Id = 16,
                MataPelajaranId = 16,
                RombelId = 2,
                PegawaiId = "PJ17-010"
            },
            new
            {
                Id = 17,
                MataPelajaranId = 14,
                RombelId = 1,
                PegawaiId = "PJ14-003"
            },
            new
            {
                Id = 18,
                MataPelajaranId = 18,
                RombelId = 1,
                PegawaiId = "PJ24-004"
            },
            new
            {
                Id = 19,
                MataPelajaranId = 13,
                RombelId = 1,
                PegawaiId = "PJ18-012"
            },
            new
            {
                Id = 20,
                MataPelajaranId = 21,
                RombelId = 1,
                PegawaiId = "PJ19-017"
            },
            new
            {
                Id = 21,
                MataPelajaranId = 22,
                RombelId = 1,
                PegawaiId = "PJ14-005"
            },
            new
            {
                Id = 22,
                MataPelajaranId = 23,
                RombelId = 1,
                PegawaiId = "PJ18-013"
            },
            new
            {
                Id = 23,
                MataPelajaranId = 24,
                RombelId = 1,
                PegawaiId = "PJ19-016"
            },
            new
            {
                Id = 24,
                MataPelajaranId = 8,
                RombelId = 1,
                PegawaiId = "PJ23-029"
            },
            new
            {
                Id = 25,
                MataPelajaranId = 26,
                RombelId = 1,
                PegawaiId = "PJ19-017"
            },
            new
            {
                Id = 26,
                MataPelajaranId = 12,
                RombelId = 1,
                PegawaiId = "PJ23-030"
            },
            new
            {
                Id = 27,
                MataPelajaranId = 5,
                RombelId = 1,
                PegawaiId = "PJ23-031"
            },
            new
            {
                Id = 28,
                MataPelajaranId = 1,
                RombelId = 1,
                PegawaiId = "PJ23-030"
            },
            new
            {
                Id = 29,
                MataPelajaranId = 6,
                RombelId = 1,
                PegawaiId = "PJ24-005"
            },
            new
            {
                Id = 30,
                MataPelajaranId = 9,
                RombelId = 1,
                PegawaiId = "PJ23-030"
            },
            new
            {
                Id = 31,
                MataPelajaranId = 17,
                RombelId = 2,
                PegawaiId = "PJ17-010"
            }
        );
    }
}
