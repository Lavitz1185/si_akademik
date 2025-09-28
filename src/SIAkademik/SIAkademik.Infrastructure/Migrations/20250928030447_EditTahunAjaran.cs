using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EditTahunAjaran : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "TanggalMulai",
                table: "TblTahunAjaran",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<DateOnly>(
                name: "TanggalSelesai",
                table: "TblTahunAjaran",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.UpdateData(
                table: "TblTahunAjaran",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "TanggalMulai", "TanggalSelesai" },
                values: new object[] { new DateOnly(2025, 1, 1), new DateOnly(2025, 7, 31) });

            migrationBuilder.UpdateData(
                table: "TblTahunAjaran",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "TanggalMulai", "TanggalSelesai" },
                values: new object[] { new DateOnly(2025, 8, 1), new DateOnly(2025, 12, 31) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TanggalMulai",
                table: "TblTahunAjaran");

            migrationBuilder.DropColumn(
                name: "TanggalSelesai",
                table: "TblTahunAjaran");
        }
    }
}
