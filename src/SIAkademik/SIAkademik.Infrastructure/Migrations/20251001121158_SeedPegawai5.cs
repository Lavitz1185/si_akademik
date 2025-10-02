using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedPegawai5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "PasswordHash", "Role", "UserName" },
                values: new object[] { 14, "AQAAAAIAAYagAAAAEKXsR8woVHO5DgmyBgmfe5b4I7jeJZYtk71JFY4HkDSCsimeHtIwzOueTyHo8gBH/A==", "GURU", "tupuyane@gmail.com" });

            migrationBuilder.InsertData(
                table: "TblDivisi",
                columns: new[] { "Id", "Nama" },
                values: new object[] { 2, "Pengadaan dan Keuangan" });

            migrationBuilder.InsertData(
                table: "TblJabatan",
                columns: new[] { "Id", "Jenis", "Nama" },
                values: new object[] { 15, 0, "Kordinator Pengadaan dan Keuangan" });

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
                    "AlamatKTP_Provinsi"
                },
                values: new object[]
                {
                    "PJ17-010",
                    0,
                    14,
                    2,
                    "tupuyane@gmail.com",
                    0,
                    15,
                    1,
                    "5371035502890005",
                    "Paulina Yane Tupu, S.Pd",
                    "yane_tupu",
                    "087765193550",
                    "3140924066 (BCA)",
                    1,
                    new DateOnly(1989, 2, 15),
                    new DateOnly(2017, 2, 1),
                    "Waikabubak",
                    "",
                    "Jln. Timor Raya",
                    15,
                    16,
                    "Kelurahan Oesapa",
                    "Kelapa Lima",
                    "Kota Kupang",
                    "NTT",
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TblPegawai",
                keyColumn: "Id",
                keyValue: "PJ17-010");

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "TblDivisi",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TblJabatan",
                keyColumn: "Id",
                keyValue: 15);
        }
    }
}
