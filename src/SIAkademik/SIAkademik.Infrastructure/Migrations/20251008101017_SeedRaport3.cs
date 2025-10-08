using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedRaport3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TblRaport",
                columns: new[] { "Id", "AnggotaRombelId", "Deskripsi", "JadwalMengajarId", "KategoriNilai", "Nama", "Predikat" },
                values: new object[,]
                {
                    { 4, 1, "Kompetensi pengetahuan sangat baik, sangat menguasai peran dan fungsi pria dan wanita dalam rumah tangga, sangat menguasai peran dan fungsi pria dan wanita dalam rumah tangga, sangat menguasai prinsip dasar pernikahan dan rumah tangga Kristen", 3, 1, "", "A" },
                    { 5, 1, "Kompetensi pengetahuan sangat baik, sangat menguasai perlindungan dan penegakan hukum di Indonesia, menguasai kasus-kasus pelanggaran hak dan pengikaran kewajiban warga negara", 4, 1, "", "A" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TblRaport",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TblRaport",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
