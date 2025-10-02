using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ResetSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "TblTahunAjaran",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TblSiswa",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TblMataPelajaran",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TblMataPelajaran",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TblRombel",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TblKelas",
                keyColumn: "Id",
                keyValue: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "PasswordHash", "Role", "UserName" },
                values: new object[] { 3, "AQAAAAIAAYagAAAAEKXsR8woVHO5DgmyBgmfe5b4I7jeJZYtk71JFY4HkDSCsimeHtIwzOueTyHo8gBH/A==", "Siswa", "0044710570" });

            migrationBuilder.InsertData(
                table: "TblKelas",
                columns: new[] { "Id", "Jenjang", "PeminatanId", "TahunAjaranId" },
                values: new object[] { 1, 0, 1, 2 });

            migrationBuilder.InsertData(
                table: "TblMataPelajaran",
                columns: new[] { "Id", "Jenjang", "KKM", "Nama", "PeminatanId" },
                values: new object[,]
                {
                    { 1, 0, 70.0, "Matematika", 1 },
                    { 2, 0, 80.0, "Bahasa Indonesia", 1 }
                });

            migrationBuilder.InsertData(
                table: "TblTahunAjaran",
                columns: new[] { "Id", "Semester", "Tahun", "TanggalMulai", "TanggalSelesai" },
                values: new object[] { 1, 1, 2024, new DateOnly(2025, 1, 1), new DateOnly(2025, 7, 31) });

            migrationBuilder.InsertData(
                table: "TblRombel",
                columns: new[] { "Id", "KelasId", "Nama", "WaliId" },
                values: new object[] { 1, 1, "A", "PJ24-003" });

            migrationBuilder.InsertData(
                table: "TblSiswa",
                columns: new[] { "Id", "Agama", "AgamaAyah", "AgamaIbu", "AgamaWali", "AktaKelahiran", "AnakKe", "AppUserId", "AsalSekolah", "BeratBadan", "Email", "GolonganDarah", "Hobi", "HubunganDenganWali", "JenisKelamin", "JumlahSaudara", "NIKAyah", "NIKIbu", "NIKWali", "NIS", "NISN", "Nama", "NamaAyah", "NamaIbu", "NamaWali", "NoHP", "NoHPAyah", "NoHPIbu", "NoHPWali", "NomorKartuKeluarga", "NomorKartuPelajar", "PekerjaanAyah", "PekerjaanIbu", "PekerjaanWali", "PeminatanId", "PendidikanTerakhirAyah", "PendidikanTerakhirIbu", "PendidikanTerakhirWali", "StatusAktif", "StatusHidupAyah", "StatusHidupIbu", "StatusHidupWali", "Suku", "TanggalLahir", "TanggalLahirAyah", "TanggalLahirIbu", "TanggalLahirWali", "TanggalMasuk", "TempatLahir", "TinggiBadan" },
                values: new object[] { 1, 1, null, null, null, null, null, 3, null, null, null, null, null, null, 0, null, null, null, null, "123456", "0044710570", "OSWALDUS PUTRA FERNANDO", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 0, null, null, null, null, new DateOnly(2004, 10, 14), null, null, null, new DateOnly(2025, 1, 1), "Makassar", null });

            migrationBuilder.InsertData(
                table: "TblAnggotaRombel",
                columns: new[] { "IdRombel", "IdSiswa", "TanggalKeluar", "TanggalMasuk" },
                values: new object[] { 1, 1, null, new DateOnly(2025, 7, 1) });

            migrationBuilder.InsertData(
                table: "TblJadwalMengajar",
                columns: new[] { "Id", "MataPelajaranId", "PegawaiId", "RombelId" },
                values: new object[,]
                {
                    { 1, 1, "PJ24-003", 1 },
                    { 2, 2, "PJ24-003", 1 }
                });

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
                    { 6, 0, 2, new TimeOnly(16, 0, 0), new TimeOnly(13, 0, 0) },
                    { 7, 1, 2, new TimeOnly(16, 0, 0), new TimeOnly(13, 0, 0) },
                    { 8, 2, 2, new TimeOnly(16, 0, 0), new TimeOnly(13, 0, 0) },
                    { 9, 3, 2, new TimeOnly(16, 0, 0), new TimeOnly(13, 0, 0) },
                    { 10, 4, 2, new TimeOnly(16, 0, 0), new TimeOnly(13, 0, 0) }
                });

            migrationBuilder.InsertData(
                table: "TblPertemuan",
                columns: new[] { "Id", "JadwalMengajarId", "Keterangan", "Nomor", "StatusPertemuan", "TanggalPelaksanaan" },
                values: new object[,]
                {
                    { 1, 1, null, 1, 0, null },
                    { 2, 1, null, 2, 0, null },
                    { 3, 1, null, 3, 0, null },
                    { 4, 1, null, 4, 0, null },
                    { 5, 1, null, 5, 0, null },
                    { 6, 1, null, 6, 0, null },
                    { 7, 1, null, 7, 0, null },
                    { 8, 1, null, 8, 0, null },
                    { 9, 1, null, 9, 0, null },
                    { 10, 1, null, 10, 0, null },
                    { 11, 2, null, 1, 0, null },
                    { 12, 2, null, 2, 0, null },
                    { 13, 2, null, 3, 0, null },
                    { 14, 2, null, 4, 0, null },
                    { 15, 2, null, 5, 0, null },
                    { 16, 2, null, 6, 0, null },
                    { 17, 2, null, 7, 0, null },
                    { 18, 2, null, 8, 0, null },
                    { 19, 2, null, 9, 0, null },
                    { 20, 2, null, 10, 0, null }
                });
        }
    }
}
