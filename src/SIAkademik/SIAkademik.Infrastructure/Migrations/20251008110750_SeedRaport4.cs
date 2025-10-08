using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedRaport4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TblMataPelajaran",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "TblMataPelajaran",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "TblMataPelajaran",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "TblMataPelajaran",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "TblMataPelajaran",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "TblMataPelajaran",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "TblMataPelajaran",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "TblMataPelajaran",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DropColumn(
                name: "Jenjang",
                table: "TblMataPelajaran");

            migrationBuilder.UpdateData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 17,
                column: "MataPelajaranId",
                value: 14);

            migrationBuilder.UpdateData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 19,
                column: "MataPelajaranId",
                value: 13);

            migrationBuilder.UpdateData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 24,
                column: "MataPelajaranId",
                value: 8);

            migrationBuilder.UpdateData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 26,
                column: "MataPelajaranId",
                value: 12);

            migrationBuilder.UpdateData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 27,
                column: "MataPelajaranId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 28,
                column: "MataPelajaranId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 29,
                column: "MataPelajaranId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 30,
                column: "MataPelajaranId",
                value: 9);

            migrationBuilder.InsertData(
                table: "TblRaport",
                columns: new[] { "Id", "AnggotaRombelId", "Deskripsi", "JadwalMengajarId", "KategoriNilai", "Nama", "Predikat" },
                values: new object[,]
                {
                    { 6, 1, "Kompetensi pengetahuan baik, sangat menguasai teks editorial, cukup menguasai teks lamaran pekerjaan", 5, 1, "", "B" },
                    { 7, 1, "Kompetensi pengetahuan baik, sangat menguasai ukuran pemusatan dan penyebaran data yang disajikan dalam bentuk tabel distribusi frekuensi dan histogram, menguasai jarak dalam ruang", 6, 1, "", "B" },
                    { 8, 1, "Kompetensi pengetahuan baik, sangat menguasai peran dan nilai-nilai perjuangan tokoh nasional dan daerah dalam mempertahankan keutuhan negara, menguasai upaya bangsa indonesia menghadapi ancaman disintegrasi negara", 7, 1, "", "B" },
                    { 9, 1, "Kompetensi pengetahuan baik, sangat menguasai perbedaan fungsi sosial, struktur teks dan kebahasaan dalam teks news item lisan dan tulis dari radio, koran, dan TV, menguasai penerapan fungsi sosial, struktur teks, dan unsur kebahasan teks dalam tindakan menawarkan jasa", 8, 1, "", "B" },
                    { 10, 1, "Kompetensi pengetahuan sangat baik, sangat menguasai teknik menyusun naskah teater kontemporer, sangat menguasai perancangan pementasan teater kontemporer", 9, 1, "", "A" },
                    { 11, 1, "Kompetensi pengetahuan baik, sangat menguasai atletik jalan cepat, lompat tinggi, lari jarak pendek, sangat menguasai permainan bulu tangkis, softball, tenis meja", 10, 1, "", "B" },
                    { 12, 1, "Kompetensi pengetahuan baik, sangat menguasai sistem produksi kerajinan inovatif sesuai kebutuhan pasar global berdasarkan daya dukung yang dimiliki oleh daerah setempat, sangat menguasai perencanaan usaha kerajinan inovatif berdasarkan kebutuhan pasar global", 11, 1, "", "B" },
                    { 13, 1, "Kompetensi pengetahuan sangat baik, sangat menguasai limit di ketakhinggaan fungsi aljabar dan trigonometri,menguasai limit fungsi trigonometri", 12, 1, "", "A" },
                    { 14, 1, "Kompetensi pengetahuan baik, sangat menguasai rangkaian arus bolak balik, cukup menguasai prinsip kerja peralatan listrik searah", 13, 1, "", "B" },
                    { 15, 1, "Kompetensi pengetahuan sangat baik, sangat menguasai pola-pola hereditas, menguasai pengaruh faktor internal dan faktor eksternal terhadap pertumbuhan dan perkembangan", 14, 1, "", "A" },
                    { 16, 1, "Kompetensi pengetahuan sangat baik, sangat menguasai analisis gejala yang terjadi sel elektrolisis yang digunakan dalam kehidupan, sangat menguasai penyebab adanya fenomena sifat koligatif larutan, dan tekanan osmosis", 15, 1, "", "A" },
                    { 17, 1, "Kompetensi pengetahuan baik, sangat menguasai ukuran pemusatan dan penyebaran data yang disajikan dalam bentuk tabel distribusi frekuensi dan histogram, menguasai jarak dalam ruang", 16, 1, "", "B" },
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TblRaport",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TblRaport",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TblRaport",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TblRaport",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TblRaport",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "TblRaport",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "TblRaport",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "TblRaport",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "TblRaport",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "TblRaport",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "TblRaport",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "TblRaport",
                keyColumn: "Id",
                keyValue: 17);

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

            migrationBuilder.AddColumn<int>(
                name: "Jenjang",
                table: "TblMataPelajaran",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 17,
                column: "MataPelajaranId",
                value: 17);

            migrationBuilder.UpdateData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 19,
                column: "MataPelajaranId",
                value: 19);

            migrationBuilder.UpdateData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 24,
                column: "MataPelajaranId",
                value: 25);

            migrationBuilder.UpdateData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 26,
                column: "MataPelajaranId",
                value: 27);

            migrationBuilder.UpdateData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 27,
                column: "MataPelajaranId",
                value: 28);

            migrationBuilder.UpdateData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 28,
                column: "MataPelajaranId",
                value: 29);

            migrationBuilder.UpdateData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 29,
                column: "MataPelajaranId",
                value: 30);

            migrationBuilder.UpdateData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 30,
                column: "MataPelajaranId",
                value: 31);

            migrationBuilder.UpdateData(
                table: "TblMataPelajaran",
                keyColumn: "Id",
                keyValue: 3,
                column: "Jenjang",
                value: 2);

            migrationBuilder.UpdateData(
                table: "TblMataPelajaran",
                keyColumn: "Id",
                keyValue: 4,
                column: "Jenjang",
                value: 2);

            migrationBuilder.UpdateData(
                table: "TblMataPelajaran",
                keyColumn: "Id",
                keyValue: 5,
                column: "Jenjang",
                value: 2);

            migrationBuilder.UpdateData(
                table: "TblMataPelajaran",
                keyColumn: "Id",
                keyValue: 6,
                column: "Jenjang",
                value: 2);

            migrationBuilder.UpdateData(
                table: "TblMataPelajaran",
                keyColumn: "Id",
                keyValue: 7,
                column: "Jenjang",
                value: 2);

            migrationBuilder.UpdateData(
                table: "TblMataPelajaran",
                keyColumn: "Id",
                keyValue: 8,
                column: "Jenjang",
                value: 2);

            migrationBuilder.UpdateData(
                table: "TblMataPelajaran",
                keyColumn: "Id",
                keyValue: 9,
                column: "Jenjang",
                value: 2);

            migrationBuilder.UpdateData(
                table: "TblMataPelajaran",
                keyColumn: "Id",
                keyValue: 10,
                column: "Jenjang",
                value: 2);

            migrationBuilder.UpdateData(
                table: "TblMataPelajaran",
                keyColumn: "Id",
                keyValue: 11,
                column: "Jenjang",
                value: 2);

            migrationBuilder.UpdateData(
                table: "TblMataPelajaran",
                keyColumn: "Id",
                keyValue: 12,
                column: "Jenjang",
                value: 2);

            migrationBuilder.UpdateData(
                table: "TblMataPelajaran",
                keyColumn: "Id",
                keyValue: 13,
                column: "Jenjang",
                value: 2);

            migrationBuilder.UpdateData(
                table: "TblMataPelajaran",
                keyColumn: "Id",
                keyValue: 14,
                column: "Jenjang",
                value: 2);

            migrationBuilder.UpdateData(
                table: "TblMataPelajaran",
                keyColumn: "Id",
                keyValue: 15,
                column: "Jenjang",
                value: 2);

            migrationBuilder.UpdateData(
                table: "TblMataPelajaran",
                keyColumn: "Id",
                keyValue: 16,
                column: "Jenjang",
                value: 2);

            migrationBuilder.UpdateData(
                table: "TblMataPelajaran",
                keyColumn: "Id",
                keyValue: 18,
                column: "Jenjang",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TblMataPelajaran",
                keyColumn: "Id",
                keyValue: 20,
                column: "Jenjang",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TblMataPelajaran",
                keyColumn: "Id",
                keyValue: 21,
                column: "Jenjang",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TblMataPelajaran",
                keyColumn: "Id",
                keyValue: 22,
                column: "Jenjang",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TblMataPelajaran",
                keyColumn: "Id",
                keyValue: 23,
                column: "Jenjang",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TblMataPelajaran",
                keyColumn: "Id",
                keyValue: 25,
                column: "Jenjang",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TblMataPelajaran",
                keyColumn: "Id",
                keyValue: 26,
                column: "Jenjang",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TblMataPelajaran",
                keyColumn: "Id",
                keyValue: 32,
                column: "Jenjang",
                value: 0);

            migrationBuilder.InsertData(
                table: "TblMataPelajaran",
                columns: new[] { "Id", "Jenjang", "KKM", "Nama", "PeminatanId" },
                values: new object[,]
                {
                    { 17, 0, 75.0, "Kimia", 1 },
                    { 19, 0, 75.0, "Biologi", 1 },
                    { 24, 0, 75.0, "Bahasa Inggris", 1 },
                    { 27, 0, 75.0, "Fisika", 1 },
                    { 28, 0, 75.0, "Bahasa Indonesia", 1 },
                    { 29, 0, 75.0, "Pendidikan Agama dan Budi Pekerti", 1 },
                    { 30, 0, 75.0, "Matematika (Umum)", 1 },
                    { 31, 0, 75.0, "Seni Budaya", 1 }
                });
        }
    }
}
