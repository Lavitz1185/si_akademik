using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TambahSiswaKelasX : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "PasswordHash", "Role", "UserName" },
                values: new object[,]
                {
                    { 20, "AQAAAAIAAYagAAAAEKXsR8woVHO5DgmyBgmfe5b4I7jeJZYtk71JFY4HkDSCsimeHtIwzOueTyHo8gBH/A==", "Siswa", "252602" },
                    { 21, "AQAAAAIAAYagAAAAEKXsR8woVHO5DgmyBgmfe5b4I7jeJZYtk71JFY4HkDSCsimeHtIwzOueTyHo8gBH/A==", "Siswa", "252603" },
                    { 22, "AQAAAAIAAYagAAAAEKXsR8woVHO5DgmyBgmfe5b4I7jeJZYtk71JFY4HkDSCsimeHtIwzOueTyHo8gBH/A==", "Siswa", "252605" },
                    { 23, "AQAAAAIAAYagAAAAEKXsR8woVHO5DgmyBgmfe5b4I7jeJZYtk71JFY4HkDSCsimeHtIwzOueTyHo8gBH/A==", "Siswa", "252606" },
                    { 24, "AQAAAAIAAYagAAAAEKXsR8woVHO5DgmyBgmfe5b4I7jeJZYtk71JFY4HkDSCsimeHtIwzOueTyHo8gBH/A==", "Siswa", "252607" },
                    { 25, "AQAAAAIAAYagAAAAEKXsR8woVHO5DgmyBgmfe5b4I7jeJZYtk71JFY4HkDSCsimeHtIwzOueTyHo8gBH/A==", "Siswa", "252608" },
                    { 26, "AQAAAAIAAYagAAAAEKXsR8woVHO5DgmyBgmfe5b4I7jeJZYtk71JFY4HkDSCsimeHtIwzOueTyHo8gBH/A==", "Siswa", "252609" },
                    { 27, "AQAAAAIAAYagAAAAEKXsR8woVHO5DgmyBgmfe5b4I7jeJZYtk71JFY4HkDSCsimeHtIwzOueTyHo8gBH/A==", "Siswa", "252610" },
                    { 28, "AQAAAAIAAYagAAAAEKXsR8woVHO5DgmyBgmfe5b4I7jeJZYtk71JFY4HkDSCsimeHtIwzOueTyHo8gBH/A==", "Siswa", "252611" },
                    { 29, "AQAAAAIAAYagAAAAEKXsR8woVHO5DgmyBgmfe5b4I7jeJZYtk71JFY4HkDSCsimeHtIwzOueTyHo8gBH/A==", "Siswa", "252612" },
                    { 30, "AQAAAAIAAYagAAAAEKXsR8woVHO5DgmyBgmfe5b4I7jeJZYtk71JFY4HkDSCsimeHtIwzOueTyHo8gBH/A==", "Siswa", "252613" },
                    { 31, "AQAAAAIAAYagAAAAEKXsR8woVHO5DgmyBgmfe5b4I7jeJZYtk71JFY4HkDSCsimeHtIwzOueTyHo8gBH/A==", "Siswa", "252614" },
                    { 32, "AQAAAAIAAYagAAAAEKXsR8woVHO5DgmyBgmfe5b4I7jeJZYtk71JFY4HkDSCsimeHtIwzOueTyHo8gBH/A==", "Siswa", "252615" },
                    { 33, "AQAAAAIAAYagAAAAEKXsR8woVHO5DgmyBgmfe5b4I7jeJZYtk71JFY4HkDSCsimeHtIwzOueTyHo8gBH/A==", "Siswa", "252616" },
                    { 34, "AQAAAAIAAYagAAAAEKXsR8woVHO5DgmyBgmfe5b4I7jeJZYtk71JFY4HkDSCsimeHtIwzOueTyHo8gBH/A==", "Siswa", "252617" },
                    { 35, "AQAAAAIAAYagAAAAEKXsR8woVHO5DgmyBgmfe5b4I7jeJZYtk71JFY4HkDSCsimeHtIwzOueTyHo8gBH/A==", "Siswa", "252618" },
                    { 36, "AQAAAAIAAYagAAAAEKXsR8woVHO5DgmyBgmfe5b4I7jeJZYtk71JFY4HkDSCsimeHtIwzOueTyHo8gBH/A==", "Siswa", "252619" },
                    { 37, "AQAAAAIAAYagAAAAEKXsR8woVHO5DgmyBgmfe5b4I7jeJZYtk71JFY4HkDSCsimeHtIwzOueTyHo8gBH/A==", "Siswa", "252620" },
                    { 38, "AQAAAAIAAYagAAAAEKXsR8woVHO5DgmyBgmfe5b4I7jeJZYtk71JFY4HkDSCsimeHtIwzOueTyHo8gBH/A==", "Siswa", "252621" },
                    { 39, "AQAAAAIAAYagAAAAEKXsR8woVHO5DgmyBgmfe5b4I7jeJZYtk71JFY4HkDSCsimeHtIwzOueTyHo8gBH/A==", "Siswa", "252622" },
                    { 40, "AQAAAAIAAYagAAAAEKXsR8woVHO5DgmyBgmfe5b4I7jeJZYtk71JFY4HkDSCsimeHtIwzOueTyHo8gBH/A==", "Siswa", "252623" },
                    { 41, "AQAAAAIAAYagAAAAEKXsR8woVHO5DgmyBgmfe5b4I7jeJZYtk71JFY4HkDSCsimeHtIwzOueTyHo8gBH/A==", "Siswa", "252624" },
                    { 42, "AQAAAAIAAYagAAAAEKXsR8woVHO5DgmyBgmfe5b4I7jeJZYtk71JFY4HkDSCsimeHtIwzOueTyHo8gBH/A==", "Siswa", "252625" },
                    { 43, "AQAAAAIAAYagAAAAEKXsR8woVHO5DgmyBgmfe5b4I7jeJZYtk71JFY4HkDSCsimeHtIwzOueTyHo8gBH/A==", "Siswa", "252626" },
                    { 44, "AQAAAAIAAYagAAAAEKXsR8woVHO5DgmyBgmfe5b4I7jeJZYtk71JFY4HkDSCsimeHtIwzOueTyHo8gBH/A==", "Siswa", "252627" },
                    { 45, "AQAAAAIAAYagAAAAEKXsR8woVHO5DgmyBgmfe5b4I7jeJZYtk71JFY4HkDSCsimeHtIwzOueTyHo8gBH/A==", "Siswa", "252628" },
                    { 46, "AQAAAAIAAYagAAAAEKXsR8woVHO5DgmyBgmfe5b4I7jeJZYtk71JFY4HkDSCsimeHtIwzOueTyHo8gBH/A==", "Siswa", "252629" }
                });

            migrationBuilder.InsertData(
                table: "TblSiswa",
                columns:
                [
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
                    "AlamatLengkap_Kecamatan",
                    "AlamatLengkap_KotaKabupaten",
                    "AlamatLengkap_Provinsi",
                ],
                values: new object[,]
                {
                    { 4, 0, null, null, null, null, null, 20, null, null, null, null, null, null, null, null, 0, 0, null, null, null, null, "252602", "252602", "Alfa Alfino Tunbonat", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 0, null, null, null, null, new DateOnly(2010, 1, 1), null, null, null, new DateOnly(2025, 8, 1), "Kupang", null, "", "", 0, 0, "", "", "", "" },
                    { 5, 0, null, null, null, null, null, 21, null, null, null, null, null, null, null, null, 0, 0, null, null, null, null, "252603", "252603", "Alfiko Musa Manekat Duka", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 0, null, null, null, null, new DateOnly(2010, 1, 1), null, null, null, new DateOnly(2025, 8, 1), "Kupang", null , "", "", 0, 0, "", "", "", ""},
                    { 6, 0, null, null, null, null, null, 22, null, null, null, null, null, null, null, null, 1, 0, null, null, null, null, "252605", "252605", "Anastasya Anin", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 0, null, null, null, null, new DateOnly(2010, 1, 1), null, null, null, new DateOnly(2025, 8, 1), "Kupang", null , "", "", 0, 0, "", "", "", ""},
                    { 7, 0, null, null, null, null, null, 23, null, null, null, null, null, null, null, null, 0, 0, null, null, null, null, "252606", "252606", "Aprian Lorenso Bauky", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 0, null, null, null, null, new DateOnly(2010, 1, 1), null, null, null, new DateOnly(2025, 8, 1), "Kupang", null , "", "", 0, 0, "", "", "", ""},
                    { 8, 0, null, null, null, null, null, 24, null, null, null, null, null, null, null, null, 0, 0, null, null, null, null, "252607", "252607", "Aryo Arjuna Ekaputra Bili", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 0, null, null, null, null, new DateOnly(2010, 1, 1), null, null, null, new DateOnly(2025, 8, 1), "Kupang", null , "", "", 0, 0, "", "", "", ""},
                    { 9, 0, null, null, null, null, null, 25, null, null, null, null, null, null, null, null, 0, 0, null, null, null, null, "252608", "252608", "Benediktus G. Araujo", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 0, null, null, null, null, new DateOnly(2010, 1, 1), null, null, null, new DateOnly(2025, 8, 1), "Kupang", null , "", "", 0, 0, "", "", "", ""},
                    { 10, 0, null, null, null, null, null, 26, null, null, null, null, null, null, null, null, 0, 0, null, null, null, null, "252609", "252609", "Brigida Frida Tampani", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 0, null, null, null, null, new DateOnly(2010, 1, 1), null, null, null, new DateOnly(2025, 8, 1), "Kupang", null , "", "", 0, 0, "", "", "", ""},
                    { 11, 0, null, null, null, null, null, 27, null, null, null, null, null, null, null, null, 1, 0, null, null, null, null, "252610", "252610", "Chenaniah Bona Ventura Buling", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 0, null, null, null, null, new DateOnly(2010, 1, 1), null, null, null, new DateOnly(2025, 8, 1), "Kupang", null , "", "", 0, 0, "", "", "", ""},
                    { 12, 0, null, null, null, null, null, 28, null, null, null, null, null, null, null, null, 0, 0, null, null, null, null, "252611", "252611", "Christian Alvaro Ufi", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 0, null, null, null, null, new DateOnly(2010, 1, 1), null, null, null, new DateOnly(2025, 8, 1), "Kupang", null , "", "", 0, 0, "", "", "", ""},
                    { 13, 0, null, null, null, null, null, 29, null, null, null, null, null, null, null, null, 1, 0, null, null, null, null, "252612", "252612", "Cici Novelita Tung Lily", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 0, null, null, null, null, new DateOnly(2010, 1, 1), null, null, null, new DateOnly(2025, 8, 1), "Kupang", null , "", "", 0, 0, "", "", "", ""},
                    { 14, 0, null, null, null, null, null, 30, null, null, null, null, null, null, null, null, 1, 0, null, null, null, null, "252613", "252613", "Deviltha Andini Landupari", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 0, null, null, null, null, new DateOnly(2010, 1, 1), null, null, null, new DateOnly(2025, 8, 1), "Kupang", null , "", "", 0, 0, "", "", "", ""},
                    { 15, 0, null, null, null, null, null, 31, null, null, null, null, null, null, null, null, 0, 0, null, null, null, null, "252614", "252614", "Efranto Mesa", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 0, null, null, null, null, new DateOnly(2010, 1, 1), null, null, null, new DateOnly(2025, 8, 1), "Kupang", null , "", "", 0, 0, "", "", "", ""},
                    { 16, 0, null, null, null, null, null, 32, null, null, null, null, null, null, null, null, 1, 0, null, null, null, null, "252615", "252615", "Gracia Prita Pandie", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 0, null, null, null, null, new DateOnly(2010, 1, 1), null, null, null, new DateOnly(2025, 8, 1), "Kupang", null , "", "", 0, 0, "", "", "", ""},
                    { 17, 0, null, null, null, null, null, 33, null, null, null, null, null, null, null, null, 0, 0, null, null, null, null, "252616", "252616", "Guenerva Kristivan Pieter Tauk", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 0, null, null, null, null, new DateOnly(2010, 1, 1), null, null, null, new DateOnly(2025, 8, 1), "Kupang", null , "", "", 0, 0, "", "", "", ""},
                    { 18, 0, null, null, null, null, null, 34, null, null, null, null, null, null, null, null, 0, 0, null, null, null, null, "252617", "252617", "Helder Yahya Lopes Beka", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 0, null, null, null, null, new DateOnly(2010, 1, 1), null, null, null, new DateOnly(2025, 8, 1), "Kupang", null , "", "", 0, 0, "", "", "", ""},
                    { 19, 0, null, null, null, null, null, 35, null, null, null, null, null, null, null, null, 1, 0, null, null, null, null, "252618", "252618", "Jenesty Elbitry Appu", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 0, null, null, null, null, new DateOnly(2010, 1, 1), null, null, null, new DateOnly(2025, 8, 1), "Kupang", null , "", "", 0, 0, "", "", "", ""},
                    { 20, 0, null, null, null, null, null, 36, null, null, null, null, null, null, null, null, 1, 0, null, null, null, null, "252619", "252619", "Kesyia Jetika Humsibu", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 0, null, null, null, null, new DateOnly(2010, 1, 1), null, null, null, new DateOnly(2025, 8, 1), "Kupang", null , "", "", 0, 0, "", "", "", ""},
                    { 21, 0, null, null, null, null, null, 37, null, null, null, null, null, null, null, null, 1, 0, null, null, null, null, "252620", "252620", "Lady Grace Julius", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 0, null, null, null, null, new DateOnly(2010, 1, 1), null, null, null, new DateOnly(2025, 8, 1), "Kupang", null , "", "", 0, 0, "", "", "", ""},
                    { 22, 0, null, null, null, null, null, 38, null, null, null, null, null, null, null, null, 0, 0, null, null, null, null, "252621", "252621", "Mean Grenaldi Aditia Dawa", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 0, null, null, null, null, new DateOnly(2010, 1, 1), null, null, null, new DateOnly(2025, 8, 1), "Kupang", null , "", "", 0, 0, "", "", "", ""},
                    { 23, 0, null, null, null, null, null, 39, null, null, null, null, null, null, null, null, 1, 0, null, null, null, null, "252622", "252622", "Michelle Paulina Alwara", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 0, null, null, null, null, new DateOnly(2010, 1, 1), null, null, null, new DateOnly(2025, 8, 1), "Kupang", null , "", "", 0, 0, "", "", "", ""},
                    { 24, 0, null, null, null, null, null, 40, null, null, null, null, null, null, null, null, 0, 0, null, null, null, null, "252623", "252623", "Natanael U. T. Ngudang", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 0, null, null, null, null, new DateOnly(2010, 1, 1), null, null, null, new DateOnly(2025, 8, 1), "Kupang", null , "", "", 0, 0, "", "", "", ""},
                    { 25, 0, null, null, null, null, null, 41, null, null, null, null, null, null, null, null, 1, 0, null, null, null, null, "252624", "252624", "Natasia Desta Moto", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 0, null, null, null, null, new DateOnly(2010, 1, 1), null, null, null, new DateOnly(2025, 8, 1), "Kupang", null , "", "", 0, 0, "", "", "", ""},
                    { 26, 0, null, null, null, null, null, 42, null, null, null, null, null, null, null, null, 1, 0, null, null, null, null, "252625", "252625", "Nicholyn Rambu Lunga", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 0, null, null, null, null, new DateOnly(2010, 1, 1), null, null, null, new DateOnly(2025, 8, 1), "Kupang", null , "", "", 0, 0, "", "", "", ""},
                    { 27, 0, null, null, null, null, null, 43, null, null, null, null, null, null, null, null, 1, 0, null, null, null, null, "252626", "252626", "Salomi Meriyanti Bekamau", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 0, null, null, null, null, new DateOnly(2010, 1, 1), null, null, null, new DateOnly(2025, 8, 1), "Kupang", null , "", "", 0, 0, "", "", "", ""},
                    { 28, 0, null, null, null, null, null, 44, null, null, null, null, null, null, null, null, 0, 0, null, null, null, null, "252627", "252627", "Sanjuan Heiland Lado", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 0, null, null, null, null, new DateOnly(2010, 1, 1), null, null, null, new DateOnly(2025, 8, 1), "Kupang", null , "", "", 0, 0, "", "", "", ""},
                    { 29, 0, null, null, null, null, null, 45, null, null, null, null, null, null, null, null, 0, 0, null, null, null, null, "252628", "252628", "Yodirson Dimas Jogoritno Kause", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 0, null, null, null, null, new DateOnly(2010, 1, 1), null, null, null, new DateOnly(2025, 8, 1), "Kupang", null , "", "", 0, 0, "", "", "", ""},
                    { 30, 0, null, null, null, null, null, 46, null, null, null, null, null, null, null, null, 1, 0, null, null, null, null, "252629", "252629", "Zhailla Hiama", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 0, null, null, null, null, new DateOnly(2010, 1, 1), null, null, null, new DateOnly(2025, 8, 1), "Kupang", null, "", "", 0, 0, "", "", "", "" }
                });

            migrationBuilder.InsertData(
                table: "TblAnggotaRombel",
                columns: new[] { "Id", "IdRombel", "IdSiswa", "TanggalKeluar", "TanggalMasuk" },
                values: new object[,]
                {
                    { 3, 1, 4, null, new DateOnly(2025, 8, 1) },
                    { 4, 1, 5, null, new DateOnly(2025, 8, 1) },
                    { 5, 1, 6, null, new DateOnly(2025, 8, 1) },
                    { 6, 1, 7, null, new DateOnly(2025, 8, 1) },
                    { 7, 1, 8, null, new DateOnly(2025, 8, 1) },
                    { 8, 1, 9, null, new DateOnly(2025, 8, 1) },
                    { 9, 1, 10, null, new DateOnly(2025, 8, 1) },
                    { 10, 1, 11, null, new DateOnly(2025, 8, 1) },
                    { 11, 1, 12, null, new DateOnly(2025, 8, 1) },
                    { 12, 1, 13, null, new DateOnly(2025, 8, 1) },
                    { 13, 1, 14, null, new DateOnly(2025, 8, 1) },
                    { 14, 1, 15, null, new DateOnly(2025, 8, 1) },
                    { 15, 1, 16, null, new DateOnly(2025, 8, 1) },
                    { 16, 1, 17, null, new DateOnly(2025, 8, 1) },
                    { 17, 1, 18, null, new DateOnly(2025, 8, 1) },
                    { 18, 1, 19, null, new DateOnly(2025, 8, 1) },
                    { 19, 1, 20, null, new DateOnly(2025, 8, 1) },
                    { 20, 1, 21, null, new DateOnly(2025, 8, 1) },
                    { 21, 1, 22, null, new DateOnly(2025, 8, 1) },
                    { 22, 1, 23, null, new DateOnly(2025, 8, 1) },
                    { 23, 1, 24, null, new DateOnly(2025, 8, 1) },
                    { 24, 1, 25, null, new DateOnly(2025, 8, 1) },
                    { 25, 1, 26, null, new DateOnly(2025, 8, 1) },
                    { 26, 1, 27, null, new DateOnly(2025, 8, 1) },
                    { 27, 1, 28, null, new DateOnly(2025, 8, 1) },
                    { 28, 1, 29, null, new DateOnly(2025, 8, 1) },
                    { 29, 1, 30, null, new DateOnly(2025, 8, 1) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "TblSiswa",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TblSiswa",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TblSiswa",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TblSiswa",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TblSiswa",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TblSiswa",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TblSiswa",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "TblSiswa",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "TblSiswa",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "TblSiswa",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "TblSiswa",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "TblSiswa",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "TblSiswa",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "TblSiswa",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "TblSiswa",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "TblSiswa",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "TblSiswa",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "TblSiswa",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "TblSiswa",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "TblSiswa",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "TblSiswa",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "TblSiswa",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "TblSiswa",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "TblSiswa",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "TblSiswa",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "TblSiswa",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "TblSiswa",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 46);
        }
    }
}
