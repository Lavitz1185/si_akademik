using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TambahStatusAktifDiMahasiswa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusAktif",
                table: "TblSiswa",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "TblSiswa",
                keyColumn: "Id",
                keyValue: 1,
                column: "StatusAktif",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusAktif",
                table: "TblSiswa");
        }
    }
}
