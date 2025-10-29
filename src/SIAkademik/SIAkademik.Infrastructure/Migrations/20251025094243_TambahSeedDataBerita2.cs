using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TambahSeedDataBerita2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TblBerita",
                keyColumn: "Id",
                keyValue: 2,
                column: "Tanggal",
                value: new DateOnly(2025, 9, 27));

            migrationBuilder.UpdateData(
                table: "TblBerita",
                keyColumn: "Id",
                keyValue: 3,
                column: "Tanggal",
                value: new DateOnly(2025, 10, 27));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TblBerita",
                keyColumn: "Id",
                keyValue: 2,
                column: "Tanggal",
                value: new DateOnly(2025, 8, 27));

            migrationBuilder.UpdateData(
                table: "TblBerita",
                keyColumn: "Id",
                keyValue: 3,
                column: "Tanggal",
                value: new DateOnly(2025, 8, 27));
        }
    }
}
