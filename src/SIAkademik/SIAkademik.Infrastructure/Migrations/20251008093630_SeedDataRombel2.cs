using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataRombel2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TblRombel",
                keyColumn: "Id",
                keyValue: 1,
                column: "WaliId",
                value: "PJ22-024");

            migrationBuilder.InsertData(
                table: "TblRombel",
                columns: new[] { "Id", "KelasId", "Nama", "WaliId" },
                values: new object[,]
                {
                    { 3, 3, "A", "PJ24-004" },
                    { 4, 3, "B", "PJ18-013" },
                    { 5, 4, "A", "PJ19-017" },
                    { 6, 4, "B", "PJ23-031" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TblRombel",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TblRombel",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TblRombel",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TblRombel",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "TblRombel",
                keyColumn: "Id",
                keyValue: 1,
                column: "WaliId",
                value: "PJ23-030");
        }
    }
}
