using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedData5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.InsertData(
                table: "TblHariMengajar",
                columns: new[] { "Id", "Hari", "JadwalMengajarId", "JamAkhir", "JamMulai" },
                values: new object[,]
                {
                    { 11, 2, 22, new TimeOnly(8, 15, 0), new TimeOnly(7, 30, 0) },
                    { 12, 2, 22, new TimeOnly(9, 5, 0), new TimeOnly(8, 20, 0) },
                    { 13, 2, 22, new TimeOnly(9, 55, 0), new TimeOnly(9, 10, 0) },
                    { 14, 2, 23, new TimeOnly(10, 45, 0), new TimeOnly(10, 0, 0) },
                    { 15, 2, 23, new TimeOnly(11, 35, 0), new TimeOnly(10, 50, 0) },
                    { 16, 2, 23, new TimeOnly(12, 25, 0), new TimeOnly(11, 45, 0) },
                    { 17, 2, 24, new TimeOnly(13, 45, 0), new TimeOnly(13, 0, 0) },
                    { 18, 2, 24, new TimeOnly(14, 35, 0), new TimeOnly(13, 50, 0) },
                    { 19, 3, 25, new TimeOnly(8, 15, 0), new TimeOnly(7, 30, 0) },
                    { 20, 3, 25, new TimeOnly(9, 5, 0), new TimeOnly(8, 20, 0) },
                    { 21, 3, 26, new TimeOnly(9, 55, 0), new TimeOnly(9, 10, 0) },
                    { 22, 3, 26, new TimeOnly(10, 45, 0), new TimeOnly(10, 0, 0) },
                    { 23, 4, 27, new TimeOnly(8, 15, 0), new TimeOnly(7, 30, 0) },
                    { 24, 4, 27, new TimeOnly(9, 5, 0), new TimeOnly(8, 20, 0) },
                    { 25, 1, 28, new TimeOnly(21, 0, 0), new TimeOnly(20, 0, 0) },
                    { 26, 4, 29, new TimeOnly(10, 45, 0), new TimeOnly(10, 0, 0) },
                    { 27, 4, 29, new TimeOnly(11, 35, 0), new TimeOnly(10, 50, 0) },
                    { 28, 3, 30, new TimeOnly(11, 35, 0), new TimeOnly(10, 50, 0) },
                    { 29, 3, 30, new TimeOnly(12, 25, 0), new TimeOnly(11, 40, 0) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TblHariMengajar",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "TblHariMengajar",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "TblHariMengajar",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "TblHariMengajar",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "TblHariMengajar",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "TblHariMengajar",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "TblHariMengajar",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "TblHariMengajar",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "TblHariMengajar",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "TblHariMengajar",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "TblHariMengajar",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "TblHariMengajar",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "TblHariMengajar",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "TblHariMengajar",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "TblHariMengajar",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "TblHariMengajar",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "TblHariMengajar",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "TblHariMengajar",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "TblHariMengajar",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.InsertData(
                table: "TblJadwalMengajar",
                columns: new[] { "Id", "MataPelajaranId", "PegawaiId", "RombelId" },
                values: new object[] { 31, 32, "PJ23-030", 1 });
        }
    }
}
