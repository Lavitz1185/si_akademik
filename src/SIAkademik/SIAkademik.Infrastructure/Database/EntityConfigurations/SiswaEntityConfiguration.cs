using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIAkademik.Domain.Entities;
using SIAkademik.Infrastructure.Database.ValueConverters;

namespace SIAkademik.Infrastructure.Database.EntityConfigurations;

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
        builder.HasMany(x => x.DaftarAnggotaRombel).WithOne(x => x.Siswa);
    }
}
