using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedPegawai : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "PasswordHash", "Role", "UserName" },
                values: new object[,]
                {
                    { 4, "AQAAAAIAAYagAAAAEKXsR8woVHO5DgmyBgmfe5b4I7jeJZYtk71JFY4HkDSCsimeHtIwzOueTyHo8gBH/A==", "GURU", "johanis@pandhegajaya.sch.id" },
                    { 5, "AQAAAAIAAYagAAAAEKXsR8woVHO5DgmyBgmfe5b4I7jeJZYtk71JFY4HkDSCsimeHtIwzOueTyHo8gBH/A==", "GURU", "jeheskia@pandhegajaya.sch.id" },
                    { 6, "AQAAAAIAAYagAAAAEKXsR8woVHO5DgmyBgmfe5b4I7jeJZYtk71JFY4HkDSCsimeHtIwzOueTyHo8gBH/A==", "GURU", "umbujonas22@gmail.com" },
                    { 7, "AQAAAAIAAYagAAAAEKXsR8woVHO5DgmyBgmfe5b4I7jeJZYtk71JFY4HkDSCsimeHtIwzOueTyHo8gBH/A==", "GURU", "nerlanemu@pandhegajaya.sch.id" },
                    { 8, "AQAAAAIAAYagAAAAEKXsR8woVHO5DgmyBgmfe5b4I7jeJZYtk71JFY4HkDSCsimeHtIwzOueTyHo8gBH/A==", "GURU", "yefrykuafeu@gmail.com" },
                    { 9, "AQAAAAIAAYagAAAAEKXsR8woVHO5DgmyBgmfe5b4I7jeJZYtk71JFY4HkDSCsimeHtIwzOueTyHo8gBH/A==", "GURU", "landoseran99@gmail.com" },
                    { 10, "AQAAAAIAAYagAAAAEKXsR8woVHO5DgmyBgmfe5b4I7jeJZYtk71JFY4HkDSCsimeHtIwzOueTyHo8gBH/A==", "GURU", "ellapandie@gmail.com" },
                    { 11, "AQAAAAIAAYagAAAAEKXsR8woVHO5DgmyBgmfe5b4I7jeJZYtk71JFY4HkDSCsimeHtIwzOueTyHo8gBH/A==", "GURU", "lindajanitaa@gmail.com" },
                    { 12, "AQAAAAIAAYagAAAAEKXsR8woVHO5DgmyBgmfe5b4I7jeJZYtk71JFY4HkDSCsimeHtIwzOueTyHo8gBH/A==", "GURU", "sofiablegur14@gmail.com" },
                    { 13, "AQAAAAIAAYagAAAAEKXsR8woVHO5DgmyBgmfe5b4I7jeJZYtk71JFY4HkDSCsimeHtIwzOueTyHo8gBH/A==", "GURU", "putrolas@gmail.com" }
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
                values: new object[,]
                {
                    {
                        "PJ18-012",
                        0,
                        null,
                        1,
                        "etymissa0703@gmail.com",
                        0,
                        4,
                        1,
                        "5371044703890005",
                        "Ety Jelly Missa, S.Pd",
                        "etyjelly",
                        "085238664779",
                        "2502791721 (BANK NTT)",
                        1,
                        new DateOnly(1989, 3, 7),
                        new DateOnly(2018, 7, 1),
                        "Kimadale",
                        "",
                        "Jln. El Tari",
                        17,
                        7,
                        "Kelurahan Naikoten Satu",
                        "Kota Raja",
                        "Kota Kupang",
                        "NTT",
                    },
                    {
                        "PJ22-026",
                        0,
                        null,
                        1,
                        "sndymeha55@gmail.com",
                        0,
                        9,
                        1,
                        "5311034607030002",
                        "Sindi Pala Meha",
                        "sndy_meha",
                        "083147694407",
                        "0245-01-087347-50-8 (BRI)",
                        1,
                        new DateOnly(2003, 7, 6),
                        new DateOnly(2022, 7, 1),
                        "Lewa",
                        "",
                        "Lewa",
                        7,
                        3,
                        "Kelurahan Kambuhapang",
                        "Lewa",
                        "Kabupaten Sumba Timur",
                        "NTT",
                    },
                    {
                        "PJ14-004",
                        0,
                        4,
                        1,
                        "johanis@pandhegajaya.sch.id",
                        0,
                        2,
                        0,
                        "5371041807900001",
                        "Johanis Oenunu, S.Si., M.M",
                        "jo_oenunu1807",
                        "081353624462",
                        "3140785155 (BCA)",
                        1,
                        new DateOnly(1990, 7, 18),
                        new DateOnly(2014, 7, 1),
                        "Naikliu",
                        "",
                        "Jln. Gereja Moria",
                        47,
                        6,
                        "Kelurahan Liliba",
                        "Oebobo",
                        "Kota Kupang",
                        "NTT",
                    },
                    {
                        "PJ14-005",
                        0,
                        5,
                        1,
                        "jeheskia@pandhegajaya.sch.id",
                        0,
                        3,
                        0,
                        "5301081205780003",
                        "Jeheskia Ngadirun, S.Th",
                        "",
                        "082341108745",
                        "7830-01-008243-53-7 (BRI)",
                        1,
                        new DateOnly(1978, 5, 12),
                        new DateOnly(2014, 7, 1),
                        "Lampung",
                        "",
                        "Oelnasi",
                        17,
                        0,
                        "Desa Oelnasi",
                        "Kupang Tengah",
                        "Kabupaten Kupang",
                        "NTT",
                    },
                    {
                        "PJ18-013",
                        0,
                        6,
                        1,
                        "umbujonas22@gmail.com",
                        0,
                        5,
                        0,
                        "5311042206910004",
                        "Yonas Jangga Ratu, S.Pd., Gr",
                        "umbu_joven",
                        "082339282852",
                        "783001012234538 (BRI)",
                        1,
                        new DateOnly(1991, 6, 22),
                        new DateOnly(2018, 7, 1),
                        "Makamenggit",
                        "",
                        "Padanjara",
                        4,
                        2,
                        "Kelurahan Makamenggit",
                        "Nggaha Ori Angu",
                        "Kabupaten Sumba Timur",
                        "NTT",
                    },
                    {
                        "PJ19-016",
                        0,
                        7,
                        1,
                        "nerlanemu@pandhegajaya.sch.id",
                        0,
                        6,
                        1,
                        "5311046311990001",
                        "Nerlan Konga Emu, S.Pd",
                        "nerlanemu",
                        "085338387302",
                        "2176-01-013590-50-0 (BRI)",
                        1,
                        new DateOnly(1999, 11, 19),
                        new DateOnly(2019, 7, 1),
                        "Barakaraha",
                        "",
                        "Hamalinda",
                        12,
                        6,
                        "Kelurahan Makamenggit",
                        "Nggaha Ori Angu",
                        "Kabupaten Sumba Timur",
                        "NTT",
                    },
                    {
                        "PJ19-017",
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
                    },
                    {
                        "PJ23-030",
                        0,
                        9,
                        1,
                        "landoseran99@gmail.com",
                        0,
                        10,
                        0,
                        "5301081804990001",
                        "Aprilando Mindeas Dibara Seran, S.Si",
                        "landoseran04",
                        "082117516199",
                        "783001019682538",
                        1,
                        new DateOnly(1999, 4, 18),
                        new DateOnly(2023, 7, 1),
                        "Kupang",
                        "",
                        "Oepunu",
                        17,
                        8,
                        "Kelurahan Oelnasi",
                        "Kupang Tengah",
                        "Kabupaten Kupang",
                        "NTT",
                    },
                    {
                        "PJ23-031",
                        0,
                        10,
                        1,
                        "ellapandie@gmail.com",
                        0,
                        11,
                        1,
                        "5371036009980003",
                        "Erika Vera Pandie, S.Pd",
                        "ellaapandie",
                        "081339600327",
                        "348801040709538",
                        1,
                        new DateOnly(1998, 9, 20),
                        new DateOnly(2023, 7, 1),
                        "Kupang",
                        "",
                        "Lasiana",
                        22,
                        5,
                        "Kelurahan Lasiana",
                        "Kelapa Lima",
                        "Kota Kupang",
                        "NTT",
                    },
                    {
                        "PJ24-002",
                        0,
                        11,
                        1,
                        "lindajanitaa@gmail.com",
                        0,
                        12,
                        1,
                        "5314034401010002",
                        "Linda Janita Thine, S.Pd",
                        "lnd8jnt",
                        "082132253251",
                        "361801040770534 (BRI)",
                        1,
                        new DateOnly(2001, 1, 20),
                        new DateOnly(2024, 7, 1),
                        "Oebelo",
                        "",
                        "Lemulik",
                        5,
                        3,
                        "Kelurahan Kuli Aisele",
                        "Lobalain",
                        "Kabupaten Rote Ndao",
                        "NTT",
                    },
                    {
                        "PJ24-004",
                        0,
                        12,
                        1,
                        "sofiablegur14@gmail.com",
                        0,
                        13,
                        1,
                        "5305015406990001",
                        "Sofia Blegur, S.H",
                        "sofia_blegur",
                        "081239270571",
                        "786201008576539 (BRI)",
                        1,
                        new DateOnly(1999, 6, 14),
                        new DateOnly(2024, 7, 1),
                        "Lospalos",
                        "",
                        "Manefeu",
                        2,
                        1,
                        "Kelurahan Baumata Timur",
                        "Taebenu",
                        "Kabupaten Kupang",
                        "NTT",
                    },
                    {
                        "PJ24-005",
                        1,
                        13,
                        1,
                        "putrolas@gmail.com",
                        0,
                        14,
                        0,
                        "5310130609950001",
                        "Paulinus Ferino, S.Pd",
                        "",
                        "082235773372",
                        "467701038760536 (BRI)",
                        1,
                        new DateOnly(1995, 8, 31),
                        new DateOnly(2024, 11, 6),
                        "Watu Wogel",
                        "",
                        "Watuwogel",
                        1,
                        1,
                        "Kelurahan Satar Ruwuk",
                        "Satar Mese Barat",
                        "Kabupaten Manggarai",
                        "NTT",
                    }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TblPegawai",
                keyColumn: "Id",
                keyValue: "PJ14-004");

            migrationBuilder.DeleteData(
                table: "TblPegawai",
                keyColumn: "Id",
                keyValue: "PJ14-005");

            migrationBuilder.DeleteData(
                table: "TblPegawai",
                keyColumn: "Id",
                keyValue: "PJ18-012");

            migrationBuilder.DeleteData(
                table: "TblPegawai",
                keyColumn: "Id",
                keyValue: "PJ18-013");

            migrationBuilder.DeleteData(
                table: "TblPegawai",
                keyColumn: "Id",
                keyValue: "PJ19-016");

            migrationBuilder.DeleteData(
                table: "TblPegawai",
                keyColumn: "Id",
                keyValue: "PJ19-017");

            migrationBuilder.DeleteData(
                table: "TblPegawai",
                keyColumn: "Id",
                keyValue: "PJ22-026");

            migrationBuilder.DeleteData(
                table: "TblPegawai",
                keyColumn: "Id",
                keyValue: "PJ23-030");

            migrationBuilder.DeleteData(
                table: "TblPegawai",
                keyColumn: "Id",
                keyValue: "PJ23-031");

            migrationBuilder.DeleteData(
                table: "TblPegawai",
                keyColumn: "Id",
                keyValue: "PJ24-002");

            migrationBuilder.DeleteData(
                table: "TblPegawai",
                keyColumn: "Id",
                keyValue: "PJ24-004");

            migrationBuilder.DeleteData(
                table: "TblPegawai",
                keyColumn: "Id",
                keyValue: "PJ24-005");

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 13);
        }
    }
}
