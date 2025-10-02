using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Infrastructure.ModulSiakad.EntityConfigurations;

internal class DivisiEntityConfiguration : IEntityTypeConfiguration<Divisi>
{
    public void Configure(EntityTypeBuilder<Divisi> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.DaftarPegawai).WithOne(y => y.Divisi);

        builder.HasData(
            new Divisi
            {
                Id = 1,
                Nama = "SMA"
            },
            new Divisi
            {
                Id = 2,
                Nama = "Pengadaan dan Keuangan"
            },
            new Divisi
            {
                Id = 3,
                Nama = "DPU"
            },
            new Divisi
            {
                Id = 4,
                Nama = "HRD"
            },
            new Divisi
            {
                Id = 5,
                Nama = "R&D"
            },
            new Divisi
            {
                Id = 6,
                Nama = "Yayasan"
            }
        );
    }
}
