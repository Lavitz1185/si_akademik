using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedData7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TblAnggotaRombel",
                columns: new[] { "IdRombel", "IdSiswa", "TanggalKeluar", "TanggalMasuk" },
                values: new object[] { 1, 3, null, new DateOnly(2025, 8, 1) });

            migrationBuilder.UpdateData(
                table: "TblSiswa",
                keyColumn: "Id",
                keyValue: 3,
                column: "TanggalLahir",
                value: new DateOnly(2010, 1, 1));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TblAnggotaRombel",
                keyColumns: new[] { "IdRombel", "IdSiswa" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.UpdateData(
                table: "TblSiswa",
                keyColumn: "Id",
                keyValue: 3,
                column: "TanggalLahir",
                value: new DateOnly(2010, 5, 10));
        }
    }
}
