using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedRaport7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TblRaport",
                keyColumn: "Id",
                keyValue: 10,
                column: "Deskripsi",
                value: "Kompetensi pengetahuan sangat baik, sangat menguasai teknik menyusun naskah teater kontemporer, sangat menguasai perencangan pemetasan teater kontemporer");

            migrationBuilder.UpdateData(
                table: "TblRaport",
                keyColumn: "Id",
                keyValue: 11,
                column: "Deskripsi",
                value: "Kompetensi pengetahuan baik, sangat menguasai atletik jalan cepat, lompat tinggi, lari jarak pendek, sangat menguasai permainan bulu tangkis, softball, tenis meja");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TblRaport",
                keyColumn: "Id",
                keyValue: 10,
                column: "Deskripsi",
                value: "Kompetensi pengetahuan baik, sangat menguasai atletik jalan cepat, lompat tinggi, lari jarak pendek, sangat menguasai permainan bulu tangkis, softball, tenis meja");

            migrationBuilder.UpdateData(
                table: "TblRaport",
                keyColumn: "Id",
                keyValue: 11,
                column: "Deskripsi",
                value: "Kompetensi pengetahuan baik, sangat menguasai sistem produksi kerajinan inovatif sesuai kebutuhan pasar global berdasarkan daya dukung yang dimiliki oleh daerah setempat, sangat menguasai perencanaan usaha kerajinan inovatif berdasarkan kebutuhan pasar global");
        }
    }
}
