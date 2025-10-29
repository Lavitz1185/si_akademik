using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UbahDanSeedingPertemuan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "TanggalPelaksanaan",
                table: "TblPertemuan",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "TblPertemuan",
                columns: new[] { "Id", "JadwalMengajarId", "Keterangan", "Nomor", "StatusPertemuan", "TanggalPelaksanaan" },
                values: new object[,]
                {
                    { 1, 17, null, 1, 0, new DateTime(2025, 7, 7, 7, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 17, null, 2, 0, new DateTime(2025, 7, 7, 8, 20, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 18, null, 1, 0, new DateTime(2025, 7, 7, 9, 10, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 18, null, 2, 0, new DateTime(2025, 7, 7, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 19, null, 1, 0, new DateTime(2025, 7, 7, 10, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 19, null, 2, 0, new DateTime(2025, 7, 7, 11, 40, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 20, null, 1, 0, new DateTime(2025, 7, 7, 13, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 20, null, 2, 0, new DateTime(2025, 7, 7, 13, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 17, null, 3, 0, new DateTime(2025, 7, 14, 7, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 17, null, 4, 0, new DateTime(2025, 7, 14, 8, 20, 0, 0, DateTimeKind.Unspecified) },
                    { 11, 18, null, 3, 0, new DateTime(2025, 7, 14, 9, 10, 0, 0, DateTimeKind.Unspecified) },
                    { 12, 18, null, 4, 0, new DateTime(2025, 7, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, 19, null, 3, 0, new DateTime(2025, 7, 14, 10, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 14, 19, null, 4, 0, new DateTime(2025, 7, 14, 11, 40, 0, 0, DateTimeKind.Unspecified) },
                    { 15, 20, null, 3, 0, new DateTime(2025, 7, 14, 13, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 16, 20, null, 4, 0, new DateTime(2025, 7, 14, 13, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 17, 17, null, 5, 0, new DateTime(2025, 7, 21, 7, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 18, 17, null, 6, 0, new DateTime(2025, 7, 21, 8, 20, 0, 0, DateTimeKind.Unspecified) },
                    { 19, 18, null, 5, 0, new DateTime(2025, 7, 21, 9, 10, 0, 0, DateTimeKind.Unspecified) },
                    { 20, 18, null, 6, 0, new DateTime(2025, 7, 21, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, 19, null, 5, 0, new DateTime(2025, 7, 21, 10, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 22, 19, null, 6, 0, new DateTime(2025, 7, 21, 11, 40, 0, 0, DateTimeKind.Unspecified) },
                    { 23, 20, null, 5, 0, new DateTime(2025, 7, 21, 13, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 24, 20, null, 6, 0, new DateTime(2025, 7, 21, 13, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 25, 17, null, 7, 0, new DateTime(2025, 7, 28, 7, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 26, 17, null, 8, 0, new DateTime(2025, 7, 28, 8, 20, 0, 0, DateTimeKind.Unspecified) },
                    { 27, 18, null, 7, 0, new DateTime(2025, 7, 28, 9, 10, 0, 0, DateTimeKind.Unspecified) },
                    { 28, 18, null, 8, 0, new DateTime(2025, 7, 28, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 29, 19, null, 7, 0, new DateTime(2025, 7, 28, 10, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 30, 19, null, 8, 0, new DateTime(2025, 7, 28, 11, 40, 0, 0, DateTimeKind.Unspecified) },
                    { 31, 20, null, 7, 0, new DateTime(2025, 7, 28, 13, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 32, 20, null, 8, 0, new DateTime(2025, 7, 28, 13, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 33, 17, null, 9, 0, new DateTime(2025, 8, 4, 7, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 34, 17, null, 10, 0, new DateTime(2025, 8, 4, 8, 20, 0, 0, DateTimeKind.Unspecified) },
                    { 35, 18, null, 9, 0, new DateTime(2025, 8, 4, 9, 10, 0, 0, DateTimeKind.Unspecified) },
                    { 36, 18, null, 10, 0, new DateTime(2025, 8, 4, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 37, 19, null, 9, 0, new DateTime(2025, 8, 4, 10, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 38, 19, null, 10, 0, new DateTime(2025, 8, 4, 11, 40, 0, 0, DateTimeKind.Unspecified) },
                    { 39, 20, null, 9, 0, new DateTime(2025, 8, 4, 13, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 40, 20, null, 10, 0, new DateTime(2025, 8, 4, 13, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 41, 17, null, 11, 0, new DateTime(2025, 8, 11, 7, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 42, 17, null, 12, 0, new DateTime(2025, 8, 11, 8, 20, 0, 0, DateTimeKind.Unspecified) },
                    { 43, 18, null, 11, 0, new DateTime(2025, 8, 11, 9, 10, 0, 0, DateTimeKind.Unspecified) },
                    { 44, 18, null, 12, 0, new DateTime(2025, 8, 11, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 45, 19, null, 11, 0, new DateTime(2025, 8, 11, 10, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 46, 19, null, 12, 0, new DateTime(2025, 8, 11, 11, 40, 0, 0, DateTimeKind.Unspecified) },
                    { 47, 20, null, 11, 0, new DateTime(2025, 8, 11, 13, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 48, 20, null, 12, 0, new DateTime(2025, 8, 11, 13, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 49, 17, null, 13, 0, new DateTime(2025, 8, 18, 7, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 50, 17, null, 14, 0, new DateTime(2025, 8, 18, 8, 20, 0, 0, DateTimeKind.Unspecified) },
                    { 51, 18, null, 13, 0, new DateTime(2025, 8, 18, 9, 10, 0, 0, DateTimeKind.Unspecified) },
                    { 52, 18, null, 14, 0, new DateTime(2025, 8, 18, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 53, 19, null, 13, 0, new DateTime(2025, 8, 18, 10, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 54, 19, null, 14, 0, new DateTime(2025, 8, 18, 11, 40, 0, 0, DateTimeKind.Unspecified) },
                    { 55, 20, null, 13, 0, new DateTime(2025, 8, 18, 13, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 56, 20, null, 14, 0, new DateTime(2025, 8, 18, 13, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 57, 17, null, 15, 0, new DateTime(2025, 8, 25, 7, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 58, 17, null, 16, 0, new DateTime(2025, 8, 25, 8, 20, 0, 0, DateTimeKind.Unspecified) },
                    { 59, 18, null, 15, 0, new DateTime(2025, 8, 25, 9, 10, 0, 0, DateTimeKind.Unspecified) },
                    { 60, 18, null, 16, 0, new DateTime(2025, 8, 25, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 61, 19, null, 15, 0, new DateTime(2025, 8, 25, 10, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 62, 19, null, 16, 0, new DateTime(2025, 8, 25, 11, 40, 0, 0, DateTimeKind.Unspecified) },
                    { 63, 20, null, 15, 0, new DateTime(2025, 8, 25, 13, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 64, 20, null, 16, 0, new DateTime(2025, 8, 25, 13, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 65, 17, null, 17, 0, new DateTime(2025, 9, 1, 7, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 66, 17, null, 18, 0, new DateTime(2025, 9, 1, 8, 20, 0, 0, DateTimeKind.Unspecified) },
                    { 67, 18, null, 17, 0, new DateTime(2025, 9, 1, 9, 10, 0, 0, DateTimeKind.Unspecified) },
                    { 68, 18, null, 18, 0, new DateTime(2025, 9, 1, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 69, 19, null, 17, 0, new DateTime(2025, 9, 1, 10, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 70, 19, null, 18, 0, new DateTime(2025, 9, 1, 11, 40, 0, 0, DateTimeKind.Unspecified) },
                    { 71, 20, null, 17, 0, new DateTime(2025, 9, 1, 13, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 72, 20, null, 18, 0, new DateTime(2025, 9, 1, 13, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 73, 17, null, 19, 0, new DateTime(2025, 9, 8, 7, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 74, 17, null, 20, 0, new DateTime(2025, 9, 8, 8, 20, 0, 0, DateTimeKind.Unspecified) },
                    { 75, 18, null, 19, 0, new DateTime(2025, 9, 8, 9, 10, 0, 0, DateTimeKind.Unspecified) },
                    { 76, 18, null, 20, 0, new DateTime(2025, 9, 8, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 77, 19, null, 19, 0, new DateTime(2025, 9, 8, 10, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 78, 19, null, 20, 0, new DateTime(2025, 9, 8, 11, 40, 0, 0, DateTimeKind.Unspecified) },
                    { 79, 20, null, 19, 0, new DateTime(2025, 9, 8, 13, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 80, 20, null, 20, 0, new DateTime(2025, 9, 8, 13, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 81, 17, null, 21, 0, new DateTime(2025, 9, 15, 7, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 82, 17, null, 22, 0, new DateTime(2025, 9, 15, 8, 20, 0, 0, DateTimeKind.Unspecified) },
                    { 83, 18, null, 21, 0, new DateTime(2025, 9, 15, 9, 10, 0, 0, DateTimeKind.Unspecified) },
                    { 84, 18, null, 22, 0, new DateTime(2025, 9, 15, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 85, 19, null, 21, 0, new DateTime(2025, 9, 15, 10, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 86, 19, null, 22, 0, new DateTime(2025, 9, 15, 11, 40, 0, 0, DateTimeKind.Unspecified) },
                    { 87, 20, null, 21, 0, new DateTime(2025, 9, 15, 13, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 88, 20, null, 22, 0, new DateTime(2025, 9, 15, 13, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 89, 17, null, 23, 0, new DateTime(2025, 9, 22, 7, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 90, 17, null, 24, 0, new DateTime(2025, 9, 22, 8, 20, 0, 0, DateTimeKind.Unspecified) },
                    { 91, 18, null, 23, 0, new DateTime(2025, 9, 22, 9, 10, 0, 0, DateTimeKind.Unspecified) },
                    { 92, 18, null, 24, 0, new DateTime(2025, 9, 22, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 93, 19, null, 23, 0, new DateTime(2025, 9, 22, 10, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 94, 19, null, 24, 0, new DateTime(2025, 9, 22, 11, 40, 0, 0, DateTimeKind.Unspecified) },
                    { 95, 20, null, 23, 0, new DateTime(2025, 9, 22, 13, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 96, 20, null, 24, 0, new DateTime(2025, 9, 22, 13, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 97, 17, null, 25, 0, new DateTime(2025, 9, 29, 7, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 98, 17, null, 26, 0, new DateTime(2025, 9, 29, 8, 20, 0, 0, DateTimeKind.Unspecified) },
                    { 99, 18, null, 25, 0, new DateTime(2025, 9, 29, 9, 10, 0, 0, DateTimeKind.Unspecified) },
                    { 100, 18, null, 26, 0, new DateTime(2025, 9, 29, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 101, 19, null, 25, 0, new DateTime(2025, 9, 29, 10, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 102, 19, null, 26, 0, new DateTime(2025, 9, 29, 11, 40, 0, 0, DateTimeKind.Unspecified) },
                    { 103, 20, null, 25, 0, new DateTime(2025, 9, 29, 13, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 104, 20, null, 26, 0, new DateTime(2025, 9, 29, 13, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 105, 17, null, 27, 0, new DateTime(2025, 10, 6, 7, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 106, 17, null, 28, 0, new DateTime(2025, 10, 6, 8, 20, 0, 0, DateTimeKind.Unspecified) },
                    { 107, 18, null, 27, 0, new DateTime(2025, 10, 6, 9, 10, 0, 0, DateTimeKind.Unspecified) },
                    { 108, 18, null, 28, 0, new DateTime(2025, 10, 6, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 109, 19, null, 27, 0, new DateTime(2025, 10, 6, 10, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 110, 19, null, 28, 0, new DateTime(2025, 10, 6, 11, 40, 0, 0, DateTimeKind.Unspecified) },
                    { 111, 20, null, 27, 0, new DateTime(2025, 10, 6, 13, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 112, 20, null, 28, 0, new DateTime(2025, 10, 6, 13, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 113, 17, null, 29, 0, new DateTime(2025, 10, 13, 7, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 114, 17, null, 30, 0, new DateTime(2025, 10, 13, 8, 20, 0, 0, DateTimeKind.Unspecified) },
                    { 115, 18, null, 29, 0, new DateTime(2025, 10, 13, 9, 10, 0, 0, DateTimeKind.Unspecified) },
                    { 116, 18, null, 30, 0, new DateTime(2025, 10, 13, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 117, 19, null, 29, 0, new DateTime(2025, 10, 13, 10, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 118, 19, null, 30, 0, new DateTime(2025, 10, 13, 11, 40, 0, 0, DateTimeKind.Unspecified) },
                    { 119, 20, null, 29, 0, new DateTime(2025, 10, 13, 13, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 120, 20, null, 30, 0, new DateTime(2025, 10, 13, 13, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 121, 17, null, 31, 0, new DateTime(2025, 10, 20, 7, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 122, 17, null, 32, 0, new DateTime(2025, 10, 20, 8, 20, 0, 0, DateTimeKind.Unspecified) },
                    { 123, 18, null, 31, 0, new DateTime(2025, 10, 20, 9, 10, 0, 0, DateTimeKind.Unspecified) },
                    { 124, 18, null, 32, 0, new DateTime(2025, 10, 20, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 125, 19, null, 31, 0, new DateTime(2025, 10, 20, 10, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 126, 19, null, 32, 0, new DateTime(2025, 10, 20, 11, 40, 0, 0, DateTimeKind.Unspecified) },
                    { 127, 20, null, 31, 0, new DateTime(2025, 10, 20, 13, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 128, 20, null, 32, 0, new DateTime(2025, 10, 20, 13, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 129, 17, null, 33, 0, new DateTime(2025, 10, 27, 7, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 130, 17, null, 34, 0, new DateTime(2025, 10, 27, 8, 20, 0, 0, DateTimeKind.Unspecified) },
                    { 131, 18, null, 33, 0, new DateTime(2025, 10, 27, 9, 10, 0, 0, DateTimeKind.Unspecified) },
                    { 132, 18, null, 34, 0, new DateTime(2025, 10, 27, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 133, 19, null, 33, 0, new DateTime(2025, 10, 27, 10, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 134, 19, null, 34, 0, new DateTime(2025, 10, 27, 11, 40, 0, 0, DateTimeKind.Unspecified) },
                    { 135, 20, null, 33, 0, new DateTime(2025, 10, 27, 13, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 136, 20, null, 34, 0, new DateTime(2025, 10, 27, 13, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 137, 17, null, 35, 0, new DateTime(2025, 11, 3, 7, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 138, 17, null, 36, 0, new DateTime(2025, 11, 3, 8, 20, 0, 0, DateTimeKind.Unspecified) },
                    { 139, 18, null, 35, 0, new DateTime(2025, 11, 3, 9, 10, 0, 0, DateTimeKind.Unspecified) },
                    { 140, 18, null, 36, 0, new DateTime(2025, 11, 3, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 141, 19, null, 35, 0, new DateTime(2025, 11, 3, 10, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 142, 19, null, 36, 0, new DateTime(2025, 11, 3, 11, 40, 0, 0, DateTimeKind.Unspecified) },
                    { 143, 20, null, 35, 0, new DateTime(2025, 11, 3, 13, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 144, 20, null, 36, 0, new DateTime(2025, 11, 3, 13, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 145, 17, null, 37, 0, new DateTime(2025, 11, 10, 7, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 146, 17, null, 38, 0, new DateTime(2025, 11, 10, 8, 20, 0, 0, DateTimeKind.Unspecified) },
                    { 147, 18, null, 37, 0, new DateTime(2025, 11, 10, 9, 10, 0, 0, DateTimeKind.Unspecified) },
                    { 148, 18, null, 38, 0, new DateTime(2025, 11, 10, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 149, 19, null, 37, 0, new DateTime(2025, 11, 10, 10, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 150, 19, null, 38, 0, new DateTime(2025, 11, 10, 11, 40, 0, 0, DateTimeKind.Unspecified) },
                    { 151, 20, null, 37, 0, new DateTime(2025, 11, 10, 13, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 152, 20, null, 38, 0, new DateTime(2025, 11, 10, 13, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 153, 17, null, 39, 0, new DateTime(2025, 11, 17, 7, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 154, 17, null, 40, 0, new DateTime(2025, 11, 17, 8, 20, 0, 0, DateTimeKind.Unspecified) },
                    { 155, 18, null, 39, 0, new DateTime(2025, 11, 17, 9, 10, 0, 0, DateTimeKind.Unspecified) },
                    { 156, 18, null, 40, 0, new DateTime(2025, 11, 17, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 157, 19, null, 39, 0, new DateTime(2025, 11, 17, 10, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 158, 19, null, 40, 0, new DateTime(2025, 11, 17, 11, 40, 0, 0, DateTimeKind.Unspecified) },
                    { 159, 20, null, 39, 0, new DateTime(2025, 11, 17, 13, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 160, 20, null, 40, 0, new DateTime(2025, 11, 17, 13, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 161, 17, null, 41, 0, new DateTime(2025, 11, 24, 7, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 162, 17, null, 42, 0, new DateTime(2025, 11, 24, 8, 20, 0, 0, DateTimeKind.Unspecified) },
                    { 163, 18, null, 41, 0, new DateTime(2025, 11, 24, 9, 10, 0, 0, DateTimeKind.Unspecified) },
                    { 164, 18, null, 42, 0, new DateTime(2025, 11, 24, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 165, 19, null, 41, 0, new DateTime(2025, 11, 24, 10, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 166, 19, null, 42, 0, new DateTime(2025, 11, 24, 11, 40, 0, 0, DateTimeKind.Unspecified) },
                    { 167, 20, null, 41, 0, new DateTime(2025, 11, 24, 13, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 168, 20, null, 42, 0, new DateTime(2025, 11, 24, 13, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 169, 17, null, 43, 0, new DateTime(2025, 12, 1, 7, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 170, 17, null, 44, 0, new DateTime(2025, 12, 1, 8, 20, 0, 0, DateTimeKind.Unspecified) },
                    { 171, 18, null, 43, 0, new DateTime(2025, 12, 1, 9, 10, 0, 0, DateTimeKind.Unspecified) },
                    { 172, 18, null, 44, 0, new DateTime(2025, 12, 1, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 173, 19, null, 43, 0, new DateTime(2025, 12, 1, 10, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 174, 19, null, 44, 0, new DateTime(2025, 12, 1, 11, 40, 0, 0, DateTimeKind.Unspecified) },
                    { 175, 20, null, 43, 0, new DateTime(2025, 12, 1, 13, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 176, 20, null, 44, 0, new DateTime(2025, 12, 1, 13, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 177, 17, null, 45, 0, new DateTime(2025, 12, 8, 7, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 178, 17, null, 46, 0, new DateTime(2025, 12, 8, 8, 20, 0, 0, DateTimeKind.Unspecified) },
                    { 179, 18, null, 45, 0, new DateTime(2025, 12, 8, 9, 10, 0, 0, DateTimeKind.Unspecified) },
                    { 180, 18, null, 46, 0, new DateTime(2025, 12, 8, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 181, 19, null, 45, 0, new DateTime(2025, 12, 8, 10, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 182, 19, null, 46, 0, new DateTime(2025, 12, 8, 11, 40, 0, 0, DateTimeKind.Unspecified) },
                    { 183, 20, null, 45, 0, new DateTime(2025, 12, 8, 13, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 184, 20, null, 46, 0, new DateTime(2025, 12, 8, 13, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 185, 17, null, 47, 0, new DateTime(2025, 12, 15, 7, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 186, 17, null, 48, 0, new DateTime(2025, 12, 15, 8, 20, 0, 0, DateTimeKind.Unspecified) },
                    { 187, 18, null, 47, 0, new DateTime(2025, 12, 15, 9, 10, 0, 0, DateTimeKind.Unspecified) },
                    { 188, 18, null, 48, 0, new DateTime(2025, 12, 15, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 189, 19, null, 47, 0, new DateTime(2025, 12, 15, 10, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 190, 19, null, 48, 0, new DateTime(2025, 12, 15, 11, 40, 0, 0, DateTimeKind.Unspecified) },
                    { 191, 20, null, 47, 0, new DateTime(2025, 12, 15, 13, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 192, 20, null, 48, 0, new DateTime(2025, 12, 15, 13, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 193, 17, null, 49, 0, new DateTime(2025, 12, 22, 7, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 194, 17, null, 50, 0, new DateTime(2025, 12, 22, 8, 20, 0, 0, DateTimeKind.Unspecified) },
                    { 195, 18, null, 49, 0, new DateTime(2025, 12, 22, 9, 10, 0, 0, DateTimeKind.Unspecified) },
                    { 196, 18, null, 50, 0, new DateTime(2025, 12, 22, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 197, 19, null, 49, 0, new DateTime(2025, 12, 22, 10, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 198, 19, null, 50, 0, new DateTime(2025, 12, 22, 11, 40, 0, 0, DateTimeKind.Unspecified) },
                    { 199, 20, null, 49, 0, new DateTime(2025, 12, 22, 13, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 200, 20, null, 50, 0, new DateTime(2025, 12, 22, 13, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 201, 17, null, 51, 0, new DateTime(2025, 12, 29, 7, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 202, 17, null, 52, 0, new DateTime(2025, 12, 29, 8, 20, 0, 0, DateTimeKind.Unspecified) },
                    { 203, 18, null, 51, 0, new DateTime(2025, 12, 29, 9, 10, 0, 0, DateTimeKind.Unspecified) },
                    { 204, 18, null, 52, 0, new DateTime(2025, 12, 29, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 205, 19, null, 51, 0, new DateTime(2025, 12, 29, 10, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 206, 19, null, 52, 0, new DateTime(2025, 12, 29, 11, 40, 0, 0, DateTimeKind.Unspecified) },
                    { 207, 20, null, 51, 0, new DateTime(2025, 12, 29, 13, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 208, 20, null, 52, 0, new DateTime(2025, 12, 29, 13, 50, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 76);

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

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 149);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 150);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 151);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 152);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 153);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 154);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 155);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 156);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 157);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 158);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 159);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 160);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 161);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 162);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 163);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 164);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 165);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 166);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 167);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 168);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 169);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 170);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 171);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 172);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 173);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 174);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 175);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 176);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 177);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 178);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 179);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 180);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 181);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 182);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 183);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 184);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 185);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 186);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 187);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 188);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 189);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 190);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 191);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 192);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 193);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 194);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 195);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 196);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 197);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 198);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 199);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 202);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 203);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 204);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 205);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 206);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 207);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 208);

            migrationBuilder.AlterColumn<DateTime>(
                name: "TanggalPelaksanaan",
                table: "TblPertemuan",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");
        }
    }
}
