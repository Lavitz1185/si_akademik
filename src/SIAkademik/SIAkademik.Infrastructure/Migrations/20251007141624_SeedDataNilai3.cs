using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataNilai3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TblEvaluasiSiswa",
                columns: new[] { "Id", "Deskripsi", "JadwalMengajarId", "Jenis" },
                values: new object[,]
                {
                    { 17, "Tugas 1", 7, 0 },
                    { 18, "UH 1", 7, 1 },
                    { 19, "UTS", 7, 2 },
                    { 20, "UAS", 7, 3 },
                    { 21, "Tugas 1", 8, 0 },
                    { 22, "UH 1", 8, 1 },
                    { 23, "UTS", 8, 2 },
                    { 24, "UAS", 8, 3 },
                    { 25, "Tugas 1", 9, 0 },
                    { 26, "UH 1", 9, 1 },
                    { 27, "UTS", 9, 2 },
                    { 28, "UAS", 9, 3 },
                    { 29, "Tugas 1", 10, 0 },
                    { 30, "UH 1", 10, 1 },
                    { 31, "UTS", 10, 2 },
                    { 32, "UAS", 10, 3 },
                    { 33, "Tugas 1", 11, 0 },
                    { 34, "UH 1", 11, 1 },
                    { 35, "UTS", 11, 2 },
                    { 36, "UAS", 11, 3 },
                    { 37, "Tugas 1", 12, 0 },
                    { 38, "UH 1", 12, 1 },
                    { 39, "UTS", 12, 2 },
                    { 40, "UAS", 12, 3 },
                    { 41, "Tugas 1", 13, 0 },
                    { 42, "UH 1", 13, 1 },
                    { 43, "UTS", 13, 2 },
                    { 44, "UAS", 13, 3 },
                    { 45, "Tugas 1", 14, 0 },
                    { 46, "UH 1", 14, 1 },
                    { 47, "UTS", 14, 2 },
                    { 48, "UAS", 14, 3 },
                    { 49, "Tugas 1", 15, 0 },
                    { 50, "UH 1", 15, 1 },
                    { 51, "UTS", 15, 2 },
                    { 52, "UAS", 15, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TblEvaluasiSiswa",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "TblEvaluasiSiswa",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "TblEvaluasiSiswa",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "TblEvaluasiSiswa",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "TblEvaluasiSiswa",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "TblEvaluasiSiswa",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "TblEvaluasiSiswa",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "TblEvaluasiSiswa",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "TblEvaluasiSiswa",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "TblEvaluasiSiswa",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "TblEvaluasiSiswa",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "TblEvaluasiSiswa",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "TblEvaluasiSiswa",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "TblEvaluasiSiswa",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "TblEvaluasiSiswa",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "TblEvaluasiSiswa",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "TblEvaluasiSiswa",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "TblEvaluasiSiswa",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "TblEvaluasiSiswa",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "TblEvaluasiSiswa",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "TblEvaluasiSiswa",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "TblEvaluasiSiswa",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "TblEvaluasiSiswa",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "TblEvaluasiSiswa",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "TblEvaluasiSiswa",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "TblEvaluasiSiswa",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "TblEvaluasiSiswa",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "TblEvaluasiSiswa",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "TblEvaluasiSiswa",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "TblEvaluasiSiswa",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "TblEvaluasiSiswa",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "TblEvaluasiSiswa",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "TblEvaluasiSiswa",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "TblEvaluasiSiswa",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "TblEvaluasiSiswa",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "TblEvaluasiSiswa",
                keyColumn: "Id",
                keyValue: 52);
        }
    }
}
