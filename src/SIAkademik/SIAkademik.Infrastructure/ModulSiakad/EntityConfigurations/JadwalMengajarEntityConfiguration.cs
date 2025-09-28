using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Infrastructure.ModulSiakad.EntityConfigurations;

internal class JadwalMengajarEntityConfiguration : IEntityTypeConfiguration<JadwalMengajar>
{
    public void Configure(EntityTypeBuilder<JadwalMengajar> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasIndex("MataPelajaranId", "RombelId", "PegawaiId").IsUnique();

        builder.HasOne(x => x.Pegawai).WithMany(y => y.DaftarJadwalMengajar);
        builder.HasOne(x => x.MataPelajaran).WithMany(y => y.DaftarJadwalMengajar);
        builder.HasOne(x => x.Rombel).WithMany(y => y.DaftarJadwalMengajar);
        builder.HasMany(x => x.DaftarNilai).WithOne(x => x.JadwalMengajar);
        builder.HasMany(x => x.DaftarHariMengajar).WithOne(x => x.JadwalMengajar);
        builder.HasMany(x => x.DaftarPertemuan).WithOne(x => x.JadwalMengajar);
        builder.HasMany(x => x.DaftarRaport).WithOne(x => x.JadwalMengajar);

        builder.HasData(
            new
            {
                Id = 1,
                MataPelajaranId = 1,
                RombelId = 1,
                PegawaiId = "PJ24-003"
            },
            new
            {
                Id = 2,
                MataPelajaranId = 2,
                RombelId = 1,
                PegawaiId = "PJ24-003"
            }
        );
    }
}
