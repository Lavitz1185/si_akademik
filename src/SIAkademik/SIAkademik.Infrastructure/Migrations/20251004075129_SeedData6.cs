using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedData6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 16,
                column: "Role",
                value: "GURU");

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 17,
                column: "Role",
                value: "GURU");

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 18,
                column: "Role",
                value: "GURU");

            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "PasswordHash", "Role", "UserName" },
                values: new object[] { 19, "AQAAAAIAAYagAAAAEKXsR8woVHO5DgmyBgmfe5b4I7jeJZYtk71JFY4HkDSCsimeHtIwzOueTyHo8gBH/A==", "Siswa", "252601" });

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
                    "FotoProfil",
                    "GolonganDarah",
                    "Hobi",
                    "HubunganDenganWali",
                    "IjazahSMP",
                    "JenisKelamin",
                    "Jenjang",
                    "JumlahSaudara",
                    "NIKAyah",
                    "NIKIbu",
                    "NIKWali",
                    "NIS",
                    "NISN",
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
                    "PendidikanTerakhirAyah",
                    "PendidikanTerakhirIbu",
                    "PendidikanTerakhirWali",
                    "StatusAktif",
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
                    "AlamatLengkap_KodePos",
                    "AlamatLengkap_Jalan",
                    "AlamatLengkap_RT",
                    "AlamatLengkap_RW",
                    "AlamatLengkap_KelurahanDesa",
                    "AlamatLengkap_KotaKabupaten",
                    "AlamatLengkap_Kecamatan",
                    "AlamatLengkap_Provinsi",
                },
                values: new object[]
                {
                    3,
                    0,
                    null,
                    null,
                    null,
                    null,
                    null,
                    19,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    1,
                    0,
                    null,
                    null,
                    null,
                    null,
                    "252601",
                    "252601",
                    "Ajesta Winarti Banamtuan",
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
                    0,
                    null,
                    null,
                    null,
                    null,
                    new DateOnly(2010, 5, 10),
                    null,
                    null,
                    null,
                    new DateOnly(2025, 8, 1),
                    "Kupang",
                    null,
                    "",
                    "",
                    0,
                    0,
                    "",
                    "",
                    "",
                    ""
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TblSiswa",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 16,
                column: "Role",
                value: "Siswa");

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 17,
                column: "Role",
                value: "Siswa");

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 18,
                column: "Role",
                value: "Siswa");
        }
    }
}
