using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EditDataTahuAjaran : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TblTahunAjaran",
                keyColumn: "Id",
                keyValue: 1,
                column: "Semester",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TblTahunAjaran",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Periode", "Semester" },
                values: new object[] { "2025/2026", 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TblTahunAjaran",
                keyColumn: "Id",
                keyValue: 1,
                column: "Semester",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TblTahunAjaran",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Periode", "Semester" },
                values: new object[] { "2024/2025", 1 });
        }
    }
}
