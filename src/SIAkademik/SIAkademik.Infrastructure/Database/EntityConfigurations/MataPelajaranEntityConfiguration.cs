using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIAkademik.Domain.Entities;

namespace SIAkademik.Infrastructure.Database.EntityConfigurations;

internal class MataPelajaranEntityConfiguration : IEntityTypeConfiguration<MataPelajaran>
{
    public void Configure(EntityTypeBuilder<MataPelajaran> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.DaftarJadwalMengajar).WithOne(y => y.MataPelajaran);
    }
}
