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
    }
}
