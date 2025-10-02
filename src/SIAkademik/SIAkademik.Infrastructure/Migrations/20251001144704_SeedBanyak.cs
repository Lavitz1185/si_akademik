using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedBanyak : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TblMataPelajaran",
                columns: new[] { "Id", "Jenjang", "KKM", "Nama", "PeminatanId" },
                values: new object[,]
                {
                    { 3, 2, 75.0, "Pendidikan Agama dan Budi Pekerti", 1 },
                    { 4, 2, 75.0, "Pendidikan Pancasila dan Kewarganegaraan", 1 },
                    { 5, 2, 75.0, "Bahasa Indonesia", 1 },
                    { 6, 2, 75.0, "Matematika", 1 },
                    { 7, 2, 75.0, "Sejarah Indonesia", 1 },
                    { 8, 2, 75.0, "Bahasa Inggris", 1 },
                    { 9, 2, 75.0, "Seni Budaya", 1 },
                    { 10, 2, 75.0, "Pendidikan Jasmani Olah Raga Kesehatan", 1 }
                });

            migrationBuilder.InsertData(
                table: "TblPeminatan",
                columns: new[] { "Id", "Jenis", "Nama" },
                values: new object[] { 5, 1, "IPA" });

            migrationBuilder.InsertData(
                table: "TblTahunAjaran",
                columns: new[] { "Id", "Semester", "Tahun", "TanggalMulai", "TanggalSelesai" },
                values: new object[] { 3, 0, 2021, new DateOnly(2021, 8, 1), new DateOnly(2021, 12, 31) });

            migrationBuilder.InsertData(
                table: "TblKelas",
                columns: new[] { "Id", "Jenjang", "PeminatanId", "TahunAjaranId" },
                values: new object[] { 2, 2, 5, 3 });

            migrationBuilder.InsertData(
                table: "TblMataPelajaran",
                columns: new[] { "Id", "Jenjang", "KKM", "Nama", "PeminatanId" },
                values: new object[,]
                {
                    { 11, 2, 75.0, "Matematika", 5 },
                    { 12, 2, 75.0, "Fisika", 5 },
                    { 13, 2, 75.0, "Biologi", 5 },
                    { 14, 2, 75.0, "Kimia", 5 },
                    { 15, 2, 75.0, "Pendalaman Minat Matematika", 5 },
                    { 16, 2, 75.0, "Pendalaman Minat Bahasa Inggris", 5 }
                });

            migrationBuilder.InsertData(
                table: "TblRombel",
                columns: new[] { "Id", "KelasId", "Nama", "WaliId" },
                values: new object[] { 2, 2, "A", "PJ17-010" });

            migrationBuilder.InsertData(
                table: "TblAnggotaRombel",
                columns: new[] { "IdRombel", "IdSiswa", "TanggalKeluar", "TanggalMasuk" },
                values: new object[] { 2, 2, null, new DateOnly(2021, 8, 1) });

            migrationBuilder.InsertData(
                table: "TblJadwalMengajar",
                columns: new[] { "Id", "MataPelajaranId", "PegawaiId", "RombelId" },
                values: new object[,]
                {
                    { 3, 3, "PJ17-010", 2 },
                    { 4, 4, "PJ17-010", 2 },
                    { 5, 5, "PJ17-010", 2 },
                    { 6, 6, "PJ17-010", 2 },
                    { 7, 7, "PJ17-010", 2 },
                    { 8, 8, "PJ17-010", 2 },
                    { 9, 9, "PJ17-010", 2 },
                    { 10, 10, "PJ17-010", 2 },
                    { 11, 11, "PJ17-010", 2 },
                    { 12, 12, "PJ17-010", 2 },
                    { 13, 13, "PJ17-010", 2 },
                    { 14, 14, "PJ17-010", 2 },
                    { 15, 15, "PJ17-010", 2 },
                    { 16, 16, "PJ17-010", 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TblAnggotaRombel",
                keyColumns: new[] { "IdRombel", "IdSiswa" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "TblMataPelajaran",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TblMataPelajaran",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TblMataPelajaran",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TblMataPelajaran",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TblMataPelajaran",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TblMataPelajaran",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TblMataPelajaran",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TblMataPelajaran",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "TblMataPelajaran",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "TblMataPelajaran",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "TblMataPelajaran",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "TblMataPelajaran",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "TblMataPelajaran",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "TblMataPelajaran",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "TblRombel",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TblKelas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TblPeminatan",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TblTahunAjaran",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
