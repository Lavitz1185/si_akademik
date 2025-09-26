using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIAkademik.Domain.Enums;
using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Infrastructure.ModulSiakad.EntityConfigurations;

internal class TahunAjaranEntityConfiguration : IEntityTypeConfiguration<TahunAjaran>
{
    public void Configure(EntityTypeBuilder<TahunAjaran> builder)
    {
        builder.HasMany(x => x.DaftarKelas).WithOne(x => x.TahunAjaran);

        builder.HasData(
            new TahunAjaran
            {
                Id = 1,
                Periode = "2024/2025",
                Semester = Semester.Ganjil,
                TahunPelaksaan = 2025
            },
            new TahunAjaran
            {
                Id = 2,
                Periode = "2024/2025",
                Semester = Semester.Genap,
                TahunPelaksaan = 2025
            }
        );
    }
}
