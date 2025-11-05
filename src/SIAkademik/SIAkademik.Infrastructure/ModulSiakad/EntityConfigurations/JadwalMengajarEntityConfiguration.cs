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
        builder.HasMany(x => x.DaftarHariMengajar).WithOne(x => x.JadwalMengajar);
        builder.HasMany(x => x.DaftarPertemuan).WithOne(x => x.JadwalMengajar);
        builder.HasMany(x => x.DaftarRaport).WithOne(x => x.JadwalMengajar);

        builder.HasMany(x => x.DaftarTujuanPembelajaran)
            .WithMany(y => y.DaftarJadwalMengajar)
            .UsingEntity<AsesmenSumatif>(
                l => l.HasOne(x => x.TujuanPembelajaran).WithMany(t => t.DaftarAsesmenSumatif).HasForeignKey(y => y.IdTujuanPembelajaran),
                l => l.HasOne(x => x.JadwalMengajar).WithMany(t => t.DaftarAsesmenSumatif).HasForeignKey(y => y.IdJadwalMengajar)
            );

        builder.HasMany(x => x.DaftarAnggotaRombel).WithMany(y => y.DaftarJadwalMengajar)
            .UsingEntity<AsesmenSumatifAkhirSemester>(
                l => l.HasOne(x => x.AnggotaRombel).WithMany(y => y.DaftarAsesmenSumatifAkhirSemester).HasForeignKey(a => a.AnggotaRombelId),
                r => r.HasOne(x => x.JadwalMengajar).WithMany(y => y.DaftarAsesmenSumatifAkhirSemester).HasForeignKey(a => a.JadwalMengajarId)
            );

        for (int i = 0; i < 15; i++)
        {
            builder.HasData(
                new
                {
                    Id = 1 + i,
                    DurasiMenit = 0,
                    MataPelajaranId = 1 + i,
                    PegawaiId = "PJ17-010",
                    RombelId = 1
                }    
            );
        }

        builder.HasData(
            new
            {
                Id = 17,
                DurasiMenit = 45,
                MataPelajaranId = 22,
                PegawaiId = "PJ14-003",
                RombelId = 2,
            },
            new
            {
                Id = 18,
                DurasiMenit = 45,
                MataPelajaranId = 16,
                PegawaiId = "PJ24-004",
                RombelId = 2,
            },
            new
            {
                Id = 19,
                DurasiMenit = 45,
                MataPelajaranId = 23,
                PegawaiId = "PJ18-012",
                RombelId = 2,
            },
            new
            {
                Id = 20,
                DurasiMenit = 45,
                MataPelajaranId = 24,
                PegawaiId = "PJ24-002",
                RombelId = 2,
            },
            new
            {
                Id = 21,
                DurasiMenit = 45,
                MataPelajaranId = 25,
                PegawaiId = "PJ22-024",
                RombelId = 2,
            },
            new
            {
                Id = 22,
                DurasiMenit = 45,
                MataPelajaranId = 5,
                PegawaiId = "PJ19-017",
                RombelId = 2,
            },
            new
            {
                Id = 23,
                DurasiMenit = 45,
                MataPelajaranId = 18,
                PegawaiId = "PJ14-005",
                RombelId = 2,
            },
            new
            {
                Id = 24,
                DurasiMenit = 45,
                MataPelajaranId = 1,
                PegawaiId = "PJ22-024",
                RombelId = 2,
            },
            new
            {
                Id = 25,
                DurasiMenit = 45,
                MataPelajaranId = 9,
                PegawaiId = "PJ18-013",
                RombelId = 2,
            },
            new
            {
                Id = 26,
                DurasiMenit = 45,
                MataPelajaranId = 6,
                PegawaiId = "PJ19-016",
                RombelId = 2,
            },
            new
            {
                Id = 27,
                DurasiMenit = 45,
                MataPelajaranId = 19,
                PegawaiId = "PJ23-029",
                RombelId = 2,
            },
            new
            {
                Id = 28,
                DurasiMenit = 45,
                MataPelajaranId = 20,
                PegawaiId = "PJ22-024",
                RombelId = 2,
            },
            new
            {
                Id = 29,
                DurasiMenit = 45,
                MataPelajaranId = 26,
                PegawaiId = "PJ23-030",
                RombelId = 2,
            },
            new
            {
                Id = 30,
                DurasiMenit = 45,
                MataPelajaranId = 21,
                PegawaiId = "PJ22-024",
                RombelId = 2,
            },
            new
            {
                Id = 31,
                DurasiMenit = 45,
                MataPelajaranId = 3,
                PegawaiId = "PJ23-031",
                RombelId = 2,
            },
            new
            {
                Id = 32,
                DurasiMenit = 45,
                MataPelajaranId = 4,
                PegawaiId = "PJ24-005",
                RombelId = 2,
            },
            new
            {
                Id = 33,
                DurasiMenit = 45,
                MataPelajaranId = 27,
                PegawaiId = "PJ22-024",
                RombelId = 2,
            }
        );
    }
}
