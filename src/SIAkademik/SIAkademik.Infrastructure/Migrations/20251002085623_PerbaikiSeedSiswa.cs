using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PerbaikiSeedSiswa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TblSiswa",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "TanggalLahir", "TempatLahir" },
                values: new object[] { new DateOnly(2004, 5, 10), "Kalabahi" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TblSiswa",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "TanggalLahir", "TempatLahir" },
                values: new object[] { new DateOnly(2004, 10, 14), "Makassar" });
        }
    }
}
