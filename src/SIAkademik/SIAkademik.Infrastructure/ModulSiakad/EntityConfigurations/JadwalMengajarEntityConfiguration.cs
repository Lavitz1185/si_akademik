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
        builder.HasMany(x => x.DaftarNilai).WithOne(x => x.JadwalMengajar);
        builder.HasMany(x => x.DaftarHariMengajar).WithOne(x => x.JadwalMengajar);
        builder.HasMany(x => x.DaftarPertemuan).WithOne(x => x.JadwalMengajar);
        builder.HasMany(x => x.DaftarRaport).WithOne(x => x.JadwalMengajar);

        builder.HasData(
            new
            {
                Id = 1,
                MataPelajaranId = 1,
                RombelId = 1,
                PegawaiId = "PJ24-003"
            },
            new
            {
                Id = 2,
                MataPelajaranId = 2,
                RombelId = 1,
                PegawaiId = "PJ24-003"
            },
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
            }
        );
    }
}
