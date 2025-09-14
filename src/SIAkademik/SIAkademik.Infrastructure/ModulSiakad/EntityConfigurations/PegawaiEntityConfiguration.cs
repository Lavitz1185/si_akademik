using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIAkademik.Domain.Enums;
using SIAkademik.Domain.ModulSiakad.Entities;
using SIAkademik.Domain.ValueObjects;
using SIAkademik.Infrastructure.Database.ValueConverters;

namespace SIAkademik.Infrastructure.ModulSiakad.EntityConfigurations;

internal class PegawaiEntityConfiguration : IEntityTypeConfiguration<Pegawai>
{
    public void Configure(EntityTypeBuilder<Pegawai> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.NoHP).HasConversion<NoHPIntConverter>();
        builder.ComplexProperty(x => x.AlamatKTP, o =>
        {
            o.Property(y => y.Jalan).IsRequired();
            o.Property(y => y.RT).IsRequired();
            o.Property(y => y.RW).IsRequired();
            o.Property(y => y.KelurahanDesa).IsRequired();
            o.Property(y => y.Kecamatan).IsRequired();
            o.Property(y => y.KotaKabupaten).IsRequired();
            o.Property(y => y.Provinsi).IsRequired();
        });
        builder.HasOne(x => x.Account).WithOne(y => y.Guru).HasForeignKey<Pegawai>("AppUserId").IsRequired(false);
        builder.HasMany(x => x.DaftarRombelWali).WithOne(y => y.Wali);
        builder.HasMany(x => x.DaftarJadwalMengajar).WithOne(y => y.Pegawai);
        builder.HasOne(x => x.Divisi).WithMany(x => x.DaftarPegawai);
        builder.HasOne(x => x.Jabatan).WithMany(x => x.DaftarPegawai);

        builder.HasData(
            new
            {
                Id = "PJ24-003",
                Nama = "Mega Lita A. Lello, S.Pd",
                TanggalMasuk = new DateOnly(2024, 7, 1),
                JenisKelamin = JenisKelamin.Perempuan,
                TempatLahir = "Noelbaki",
                TanggalLahir = new DateOnly(2001, 7, 27),
                NoHP = NoHP.Create("081237731427").Value,
                Email = "megalello99@gmail.com",
                NIK = "5301086707010008",
                AlamatKTP_KodePos = "",
                AlamatKTP_Jalan = "Noelbaki",
                AlamatKTP_RT = 37,
                AlamatKTP_RW = 14,
                AlamatKTP_KelurahanDesa = "Kelurahan Noelbaki",
                AlamatKTP_Kecamatan = "Kupang Tengah",
                AlamatKTP_KotaKabupaten = "Kabupaten Kupang",
                AlamatKTP_Provinsi = "NTT",
                Agama = Agama.KristenProtestan,
                GolonganDarah = GolonganDarah.A,
                StatusPerkawinan = StatusPerkawinan.TidakKawin,
                NamaInstagram = string.Empty,
                NoRekening = "169601013554503(BRI)",
                JabatanId = 1,
                DivisiId = 1,
                AppUserId = 2
            }
        );
    }
}
