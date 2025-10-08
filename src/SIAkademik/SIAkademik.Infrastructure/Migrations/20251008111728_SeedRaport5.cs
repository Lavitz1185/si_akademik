using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedRaport5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TblRaport",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "TblRaport",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "TblRaport",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "TblRaport",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "TblRaport",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "TblRaport",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "TblRaport",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "TblRaport",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "TblRaport",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "TblRaport",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "TblRaport",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "TblRaport",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "TblRaport",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "TblRaport",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.UpdateData(
                table: "TblRaport",
                keyColumn: "Id",
                keyValue: 10,
                column: "Deskripsi",
                value: "Kompetensi pengetahuan baik, sangat menguasai atletik jalan cepat, lompat tinggi, lari jarak pendek, sangat menguasai permainan bulu tangkis, softball, tenis meja");

            migrationBuilder.UpdateData(
                table: "TblRaport",
                keyColumn: "Id",
                keyValue: 11,
                column: "Deskripsi",
                value: "Kompetensi pengetahuan baik, sangat menguasai sistem produksi kerajinan inovatif sesuai kebutuhan pasar global berdasarkan daya dukung yang dimiliki oleh daerah setempat, sangat menguasai perencanaan usaha kerajinan inovatif berdasarkan kebutuhan pasar global");

            migrationBuilder.UpdateData(
                table: "TblRaport",
                keyColumn: "Id",
                keyValue: 12,
                column: "Deskripsi",
                value: "Kompetensi pengetahuan sangat baik, sangat menguasai limit di ketakhinggaan fungsi aljabar dan trigonometri,menguasai limit fungsi trigonometri");

            migrationBuilder.UpdateData(
                table: "TblRaport",
                keyColumn: "Id",
                keyValue: 13,
                column: "Deskripsi",
                value: "Kompetensi pengetahuan baik, sangat menguasai rangkaian arus bolak balik, cukup menguasai prinsip kerja peralatan listrik searah");

            migrationBuilder.UpdateData(
                table: "TblRaport",
                keyColumn: "Id",
                keyValue: 14,
                column: "Deskripsi",
                value: "Kompetensi pengetahuan sangat baik, sangat menguasai pola-pola hereditas, menguasai pengaruh faktor internal dan faktor eksternal terhadap pertumbuhan dan perkembangan");

            migrationBuilder.UpdateData(
                table: "TblRaport",
                keyColumn: "Id",
                keyValue: 15,
                column: "Deskripsi",
                value: "Kompetensi pengetahuan sangat baik, sangat menguasai analisis gejala yang terjadi sel elektrolisis yang digunakan dalam kehidupan, sangat menguasai penyebab adanya fenomena sifat koligatif larutan, dan tekanan osmosis");

            migrationBuilder.UpdateData(
                table: "TblRaport",
                keyColumn: "Id",
                keyValue: 16,
                column: "Deskripsi",
                value: "Kompetensi pengetahuan baik, sangat menguasai ukuran pemusatan dan penyebaran data yang disajikan dalam bentuk tabel distribusi frekuensi dan histogram, menguasai jarak dalam ruang");

            migrationBuilder.UpdateData(
                table: "TblRaport",
                keyColumn: "Id",
                keyValue: 17,
                column: "Deskripsi",
                value: "Kompetensi pengetahuan baik, sangat menguasai perbedaan fungsi sosial struktur teks news item lisan dan tulis dari radio, koran, dan TV, menguasai penerapan fungsi sosial, struktur teks dan unsur kebahasaan teks dalam tindakan menawarkan jasa");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TblRaport",
                keyColumn: "Id",
                keyValue: 10,
                column: "Deskripsi",
                value: "Kompetensi pengetahuan sangat baik, sangat menguasai teknik menyusun naskah teater kontemporer, sangat menguasai perancangan pementasan teater kontemporer");

            migrationBuilder.UpdateData(
                table: "TblRaport",
                keyColumn: "Id",
                keyValue: 11,
                column: "Deskripsi",
                value: "Kompetensi pengetahuan baik, sangat menguasai atletik jalan cepat, lompat tinggi, lari jarak pendek, sangat menguasai permainan bulu tangkis, softball, tenis meja");

            migrationBuilder.UpdateData(
                table: "TblRaport",
                keyColumn: "Id",
                keyValue: 12,
                column: "Deskripsi",
                value: "Kompetensi pengetahuan baik, sangat menguasai sistem produksi kerajinan inovatif sesuai kebutuhan pasar global berdasarkan daya dukung yang dimiliki oleh daerah setempat, sangat menguasai perencanaan usaha kerajinan inovatif berdasarkan kebutuhan pasar global");

            migrationBuilder.UpdateData(
                table: "TblRaport",
                keyColumn: "Id",
                keyValue: 13,
                column: "Deskripsi",
                value: "Kompetensi pengetahuan sangat baik, sangat menguasai limit di ketakhinggaan fungsi aljabar dan trigonometri,menguasai limit fungsi trigonometri");

            migrationBuilder.UpdateData(
                table: "TblRaport",
                keyColumn: "Id",
                keyValue: 14,
                column: "Deskripsi",
                value: "Kompetensi pengetahuan baik, sangat menguasai rangkaian arus bolak balik, cukup menguasai prinsip kerja peralatan listrik searah");

            migrationBuilder.UpdateData(
                table: "TblRaport",
                keyColumn: "Id",
                keyValue: 15,
                column: "Deskripsi",
                value: "Kompetensi pengetahuan sangat baik, sangat menguasai pola-pola hereditas, menguasai pengaruh faktor internal dan faktor eksternal terhadap pertumbuhan dan perkembangan");

            migrationBuilder.UpdateData(
                table: "TblRaport",
                keyColumn: "Id",
                keyValue: 16,
                column: "Deskripsi",
                value: "Kompetensi pengetahuan sangat baik, sangat menguasai analisis gejala yang terjadi sel elektrolisis yang digunakan dalam kehidupan, sangat menguasai penyebab adanya fenomena sifat koligatif larutan, dan tekanan osmosis");

            migrationBuilder.UpdateData(
                table: "TblRaport",
                keyColumn: "Id",
                keyValue: 17,
                column: "Deskripsi",
                value: "Kompetensi pengetahuan baik, sangat menguasai ukuran pemusatan dan penyebaran data yang disajikan dalam bentuk tabel distribusi frekuensi dan histogram, menguasai jarak dalam ruang");

            migrationBuilder.InsertData(
                table: "TblRaport",
                columns: new[] { "Id", "AnggotaRombelId", "Deskripsi", "JadwalMengajarId", "KategoriNilai", "Nama", "Predikat" },
                values: new object[,]
                {
                    { 18, 1, "Kompetensi pengetahuan sangat baik, sangat menguasai peran dan fungsi pria dan wanita dalam rumah tangga, sangat menguasai peran dan fungsi pria dan wanita dalam rumah tangga, sangat menguasai prinsip dasar pernikahan dan rumah tangga Kristen", 3, 2, "", "A" },
                    { 19, 1, "Kompetensi pengetahuan sangat baik, sangat menguasai perlindungan dan penegakan hukum di Indonesia, menguasai kasus-kasus pelanggaran hak dan pengikaran kewajiban warga negara", 4, 2, "", "A" },
                    { 20, 1, "Kompetensi pengetahuan baik, sangat menguasai teks editorial, cukup menguasai teks lamaran pekerjaan", 5, 2, "", "B" },
                    { 21, 1, "Kompetensi pengetahuan baik, sangat menguasai ukuran pemusatan dan penyebaran data yang disajikan dalam bentuk tabel distribusi frekuensi dan histogram, menguasai jarak dalam ruang", 6, 2, "", "B" },
                    { 22, 1, "Kompetensi pengetahuan baik, sangat menguasai peran dan nilai-nilai perjuangan tokoh nasional dan daerah dalam mempertahankan keutuhan negara, menguasai upaya bangsa indonesia menghadapi ancaman disintegrasi negara", 7, 2, "", "B" },
                    { 23, 1, "Kompetensi pengetahuan baik, sangat menguasai perbedaan fungsi sosial, struktur teks dan kebahasaan dalam teks news item lisan dan tulis dari radio, koran, dan TV, menguasai penerapan fungsi sosial, struktur teks, dan unsur kebahasan teks dalam tindakan menawarkan jasa", 8, 2, "", "B" },
                    { 24, 1, "Kompetensi pengetahuan sangat baik, sangat menguasai teknik menyusun naskah teater kontemporer, sangat menguasai perancangan pementasan teater kontemporer", 9, 2, "", "A" },
                    { 25, 1, "Kompetensi pengetahuan baik, sangat menguasai atletik jalan cepat, lompat tinggi, lari jarak pendek, sangat menguasai permainan bulu tangkis, softball, tenis meja", 10, 2, "", "B" },
                    { 26, 1, "Kompetensi pengetahuan baik, sangat menguasai sistem produksi kerajinan inovatif sesuai kebutuhan pasar global berdasarkan daya dukung yang dimiliki oleh daerah setempat, sangat menguasai perencanaan usaha kerajinan inovatif berdasarkan kebutuhan pasar global", 11, 2, "", "B" },
                    { 27, 1, "Kompetensi pengetahuan sangat baik, sangat menguasai limit di ketakhinggaan fungsi aljabar dan trigonometri,menguasai limit fungsi trigonometri", 12, 2, "", "A" },
                    { 28, 1, "Kompetensi pengetahuan baik, sangat menguasai rangkaian arus bolak balik, cukup menguasai prinsip kerja peralatan listrik searah", 13, 2, "", "B" },
                    { 29, 1, "Kompetensi pengetahuan sangat baik, sangat menguasai pola-pola hereditas, menguasai pengaruh faktor internal dan faktor eksternal terhadap pertumbuhan dan perkembangan", 14, 2, "", "A" },
                    { 30, 1, "Kompetensi pengetahuan sangat baik, sangat menguasai analisis gejala yang terjadi sel elektrolisis yang digunakan dalam kehidupan, sangat menguasai penyebab adanya fenomena sifat koligatif larutan, dan tekanan osmosis", 15, 2, "", "A" },
                    { 31, 1, "Kompetensi pengetahuan baik, sangat menguasai ukuran pemusatan dan penyebaran data yang disajikan dalam bentuk tabel distribusi frekuensi dan histogram, menguasai jarak dalam ruang", 16, 2, "", "B" }
                });
        }
    }
}
