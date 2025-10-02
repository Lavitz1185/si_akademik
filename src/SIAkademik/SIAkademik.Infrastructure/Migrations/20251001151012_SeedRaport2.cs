using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedRaport2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TblRaport",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Deskripsi", "Predikat" },
                values: new object[] { "Aktif dalam ekstrakulikuler Microsoft Word", "Memuaskan" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TblRaport",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Deskripsi", "Predikat" },
                values: new object[] { "Memuaskan. Aktif dalam ekstrakulikuler Microsoft Word", "Baik" });
        }
    }
}
