using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIAkademik.Domain.Entities;

namespace SIAkademik.Infrastructure.Database.EntityConfigurations;

internal class JadwalMengajarEntityConfiguration : IEntityTypeConfiguration<JadwalMengajar>
{
    public void Configure(EntityTypeBuilder<JadwalMengajar> builder)
    {
        builder.HasKey(x => new { x.NIP, x.IdMataPelajaran, x.IdRombel });
        builder.HasOne(x => x.Pegawai).WithMany(y => y.DaftarJadwalMengajar).HasForeignKey(x => x.NIP);
        builder.HasOne(x => x.MataPelajaran).WithMany(y => y.DaftarJadwalMengajar).HasForeignKey(x => x.IdMataPelajaran);
        builder.HasOne(x => x.Rombel).WithMany(y => y.DaftarJadwalMengajar).HasForeignKey(x => x.IdRombel);
        builder.HasMany(x => x.DaftarNilai).WithOne(x => x.JadwalMengajar);
    }
}
