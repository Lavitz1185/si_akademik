using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIAkademik.Domain.Entities;
using SIAkademik.Infrastructure.Database.ValueConverters;

namespace SIAkademik.Infrastructure.Database.EntityConfigurations;

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
        builder.HasOne(x => x.Account).WithOne(y => y.Guru).HasForeignKey<Pegawai>("AppUserId");
        builder.HasMany(x => x.DaftarRombelWali).WithOne(y => y.Wali);
        builder.HasMany(x => x.DaftarJadwalMengajar).WithOne(y => y.Pegawai);
        builder.HasOne(x => x.Divisi).WithMany(x => x.DaftarPegawai);
        builder.HasOne(x => x.Jabatan).WithMany(x => x.DaftarPegawai);
    }
}
