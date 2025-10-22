using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataJadwalKelasX : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TblJadwalMengajar",
                columns: new[] { "Id", "MataPelajaranId", "PegawaiId", "RombelId" },
                values: new object[,]
                {
                    { 18, 16, "PJ24-004", 2 },
                    { 22, 5, "PJ19-017", 2 },
                    { 23, 18, "PJ14-005", 2 },
                    { 24, 1, "PJ22-024", 2 },
                    { 25, 9, "PJ18-013", 2 },
                    { 26, 6, "PJ19-016", 2 },
                    { 27, 19, "PJ23-029", 2 },
                    { 28, 20, "PJ22-024", 2 },
                    { 30, 21, "PJ22-024", 2 },
                    { 31, 3, "PJ23-031", 2 },
                    { 32, 4, "PJ24-005", 2 }
                });

            migrationBuilder.InsertData(
                table: "TblMataPelajaran",
                columns: new[] { "Id", "KKM", "Nama", "PeminatanId" },
                values: new object[,]
                {
                    { 22, 75.0, "Kimia", 1 },
                    { 23, 75.0, "Biologi", 1 },
                    { 24, 75.0, "English Corner", 1 },
                    { 25, 75.0, "Coding", 1 },
                    { 26, 75.0, "Fisika", 1 },
                    { 27, 75.0, "Gardha Pandhega", 1 }
                });

            migrationBuilder.InsertData(
                table: "TblHariMengajar",
                columns: new[] { "Id", "Hari", "JadwalMengajarId", "JamAkhir", "JamMulai" },
                values: new object[,]
                {
                    { 3, 0, 18, new TimeOnly(9, 55, 0), new TimeOnly(9, 10, 0) },
                    { 4, 0, 18, new TimeOnly(10, 45, 0), new TimeOnly(10, 0, 0) },
                    { 13, 1, 22, new TimeOnly(9, 55, 0), new TimeOnly(9, 10, 0) },
                    { 14, 1, 22, new TimeOnly(10, 45, 0), new TimeOnly(10, 0, 0) },
                    { 15, 1, 23, new TimeOnly(11, 35, 0), new TimeOnly(10, 50, 0) },
                    { 16, 1, 23, new TimeOnly(12, 25, 0), new TimeOnly(11, 40, 0) },
                    { 17, 1, 24, new TimeOnly(21, 0, 0), new TimeOnly(20, 0, 0) },
                    { 18, 2, 25, new TimeOnly(8, 15, 0), new TimeOnly(7, 30, 0) },
                    { 19, 2, 25, new TimeOnly(9, 5, 0), new TimeOnly(8, 20, 0) },
                    { 20, 2, 25, new TimeOnly(9, 55, 0), new TimeOnly(9, 10, 0) },
                    { 21, 2, 26, new TimeOnly(10, 45, 0), new TimeOnly(10, 0, 0) },
                    { 22, 2, 26, new TimeOnly(11, 35, 0), new TimeOnly(10, 50, 0) },
                    { 23, 2, 26, new TimeOnly(12, 25, 0), new TimeOnly(11, 40, 0) },
                    { 24, 2, 27, new TimeOnly(13, 45, 0), new TimeOnly(13, 0, 0) },
                    { 25, 2, 27, new TimeOnly(14, 35, 0), new TimeOnly(13, 50, 0) },
                    { 26, 3, 28, new TimeOnly(8, 15, 0), new TimeOnly(7, 30, 0) },
                    { 27, 3, 28, new TimeOnly(9, 5, 0), new TimeOnly(8, 20, 0) },
                    { 30, 3, 30, new TimeOnly(11, 35, 0), new TimeOnly(10, 50, 0) },
                    { 31, 3, 30, new TimeOnly(12, 25, 0), new TimeOnly(11, 40, 0) },
                    { 32, 4, 31, new TimeOnly(8, 15, 0), new TimeOnly(7, 30, 0) },
                    { 33, 4, 31, new TimeOnly(9, 5, 0), new TimeOnly(8, 20, 0) },
                    { 34, 4, 31, new TimeOnly(9, 55, 0), new TimeOnly(9, 10, 0) },
                    { 35, 4, 32, new TimeOnly(10, 45, 0), new TimeOnly(10, 0, 0) },
                    { 36, 4, 32, new TimeOnly(11, 35, 0), new TimeOnly(10, 50, 0) },
                    { 37, 4, 32, new TimeOnly(12, 25, 0), new TimeOnly(11, 40, 0) }
                });

            migrationBuilder.InsertData(
                table: "TblJadwalMengajar",
                columns: new[] { "Id", "MataPelajaranId", "PegawaiId", "RombelId" },
                values: new object[,]
                {
                    { 17, 22, "PJ14-003", 2 },
                    { 19, 23, "PJ18-012", 2 },
                    { 20, 24, "PJ24-002", 2 },
                    { 21, 25, "PJ22-024", 2 },
                    { 29, 26, "PJ23-030", 2 },
                    { 33, 27, "PJ22-024", 2 }
                });

            migrationBuilder.InsertData(
                table: "TblHariMengajar",
                columns: new[] { "Id", "Hari", "JadwalMengajarId", "JamAkhir", "JamMulai" },
                values: new object[,]
                {
                    { 1, 0, 17, new TimeOnly(8, 15, 0), new TimeOnly(7, 30, 0) },
                    { 2, 0, 17, new TimeOnly(9, 5, 0), new TimeOnly(8, 20, 0) },
                    { 5, 0, 19, new TimeOnly(11, 35, 0), new TimeOnly(10, 50, 0) },
                    { 6, 0, 19, new TimeOnly(12, 25, 0), new TimeOnly(11, 40, 0) },
                    { 7, 0, 20, new TimeOnly(13, 45, 0), new TimeOnly(13, 0, 0) },
                    { 8, 0, 20, new TimeOnly(14, 35, 0), new TimeOnly(13, 50, 0) },
                    { 9, 1, 20, new TimeOnly(13, 45, 0), new TimeOnly(13, 0, 0) },
                    { 10, 1, 20, new TimeOnly(14, 35, 0), new TimeOnly(13, 50, 0) },
                    { 11, 1, 21, new TimeOnly(8, 15, 0), new TimeOnly(7, 30, 0) },
                    { 12, 1, 21, new TimeOnly(9, 5, 0), new TimeOnly(8, 20, 0) },
                    { 28, 3, 29, new TimeOnly(9, 55, 0), new TimeOnly(9, 10, 0) },
                    { 29, 3, 29, new TimeOnly(10, 45, 0), new TimeOnly(10, 0, 0) },
                    { 38, 4, 33, new TimeOnly(13, 45, 0), new TimeOnly(12, 30, 0) },
                    { 39, 4, 33, new TimeOnly(14, 35, 0), new TimeOnly(13, 50, 0) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TblHariMengajar",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TblHariMengajar",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TblHariMengajar",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TblHariMengajar",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TblHariMengajar",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TblHariMengajar",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TblHariMengajar",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TblHariMengajar",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TblHariMengajar",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TblHariMengajar",
                keyColumn: "Id",
                keyValue: 10);

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

            migrationBuilder.DeleteData(
                table: "TblHariMengajar",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "TblHariMengajar",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "TblHariMengajar",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "TblHariMengajar",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "TblHariMengajar",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "TblHariMengajar",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "TblHariMengajar",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "TblHariMengajar",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "TblHariMengajar",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "TblHariMengajar",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "TblMataPelajaran",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "TblMataPelajaran",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "TblMataPelajaran",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "TblMataPelajaran",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "TblMataPelajaran",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "TblMataPelajaran",
                keyColumn: "Id",
                keyValue: 27);
        }
    }
}
