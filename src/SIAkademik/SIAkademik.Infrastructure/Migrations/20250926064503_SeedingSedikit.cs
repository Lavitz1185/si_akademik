using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedingSedikit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TblAnggotaRombel",
                columns: new[] { "IdRombel", "IdSiswa", "TanggalKeluar", "TanggalMasuk" },
                values: new object[] { 1, 1, null, new DateOnly(2025, 7, 1) });

            migrationBuilder.InsertData(
                table: "TblMataPelajaran",
                columns: new[] { "Id", "Jenjang", "Nama", "Peminatan" },
                values: new object[] { 1, 0, "Matematika", 0 });

            migrationBuilder.InsertData(
                table: "TblJadwalMengajar",
                columns: new[] { "Id", "MataPelajaranId", "PegawaiId", "RombelId" },
                values: new object[] { 1, 1, "PJ24-003", 1 });

            migrationBuilder.InsertData(
                table: "TblHariMengajar",
                columns: new[] { "Id", "Hari", "JadwalMengajarId", "JamAkhir", "JamMulai" },
                values: new object[,]
                {
                    { 1, 0, 1, new TimeOnly(12, 0, 0), new TimeOnly(7, 0, 0) },
                    { 2, 1, 1, new TimeOnly(12, 0, 0), new TimeOnly(7, 0, 0) },
                    { 3, 2, 1, new TimeOnly(12, 0, 0), new TimeOnly(7, 0, 0) },
                    { 4, 3, 1, new TimeOnly(12, 0, 0), new TimeOnly(7, 0, 0) },
                    { 5, 4, 1, new TimeOnly(12, 0, 0), new TimeOnly(7, 0, 0) },
                    { 6, 5, 1, new TimeOnly(12, 0, 0), new TimeOnly(7, 0, 0) },
                    { 7, 6, 1, new TimeOnly(12, 0, 0), new TimeOnly(7, 0, 0) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TblAnggotaRombel",
                keyColumns: new[] { "IdRombel", "IdSiswa" },
                keyValues: new object[] { 1, 1 });

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
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TblMataPelajaran",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
