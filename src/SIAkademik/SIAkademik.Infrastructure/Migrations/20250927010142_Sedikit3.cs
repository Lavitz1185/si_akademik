using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Sedikit3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TblHariMengajar",
                columns: new[] { "Id", "Hari", "JadwalMengajarId", "JamAkhir", "JamMulai" },
                values: new object[,]
                {
                    { 8, 8, 2, new TimeOnly(16, 0, 0), new TimeOnly(13, 0, 0) },
                    { 9, 9, 2, new TimeOnly(16, 0, 0), new TimeOnly(13, 0, 0) },
                    { 10, 10, 2, new TimeOnly(16, 0, 0), new TimeOnly(13, 0, 0) },
                    { 11, 11, 2, new TimeOnly(16, 0, 0), new TimeOnly(13, 0, 0) },
                    { 12, 12, 2, new TimeOnly(16, 0, 0), new TimeOnly(13, 0, 0) },
                    { 13, 13, 2, new TimeOnly(16, 0, 0), new TimeOnly(13, 0, 0) },
                    { 14, 14, 2, new TimeOnly(16, 0, 0), new TimeOnly(13, 0, 0) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
