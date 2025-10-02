using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PerbaikiSeedTahunAjaran : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TblTahunAjaran",
                keyColumn: "Id",
                keyValue: 2,
                column: "TanggalMulai",
                value: new DateOnly(2025, 7, 1));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TblTahunAjaran",
                keyColumn: "Id",
                keyValue: 2,
                column: "TanggalMulai",
                value: new DateOnly(2025, 8, 1));
        }
    }
}
