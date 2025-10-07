using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Infrastructure.ModulSiakad.EntityConfigurations;

internal class RaportEntityConfiguration : IEntityTypeConfiguration<Raport>
{
    public void Configure(EntityTypeBuilder<Raport> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.AnggotaRombel).WithMany(y => y.DaftarRaport);
        builder.HasOne(x => x.JadwalMengajar).WithMany(y => y.DaftarRaport);

        builder.HasData(
            new
            {
                Id = 1,
                Nama = "Sikap Spiritual",
                Deskripsi = "Anlidua Lua Hingmadi, baik dalam sikap berinisiatif berdoa sebelum-sesudah melakukan kegiatan, baik dalam sikap" +
                            " mengikuit jadwal kegiatan sekolah, baik dalam sikap menolong teman sebaya yang membutuhkan, baik dalam sikap disiplin" +
                            " dalam kelas, baik dalam bertanggung jawab menjaga lingkungan sekolah, baik dalam sikap menjaga hubungan dengan orang" +
                            " lain",
                KategoriNilai = KategoriNilaiRaport.Sikap,
                Predikat = "Baik",
                AnggotaRombelId = 1
            },
            new
            {
                Id = 2,
                Nama = "Sikap Sosial",
                Deskripsi = "Anlidua Lua Hingmadi, baik dalam sikap jujur, baik dalam sikap disiplin, baik dalam sikap tanggungjawab, baik dalam " +
                            "sikap toleransi, baik dalam sikap gotong royong, baik dalam sikap santun, selalu peduli, baik dalam sikap percaya diri, " +
                            "selalu memiliki rasa ingin tahu, baik dalam sikap ramah tamah",
                KategoriNilai = KategoriNilaiRaport.Sikap,
                Predikat = "Baik",
                AnggotaRombelId = 1
            },
            new
            {
                Id = 3,
                Nama = "Microsoft Word",
                Deskripsi = "Aktif dalam ekstrakulikuler Microsoft Word",
                KategoriNilai = KategoriNilaiRaport.Ekstrakulikuler,
                Predikat = "Memuaskan",
                AnggotaRombelId = 1
            }
        );
    }
}
