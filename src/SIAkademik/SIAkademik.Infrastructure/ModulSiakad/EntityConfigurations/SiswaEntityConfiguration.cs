using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIAkademik.Domain.Enums;
using SIAkademik.Domain.ModulSiakad.Entities;
using SIAkademik.Domain.ValueObjects;
using SIAkademik.Infrastructure.Database.ValueConverters;

namespace SIAkademik.Infrastructure.ModulSiakad.EntityConfigurations;

internal class SiswaEntityConfiguration : IEntityTypeConfiguration<Siswa>
{
    public void Configure(EntityTypeBuilder<Siswa> builder)
    {
        builder.HasKey(x => x.Id);

        builder.ComplexProperty(x => x.AlamatLengkap, o =>
        {
            o.Property(y => y.Jalan).IsRequired();
            o.Property(y => y.RT).IsRequired();
            o.Property(y => y.RW).IsRequired();
            o.Property(y => y.KelurahanDesa).IsRequired();
            o.Property(y => y.Kecamatan).IsRequired();
            o.Property(y => y.KotaKabupaten).IsRequired();
            o.Property(y => y.Provinsi).IsRequired();
        });

        builder.Property(x => x.NoHP).HasConversion<NoHPIntConverter>();
        builder.Property(x => x.NoHPAyah).HasConversion<NoHPIntConverter>();
        builder.Property(x => x.NoHPIbu).HasConversion<NoHPIntConverter>();
        builder.Property(x => x.NoHPWali).HasConversion<NoHPIntConverter>();
        builder.HasOne(x => x.Account).WithOne(x => x.Siswa).HasForeignKey<Siswa>("AppUserId");
        builder.HasMany(x => x.DaftarRombel).WithMany(y => y.DaftarSiswa).UsingEntity<AnggotaRombel>();

        builder.HasData(
            new
            {
                Id = 2,
                NISN = "0047892929",
                Nama = "Anlidua Lua Hingmadi",
                NIS = "192005",
                JenisKelamin = JenisKelamin.Perempuan,
                TanggalLahir = new DateOnly(2004, 5, 10),
                TanggalMasuk = new DateOnly(2019, 08, 01),
                TempatLahir = "Kalabahi",
                Agama = Agama.KristenProtestan,
                Jenjang = Jenjang.XII,
                StatusAktif = StatusAktifMahasiswa.TidakAktif,
                AppUserId = 15
            },
            new
            {
                Id = 3,
                NISN = "252601",
                Nama = "Ajesta Winarti Banamtuan",
                NIS = "252601",
                JenisKelamin = JenisKelamin.Perempuan,
                TanggalLahir = new DateOnly(2010, 1, 1),
                TanggalMasuk = new DateOnly(2025, 08, 01),
                TempatLahir = "Kupang",
                Agama = Agama.KristenProtestan,
                Jenjang = Jenjang.X,
                StatusAktif = StatusAktifMahasiswa.Aktif,
                AppUserId = 19
            },
            new
            {
                Id = 4,
                NISN = "252602",
                Nama = "Alfa Alfino Tunbonat",
                NIS = "252602",
                JenisKelamin = JenisKelamin.LakiLaki,
                TanggalLahir = new DateOnly(2010, 1, 1),
                TanggalMasuk = new DateOnly(2025, 08, 01),
                TempatLahir = "Kupang",
                Agama = Agama.KristenProtestan,
                Jenjang = Jenjang.X,
                StatusAktif = StatusAktifMahasiswa.Aktif,
                AppUserId = 20
            },
            new
            {
                Id = 5,
                NISN = "252603",
                Nama = "Alfiko Musa Manekat Duka",
                NIS = "252603",
                JenisKelamin = JenisKelamin.LakiLaki,
                TanggalLahir = new DateOnly(2010, 1, 1),
                TanggalMasuk = new DateOnly(2025, 08, 01),
                TempatLahir = "Kupang",
                Agama = Agama.KristenProtestan,
                Jenjang = Jenjang.X,
                StatusAktif = StatusAktifMahasiswa.Aktif,
                AppUserId = 21
            },
            new
            {
                Id = 6,
                NISN = "252605",
                Nama = "Anastasya Anin",
                NIS = "252605",
                JenisKelamin = JenisKelamin.Perempuan,
                TanggalLahir = new DateOnly(2010, 1, 1),
                TanggalMasuk = new DateOnly(2025, 08, 01),
                TempatLahir = "Kupang",
                Agama = Agama.KristenProtestan,
                Jenjang = Jenjang.X,
                StatusAktif = StatusAktifMahasiswa.Aktif,
                AppUserId = 22
            },
            new
            {
                Id = 7,
                NISN = "252606",
                Nama = "Aprian Lorenso Bauky",
                NIS = "252606",
                JenisKelamin = JenisKelamin.LakiLaki,
                TanggalLahir = new DateOnly(2010, 1, 1),
                TanggalMasuk = new DateOnly(2025, 08, 01),
                TempatLahir = "Kupang",
                Agama = Agama.KristenProtestan,
                Jenjang = Jenjang.X,
                StatusAktif = StatusAktifMahasiswa.Aktif,
                AppUserId = 23
            },
            new
            {
                Id = 8,
                NISN = "252607",
                Nama = "Aryo Arjuna Ekaputra Bili",
                NIS = "252607",
                JenisKelamin = JenisKelamin.LakiLaki,
                TanggalLahir = new DateOnly(2010, 1, 1),
                TanggalMasuk = new DateOnly(2025, 08, 01),
                TempatLahir = "Kupang",
                Agama = Agama.KristenProtestan,
                Jenjang = Jenjang.X,
                StatusAktif = StatusAktifMahasiswa.Aktif,
                AppUserId = 24
            },
            new
            {
                Id = 9,
                NISN = "252608",
                Nama = "Benediktus G. Araujo",
                NIS = "252608",
                JenisKelamin = JenisKelamin.LakiLaki,
                TanggalLahir = new DateOnly(2010, 1, 1),
                TanggalMasuk = new DateOnly(2025, 08, 01),
                TempatLahir = "Kupang",
                Agama = Agama.KristenProtestan,
                Jenjang = Jenjang.X,
                StatusAktif = StatusAktifMahasiswa.Aktif,
                AppUserId = 25
            },
            new
            {
                Id = 10,
                NISN = "252609",
                Nama = "Brigida Frida Tampani",
                NIS = "252609",
                JenisKelamin = JenisKelamin.LakiLaki,
                TanggalLahir = new DateOnly(2010, 1, 1),
                TanggalMasuk = new DateOnly(2025, 08, 01),
                TempatLahir = "Kupang",
                Agama = Agama.KristenProtestan,
                Jenjang = Jenjang.X,
                StatusAktif = StatusAktifMahasiswa.Aktif,
                AppUserId = 26
            },
            new
            {
                Id = 11,
                NISN = "252610",
                Nama = "Chenaniah Bona Ventura Buling",
                NIS = "252610",
                JenisKelamin = JenisKelamin.Perempuan,
                TanggalLahir = new DateOnly(2010, 1, 1),
                TanggalMasuk = new DateOnly(2025, 08, 01),
                TempatLahir = "Kupang",
                Agama = Agama.KristenProtestan,
                Jenjang = Jenjang.X,
                StatusAktif = StatusAktifMahasiswa.Aktif,
                AppUserId = 27
            },
            new
            {
                Id = 12,
                NISN = "252611",
                Nama = "Christian Alvaro Ufi",
                NIS = "252611",
                JenisKelamin = JenisKelamin.LakiLaki,
                TanggalLahir = new DateOnly(2010, 1, 1),
                TanggalMasuk = new DateOnly(2025, 08, 01),
                TempatLahir = "Kupang",
                Agama = Agama.KristenProtestan,
                Jenjang = Jenjang.X,
                StatusAktif = StatusAktifMahasiswa.Aktif,
                AppUserId = 28
            },
            new
            {
                Id = 13,
                NISN = "252612",
                Nama = "Cici Novelita Tung Lily",
                NIS = "252612",
                JenisKelamin = JenisKelamin.Perempuan,
                TanggalLahir = new DateOnly(2010, 1, 1),
                TanggalMasuk = new DateOnly(2025, 08, 01),
                TempatLahir = "Kupang",
                Agama = Agama.KristenProtestan,
                Jenjang = Jenjang.X,
                StatusAktif = StatusAktifMahasiswa.Aktif,
                AppUserId = 29
            },
            new
            {
                Id = 14,
                NISN = "252613",
                Nama = "Deviltha Andini Landupari",
                NIS = "252613",
                JenisKelamin = JenisKelamin.Perempuan,
                TanggalLahir = new DateOnly(2010, 1, 1),
                TanggalMasuk = new DateOnly(2025, 08, 01),
                TempatLahir = "Kupang",
                Agama = Agama.KristenProtestan,
                Jenjang = Jenjang.X,
                StatusAktif = StatusAktifMahasiswa.Aktif,
                AppUserId = 30
            },
            new
            {
                Id = 15,
                NISN = "252614",
                Nama = "Efranto Mesa",
                NIS = "252614",
                JenisKelamin = JenisKelamin.LakiLaki,
                TanggalLahir = new DateOnly(2010, 1, 1),
                TanggalMasuk = new DateOnly(2025, 08, 01),
                TempatLahir = "Kupang",
                Agama = Agama.KristenProtestan,
                Jenjang = Jenjang.X,
                StatusAktif = StatusAktifMahasiswa.Aktif,
                AppUserId = 31
            },
            new
            {
                Id = 16,
                NISN = "252615",
                Nama = "Gracia Prita Pandie",
                NIS = "252615",
                JenisKelamin = JenisKelamin.Perempuan,
                TanggalLahir = new DateOnly(2010, 1, 1),
                TanggalMasuk = new DateOnly(2025, 08, 01),
                TempatLahir = "Kupang",
                Agama = Agama.KristenProtestan,
                Jenjang = Jenjang.X,
                StatusAktif = StatusAktifMahasiswa.Aktif,
                AppUserId = 32
            },
            new
            {
                Id = 17,
                NISN = "252616",
                Nama = "Guenerva Kristivan Pieter Tauk",
                NIS = "252616",
                JenisKelamin = JenisKelamin.LakiLaki,
                TanggalLahir = new DateOnly(2010, 1, 1),
                TanggalMasuk = new DateOnly(2025, 08, 01),
                TempatLahir = "Kupang",
                Agama = Agama.KristenProtestan,
                Jenjang = Jenjang.X,
                StatusAktif = StatusAktifMahasiswa.Aktif,
                AppUserId = 33
            },
            new
            {
                Id = 18,
                NISN = "252617",
                Nama = "Helder Yahya Lopes Beka",
                NIS = "252617",
                JenisKelamin = JenisKelamin.LakiLaki,
                TanggalLahir = new DateOnly(2010, 1, 1),
                TanggalMasuk = new DateOnly(2025, 08, 01),
                TempatLahir = "Kupang",
                Agama = Agama.KristenProtestan,
                Jenjang = Jenjang.X,
                StatusAktif = StatusAktifMahasiswa.Aktif,
                AppUserId = 34
            },
            new
            {
                Id = 19,
                NISN = "252618",
                Nama = "Jenesty Elbitry Appu",
                NIS = "252618",
                JenisKelamin = JenisKelamin.Perempuan,
                TanggalLahir = new DateOnly(2010, 1, 1),
                TanggalMasuk = new DateOnly(2025, 08, 01),
                TempatLahir = "Kupang",
                Agama = Agama.KristenProtestan,
                Jenjang = Jenjang.X,
                StatusAktif = StatusAktifMahasiswa.Aktif,
                AppUserId = 35
            },
            new
            {
                Id = 20,
                NISN = "252619",
                Nama = "Kesyia Jetika Humsibu",
                NIS = "252619",
                JenisKelamin = JenisKelamin.Perempuan,
                TanggalLahir = new DateOnly(2010, 1, 1),
                TanggalMasuk = new DateOnly(2025, 08, 01),
                TempatLahir = "Kupang",
                Agama = Agama.KristenProtestan,
                Jenjang = Jenjang.X,
                StatusAktif = StatusAktifMahasiswa.Aktif,
                AppUserId = 36
            },
            new
            {
                Id = 21,
                NISN = "252620",
                Nama = "Lady Grace Julius",
                NIS = "252620",
                JenisKelamin = JenisKelamin.Perempuan,
                TanggalLahir = new DateOnly(2010, 1, 1),
                TanggalMasuk = new DateOnly(2025, 08, 01),
                TempatLahir = "Kupang",
                Agama = Agama.KristenProtestan,
                Jenjang = Jenjang.X,
                StatusAktif = StatusAktifMahasiswa.Aktif,
                AppUserId = 37
            },
            new
            {
                Id = 22,
                NISN = "252621",
                Nama = "Mean Grenaldi Aditia Dawa",
                NIS = "252621",
                JenisKelamin = JenisKelamin.LakiLaki,
                TanggalLahir = new DateOnly(2010, 1, 1),
                TanggalMasuk = new DateOnly(2025, 08, 01),
                TempatLahir = "Kupang",
                Agama = Agama.KristenProtestan,
                Jenjang = Jenjang.X,
                StatusAktif = StatusAktifMahasiswa.Aktif,
                AppUserId = 38
            },
            new
            {
                Id = 23,
                NISN = "252622",
                Nama = "Michelle Paulina Alwara",
                NIS = "252622",
                JenisKelamin = JenisKelamin.Perempuan,
                TanggalLahir = new DateOnly(2010, 1, 1),
                TanggalMasuk = new DateOnly(2025, 08, 01),
                TempatLahir = "Kupang",
                Agama = Agama.KristenProtestan,
                Jenjang = Jenjang.X,
                StatusAktif = StatusAktifMahasiswa.Aktif,
                AppUserId = 39
            },
            new
            {
                Id = 24,
                NISN = "252623",
                Nama = "Natanael U. T. Ngudang",
                NIS = "252623",
                JenisKelamin = JenisKelamin.LakiLaki,
                TanggalLahir = new DateOnly(2010, 1, 1),
                TanggalMasuk = new DateOnly(2025, 08, 01),
                TempatLahir = "Kupang",
                Agama = Agama.KristenProtestan,
                Jenjang = Jenjang.X,
                StatusAktif = StatusAktifMahasiswa.Aktif,
                AppUserId = 40
            },
            new
            {
                Id = 25,
                NISN = "252624",
                Nama = "Natasia Desta Moto",
                NIS = "252624",
                JenisKelamin = JenisKelamin.Perempuan,
                TanggalLahir = new DateOnly(2010, 1, 1),
                TanggalMasuk = new DateOnly(2025, 08, 01),
                TempatLahir = "Kupang",
                Agama = Agama.KristenProtestan,
                Jenjang = Jenjang.X,
                StatusAktif = StatusAktifMahasiswa.Aktif,
                AppUserId = 41
            },
            new
            {
                Id = 26,
                NISN = "252625",
                Nama = "Nicholyn Rambu Lunga",
                NIS = "252625",
                JenisKelamin = JenisKelamin.Perempuan,
                TanggalLahir = new DateOnly(2010, 1, 1),
                TanggalMasuk = new DateOnly(2025, 08, 01),
                TempatLahir = "Kupang",
                Agama = Agama.KristenProtestan,
                Jenjang = Jenjang.X,
                StatusAktif = StatusAktifMahasiswa.Aktif,
                AppUserId = 42
            },
            new
            {
                Id = 27,
                NISN = "252626",
                Nama = "Salomi Meriyanti Bekamau",
                NIS = "252626",
                JenisKelamin = JenisKelamin.Perempuan,
                TanggalLahir = new DateOnly(2010, 1, 1),
                TanggalMasuk = new DateOnly(2025, 08, 01),
                TempatLahir = "Kupang",
                Agama = Agama.KristenProtestan,
                Jenjang = Jenjang.X,
                StatusAktif = StatusAktifMahasiswa.Aktif,
                AppUserId = 43
            },
            new
            {
                Id = 28,
                NISN = "252627",
                Nama = "Sanjuan Heiland Lado",
                NIS = "252627",
                JenisKelamin = JenisKelamin.LakiLaki,
                TanggalLahir = new DateOnly(2010, 1, 1),
                TanggalMasuk = new DateOnly(2025, 08, 01),
                TempatLahir = "Kupang",
                Agama = Agama.KristenProtestan,
                Jenjang = Jenjang.X,
                StatusAktif = StatusAktifMahasiswa.Aktif,
                AppUserId = 44
            },
            new
            {
                Id = 29,
                NISN = "252628",
                Nama = "Yodirson Dimas Jogoritno Kause",
                NIS = "252628",
                JenisKelamin = JenisKelamin.LakiLaki,
                TanggalLahir = new DateOnly(2010, 1, 1),
                TanggalMasuk = new DateOnly(2025, 08, 01),
                TempatLahir = "Kupang",
                Agama = Agama.KristenProtestan,
                Jenjang = Jenjang.X,
                StatusAktif = StatusAktifMahasiswa.Aktif,
                AppUserId = 45
            },
            new
            {
                Id = 30,
                NISN = "252629",
                Nama = "Zhailla Hiama",
                NIS = "252629",
                JenisKelamin = JenisKelamin.Perempuan,
                TanggalLahir = new DateOnly(2010, 1, 1),
                TanggalMasuk = new DateOnly(2025, 08, 01),
                TempatLahir = "Kupang",
                Agama = Agama.KristenProtestan,
                Jenjang = Jenjang.X,
                StatusAktif = StatusAktifMahasiswa.Aktif,
                AppUserId = 46
            }
        );
    }
}
