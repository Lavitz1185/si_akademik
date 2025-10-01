using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedPegawai3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TblPegawai",
                keyColumn: "Id",
                keyValue: "PJ14-005",
                column: "AppUserId",
                value: 5);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TblPegawai",
                keyColumn: "Id",
                keyValue: "PJ14-005",
                column: "AppUserId",
                value: 4);
        }
    }
}
