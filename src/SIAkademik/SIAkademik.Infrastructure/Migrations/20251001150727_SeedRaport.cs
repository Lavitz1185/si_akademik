using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedRaport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TblRaport",
                columns: new[] { "Id", "AnggotaRombelIdRombel", "AnggotaRombelIdSiswa", "Deskripsi", "JadwalMengajarId", "KategoriNilai", "Nama", "Predikat" },
                values: new object[,]
                {
                    { 1, 2, 2, "Anlidua Lua Hingmadi, baik dalam sikap berinisiatif berdoa sebelum-sesudah melakukan kegiatan, baik dalam sikap mengikuit jadwal kegiatan sekolah, baik dalam sikap menolong teman sebaya yang membutuhkan, baik dalam sikap disiplin dalam kelas, baik dalam bertanggung jawab menjaga lingkungan sekolah, baik dalam sikap menjaga hubungan dengan orang lain", null, 0, "Sikap Spiritual", "Baik" },
                    { 2, 2, 2, "Anlidua Lua Hingmadi, baik dalam sikap jujur, baik dalam sikap disiplin, baik dalam sikap tanggungjawab, baik dalam sikap toleransi, baik dalam sikap gotong royong, baik dalam sikap santun, selalu peduli, baik dalam sikap percaya diri, selalu memiliki rasa ingin tahu, baik dalam sikap ramah tamah", null, 0, "Sikap Sosial", "Baik" },
                    { 3, 2, 2, "Memuaskan. Aktif dalam ekstrakulikuler Microsoft Word", null, 3, "Microsoft Word", "Baik" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TblRaport",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TblRaport",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TblRaport",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
