using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PerbaikiHari : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "TblHariMengajar",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Hari", "JadwalMengajarId", "JamAkhir", "JamMulai" },
                values: new object[] { 0, 2, new TimeOnly(16, 0, 0), new TimeOnly(13, 0, 0) });

            migrationBuilder.UpdateData(
                table: "TblHariMengajar",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Hari", "JadwalMengajarId", "JamAkhir", "JamMulai" },
                values: new object[] { 1, 2, new TimeOnly(16, 0, 0), new TimeOnly(13, 0, 0) });

            migrationBuilder.UpdateData(
                table: "TblHariMengajar",
                keyColumn: "Id",
                keyValue: 8,
                column: "Hari",
                value: 2);

            migrationBuilder.UpdateData(
                table: "TblHariMengajar",
                keyColumn: "Id",
                keyValue: 9,
                column: "Hari",
                value: 3);

            migrationBuilder.UpdateData(
                table: "TblHariMengajar",
                keyColumn: "Id",
                keyValue: 10,
                column: "Hari",
                value: 4);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TblHariMengajar",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Hari", "JadwalMengajarId", "JamAkhir", "JamMulai" },
                values: new object[] { 5, 1, new TimeOnly(12, 0, 0), new TimeOnly(7, 0, 0) });

            migrationBuilder.UpdateData(
                table: "TblHariMengajar",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Hari", "JadwalMengajarId", "JamAkhir", "JamMulai" },
                values: new object[] { 6, 1, new TimeOnly(12, 0, 0), new TimeOnly(7, 0, 0) });

            migrationBuilder.UpdateData(
                table: "TblHariMengajar",
                keyColumn: "Id",
                keyValue: 8,
                column: "Hari",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TblHariMengajar",
                keyColumn: "Id",
                keyValue: 9,
                column: "Hari",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TblHariMengajar",
                keyColumn: "Id",
                keyValue: 10,
                column: "Hari",
                value: 2);

            migrationBuilder.InsertData(
                table: "TblHariMengajar",
                columns: new[] { "Id", "Hari", "JadwalMengajarId", "JamAkhir", "JamMulai" },
                values: new object[,]
                {
                    { 11, 3, 2, new TimeOnly(16, 0, 0), new TimeOnly(13, 0, 0) },
                    { 12, 4, 2, new TimeOnly(16, 0, 0), new TimeOnly(13, 0, 0) },
                    { 13, 5, 2, new TimeOnly(16, 0, 0), new TimeOnly(13, 0, 0) },
                    { 14, 6, 2, new TimeOnly(16, 0, 0), new TimeOnly(13, 0, 0) }
                });
        }
    }
}
