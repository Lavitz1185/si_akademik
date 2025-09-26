using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Sedikti : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                column: "Semester",
                value: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                column: "Semester",
                value: 0);
        }
    }
}
