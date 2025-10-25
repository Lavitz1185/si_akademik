using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIAkademik.Domain.ModulProfil.Entities;

namespace SIAkademik.Infrastructure.ModulProfil.EntityConfigurations;

internal class KategoriBeritaEntityConfiguration : IEntityTypeConfiguration<KategoriBerita>
{
    public void Configure(EntityTypeBuilder<KategoriBerita> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.DaftarBerita).WithOne(y => y.KategoriBerita);

        builder.HasData(
            new KategoriBerita
            {
                Id = 1,
                Nama = "Berita"
            },
            new KategoriBerita
            {
                Id = 2,
                Nama = "Pengumuman"
            }
        );
    }
}
