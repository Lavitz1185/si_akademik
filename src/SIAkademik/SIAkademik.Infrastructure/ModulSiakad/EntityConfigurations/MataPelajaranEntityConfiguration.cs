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

        builder.HasData(
            new
            {
                Id = 3,
                Nama = "Pendidikan Agama dan Budi Pekerti",
                PeminatanId = 1,
                Jenjang = Jenjang.XII,
                KKM = 75d
            },
            new
            {
                Id = 4,
                Nama = "Pendidikan Pancasila dan Kewarganegaraan",
                PeminatanId = 1,
                Jenjang = Jenjang.XII,
                KKM = 75d
            },
            new
            {
                Id = 5,
                Nama = "Bahasa Indonesia",
                PeminatanId = 1,
                Jenjang = Jenjang.XII,
                KKM = 75d
            },
            new
            {
                Id = 6,
                Nama = "Matematika",
                PeminatanId = 1,
                Jenjang = Jenjang.XII,
                KKM = 75d
            },
            new
            {
                Id = 7,
                Nama = "Sejarah Indonesia",
                PeminatanId = 1,
                Jenjang = Jenjang.XII,
                KKM = 75d
            },
            new
            {
                Id = 8,
                Nama = "Bahasa Inggris",
                PeminatanId = 1,
                Jenjang = Jenjang.XII,
                KKM = 75d
            },
            new
            {
                Id = 9,
                Nama = "Seni Budaya",
                PeminatanId = 1,
                Jenjang = Jenjang.XII,
                KKM = 75d
            },
            new
            {
                Id = 10,
                Nama = "Pendidikan Jasmani Olah Raga Kesehatan",
                PeminatanId = 1,
                Jenjang = Jenjang.XII,
                KKM = 75d
            },
            new
            {
                Id = 11,
                Nama = "Matematika",
                PeminatanId = 5,
                Jenjang = Jenjang.XII,
                KKM = 75d
            },
            new
            {
                Id = 12,
                Nama = "Fisika",
                PeminatanId = 5,
                Jenjang = Jenjang.XII,
                KKM = 75d
            },
            new
            {
                Id = 13,
                Nama = "Biologi",
                PeminatanId = 5,
                Jenjang = Jenjang.XII,
                KKM = 75d
            },
            new
            {
                Id = 14,
                Nama = "Kimia",
                PeminatanId = 5,
                Jenjang = Jenjang.XII,
                KKM = 75d
            },
            new
            {
                Id = 15,
                Nama = "Pendalaman Minat Matematika",
                PeminatanId = 5,
                Jenjang = Jenjang.XII,
                KKM = 75d
            },
            new
            {
                Id = 16,
                Nama = "Pendalaman Minat Bahasa Inggris",
                PeminatanId = 5,
                Jenjang = Jenjang.XII,
                KKM = 75d
            },
            new
            {
                Id = 17,
                Nama = "Kimia",
                PeminatanId = 1,
                Jenjang = Jenjang.X,
                KKM = 75d
            },
            new
            {
                Id = 18,
                Nama = "Pendidikan Pancasila",
                PeminatanId = 1,
                Jenjang = Jenjang.X,
                KKM = 75d
            },
            new
            {
                Id = 19,
                Nama = "Biologi",
                PeminatanId = 1,
                Jenjang = Jenjang.X,
                KKM = 75d
            },
            new
            {
                Id = 20,
                Nama = "Coding",
                PeminatanId = 1,
                Jenjang = Jenjang.X,
                KKM = 75d
            },
            new
            {
                Id = 21,
                Nama = "Sejarah",
                PeminatanId = 1,
                Jenjang = Jenjang.X,
                KKM = 75d
            },
            new
            {
                Id = 22,
                Nama = "Sosiologi",
                PeminatanId = 1,
                Jenjang = Jenjang.X,
                KKM = 75d
            },
            new
            {
                Id = 23,
                Nama = "Pendidikan Jasmani, Olah Raga dan Kesehatan",
                PeminatanId = 1,
                Jenjang = Jenjang.X,
                KKM = 75d
            },
            new
            {
                Id = 24,
                Nama = "Bahasa Inggris",
                PeminatanId = 1,
                Jenjang = Jenjang.X,
                KKM = 75d
            },
            new
            {
                Id = 25,
                Nama = "Ekonomi",
                PeminatanId = 1,
                Jenjang = Jenjang.X,
                KKM = 75d
            },
            new
            {
                Id = 26,
                Nama = "Geografi",
                PeminatanId = 1,
                Jenjang = Jenjang.X,
                KKM = 75d
            },
            new
            {
                Id = 27,
                Nama = "Fisika",
                PeminatanId = 1,
                Jenjang = Jenjang.X,
                KKM = 75d
            },
            new
            {   
                Id = 28,
                Nama = "Bahasa Indonesia",
                PeminatanId = 1,
                Jenjang = Jenjang.X,
                KKM = 75d
            },
            new
            {
                Id = 29,
                Nama = "Pendidikan Agama dan Budi Pekerti",
                PeminatanId = 1,
                Jenjang = Jenjang.X,
                KKM = 75d
            },
            new
            {
                Id = 30,
                Nama = "Matematika (Umum)",
                PeminatanId = 1,
                Jenjang = Jenjang.X,
                KKM = 75d
            },
            new
            {
                Id = 31,
                Nama = "Seni Budaya",
                PeminatanId = 1,
                Jenjang = Jenjang.X,
                KKM = 75d
            },
            new
            {
                Id = 32,
                Nama = "Prakarya dan Kewirausahaan",
                PeminatanId = 1,
                Jenjang = Jenjang.X,
                KKM = 75d
            }
        );
    }
}
