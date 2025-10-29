using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class BanyakUbahHariMengajarDanPertemuan2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 104);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TblPertemuan",
                columns: new[] { "Id", "JadwalMengajarId", "Keterangan", "Nomor", "StatusPertemuan", "TanggalPelaksanaan" },
                values: new object[,]
                {
                    { 77, 17, null, 20, 0, new DateTime(2025, 11, 17, 7, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 78, 18, null, 20, 0, new DateTime(2025, 11, 17, 9, 10, 0, 0, DateTimeKind.Unspecified) },
                    { 79, 19, null, 20, 0, new DateTime(2025, 11, 17, 10, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 80, 20, null, 20, 0, new DateTime(2025, 11, 17, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 81, 17, null, 21, 0, new DateTime(2025, 11, 24, 7, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 82, 18, null, 21, 0, new DateTime(2025, 11, 24, 9, 10, 0, 0, DateTimeKind.Unspecified) },
                    { 83, 19, null, 21, 0, new DateTime(2025, 11, 24, 10, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 84, 20, null, 21, 0, new DateTime(2025, 11, 24, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 85, 17, null, 22, 0, new DateTime(2025, 12, 1, 7, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 86, 18, null, 22, 0, new DateTime(2025, 12, 1, 9, 10, 0, 0, DateTimeKind.Unspecified) },
                    { 87, 19, null, 22, 0, new DateTime(2025, 12, 1, 10, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 88, 20, null, 22, 0, new DateTime(2025, 12, 1, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 89, 17, null, 23, 0, new DateTime(2025, 12, 8, 7, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 90, 18, null, 23, 0, new DateTime(2025, 12, 8, 9, 10, 0, 0, DateTimeKind.Unspecified) },
                    { 91, 19, null, 23, 0, new DateTime(2025, 12, 8, 10, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 92, 20, null, 23, 0, new DateTime(2025, 12, 8, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 93, 17, null, 24, 0, new DateTime(2025, 12, 15, 7, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 94, 18, null, 24, 0, new DateTime(2025, 12, 15, 9, 10, 0, 0, DateTimeKind.Unspecified) },
                    { 95, 19, null, 24, 0, new DateTime(2025, 12, 15, 10, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 96, 20, null, 24, 0, new DateTime(2025, 12, 15, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 97, 17, null, 25, 0, new DateTime(2025, 12, 22, 7, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 98, 18, null, 25, 0, new DateTime(2025, 12, 22, 9, 10, 0, 0, DateTimeKind.Unspecified) },
                    { 99, 19, null, 25, 0, new DateTime(2025, 12, 22, 10, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 100, 20, null, 25, 0, new DateTime(2025, 12, 22, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 101, 17, null, 26, 0, new DateTime(2025, 12, 29, 7, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 102, 18, null, 26, 0, new DateTime(2025, 12, 29, 9, 10, 0, 0, DateTimeKind.Unspecified) },
                    { 103, 19, null, 26, 0, new DateTime(2025, 12, 29, 10, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 104, 20, null, 26, 0, new DateTime(2025, 12, 29, 13, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }
    }
}
