using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PindahTahunAjaranKeRombel2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TblKelas",
                keyColumn: "Id",
                keyValue: 1,
                column: "PeminatanId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "TblKelas",
                keyColumn: "Id",
                keyValue: 2,
                column: "PeminatanId",
                value: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TblKelas",
                keyColumn: "Id",
                keyValue: 1,
                column: "PeminatanId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TblKelas",
                keyColumn: "Id",
                keyValue: 2,
                column: "PeminatanId",
                value: 5);
        }
    }
}
