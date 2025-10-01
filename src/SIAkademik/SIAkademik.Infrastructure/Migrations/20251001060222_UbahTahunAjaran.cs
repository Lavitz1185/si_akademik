using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UbahTahunAjaran : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Periode",
                table: "TblTahunAjaran");

            migrationBuilder.RenameColumn(
                name: "TahunPelaksaan",
                table: "TblTahunAjaran",
                newName: "Tahun");

            migrationBuilder.UpdateData(
                table: "TblTahunAjaran",
                keyColumn: "Id",
                keyValue: 1,
                column: "Tahun",
                value: 2024);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tahun",
                table: "TblTahunAjaran",
                newName: "TahunPelaksaan");

            migrationBuilder.AddColumn<string>(
                name: "Periode",
                table: "TblTahunAjaran",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "TblTahunAjaran",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Periode", "TahunPelaksaan" },
                values: new object[] { "2024/2025", 2025 });

            migrationBuilder.UpdateData(
                table: "TblTahunAjaran",
                keyColumn: "Id",
                keyValue: 2,
                column: "Periode",
                value: "2025/2026");
        }
    }
}
