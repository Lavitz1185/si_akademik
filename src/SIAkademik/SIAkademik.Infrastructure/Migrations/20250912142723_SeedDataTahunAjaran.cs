using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataTahunAjaran : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TblTahunAjaran",
                columns: new[] { "Id", "Periode", "Semester" },
                values: new object[,]
                {
                    { 1, "2024/2025", 1 },
                    { 2, "2024/2025", 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TblTahunAjaran",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TblTahunAjaran",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
