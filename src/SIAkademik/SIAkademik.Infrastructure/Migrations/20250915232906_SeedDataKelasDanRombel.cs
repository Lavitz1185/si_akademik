using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataKelasDanRombel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TblKelas",
                columns: new[] { "Id", "Jenjang", "Peminatan", "TahunAjaranId" },
                values: new object[] { 1, 0, 0, 1 });

            migrationBuilder.InsertData(
                table: "TblRombel",
                columns: new[] { "Id", "KelasId", "Nama", "WaliId" },
                values: new object[] { 1, 1, "A", "PJ24-003" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TblRombel",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TblKelas",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
