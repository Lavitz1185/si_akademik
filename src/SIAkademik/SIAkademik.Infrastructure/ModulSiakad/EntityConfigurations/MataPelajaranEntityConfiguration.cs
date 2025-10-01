using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIAkademik.Domain.Enums;
using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Infrastructure.ModulSiakad.EntityConfigurations;

internal class MataPelajaranEntityConfiguration : IEntityTypeConfiguration<MataPelajaran>
{
    public void Configure(EntityTypeBuilder<MataPelajaran> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.DaftarJadwalMengajar).WithOne(y => y.MataPelajaran);
        builder.HasOne(x => x.Peminatan).WithMany(p => p.DaftarMataPelajaran);

        builder.HasData(
            new
            {
                Id = 1,
                Nama = "Matematika",
                PeminatanId = 1,
                Jenjang = Jenjang.X,
                KKM = 70d
            },
            new
            {
                Id = 2,
                Nama = "Bahasa Indonesia",
                PeminatanId = 1,
                Jenjang = Jenjang.X,
                KKM = 80d
            }
        );
    }
}
