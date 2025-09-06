using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TambahDataPegawai3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "PasswordHash", "Role", "UserName" },
                values: new object[] { 2, "AQAAAAIAAYagAAAAEKXsR8woVHO5DgmyBgmfe5b4I7jeJZYtk71JFY4HkDSCsimeHtIwzOueTyHo8gBH/A==", "ADMIN", "megalello99@gmail.com" });

            migrationBuilder.InsertData(
                table: "TblDivisi",
                columns: new[] { "Id", "Nama" },
                values: new object[] { 1, "SMA" });

            migrationBuilder.InsertData(
                table: "TblJabatan",
                columns: new[] { "Id", "Nama" },
                values: new object[] { 1, "Guru Matematika" });

            migrationBuilder.InsertData(
                table: "TblPegawai",
                columns: new[]
                {
                    "Id",
                    "Agama",
                    "AppUserId",
                    "DivisiId",
                    "Email",
                    "GolonganDarah",
                    "JabatanId",
                    "JenisKelamin",
                    "NIK",
                    "Nama",
                    "NamaInstagram",
                    "NoHP",
                    "NoRekening",
                    "StatusPerkawinan",
                    "TanggalLahir",
                    "TanggalMasuk",
                    "TempatLahir",
                    "AlamatKTP_KodePos",
                    "AlamatKTP_Jalan",
                    "AlamatKTP_RT",
                    "AlamatKTP_RW",
                    "AlamatKTP_KelurahanDesa",
                    "AlamatKTP_Kecamatan",
                    "AlamatKTP_KotaKabupaten",
                    "AlamatKTP_Provinsi",
                },
                values: new object[]
                {
                    "PJ24-003",
                    "Kristen Protestan",
                    2,
                    1,
                    "megalello99@gmail.com",
                    0,
                    1,
                    1,
                    "5301086707010008",
                    "Mega Lita A. Lello, S.Pd",
                    "",
                    "081237731427",
                    "169601013554503(BRI)",
                    1,
                    new DateOnly(2001, 7, 27),
                    new DateOnly(2024, 7, 1),
                    "Noelbaki",
                    "",
                    "Noelbaki",
                    37,
                    14,
                    "Kelurahan Noelbaki",
                    "Kupang Tengah",
                    "Kabupaten Kupang",
                    "NTT",
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TblPegawai",
                keyColumn: "Id",
                keyValue: "PJ24-003");

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TblDivisi",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TblJabatan",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
