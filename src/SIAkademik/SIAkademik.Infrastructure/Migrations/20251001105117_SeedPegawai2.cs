using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedPegawai2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TblPegawai",
                keyColumn: "Id",
                keyValue: "PJ18-013",
                column: "Nama",
                value: "Yonas Jangga Ratu, S.Pd., Gr");

            migrationBuilder.UpdateData(
                table: "TblPegawai",
                keyColumn: "Id",
                keyValue: "PJ24-004",
                column: "Nama",
                value: "Sofia Blegur, S.H");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TblPegawai",
                keyColumn: "Id",
                keyValue: "PJ18-013",
                column: "Nama",
                value: "Yonas jangga Ratu, S.Pd., Gr");

            migrationBuilder.UpdateData(
                table: "TblPegawai",
                keyColumn: "Id",
                keyValue: "PJ24-004",
                column: "Nama",
                value: "Sofia Blegur , S.H");
        }
    }
}
