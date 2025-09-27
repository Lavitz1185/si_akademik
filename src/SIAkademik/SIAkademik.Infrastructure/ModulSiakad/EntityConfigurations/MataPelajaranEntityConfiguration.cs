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

        builder.HasData(
            new MataPelajaran
            {
                Id = 1,
                Nama = "Matematika",
                Peminatan = Peminatan.Umum,
                Jenjang = Jenjang.X
            },
            new MataPelajaran
            {
                Id = 2,
                Nama = "Bahasa Indonesia",
                Peminatan = Peminatan.Umum,
                Jenjang = Jenjang.X
            }
        );
    }
}
