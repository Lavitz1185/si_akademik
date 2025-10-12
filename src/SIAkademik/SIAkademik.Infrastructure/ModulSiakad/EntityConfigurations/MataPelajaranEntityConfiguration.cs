using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIAkademik.Domain.Enums;
using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Infrastructure.ModulSiakad.EntityConfigurations;

internal class MataPelajaranEntityConfiguration : IEntityTypeConfiguration<MataPelajaran>
{
    public void Configure(EntityTypeBuilder<MataPelajaran> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.DaftarJadwalMengajar).WithOne(y => y.MataPelajaran);
        builder.HasOne(x => x.Peminatan).WithMany(p => p.DaftarMataPelajaran);
        builder.HasMany(x => x.DaftarTujuanPembelajaran).WithOne(t => t.MataPelajaran);

        builder.HasData(
            new
            {
                Id = 1,
                Nama = "Pendidikan Agama dan Budi Pekerti",
                PeminatanId = 1,
                KKM = 75d
            },
            new
            {
                Id = 2,
                Nama = "Pendidikan Pancasila dan Kewarganegaraan",
                PeminatanId = 1,
                KKM = 75d
            },
            new
            {
                Id = 3,
                Nama = "Bahasa Indonesia",
                PeminatanId = 1,
                KKM = 75d
            },
            new
            {
                Id = 4,
                Nama = "Matematika",
                PeminatanId = 1,
                KKM = 75d
            },
            new
            {
                Id = 5,
                Nama = "Sejarah Indonesia",
                PeminatanId = 1,
                KKM = 75d
            },
            new
            {
                Id = 6,
                Nama = "Bahasa Inggris",
                PeminatanId = 1,
                KKM = 75d
            },
            new
            {
                Id = 7,
                Nama = "Seni Budaya",
                PeminatanId = 1,
                KKM = 75d
            },
            new
            {
                Id = 8,
                Nama = "Prakarya dan Kewirausahaan",
                PeminatanId = 1,
                KKM = 75d
            },
            new
            {
                Id = 9,
                Nama = "Pendidikan Jasmani Olah Raga Kesehatan",
                PeminatanId = 1,
                KKM = 75d
            },
            new
            {
                Id = 10,
                Nama = "Matematika Tingkat Lanjut",
                PeminatanId = 5,
                KKM = 75d
            },
            new
            {
                Id = 11,
                Nama = "Fisika",
                PeminatanId = 5,
                KKM = 75d
            },
            new
            {
                Id = 12,
                Nama = "Biologi",
                PeminatanId = 5,
                KKM = 75d
            },
            new
            {
                Id = 13,
                Nama = "Kimia",
                PeminatanId = 5,
                KKM = 75d
            },
            new
            {
                Id = 14,
                Nama = "Pendalaman Minat Matematika",
                PeminatanId = 5,
                KKM = 75d
            },
            new
            {
                Id = 15,
                Nama = "Pendalaman Minat Bahasa Inggris",
                PeminatanId = 5,
                KKM = 75d
            },
            new
            {
                Id = 16,
                Nama = "Pendidikan Pancasila",
                PeminatanId = 1,
                KKM = 75d
            },
            new
            {
                Id = 17,
                Nama = "Coding",
                PeminatanId = 1,
                KKM = 75d
            },
            new
            {
                Id = 18,
                Nama = "Sosiologi",
                PeminatanId = 1,
                KKM = 75d
            },
            new
            {
                Id = 19,
                Nama = "Ekonomi",
                PeminatanId = 1,
                KKM = 75d
            },
            new
            {
                Id = 20,
                Nama = "Geografi",
                PeminatanId = 1,
                KKM = 75d
            },
            new
            {
                Id = 21,
                Nama = "Seni Tari, Teater, dan Rupa",
                PeminatanId = 1,
                KKM = 75d
            }
        );
    }
}
