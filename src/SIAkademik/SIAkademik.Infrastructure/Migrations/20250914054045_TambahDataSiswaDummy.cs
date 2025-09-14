using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TambahDataSiswaDummy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "PasswordHash", "Role", "UserName" },
                values: new object[] { 3, "AQAAAAIAAYagAAAAEKXsR8woVHO5DgmyBgmfe5b4I7jeJZYtk71JFY4HkDSCsimeHtIwzOueTyHo8gBH/A==", "Siswa", "0044710570" });

            migrationBuilder.InsertData(
                table: "TblSiswa",
                columns: new[]
                {
                    "Id",
                    "Agama",
                    "AgamaAyah",
                    "AgamaIbu",
                    "AgamaWali",
                    "AktaKelahiran",
                    "AnakKe",
                    "AppUserId",
                    "AsalSekolah",
                    "BeratBadan",
                    "Email",
                    "GolonganDarah",
                    "Hobi",
                    "HubunganDenganWali",
                    "JenisKelamin",
                    "JumlahSaudara",
                    "NIKAyah",
                    "NIKIbu",
                    "NIKWali",
                    "Nama",
                    "NamaAyah",
                    "NamaIbu",
                    "NamaWali",
                    "NoHP",
                    "NoHPAyah",
                    "NoHPIbu",
                    "NoHPWali",
                    "NomorKartuKeluarga",
                    "NomorKartuPelajar",
                    "PekerjaanAyah",
                    "PekerjaanIbu",
                    "PekerjaanWali",
                    "Peminatan",
                    "PendidikanTerakhirAyah",
                    "PendidikanTerakhirIbu",
                    "PendidikanTerakhirWali",
                    "StatusHidupAyah",
                    "StatusHidupIbu",
                    "StatusHidupWali",
                    "Suku",
                    "TanggalLahir",
                    "TanggalLahirAyah",
                    "TanggalLahirIbu",
                    "TanggalLahirWali",
                    "TanggalMasuk",
                    "TempatLahir",
                    "TinggiBadan",
                    "AlamatLengkap_Jalan",
                    "AlamatLengkap_RT",
                    "AlamatLengkap_RW",
                    "AlamatLengkap_KelurahanDesa",
                    "AlamatLengkap_Kecamatan",
                    "AlamatLengkap_KotaKabupaten",
                    "AlamatLengkap_Provinsi",
                    "AlamatLengkap_KodePos",
                },
                values: new object[]
                {
                    "0044710570",
                    1,
                    null,
                    null,
                    null,
                    null,
                    null,
                    3,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    0,
                    null,
                    null,
                    null,
                    null,
                    "OSWALDUS PUTRA FERNANDO",
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    new DateOnly(2004, 10, 14),
                    null,
                    null,
                    null,
                    new DateOnly(2025, 1, 1),
                    "Makassar",
                    null,
                    "",
                    0,
                    0,
                    "",
                    "",
                    "",
                    "",
                    "",
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TblSiswa",
                keyColumn: "Id",
                keyValue: "0044710570");

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
