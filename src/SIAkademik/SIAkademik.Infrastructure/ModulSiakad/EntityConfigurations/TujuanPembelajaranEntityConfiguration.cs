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
                Fase = Fase.E,
                Nomor = 1,
            },
            new
            {
                Id = 2,
                Deskripsi = "Menghayati makna perilaku dewasa dan tidak dewasa dilingkungan keluarga dan masyarakat",
                MataPelajaranId = 3,
                Fase = Fase.E,
                Nomor = 2,
            },
            new
            {
                Id = 3,
                Deskripsi = "Meyakini pesan Alkitab dalam Lukas 2:42-52, I Korintus 14: 20 dan Kolose 1:10,serta memiliki tekad untuk bertumbuh " +
                            "semakin dewasa.",
                MataPelajaranId = 3,
                Fase = Fase.E,
                Nomor = 3,
            },
            new
            {
                Id = 4,
                Deskripsi = "Menghayati teks Alkitab tentang pemeliharaan Allah dalam kehidupan",
                MataPelajaranId = 3,
                Fase = Fase.E,
                Nomor = 4,
            },
            new
            {
                Id = 5,
                Deskripsi = "Memahami cara Allah memelihara ciptaan-Nya diberbagai dinamika kehidupan",
                MataPelajaranId = 3,
                Fase = Fase.E,
                Nomor = 5,
            },
            new
            {
                Id = 6,
                Deskripsi = "Meyakini kemahakuasaan Allah dalam memelihara kehidupan melalui puisi, cerita pendek atau narasi",
                MataPelajaranId = 3,
                Fase = Fase.E,
                Nomor = 6,
            },
            new
            {
                Id = 7,
                Deskripsi = "Merancang sebuah kegiatan sebagi bentuk rasa syukur atas pemeliharaan Allah dalam suka maupun duka.",
                MataPelajaranId = 3,
                Fase = Fase.E,
                Nomor = 7,
            },
            new
            {
                Id = 8,
                Deskripsi = "Memahami peran dan tanggungjawab orangtua sebagai pendidik utama dalam keluarga",
                MataPelajaranId = 3,
                Fase = Fase.E,
                Nomor = 8,
            },
            new
            {
                Id = 9,
                Deskripsi = "Menghayati nilai-nilai iman Kristen sebagai dasar hidup keluarga",
                MataPelajaranId = 3,
                Fase = Fase.E,
                Nomor = 9,
            },
            new
            {
                Id = 10,
                Deskripsi = "Mensyukuri kehadiaran orangtua sebagai pendidik utama",
                MataPelajaranId = 3,
                Fase = Fase.E,
                Nomor = 10,
            },
            new
            {
                Id = 11,
                Deskripsi = "Memahami makna hidup baru.",
                MataPelajaranId = 3,
                Fase = Fase.E,
                Nomor = 11,
            },
            new
            {
                Id = 12,
                Deskripsi = "Meyakini proses perubahan hidup seseorang menjadi pribadi yang lebih baik.",
                MataPelajaranId = 3,
                Fase = Fase.E,
                Nomor = 12,
            },
            new
            {
                Id = 13,
                Deskripsi = "Menghayati pemeliharaan Allah dalam kehidupan Nuh.",
                MataPelajaranId = 3,
                Fase = Fase.E,
                Nomor = 13,
            },
            new
            {
                Id = 14,
                Deskripsi = "Meyakini isi Alkitab Yeremia 1: 4-10 mengenai Allah membaharui hidup manusia.",
                MataPelajaranId = 3,
                Fase = Fase.E,
                Nomor = 14,
            },
            new
            {
                Id = 15,
                Deskripsi = "Membuat komitmen kepada Allah untuk hidup kudus atas pembaharuan hidup yang dialaminya.",
                MataPelajaranId = 3,
                Fase = Fase.E,
                Nomor = 15,
            },
            new
            {
                Id = 16,
                Deskripsi = "Memahami ciri-ciri manusia dewasa dalam pergaulan menurut Alkitab/beberapa teks Alkitab.",
                MataPelajaranId = 3,
                Fase = Fase.E,
                Nomor = 16,
            },
            new
            {
                Id = 17,
                Deskripsi = "Meyakini pandangan Alkitab terhadap interaksi manusia dewasa dengan sesamanya",
                MataPelajaranId = 3,
                Fase = Fase.E,
                Nomor = 17,
            },
            new
            {
                Id = 18,
                Deskripsi = "Menghayati manfaat pertemanan, persahabatan, dan pacaran sebagai manusia dewasa.",
                MataPelajaranId = 3,
                Fase = Fase.E,
                Nomor = 18,
            },
            new
            {
                Id = 19,
                Deskripsi = "Membuat karya kreatif berdasarkan pengajaran iman Kristen terkait pertemanan, persahabatan dan pacaran.",
                MataPelajaranId = 3,
                Fase = Fase.E,
                Nomor = 19,
            },
            new
            {
                Id = 20,
                Deskripsi = "Menghayati sikap kesetian, kasih dan keadilan sebagai dasar nilai-nilai Kristen dalam kehidupan keluarga dan" +
                            " masyarakat.",
                MataPelajaranId = 3,
                Fase = Fase.E,
                Nomor = 20,
            },
            new
            {
                Id = 21,
                Deskripsi = "Memahami berbagai perilaku yang menyimpang dari nilai kesetian, kasih dan keadilan. dalam keluarga dan" +
                            " masyarakat.",
                MataPelajaranId = 3,
                Fase = Fase.E,
                Nomor = 21,
            },
            new
            {
                Id = 22,
                Deskripsi = "Merancang sebuah kegiatan sebagai wujud kesetian, kasih dan keadilan dalam hidup sehari-hari dalam keluarga " +
                            "dan lingkungan masyarakat.",
                MataPelajaranId = 3,
                Fase = Fase.E,
                Nomor = 22,
            },
            new
            {
                Id = 23,
                Deskripsi = "Membuat karya kreatif sebagai bentuk kesetian, kasih dan keadilan dalam hidup sehari-hari dalam keluarga dan" +
                            " lingkungan masyarakat",
                MataPelajaranId = 3,
                Fase = Fase.E,
                Nomor = 23,
            },
            new
            {
                Id = 24,
                Deskripsi = "Memahami makna diskriminasi dan menganalisis bukti - bukti perlakuan diskriminatif terhadap perbedaan " +
                            "ras/etnis, gender dan budaya dalam lingkup lokal, nasional dan internasional.",
                MataPelajaranId = 3,
                Fase = Fase.E,
                Nomor = 24,
            },
            new
            {
                Id = 25,
                Deskripsi = "Meyakini teks Alkitab yang berhubungan dengan kepekaan dan belarasa terhadap manusia.",
                MataPelajaranId = 3,
                Fase = Fase.E,
                Nomor = 25,
            },
            new
            {
                Id = 26,
                Deskripsi = "Membuat karya kreatif tentang kepekaan dan belarasa dalam kehidupan sehari-hari",
                MataPelajaranId = 3,
                Fase = Fase.E,
                Nomor = 26,
            },
            new
            {
                Id = 27,
                Deskripsi = "Memahami sekolah dan keluarga sebagai lembagai Pendidikan.",
                MataPelajaranId = 3,
                Fase = Fase.E,
                Nomor = 27,
            },
            new
            {
                Id = 28,
                Deskripsi = "Memahami peran sekolah dalam membantu orang tua mendidik anak anak.",
                MataPelajaranId = 3,
                Fase = Fase.E,
                Nomor = 28,
            },
            new
            {
                Id = 29,
                Deskripsi = "Menghayati peran sekolah dan keluarga dalam mendidik serta melatih siswa hidup dalam kemajemukan",
                MataPelajaranId = 3,
                Fase = Fase.E,
                Nomor = 29,
            },
            new
            {
                Id = 30,
                Deskripsi = "Memahami berbagai bentuk kerusakan alam yang disebabkan oleh manusia serta cara untuk mencegah dan mengatasi.",
                MataPelajaranId = 3,
                Fase = Fase.E,
                Nomor = 30,
            },
            new
            {
                Id = 31,
                Deskripsi = "Menghayati peran berbagai pihak dalam menjaga dan melestarikan alam ciptaan Tuhan serta membuat karya kreatif yang" +
                            " berkaitan dengan upaya pencegahan kerusakan alam.",
                MataPelajaranId = 3,
                Fase = Fase.E,
                Nomor = 31,
            },
            new
            {
                Id = 32,
                Deskripsi = "Menyakini teks alkitab yang berkaitan dengan memelihara dan melestarikan alam ciptaan Tuhan",
                MataPelajaranId = 3,
                Fase = Fase.E,
                Nomor = 32,
            },
            new
            {
                Id = 33,
                Deskripsi = "Membuat karya nyata yang berkaitan dengan tanggung jawabnya memelihara alam ciptaan Allah",
                MataPelajaranId = 3,
                Fase = Fase.E,
                Nomor = 33,
            }
        );
    }
}
