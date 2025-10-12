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
            },
            new
            {
                Id = 4,
                Nama = string.Empty,
                Deskripsi = "Kompetensi pengetahuan sangat baik, sangat menguasai peran dan fungsi pria dan wanita dalam rumah tangga, sangat " +
                            "menguasai peran dan fungsi pria dan wanita dalam rumah tangga, sangat menguasai prinsip dasar pernikahan dan rumah " +
                            "tangga Kristen",
                KategoriNilai = KategoriNilaiRaport.Pengetahuan,
                Predikat = "A",
                AnggotaRombelId = 1,
                JadwalMengajarId = 1
            },
            new
            {
                Id = 5,
                Nama = string.Empty,
                Deskripsi = "Kompetensi pengetahuan sangat baik, sangat menguasai perlindungan dan penegakan hukum di Indonesia, menguasai kasus-" +
                            "kasus pelanggaran hak dan pengikaran kewajiban warga negara",
                KategoriNilai = KategoriNilaiRaport.Pengetahuan,
                Predikat = "A",
                AnggotaRombelId = 1,
                JadwalMengajarId = 2
            },
            new
            {
                Id = 6,
                Nama = string.Empty,
                Deskripsi = "Kompetensi pengetahuan baik, sangat menguasai teks editorial, cukup menguasai teks lamaran pekerjaan",
                KategoriNilai = KategoriNilaiRaport.Pengetahuan,
                Predikat = "B",
                AnggotaRombelId = 1,
                JadwalMengajarId = 3
            },
            new
            {
                Id = 7,
                Nama = string.Empty,
                Deskripsi = "Kompetensi pengetahuan baik, sangat menguasai ukuran pemusatan dan penyebaran data yang disajikan dalam bentuk tabel " +
                            "distribusi frekuensi dan histogram, menguasai jarak dalam ruang",
                KategoriNilai = KategoriNilaiRaport.Pengetahuan,
                Predikat = "B",
                AnggotaRombelId = 1,
                JadwalMengajarId = 4
            },
            new
            {
                Id = 8,
                Nama = string.Empty,
                Deskripsi = "Kompetensi pengetahuan baik, sangat menguasai peran dan nilai-nilai perjuangan tokoh nasional dan daerah dalam " +
                            "mempertahankan keutuhan negara, menguasai upaya bangsa indonesia menghadapi ancaman disintegrasi negara",
                KategoriNilai = KategoriNilaiRaport.Pengetahuan,
                Predikat = "B",
                AnggotaRombelId = 1,
                JadwalMengajarId = 5
            },
            new
            {
                Id = 9,
                Nama = string.Empty,
                Deskripsi = "Kompetensi pengetahuan baik, sangat menguasai perbedaan fungsi sosial, struktur teks dan kebahasaan dalam teks " +
                            "news item lisan dan tulis dari radio, koran, dan TV, menguasai penerapan fungsi sosial, struktur teks, dan unsur " +
                            "kebahasan teks dalam tindakan menawarkan jasa",
                KategoriNilai = KategoriNilaiRaport.Pengetahuan,
                Predikat = "B",
                AnggotaRombelId = 1,
                JadwalMengajarId = 6
            },
            new
            {
                Id = 10,
                Nama = string.Empty,
                Deskripsi = "Kompetensi pengetahuan sangat baik, sangat menguasai teknik menyusun naskah teater kontemporer, sangat menguasai " +
                            "perencangan pemetasan teater kontemporer",
                KategoriNilai = KategoriNilaiRaport.Pengetahuan,
                Predikat = "A",
                AnggotaRombelId = 1,
                JadwalMengajarId = 7
            },
            new
            {
                Id = 11,
                Nama = string.Empty,
                Deskripsi = "Kompetensi pengetahuan baik, sangat menguasai sistem produksi kerajinan inovatif sesuai kebutuhan pasar global " +
                            "berdasarkan daya dukung yang dimiliki oleh daerah setempat, sangat menguasai perencanaan usaha kerajinan inovatif " +
                            "berdasarkan kebutuhan pasar global",
                KategoriNilai = KategoriNilaiRaport.Pengetahuan,
                Predikat = "A",
                AnggotaRombelId = 1,
                JadwalMengajarId = 8
            },
            new
            {
                Id = 12,
                Nama = string.Empty,
                Deskripsi = "Kompetensi pengetahuan baik, sangat menguasai atletik jalan cepat, lompat tinggi, lari jarak pendek, sangat menguasai " +
                            "permainan bulu tangkis, softball, tenis meja",
                KategoriNilai = KategoriNilaiRaport.Pengetahuan,
                Predikat = "B",
                AnggotaRombelId = 1,
                JadwalMengajarId = 9
            },
            new
            {
                Id = 13,
                Nama = string.Empty,
                Deskripsi = "Kompetensi pengetahuan sangat baik, sangat menguasai limit di ketakhinggaan fungsi aljabar dan trigonometri," +
                            "menguasai limit fungsi trigonometri",
                KategoriNilai = KategoriNilaiRaport.Pengetahuan,
                Predikat = "B",
                AnggotaRombelId = 1,
                JadwalMengajarId = 10
            },
            new
            {
                Id = 14,
                Nama = string.Empty,
                Deskripsi = "Kompetensi pengetahuan baik, sangat menguasai rangkaian arus bolak balik, cukup menguasai prinsip kerja peralatan " +
                            "listrik searah",
                KategoriNilai = KategoriNilaiRaport.Pengetahuan,
                Predikat = "A",
                AnggotaRombelId = 1,
                JadwalMengajarId = 11
            },
            new
            {
                Id = 15,
                Nama = string.Empty,
                Deskripsi = "Kompetensi pengetahuan sangat baik, sangat menguasai pola-pola hereditas, menguasai pengaruh faktor internal dan faktor " +
                            "eksternal terhadap pertumbuhan dan perkembangan",
                KategoriNilai = KategoriNilaiRaport.Pengetahuan,
                Predikat = "B",
                AnggotaRombelId = 1,
                JadwalMengajarId = 12
            },
            new
            {
                Id = 16,
                Nama = string.Empty,
                Deskripsi = "Kompetensi pengetahuan sangat baik, sangat menguasai analisis gejala yang terjadi sel elektrolisis yang digunakan dalam " +
                            "kehidupan, sangat menguasai penyebab adanya fenomena sifat koligatif larutan, dan tekanan osmosis",
                KategoriNilai = KategoriNilaiRaport.Pengetahuan,
                Predikat = "A",
                AnggotaRombelId = 1,
                JadwalMengajarId = 13
            },
            new
            {
                Id = 17,
                Nama = string.Empty,
                Deskripsi = "Kompetensi pengetahuan baik, sangat menguasai ukuran pemusatan dan penyebaran data yang disajikan dalam bentuk tabel " +
                            "distribusi frekuensi dan histogram, menguasai jarak dalam ruang",
                KategoriNilai = KategoriNilaiRaport.Pengetahuan,
                Predikat = "A",
                AnggotaRombelId = 1,
                JadwalMengajarId = 14
            },
            new
            {
                Id = 18,
                Nama = string.Empty,
                Deskripsi = "Kompetensi pengetahuan baik, sangat menguasai perbedaan fungsi sosial struktur teks news item lisan dan tulis dari " +
                            "radio, koran, dan TV, menguasai penerapan fungsi sosial, struktur teks dan unsur kebahasaan teks dalam tindakan " +
                            "menawarkan jasa",
                KategoriNilai = KategoriNilaiRaport.Pengetahuan,
                Predikat = "B",
                AnggotaRombelId = 1,
                JadwalMengajarId = 15
            },
            new
            {
                Id = 19,
                Nama = string.Empty,
                Deskripsi = "Kompetensi pengetahuan sangat baik, sangat menguasai peran dan fungsi pria dan wanita dalam rumah tangga, sangat " +
                            "menguasai peran dan fungsi pria dan wanita dalam rumah tangga, sangat menguasai prinsip dasar pernikahan dan rumah " +
                            "tangga Kristen",
                KategoriNilai = KategoriNilaiRaport.Keterampilan,
                Predikat = "A",
                AnggotaRombelId = 1,
                JadwalMengajarId = 1
            },
            new
            {
                Id = 20,
                Nama = string.Empty,
                Deskripsi = "Kompetensi pengetahuan sangat baik, sangat menguasai perlindungan dan penegakan hukum di Indonesia, menguasai kasus-" +
                            "kasus pelanggaran hak dan pengikaran kewajiban warga negara",
                KategoriNilai = KategoriNilaiRaport.Keterampilan,
                Predikat = "A",
                AnggotaRombelId = 1,
                JadwalMengajarId = 2
            },
            new
            {
                Id = 21,
                Nama = string.Empty,
                Deskripsi = "Kompetensi pengetahuan baik, sangat menguasai teks editorial, cukup menguasai teks lamaran pekerjaan",
                KategoriNilai = KategoriNilaiRaport.Keterampilan,
                Predikat = "B",
                AnggotaRombelId = 1,
                JadwalMengajarId = 3
            },
            new
            {
                Id = 22,
                Nama = string.Empty,
                Deskripsi = "Kompetensi pengetahuan baik, sangat menguasai ukuran pemusatan dan penyebaran data yang disajikan dalam bentuk tabel " +
                            "distribusi frekuensi dan histogram, menguasai jarak dalam ruang",
                KategoriNilai = KategoriNilaiRaport.Keterampilan,
                Predikat = "B",
                AnggotaRombelId = 1,
                JadwalMengajarId = 4
            },
            new
            {
                Id = 23,
                Nama = string.Empty,
                Deskripsi = "Kompetensi pengetahuan baik, sangat menguasai peran dan nilai-nilai perjuangan tokoh nasional dan daerah dalam " +
                            "mempertahankan keutuhan negara, menguasai upaya bangsa indonesia menghadapi ancaman disintegrasi negara",
                KategoriNilai = KategoriNilaiRaport.Keterampilan,
                Predikat = "B",
                AnggotaRombelId = 1,
                JadwalMengajarId = 5
            },
            new
            {
                Id = 24,
                Nama = string.Empty,
                Deskripsi = "Kompetensi pengetahuan baik, sangat menguasai perbedaan fungsi sosial, struktur teks dan kebahasaan dalam teks " +
                            "news item lisan dan tulis dari radio, koran, dan TV, menguasai penerapan fungsi sosial, struktur teks, dan unsur " +
                            "kebahasan teks dalam tindakan menawarkan jasa",
                KategoriNilai = KategoriNilaiRaport.Keterampilan,
                Predikat = "B",
                AnggotaRombelId = 1,
                JadwalMengajarId = 6
            },
            new
            {
                Id = 25,
                Nama = string.Empty,
                Deskripsi = "Kompetensi pengetahuan sangat baik, sangat menguasai teknik menyusun naskah teater kontemporer, sangat menguasai " +
                            "perencangan pemetasan teater kontemporer",
                KategoriNilai = KategoriNilaiRaport.Keterampilan,
                Predikat = "A",
                AnggotaRombelId = 1,
                JadwalMengajarId = 7
            },
            new
            {
                Id = 26,
                Nama = string.Empty,
                Deskripsi = "Kompetensi pengetahuan baik, sangat menguasai sistem produksi kerajinan inovatif sesuai kebutuhan pasar global " +
                            "berdasarkan daya dukung yang dimiliki oleh daerah setempat, sangat menguasai perencanaan usaha kerajinan inovatif " +
                            "berdasarkan kebutuhan pasar global",
                KategoriNilai = KategoriNilaiRaport.Keterampilan,
                Predikat = "A",
                AnggotaRombelId = 1,
                JadwalMengajarId = 8
            },
            new
            {
                Id = 27,
                Nama = string.Empty,
                Deskripsi = "Kompetensi pengetahuan baik, sangat menguasai atletik jalan cepat, lompat tinggi, lari jarak pendek, sangat menguasai " +
                            "permainan bulu tangkis, softball, tenis meja",
                KategoriNilai = KategoriNilaiRaport.Keterampilan,
                Predikat = "B",
                AnggotaRombelId = 1,
                JadwalMengajarId = 9
            },
            new
            {
                Id = 28,
                Nama = string.Empty,
                Deskripsi = "Kompetensi pengetahuan sangat baik, sangat menguasai limit di ketakhinggaan fungsi aljabar dan trigonometri," +
                            "menguasai limit fungsi trigonometri",
                KategoriNilai = KategoriNilaiRaport.Keterampilan,
                Predikat = "B",
                AnggotaRombelId = 1,
                JadwalMengajarId = 10
            },
            new
            {
                Id = 29,
                Nama = string.Empty,
                Deskripsi = "Kompetensi pengetahuan baik, sangat menguasai rangkaian arus bolak balik, cukup menguasai prinsip kerja peralatan " +
                            "listrik searah",
                KategoriNilai = KategoriNilaiRaport.Keterampilan,
                Predikat = "A",
                AnggotaRombelId = 1,
                JadwalMengajarId = 11
            },
            new
            {
                Id = 30,
                Nama = string.Empty,
                Deskripsi = "Kompetensi pengetahuan sangat baik, sangat menguasai pola-pola hereditas, menguasai pengaruh faktor internal dan faktor " +
                            "eksternal terhadap pertumbuhan dan perkembangan",
                KategoriNilai = KategoriNilaiRaport.Keterampilan,
                Predikat = "B",
                AnggotaRombelId = 1,
                JadwalMengajarId = 12
            },
            new
            {
                Id = 31,
                Nama = string.Empty,
                Deskripsi = "Kompetensi pengetahuan sangat baik, sangat menguasai analisis gejala yang terjadi sel elektrolisis yang digunakan dalam " +
                            "kehidupan, sangat menguasai penyebab adanya fenomena sifat koligatif larutan, dan tekanan osmosis",
                KategoriNilai = KategoriNilaiRaport.Keterampilan,
                Predikat = "A",
                AnggotaRombelId = 1,
                JadwalMengajarId = 13
            },
            new
            {
                Id = 32,
                Nama = string.Empty,
                Deskripsi = "Kompetensi pengetahuan baik, sangat menguasai ukuran pemusatan dan penyebaran data yang disajikan dalam bentuk tabel " +
                            "distribusi frekuensi dan histogram, menguasai jarak dalam ruang",
                KategoriNilai = KategoriNilaiRaport.Keterampilan,
                Predikat = "A",
                AnggotaRombelId = 1,
                JadwalMengajarId = 14
            },
            new
            {
                Id = 33,
                Nama = string.Empty,
                Deskripsi = "Kompetensi pengetahuan baik, sangat menguasai perbedaan fungsi sosial struktur teks news item lisan dan tulis dari " +
                            "radio, koran, dan TV, menguasai penerapan fungsi sosial, struktur teks dan unsur kebahasaan teks dalam tindakan " +
                            "menawarkan jasa",
                KategoriNilai = KategoriNilaiRaport.Keterampilan,
                Predikat = "B",
                AnggotaRombelId = 1,
                JadwalMengajarId = 15
            }
        );
    }
}
