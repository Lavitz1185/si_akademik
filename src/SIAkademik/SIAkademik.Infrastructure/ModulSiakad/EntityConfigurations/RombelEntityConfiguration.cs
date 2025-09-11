using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Infrastructure.ModulSiakad.EntityConfigurations;

internal class RombelEntityConfiguration : IEntityTypeConfiguration<Rombel>
{
    public void Configure(EntityTypeBuilder<Rombel> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.Kelas).WithMany(y => y.DaftarRombel);
        builder.HasOne(x => x.Wali).WithMany(y => y.DaftarRombelWali);
        builder.HasMany(x => x.DaftarAnggotaRombel).WithOne(x => x.Rombel);
        builder.HasMany(x => x.DaftarJadwalMengajar).WithOne(x => x.Rombel);
    }
}
