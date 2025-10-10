using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIAkademik.Domain.Enums;
using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Infrastructure.ModulSiakad.EntityConfigurations;

internal class TujuanPembelajaranEntityConfiguration : IEntityTypeConfiguration<TujuanPembelajaran>
{
    public void Configure(EntityTypeBuilder<TujuanPembelajaran> builder)
    {
        builder.HasKey(a => a.Id);
        builder.HasOne(a => a.MataPelajaran).WithMany(m => m.DaftarTujuanPembelajaran);

        builder.HasData(
            new
            {
                Id = 1,
                Deskripsi = "Memahami arti dewasa secara fisik, intelektual, emosional, sosial, moral dan spiritual",
                MataPelajaranId = 3,
                Fase = Fase.E
            },
            new
            {
                Id = 2,
                Deskripsi = "Menghayati makna perilaku dewasa dan tidak dewasa dilingkungan keluarga dan masyarakat",
                MataPelajaranId = 3,
                Fase = Fase.E
            },
            new
            {
                Id = 3,
                Deskripsi = "Memahami arti dewasa secara fisik, intelektual, emosional, sosial, moral dan spiritual",
                MataPelajaranId = 3,
                Fase = Fase.E
            },
            new
            {
                Id = 4,
                Deskripsi = "Memahami arti dewasa secara fisik, intelektual, emosional, sosial, moral dan spiritual",
                MataPelajaranId = 3,
                Fase = Fase.E
            },
            new
            {
                Id = 5,
                Deskripsi = "Memahami arti dewasa secara fisik, intelektual, emosional, sosial, moral dan spiritual",
                MataPelajaranId = 3,
                Fase = Fase.E
            },
            new
            {
                Id = 6,
                Deskripsi = "Memahami arti dewasa secara fisik, intelektual, emosional, sosial, moral dan spiritual",
                MataPelajaranId = 3,
                Fase = Fase.E
            },
            new
            {
                Id = 7,
                Deskripsi = "Memahami arti dewasa secara fisik, intelektual, emosional, sosial, moral dan spiritual",
                MataPelajaranId = 3,
                Fase = Fase.E
            },
            new
            {
                Id = 8,
                Deskripsi = "Memahami arti dewasa secara fisik, intelektual, emosional, sosial, moral dan spiritual",
                MataPelajaranId = 3,
                Fase = Fase.E
            },
            new
            {
                Id = 9,
                Deskripsi = "Memahami arti dewasa secara fisik, intelektual, emosional, sosial, moral dan spiritual",
                MataPelajaranId = 3,
                Fase = Fase.E
            },
            new
            {
                Id = 10,
                Deskripsi = "Memahami arti dewasa secara fisik, intelektual, emosional, sosial, moral dan spiritual",
                MataPelajaranId = 3,
                Fase = Fase.E
            },
            new
            {
                Id = 11,
                Deskripsi = "Memahami arti dewasa secara fisik, intelektual, emosional, sosial, moral dan spiritual",
                MataPelajaranId = 3,
                Fase = Fase.E
            },
            new
            {
                Id = 12,
                Deskripsi = "Memahami arti dewasa secara fisik, intelektual, emosional, sosial, moral dan spiritual",
                MataPelajaranId = 3,
                Fase = Fase.E
            },
            new
            {
                Id = 13,
                Deskripsi = "Memahami arti dewasa secara fisik, intelektual, emosional, sosial, moral dan spiritual",
                MataPelajaranId = 3,
                Fase = Fase.E
            },
            new
            {
                Id = 14,
                Deskripsi = "Memahami arti dewasa secara fisik, intelektual, emosional, sosial, moral dan spiritual",
                MataPelajaranId = 3,
                Fase = Fase.E
            },
            new
            {
                Id = 15,
                Deskripsi = "Memahami arti dewasa secara fisik, intelektual, emosional, sosial, moral dan spiritual",
                MataPelajaranId = 3,
                Fase = Fase.E
            },
            new
            {
                Id = 16,
                Deskripsi = "Memahami arti dewasa secara fisik, intelektual, emosional, sosial, moral dan spiritual",
                MataPelajaranId = 3,
                Fase = Fase.E
            },
            new
            {
                Id = 17,
                Deskripsi = "Memahami arti dewasa secara fisik, intelektual, emosional, sosial, moral dan spiritual",
                MataPelajaranId = 3,
                Fase = Fase.E
            },
            new
            {
                Id = 18,
                Deskripsi = "Memahami arti dewasa secara fisik, intelektual, emosional, sosial, moral dan spiritual",
                MataPelajaranId = 3,
                Fase = Fase.E
            },
            new
            {
                Id = 19,
                Deskripsi = "Memahami arti dewasa secara fisik, intelektual, emosional, sosial, moral dan spiritual",
                MataPelajaranId = 3,
                Fase = Fase.E
            },
            new
            {
                Id = 20,
                Deskripsi = "Memahami arti dewasa secara fisik, intelektual, emosional, sosial, moral dan spiritual",
                MataPelajaranId = 3,
                Fase = Fase.E
            },
            new
            {
                Id = 21,
                Deskripsi = "Memahami arti dewasa secara fisik, intelektual, emosional, sosial, moral dan spiritual",
                MataPelajaranId = 3,
                Fase = Fase.E
            },
            new
            {
                Id = 22,
                Deskripsi = "Memahami arti dewasa secara fisik, intelektual, emosional, sosial, moral dan spiritual",
                MataPelajaranId = 3,
                Fase = Fase.E
            },
            new
            {
                Id = 23,
                Deskripsi = "Memahami arti dewasa secara fisik, intelektual, emosional, sosial, moral dan spiritual",
                MataPelajaranId = 3,
                Fase = Fase.E
            },
            new
            {
                Id = 24,
                Deskripsi = "Memahami arti dewasa secara fisik, intelektual, emosional, sosial, moral dan spiritual",
                MataPelajaranId = 3,
                Fase = Fase.E
            },
            new
            {
                Id = 25,
                Deskripsi = "Memahami arti dewasa secara fisik, intelektual, emosional, sosial, moral dan spiritual",
                MataPelajaranId = 3,
                Fase = Fase.E
            },
            new
            {
                Id = 26,
                Deskripsi = "Memahami arti dewasa secara fisik, intelektual, emosional, sosial, moral dan spiritual",
                MataPelajaranId = 3,
                Fase = Fase.E
            }
        );
    }
}
