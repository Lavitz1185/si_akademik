using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedData4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "PasswordHash", "Role", "UserName" },
                values: new object[,]
                {
                    { 16, "AQAAAAIAAYagAAAAEKXsR8woVHO5DgmyBgmfe5b4I7jeJZYtk71JFY4HkDSCsimeHtIwzOueTyHo8gBH/A==", "Siswa", "sam.meha@pandhegajaya.sch.id" },
                    { 17, "AQAAAAIAAYagAAAAEKXsR8woVHO5DgmyBgmfe5b4I7jeJZYtk71JFY4HkDSCsimeHtIwzOueTyHo8gBH/A==", "Siswa", "yunias@pandhegajaya.sch.id" },
                    { 18, "AQAAAAIAAYagAAAAEKXsR8woVHO5DgmyBgmfe5b4I7jeJZYtk71JFY4HkDSCsimeHtIwzOueTyHo8gBH/A==", "Siswa", "dussebotahala02@gmail.com" }
                });

            migrationBuilder.UpdateData(
                table: "TblJabatan",
                keyColumn: "Id",
                keyValue: 7,
                column: "Jenis",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TblPegawai",
                keyColumn: "Id",
                keyValue: "PJ19-017",
                columns: new[]
                {
                    "AppUserId",
                    "Email",
                    "JabatanId",
                    "NIK",
                    "Nama",
                    "NamaInstagram",
                    "NoHP",
                    "NoRekening",
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
                },
                values: new object[]
                {
                    17,
                    "yunias@pandhegajaya.sch.id",
                    7,
                    "5301060607000002",
                    "Yunias Lopes Beka, S.I.Kom",
                    "yuniaslopesbeka",
                    "081339638529",
                    "4677 0104 6004 534 (BRI)",
                    new DateOnly(2000, 7, 6),
                    new DateOnly(2019, 7, 1),
                    "Naibonat",
                    "",
                    "Naibonat",
                    20,
                    7,
                    "Kelurahan Naibonat",
                    "Kupang Timur",
                    "Kabupaten Kupang",
                });

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
                    "PJ22-024",
                    0,
                    8,
                    1,
                    "yefrykuafeu@gmail.com",
                    0,
                    8,
                    0,
                    "5302271707910002",
                    "Yefry O. M. Kuafeu, S.Pd., M.Sc., Gr",
                    "Yefry_kuafeu",
                    "081220042511",
                    "0245-01-087347-50-8 (BRI)",
                    1,
                    new DateOnly(1991, 7, 17),
                    new DateOnly(2022, 7, 1),
                    "Oeleu",
                    "",
                    "Jl. Atambua No. 15",
                    4,
                    2,
                    "Kelurahan Pasir Panjang",
                    "Kota Lama",
                    "Kota Kupang",
                    "NTT",
                });

            migrationBuilder.InsertData(
                table: "TblRombel",
                columns: new[] { "Id", "KelasId", "Nama", "WaliId" },
                values: new object[] { 1, 1, "A", "PJ23-030" });

            migrationBuilder.InsertData(
                table: "TblJadwalMengajar",
                columns: new[] { "Id", "MataPelajaranId", "PegawaiId", "RombelId" },
                values: new object[,]
                {
                    { 18, 18, "PJ24-004", 1 },
                    { 19, 19, "PJ18-012", 1 },
                    { 20, 21, "PJ19-017", 1 },
                    { 21, 22, "PJ14-005", 1 },
                    { 22, 23, "PJ18-013", 1 },
                    { 23, 24, "PJ19-016", 1 },
                    { 25, 26, "PJ19-017", 1 },
                    { 26, 27, "PJ23-030", 1 },
                    { 27, 28, "PJ23-031", 1 },
                    { 28, 29, "PJ23-030", 1 },
                    { 29, 30, "PJ24-005", 1 },
                    { 30, 31, "PJ23-030", 1 },
                    { 31, 32, "PJ23-030", 1 }
                });

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
                values: new object[,]
                {
                {
                        "PJ14-003",
                        0,
                        16,
                        6,
                        "sam.meha@pandhegajaya.sch.id",
                        0,
                        21,
                        0,
                        "5371031811860003",
                        "Samuel Pura Ngunju Meha, S. Pd, M.M",
                        "sam_meha",
                        "081138226931",
                        "3140737291 (BCA)",
                        1,
                        new DateOnly(1986, 11, 18),
                        new DateOnly(2014, 1, 1),
                        "Makamenggit",
                        "",
                        "Jln. Timor Raya",
                        14,
                        5,
                        "Kelurahan Oesapa",
                        "Kelapa Lima",
                        "Kota Kupang",
                        "NTT",
                },
                {
                        "PJ23-029",
                        0,
                        18,
                        1,
                        "dussebotahala02@gmail.com",
                        0,
                        18,
                        1,
                        "5305014209030001",
                        "Dusse Elma Botahala",
                        "deb.yeol_",
                        "081237684620",
                        "350101045896530",
                        1,
                        new DateOnly(2003, 9, 2),
                        new DateOnly(2023, 7, 1),
                        "Fanating",
                        "",
                        "Fanating",
                        1,
                        1,
                        "Kelurahan Fanating",
                        "Teluk Mutiara",
                        "Kabupaten Alor",
                        "NTT",
                }
                });

            migrationBuilder.InsertData(
                table: "TblHariMengajar",
                columns: new[] { "Id", "Hari", "JadwalMengajarId", "JamAkhir", "JamMulai" },
                values: new object[,]
                {
                    { 3, 0, 18, new TimeOnly(9, 55, 0), new TimeOnly(9, 10, 0) },
                    { 4, 0, 18, new TimeOnly(10, 45, 0), new TimeOnly(10, 0, 0) },
                    { 5, 0, 19, new TimeOnly(11, 35, 0), new TimeOnly(10, 50, 0) },
                    { 6, 0, 19, new TimeOnly(12, 25, 0), new TimeOnly(11, 40, 0) },
                    { 7, 1, 20, new TimeOnly(9, 55, 0), new TimeOnly(9, 10, 0) },
                    { 8, 1, 20, new TimeOnly(10, 45, 0), new TimeOnly(10, 0, 0) },
                    { 9, 1, 21, new TimeOnly(11, 35, 0), new TimeOnly(10, 50, 0) },
                    { 10, 1, 21, new TimeOnly(12, 25, 0), new TimeOnly(11, 40, 0) }
                });

            migrationBuilder.InsertData(
                table: "TblJadwalMengajar",
                columns: new[] { "Id", "MataPelajaranId", "PegawaiId", "RombelId" },
                values: new object[,]
                {
                    { 17, 17, "PJ14-003", 1 },
                    { 24, 25, "PJ23-029", 1 }
                });

            migrationBuilder.InsertData(
                table: "TblHariMengajar",
                columns: new[] { "Id", "Hari", "JadwalMengajarId", "JamAkhir", "JamMulai" },
                values: new object[,]
                {
                    { 1, 0, 17, new TimeOnly(8, 15, 0), new TimeOnly(7, 30, 0) },
                    { 2, 0, 17, new TimeOnly(9, 5, 0), new TimeOnly(8, 20, 0) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 17);

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
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "TblPegawai",
                keyColumn: "Id",
                keyValue: "PJ22-024");

            migrationBuilder.DeleteData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "TblPegawai",
                keyColumn: "Id",
                keyValue: "PJ23-029");

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "TblPegawai",
                keyColumn: "Id",
                keyValue: "PJ14-003");

            migrationBuilder.DeleteData(
                table: "TblRombel",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.UpdateData(
                table: "TblJabatan",
                keyColumn: "Id",
                keyValue: 7,
                column: "Jenis",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TblPegawai",
                keyColumn: "Id",
                keyValue: "PJ19-017",
                columns: new[] { "AppUserId", "Email", "JabatanId", "NIK", "Nama", "NamaInstagram", "NoHP", "NoRekening", "TanggalLahir", "TanggalMasuk", "TempatLahir" },
                values: new object[] { 8, "yefrykuafeu@gmail.com", 8, "5302271707910002", "Yefry O. M. Kuafeu, S.Pd., M.Sc., Gr", "Yefry_kuafeu", "081220042511", "0245-01-087347-50-8 (BRI)", new DateOnly(1991, 7, 17), new DateOnly(2022, 7, 1), "Oeleu" });
        }
    }
}
