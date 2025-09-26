using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedingSedikit2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TblKelas",
                keyColumn: "Id",
                keyValue: 1,
                column: "TahunAjaranId",
                value: 2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TblKelas",
                keyColumn: "Id",
                keyValue: 1,
                column: "TahunAjaranId",
                value: 1);
        }
    }
}
