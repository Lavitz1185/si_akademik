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
        builder.HasMany(a => a.DaftarJadwalMengajar).WithMany(j => j.DaftarTujuanPembelajaran)
            .UsingEntity<AsesmenSumatif>(
                l => l.HasOne(x => x.JadwalMengajar).WithMany(x => x.DaftarAsesmenSumatif).HasForeignKey(a => a.IdJadwalMengajar),
                r => r.HasOne(x => x.TujuanPembelajaran).WithMany(x => x.DaftarAsesmenSumatif).HasForeignKey(a => a.IdTujuanPembelajaran)
            );

        builder.HasData(
            new
            {
                Id = 1,
                Deskripsi = "Memahami arti dewasa secara fisik, intelektual, emosional, sosial, moral dan spiritual",
                MataPelajaranId = 1,
                Fase = Fase.E,
                Nomor = 1,
            },
            new
            {
                Id = 2,
                Deskripsi = "Memahami secara kritis perkembangan kebudayaan, ilmu pengetahuan dan tehnologi sebagai anugerah Allah.",
                MataPelajaranId = 1,
                Fase = Fase.F,
                Nomor = 1,
            },
            new
            {
                Id = 3,
                Deskripsi = "Menganalisis cara pandang para pendiri negara tentang dasar negara",
                MataPelajaranId = 2,
                Fase = Fase.E,
                Nomor = 1,
            },
            new
            {
                Id = 4,
                Deskripsi = "Mendeskripsikan rumusan dan keterkaitan sila-sila dalam Pancasila",
                MataPelajaranId = 2,
                Fase = Fase.F,
                Nomor = 1,
            },
            new
            {
                Id = 5,
                Deskripsi = "Memahami dan menganalisis gagasan teks, makna kata, dan informasi faktual yang dibaca untuk dapat dievaluasi " +
                            "keakuratan informasinya. (menyimak dan membaca)",
                MataPelajaranId = 3,
                Fase = Fase.E,
                Nomor = 1,
            },
            new
            {
                Id = 6,
                Deskripsi = "Mengidentifikasi ide pokok dan pendukung teks yang dibaca serta menulis opini untuk berbagai tujuan secara logis, " +
                            "kritis, dan kreatif.",
                MataPelajaranId = 3,
                Fase = Fase.F,
                Nomor = 1,
            },
            new
            {
                Id = 7,
                Deskripsi = "Menggeneralisasi sifat-sifat bilangan berpangkat",
                MataPelajaranId = 4,
                Fase = Fase.E,
                Nomor = 1,
            },
            new
            {
                Id = 8,
                Deskripsi = "Memodelkan pinjaman dan investasi dengan bunga majemuk dan anuitas.",
                MataPelajaranId = 4,
                Fase = Fase.F,
                Nomor = 1,
            },
            new
            {
                Id = 9,
                Deskripsi = "Memahami konsep-konsep dasar ilmu sejarah yaitu: manusia, ruang, waktu, diakronik (kronologi), sinkronik, dan " +
                            "penelitian sejarah",
                MataPelajaranId = 5,
                Fase = Fase.E,
                Nomor = 1,
            },
            new
            {
                Id = 10,
                Deskripsi = "Memahami berbagai peristiwa sejarah pada masa penjajahan bangsa barat.",
                MataPelajaranId = 5,
                Fase = Fase.F,
                Nomor = 1,
            },
            new
            {
                Id = 11,
                Deskripsi = "Menggunakan bahasa Inggris untuk memproduksi teks deskripsi lisan, tulisan, dan visual.",
                MataPelajaranId = 6,
                Fase = Fase.E,
                Nomor = 1,
            },
            new
            {
                Id = 12,
                Deskripsi = "Menganalisis ekspresi di berbagai konteks dalam bentuk percakapan transaksional lisan.",
                MataPelajaranId = 6,
                Fase = Fase.F,
                Nomor = 1,
            },
            new
            {
                Id = 13,
                Deskripsi = "Menggunakan dan mengembangkan unsur-unsur bunyi musik berupa nada, irama, melodi, harmoni, timbre," +
                            " tempo, dan dinamika menggunakan instrumen atau teknologi yang tersedia",
                MataPelajaranId = 7,
                Fase = Fase.E,
                Nomor = 1,
            },
            new
            {
                Id = 14,
                Deskripsi = "Memahami bunyi musik dan elemen musik dengan melibatkan diri secara aktif.",
                MataPelajaranId = 7,
                Fase = Fase.F,
                Nomor = 1,
            },
            new
            {
                Id = 15,
                Deskripsi = "Menemutunjukkan bahan, alat, teknik, prosedur, dan sistem budidaya produk bernilai ekonomis dari berbagai " +
                            "sumber",
                MataPelajaranId = 8,
                Fase = Fase.E,
                Nomor = 1,
            },
            new
            {
                Id = 16,
                Deskripsi = "Menganalisis potensi internal dan eksternal produk budi daya.",
                MataPelajaranId = 8,
                Fase = Fase.F,
                Nomor = 1,
            },
            new
            {
                Id = 17,
                Deskripsi = "Merancang, menerapkan, dan menghaluskan keterampilan gerak dalam situasi gerak yang menantang.",
                MataPelajaranId = 9,
                Fase = Fase.E,
                Nomor = 1,
            },
            new
            {
                Id = 18,
                Deskripsi = "Merancang, menerapkan, menghaluskan dan mengevaluasi keterampilan gerak spesifik di dalam berbagai situasi gerak" +
                            " yang menantang untuk meningkatkan kinerja gerak.",
                MataPelajaranId = 9,
                Fase = Fase.F,
                Nomor = 1,
            },
            new
            {
                Id = 19,
                Deskripsi = "Melakukan operasi aritmetika pada polinomial (suku banyak), menentukan faktor polinomial, dan menggunakan identitas " +
                            "polinomial untuk menyelesaikan masalah",
                MataPelajaranId = 10,
                Fase = Fase.F,
                Nomor = 1,
            },
            new
            {
                Id = 20,
                Deskripsi = "Mendeskripsikan gejala alam dalam cakupan keterampilan proses dalam pengukuran",
                MataPelajaranId = 11,
                Fase = Fase.E,
                Nomor = 1,
            },
            new
            {
                Id = 21,
                Deskripsi = "Menganalisis konsep gerak menggunakan vektor untuk menjelaskan berbagai fenomena.",
                MataPelajaranId = 11,
                Fase = Fase.F,
                Nomor = 1,
            },
            new
            {
                Id = 22,
                Deskripsi = "Mengidentifikasi jenis-jenis interaksi pada ekosistem dan aliran  energi dalam ekositemual",
                MataPelajaranId = 12,
                Fase = Fase.E,
                Nomor = 1,
            },
            new
            {
                Id = 23,
                Deskripsi = "Memahami struktur sel dan organel sel beserta fungsinya sebagai unit fungsional terintegrasi",
                MataPelajaranId = 12,
                Fase = Fase.F,
                Nomor = 1,
            },
            new
            {
                Id = 24,
                Deskripsi = "Menerapkan  konsep kimia dalam pengelolaan lingkungan termasuk menjelaskan  fenomena pemanasan global",
                MataPelajaranId = 13,
                Fase = Fase.E,
                Nomor = 1,
            },
            new
            {
                Id = 25,
                Deskripsi = "Menganalisis proses terjadinya ikatan kimia dari unsur-unsur pembentuknya dan implikasinya terhadap " +
                            "sifat-sifat fisik senyawa yang dihasilkan.",
                MataPelajaranId = 13,
                Fase = Fase.F,
                Nomor = 1,
            },
            new
            {
                Id = 26,
                Deskripsi = "Menguasai ukuran pemusatan dan penyebaran data yang disajikan dalam bentuk tabel distribusi frekuensi dan histogram",
                MataPelajaranId = 14,
                Fase = Fase.F,
                Nomor = 1,
            },
            new
            {
                Id = 27,
                Deskripsi = "Menguasai perbedaan fungsi sosial struktur teks news item lisan dan tulis dari radio, koran, dan TV",
                MataPelajaranId = 15,
                Fase = Fase.F,
                Nomor = 1,
            }
        );
    }
}
