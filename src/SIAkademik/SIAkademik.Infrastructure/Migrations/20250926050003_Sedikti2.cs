using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Sedikti2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TahunPelaksaan",
                table: "TblTahunAjaran",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "TblTahunAjaran",
                keyColumn: "Id",
                keyValue: 1,
                column: "TahunPelaksaan",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "TblTahunAjaran",
                keyColumn: "Id",
                keyValue: 2,
                column: "TahunPelaksaan",
                value: 2025);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TahunPelaksaan",
                table: "TblTahunAjaran");
        }
    }
}
