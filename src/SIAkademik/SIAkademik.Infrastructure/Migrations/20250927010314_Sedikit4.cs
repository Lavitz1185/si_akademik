using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Sedikit4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TblHariMengajar",
                keyColumn: "Id",
                keyValue: 8,
                column: "Hari",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TblHariMengajar",
                keyColumn: "Id",
                keyValue: 9,
                column: "Hari",
                value: 2);

            migrationBuilder.UpdateData(
                table: "TblHariMengajar",
                keyColumn: "Id",
                keyValue: 10,
                column: "Hari",
                value: 3);

            migrationBuilder.UpdateData(
                table: "TblHariMengajar",
                keyColumn: "Id",
                keyValue: 11,
                column: "Hari",
                value: 4);

            migrationBuilder.UpdateData(
                table: "TblHariMengajar",
                keyColumn: "Id",
                keyValue: 12,
                column: "Hari",
                value: 5);

            migrationBuilder.UpdateData(
                table: "TblHariMengajar",
                keyColumn: "Id",
                keyValue: 13,
                column: "Hari",
                value: 6);

            migrationBuilder.UpdateData(
                table: "TblHariMengajar",
                keyColumn: "Id",
                keyValue: 14,
                column: "Hari",
                value: 7);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TblHariMengajar",
                keyColumn: "Id",
                keyValue: 8,
                column: "Hari",
                value: 8);

            migrationBuilder.UpdateData(
                table: "TblHariMengajar",
                keyColumn: "Id",
                keyValue: 9,
                column: "Hari",
                value: 9);

            migrationBuilder.UpdateData(
                table: "TblHariMengajar",
                keyColumn: "Id",
                keyValue: 10,
                column: "Hari",
                value: 10);

            migrationBuilder.UpdateData(
                table: "TblHariMengajar",
                keyColumn: "Id",
                keyValue: 11,
                column: "Hari",
                value: 11);

            migrationBuilder.UpdateData(
                table: "TblHariMengajar",
                keyColumn: "Id",
                keyValue: 12,
                column: "Hari",
                value: 12);

            migrationBuilder.UpdateData(
                table: "TblHariMengajar",
                keyColumn: "Id",
                keyValue: 13,
                column: "Hari",
                value: 13);

            migrationBuilder.UpdateData(
                table: "TblHariMengajar",
                keyColumn: "Id",
                keyValue: 14,
                column: "Hari",
                value: 14);
        }
    }
}
