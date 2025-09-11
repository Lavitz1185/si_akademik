using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Infrastructure.ModulSiakad.EntityConfigurations;

internal class AnggotaRombelEntityConfiguration : IEntityTypeConfiguration<AnggotaRombel>
{
    public void Configure(EntityTypeBuilder<AnggotaRombel> builder)
    {
        builder.HasKey(x => new { x.NISN, x.IdRombel });
        builder.HasOne(x => x.Siswa).WithMany(s => s.DaftarAnggotaRombel).HasForeignKey(x => x.NISN);
        builder.HasOne(x => x.Rombel).WithMany(s => s.DaftarAnggotaRombel).HasForeignKey(x => x.IdRombel);
        builder.HasMany(x => x.DaftarNilai).WithOne(s => s.AnggotaRombel);
        builder.HasMany(x => x.DaftarAbsen).WithOne(s => s.AnggotaRombel);
    }
}
