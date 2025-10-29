using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateLogoSekolahDiInformasiUmum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TblInformasiUmum",
                keyColumn: "Id",
                keyValue: 1,
                column: "LogoSekolah",
                value: "/images/logo_sekolah_transparent.png");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TblInformasiUmum",
                keyColumn: "Id",
                keyValue: 1,
                column: "LogoSekolah",
                value: "/images/logo_sekolah.jpg");
        }
    }
}
