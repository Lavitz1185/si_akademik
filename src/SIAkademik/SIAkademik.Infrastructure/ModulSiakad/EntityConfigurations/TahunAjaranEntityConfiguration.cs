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
                Semester = Semester.Ganjil,
                Tahun = 2021,
                TanggalMulai = new DateOnly(2021, 08, 01),
                TanggalSelesai = new DateOnly(2021, 12, 31)
            }, new TahunAjaran
            {
                Id = 2,
                Semester = Semester.Ganjil,
                Tahun = 2025,
                TanggalMulai = new DateOnly(2025, 07, 01),
                TanggalSelesai = new DateOnly(2025, 12, 31)
            }
        );
    }
}
