using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedSiswa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "PasswordHash", "Role", "UserName" },
                values: new object[] { 15, "AQAAAAIAAYagAAAAEKXsR8woVHO5DgmyBgmfe5b4I7jeJZYtk71JFY4HkDSCsimeHtIwzOueTyHo8gBH/A==", "Siswa", "0047892929" });

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
                    "PeminatanId",
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
                    "AlamatLengkap_Kecamatan",
                    "AlamatLengkap_KotaKabupaten",
                    "AlamatLengkap_Provinsi",
                },
                values: new object[]
                {
                    2,
                    0,
                    null,
                    null,
                    null,
                    null,
                    null,
                    15,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    1,
                    null,
                    null,
                    null,
                    null,
                    "192005",
                    "0047892929",
                    "Anlidua Lua Hingmadi",
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
                    1,
                    null,
                    null,
                    null,
                    null,
                    new DateOnly(2004, 10, 14),
                    null,
                    null,
                    null,
                    new DateOnly(2019, 8, 1),
                    "Makassar",
                    null,
                    "",
                    "",
                    0,
                    0,
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
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 15);
        }
    }
}
