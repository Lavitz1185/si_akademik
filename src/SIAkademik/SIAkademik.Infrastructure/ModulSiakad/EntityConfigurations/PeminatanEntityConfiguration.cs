using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIAkademik.Domain.Enums;
using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Infrastructure.ModulSiakad.EntityConfigurations;

internal class PeminatanEntityConfiguration : IEntityTypeConfiguration<Peminatan>
{
    public void Configure(EntityTypeBuilder<Peminatan> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.DaftarKelas).WithOne(k => k.Peminatan);
        builder.HasMany(x => x.DaftarMataPelajaran).WithOne(k => k.Peminatan);

        builder.HasData(
            new Peminatan
            {
                Id = 1,
                Nama = "Umum",
                Jenis = JenisPeminatan.Umum
            },
            new Peminatan
            {
                Id = 2,
                Nama = "MIPA",
                Jenis = JenisPeminatan.Peminatan
            },
            new Peminatan
            {
                Id = 3,
                Nama = "IPS",
                Jenis = JenisPeminatan.Peminatan
            },
            new Peminatan
            {
                Id = 4,
                Nama = "Bahasa",
                Jenis = JenisPeminatan.Peminatan
            }
        );
    }
}
