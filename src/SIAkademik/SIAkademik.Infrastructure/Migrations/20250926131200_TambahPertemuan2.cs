using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TambahPertemuan2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tanggal",
                table: "TblPertemuan");

            migrationBuilder.AddColumn<DateTime>(
                name: "TanggalPelaksanaan",
                table: "TblPertemuan",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.InsertData(
                table: "TblPertemuan",
                columns: new[] { "Id", "JadwalMengajarId", "Keterangan", "Nomor", "StatusPertemuan", "TanggalPelaksanaan" },
                values: new object[,]
                {
                    { 1, 1, "", 1, 0, null },
                    { 2, 1, "", 2, 0, null },
                    { 3, 1, "", 3, 0, null },
                    { 4, 1, "", 4, 0, null },
                    { 5, 1, "", 5, 0, null },
                    { 6, 1, "", 6, 0, null },
                    { 7, 1, "", 7, 0, null },
                    { 8, 1, "", 8, 0, null },
                    { 9, 1, "", 9, 0, null },
                    { 10, 1, "", 10, 0, null }
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

            migrationBuilder.DropColumn(
                name: "TanggalPelaksanaan",
                table: "TblPertemuan");

            migrationBuilder.AddColumn<DateTime>(
                name: "Tanggal",
                table: "TblPertemuan",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
