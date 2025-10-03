using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataMataPelajaran2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TblKelas",
                columns: new[] { "Id", "Jenjang", "PeminatanId", "TahunAjaranId" },
                values: new object[,]
                {
                    { 1, 0, 1, 2 },
                    { 3, 1, 1, 2 },
                    { 4, 2, 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "TblMataPelajaran",
                columns: new[] { "Id", "Jenjang", "KKM", "Nama", "PeminatanId" },
                values: new object[,]
                {
                    { 17, 0, 75.0, "Kimia", 1 },
                    { 18, 0, 75.0, "Pendidikan Pancasila", 1 },
                    { 19, 0, 75.0, "Biologi", 1 },
                    { 20, 0, 75.0, "Coding", 1 },
                    { 21, 0, 75.0, "Sejarah", 1 },
                    { 22, 0, 75.0, "Sosiologi", 1 },
                    { 23, 0, 75.0, "Pendidikan Jasmani, Olah Raga dan Kesehatan", 1 },
                    { 24, 0, 75.0, "Bahasa Inggris", 1 },
                    { 25, 0, 75.0, "Ekonomi", 1 },
                    { 26, 0, 75.0, "Geografi", 1 },
                    { 27, 0, 75.0, "Fisika", 1 },
                    { 28, 0, 75.0, "Bahasa Indonesia", 1 },
                    { 29, 0, 75.0, "Pendidikan Agama dan Budi Pekerti", 1 },
                    { 30, 0, 75.0, "Matematika (Umum)", 1 },
                    { 31, 0, 75.0, "Seni Budaya", 1 },
                    { 32, 0, 75.0, "Prakarya dan Kewirausahaan", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TblKelas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TblKelas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TblKelas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TblMataPelajaran",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "TblMataPelajaran",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "TblMataPelajaran",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "TblMataPelajaran",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "TblMataPelajaran",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "TblMataPelajaran",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "TblMataPelajaran",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "TblMataPelajaran",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "TblMataPelajaran",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "TblMataPelajaran",
                keyColumn: "Id",
                keyValue: 26);

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

            migrationBuilder.DeleteData(
                table: "TblMataPelajaran",
                keyColumn: "Id",
                keyValue: 32);
        }
    }
}
