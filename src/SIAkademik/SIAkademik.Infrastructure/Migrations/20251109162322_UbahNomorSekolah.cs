using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UbahNomorSekolah : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TblInformasiUmum",
                keyColumn: "Id",
                keyValue: 1,
                column: "NoHPSekolah",
                value: "+6281238007577");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TblInformasiUmum",
                keyColumn: "Id",
                keyValue: 1,
                column: "NoHPSekolah",
                value: "081238007577");
        }
    }
}
