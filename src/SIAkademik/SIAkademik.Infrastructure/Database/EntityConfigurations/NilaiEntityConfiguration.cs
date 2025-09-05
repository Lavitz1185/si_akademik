using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIAkademik.Domain.Entities;

namespace SIAkademik.Infrastructure.Database.EntityConfigurations;

internal class NilaiEntityConfiguration : IEntityTypeConfiguration<Nilai>
{
    public void Configure(EntityTypeBuilder<Nilai> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.JadwalMengajar).WithMany(y => y.DaftarNilai);
        builder.HasOne(x => x.AnggotaRombel).WithMany(y => y.DaftarNilai);
    }
}
