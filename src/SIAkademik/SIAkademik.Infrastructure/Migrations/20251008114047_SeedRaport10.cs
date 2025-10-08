using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedRaport10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TblMataPelajaran",
                keyColumn: "Id",
                keyValue: 17,
                column: "Nama",
                value: "Prakarya dan Kewirausahaan");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TblMataPelajaran",
                keyColumn: "Id",
                keyValue: 17,
                column: "Nama",
                value: "Seni Budaya");
        }
    }
}
