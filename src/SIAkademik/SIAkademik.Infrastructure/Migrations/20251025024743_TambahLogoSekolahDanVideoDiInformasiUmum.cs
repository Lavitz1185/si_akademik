using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TambahLogoSekolahDanVideoDiInformasiUmum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LogoSekolah",
                table: "TblInformasiUmum",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VideoHalamanBeranda",
                table: "TblInformasiUmum",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VideoHalamanTentangKami",
                table: "TblInformasiUmum",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "TblInformasiUmum",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "LogoSekolah", "VideoHalamanBeranda", "VideoHalamanTentangKami" },
                values: new object[] { "/images/logo_sekolah.jpg", "https://www.youtube.com/embed/0F0zrVop0Gg?si=-bMdPjk3DHJkXz7H", "https://www.youtube.com/embed/4Wt526OVxGg?si=L2EcPoD6nAunNxC6" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LogoSekolah",
                table: "TblInformasiUmum");

            migrationBuilder.DropColumn(
                name: "VideoHalamanBeranda",
                table: "TblInformasiUmum");

            migrationBuilder.DropColumn(
                name: "VideoHalamanTentangKami",
                table: "TblInformasiUmum");
        }
    }
}
