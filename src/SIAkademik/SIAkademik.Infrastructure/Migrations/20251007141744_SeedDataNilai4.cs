using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataNilai4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TblEvaluasiSiswa",
                columns: new[] { "Id", "Deskripsi", "JadwalMengajarId", "Jenis" },
                values: new object[,]
                {
                    { 53, "Tugas 1", 16, 0 },
                    { 54, "UH 1", 16, 1 },
                    { 55, "UTS", 16, 2 },
                    { 56, "UAS", 16, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TblEvaluasiSiswa",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "TblEvaluasiSiswa",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "TblEvaluasiSiswa",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "TblEvaluasiSiswa",
                keyColumn: "Id",
                keyValue: 56);
        }
    }
}
