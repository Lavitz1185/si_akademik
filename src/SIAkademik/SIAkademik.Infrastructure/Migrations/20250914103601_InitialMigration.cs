using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblDivisi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nama = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblDivisi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblJabatan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nama = table.Column<string>(type: "text", nullable: false),
                    Jenis = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblJabatan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblMataPelajaran",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nama = table.Column<string>(type: "text", nullable: false),
                    Jenjang = table.Column<int>(type: "integer", nullable: false),
                    Peminatan = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblMataPelajaran", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblTahunAjaran",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Periode = table.Column<string>(type: "text", nullable: false),
                    Semester = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblTahunAjaran", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblSiswa",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Nama = table.Column<string>(type: "text", nullable: false),
                    NIS = table.Column<string>(type: "text", nullable: false),
                    JenisKelamin = table.Column<int>(type: "integer", nullable: false),
                    TanggalLahir = table.Column<DateOnly>(type: "date", nullable: false),
                    TempatLahir = table.Column<string>(type: "text", nullable: false),
                    Agama = table.Column<int>(type: "integer", nullable: false),
                    TanggalMasuk = table.Column<DateOnly>(type: "date", nullable: false),
                    Suku = table.Column<string>(type: "text", nullable: true),
                    GolonganDarah = table.Column<int>(type: "integer", nullable: true),
                    TinggiBadan = table.Column<double>(type: "double precision", nullable: true),
                    BeratBadan = table.Column<double>(type: "double precision", nullable: true),
                    Hobi = table.Column<string>(type: "text", nullable: true),
                    NoHP = table.Column<string>(type: "text", nullable: true),
                    JumlahSaudara = table.Column<int>(type: "integer", nullable: true),
                    AnakKe = table.Column<int>(type: "integer", nullable: true),
                    AktaKelahiran = table.Column<string>(type: "text", nullable: true),
                    NomorKartuKeluarga = table.Column<string>(type: "text", nullable: true),
                    NomorKartuPelajar = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    AsalSekolah = table.Column<string>(type: "text", nullable: true),
                    Peminatan = table.Column<int>(type: "integer", nullable: true),
                    NamaAyah = table.Column<string>(type: "text", nullable: true),
                    NIKAyah = table.Column<string>(type: "text", nullable: true),
                    PekerjaanAyah = table.Column<string>(type: "text", nullable: true),
                    AgamaAyah = table.Column<string>(type: "text", nullable: true),
                    NoHPAyah = table.Column<string>(type: "text", nullable: true),
                    TanggalLahirAyah = table.Column<DateOnly>(type: "date", nullable: true),
                    StatusHidupAyah = table.Column<int>(type: "integer", nullable: true),
                    PendidikanTerakhirAyah = table.Column<string>(type: "text", nullable: true),
                    NamaIbu = table.Column<string>(type: "text", nullable: true),
                    NIKIbu = table.Column<string>(type: "text", nullable: true),
                    PekerjaanIbu = table.Column<string>(type: "text", nullable: true),
                    AgamaIbu = table.Column<string>(type: "text", nullable: true),
                    NoHPIbu = table.Column<string>(type: "text", nullable: true),
                    TanggalLahirIbu = table.Column<DateOnly>(type: "date", nullable: true),
                    StatusHidupIbu = table.Column<int>(type: "integer", nullable: true),
                    PendidikanTerakhirIbu = table.Column<string>(type: "text", nullable: true),
                    NamaWali = table.Column<string>(type: "text", nullable: true),
                    NIKWali = table.Column<string>(type: "text", nullable: true),
                    PekerjaanWali = table.Column<string>(type: "text", nullable: true),
                    AgamaWali = table.Column<string>(type: "text", nullable: true),
                    NoHPWali = table.Column<string>(type: "text", nullable: true),
                    TanggalLahirWali = table.Column<DateOnly>(type: "date", nullable: true),
                    StatusHidupWali = table.Column<int>(type: "integer", nullable: true),
                    PendidikanTerakhirWali = table.Column<string>(type: "text", nullable: true),
                    HubunganDenganWali = table.Column<string>(type: "text", nullable: true),
                    AppUserId = table.Column<int>(type: "integer", nullable: false),
                    AlamatLengkap_Jalan = table.Column<string>(type: "text", nullable: false),
                    AlamatLengkap_Kecamatan = table.Column<string>(type: "text", nullable: false),
                    AlamatLengkap_KelurahanDesa = table.Column<string>(type: "text", nullable: false),
                    AlamatLengkap_KodePos = table.Column<string>(type: "text", nullable: false),
                    AlamatLengkap_KotaKabupaten = table.Column<string>(type: "text", nullable: false),
                    AlamatLengkap_Provinsi = table.Column<string>(type: "text", nullable: false),
                    AlamatLengkap_RT = table.Column<int>(type: "integer", nullable: false),
                    AlamatLengkap_RW = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblSiswa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblSiswa_AppUser_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TblPegawai",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Nama = table.Column<string>(type: "text", nullable: false),
                    JenisKelamin = table.Column<int>(type: "integer", nullable: false),
                    Agama = table.Column<int>(type: "integer", nullable: false),
                    TanggalLahir = table.Column<DateOnly>(type: "date", nullable: false),
                    TempatLahir = table.Column<string>(type: "text", nullable: false),
                    StatusPerkawinan = table.Column<int>(type: "integer", nullable: false),
                    NoHP = table.Column<string>(type: "text", nullable: false),
                    GolonganDarah = table.Column<int>(type: "integer", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    TanggalMasuk = table.Column<DateOnly>(type: "date", nullable: false),
                    NIK = table.Column<string>(type: "text", nullable: false),
                    NamaInstagram = table.Column<string>(type: "text", nullable: false),
                    NoRekening = table.Column<string>(type: "text", nullable: false),
                    DivisiId = table.Column<int>(type: "integer", nullable: false),
                    JabatanId = table.Column<int>(type: "integer", nullable: false),
                    AppUserId = table.Column<int>(type: "integer", nullable: true),
                    AlamatKTP_Jalan = table.Column<string>(type: "text", nullable: false),
                    AlamatKTP_Kecamatan = table.Column<string>(type: "text", nullable: false),
                    AlamatKTP_KelurahanDesa = table.Column<string>(type: "text", nullable: false),
                    AlamatKTP_KodePos = table.Column<string>(type: "text", nullable: false),
                    AlamatKTP_KotaKabupaten = table.Column<string>(type: "text", nullable: false),
                    AlamatKTP_Provinsi = table.Column<string>(type: "text", nullable: false),
                    AlamatKTP_RT = table.Column<int>(type: "integer", nullable: false),
                    AlamatKTP_RW = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblPegawai", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblPegawai_AppUser_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TblPegawai_TblDivisi_DivisiId",
                        column: x => x.DivisiId,
                        principalTable: "TblDivisi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblPegawai_TblJabatan_JabatanId",
                        column: x => x.JabatanId,
                        principalTable: "TblJabatan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TblKelas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Jenjang = table.Column<int>(type: "integer", nullable: false),
                    Peminatan = table.Column<int>(type: "integer", nullable: false),
                    TahunAjaranId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblKelas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblKelas_TblTahunAjaran_TahunAjaranId",
                        column: x => x.TahunAjaranId,
                        principalTable: "TblTahunAjaran",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TblRombel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nama = table.Column<string>(type: "text", nullable: false),
                    KelasId = table.Column<int>(type: "integer", nullable: false),
                    WaliId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblRombel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblRombel_TblKelas_KelasId",
                        column: x => x.KelasId,
                        principalTable: "TblKelas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblRombel_TblPegawai_WaliId",
                        column: x => x.WaliId,
                        principalTable: "TblPegawai",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TblAnggotaRombel",
                columns: table => new
                {
                    NISN = table.Column<string>(type: "text", nullable: false),
                    IdRombel = table.Column<int>(type: "integer", nullable: false),
                    TanggalMasuk = table.Column<DateOnly>(type: "date", nullable: false),
                    TanggalKeluar = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblAnggotaRombel", x => new { x.NISN, x.IdRombel });
                    table.ForeignKey(
                        name: "FK_TblAnggotaRombel_TblRombel_IdRombel",
                        column: x => x.IdRombel,
                        principalTable: "TblRombel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblAnggotaRombel_TblSiswa_NISN",
                        column: x => x.NISN,
                        principalTable: "TblSiswa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TblJadwalMengajar",
                columns: table => new
                {
                    NIP = table.Column<string>(type: "text", nullable: false),
                    IdMataPelajaran = table.Column<int>(type: "integer", nullable: false),
                    IdRombel = table.Column<int>(type: "integer", nullable: false),
                    Hari = table.Column<int>(type: "integer", nullable: false),
                    JamMulai = table.Column<TimeOnly>(type: "time without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblJadwalMengajar", x => new { x.NIP, x.IdMataPelajaran, x.IdRombel });
                    table.ForeignKey(
                        name: "FK_TblJadwalMengajar_TblMataPelajaran_IdMataPelajaran",
                        column: x => x.IdMataPelajaran,
                        principalTable: "TblMataPelajaran",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblJadwalMengajar_TblPegawai_NIP",
                        column: x => x.NIP,
                        principalTable: "TblPegawai",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblJadwalMengajar_TblRombel_IdRombel",
                        column: x => x.IdRombel,
                        principalTable: "TblRombel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TblAbsen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Tanggal = table.Column<DateOnly>(type: "date", nullable: false),
                    Absensi = table.Column<int>(type: "integer", nullable: false),
                    Keterangan = table.Column<string>(type: "text", nullable: true),
                    AnggotaRombelNISN = table.Column<string>(type: "text", nullable: false),
                    AnggotaRombelIdRombel = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblAbsen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblAbsen_TblAnggotaRombel_AnggotaRombelNISN_AnggotaRombelId~",
                        columns: x => new { x.AnggotaRombelNISN, x.AnggotaRombelIdRombel },
                        principalTable: "TblAnggotaRombel",
                        principalColumns: new[] { "NISN", "IdRombel" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TblNilai",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Skor = table.Column<double>(type: "double precision", nullable: false),
                    Deskripsi = table.Column<string>(type: "text", nullable: false),
                    Jenis = table.Column<int>(type: "integer", nullable: false),
                    AnggotaRombelNISN = table.Column<string>(type: "text", nullable: false),
                    AnggotaRombelIdRombel = table.Column<int>(type: "integer", nullable: false),
                    JadwalMengajarNIP = table.Column<string>(type: "text", nullable: false),
                    JadwalMengajarIdMataPelajaran = table.Column<int>(type: "integer", nullable: false),
                    JadwalMengajarIdRombel = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblNilai", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblNilai_TblAnggotaRombel_AnggotaRombelNISN_AnggotaRombelId~",
                        columns: x => new { x.AnggotaRombelNISN, x.AnggotaRombelIdRombel },
                        principalTable: "TblAnggotaRombel",
                        principalColumns: new[] { "NISN", "IdRombel" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblNilai_TblJadwalMengajar_JadwalMengajarNIP_JadwalMengajar~",
                        columns: x => new { x.JadwalMengajarNIP, x.JadwalMengajarIdMataPelajaran, x.JadwalMengajarIdRombel },
                        principalTable: "TblJadwalMengajar",
                        principalColumns: new[] { "NIP", "IdMataPelajaran", "IdRombel" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "PasswordHash", "Role", "UserName" },
                values: new object[,]
                {
                    { 1, "AQAAAAIAAYagAAAAEKXsR8woVHO5DgmyBgmfe5b4I7jeJZYtk71JFY4HkDSCsimeHtIwzOueTyHo8gBH/A==", "ADMIN", "Admin" },
                    { 2, "AQAAAAIAAYagAAAAEKXsR8woVHO5DgmyBgmfe5b4I7jeJZYtk71JFY4HkDSCsimeHtIwzOueTyHo8gBH/A==", "GURU", "megalello99@gmail.com" },
                    { 3, "AQAAAAIAAYagAAAAEKXsR8woVHO5DgmyBgmfe5b4I7jeJZYtk71JFY4HkDSCsimeHtIwzOueTyHo8gBH/A==", "Siswa", "0044710570" }
                });

            migrationBuilder.InsertData(
                table: "TblDivisi",
                columns: new[] { "Id", "Nama" },
                values: new object[] { 1, "SMA" });

            migrationBuilder.InsertData(
                table: "TblJabatan",
                columns: new[] { "Id", "Jenis", "Nama" },
                values: new object[] { 1, 0, "Guru Matematika" });

            migrationBuilder.InsertData(
                table: "TblTahunAjaran",
                columns: new[] { "Id", "Periode", "Semester" },
                values: new object[,]
                {
                    { 1, "2024/2025", 1 },
                    { 2, "2024/2025", 0 }
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
                    "PJ24-003",
                    0,
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
                    "123456",
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
                    "",
                    0,
                    0,
                    "",
                    "",
                    "",
                    "",
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblAbsen_AnggotaRombelNISN_AnggotaRombelIdRombel",
                table: "TblAbsen",
                columns: new[] { "AnggotaRombelNISN", "AnggotaRombelIdRombel" });

            migrationBuilder.CreateIndex(
                name: "IX_TblAnggotaRombel_IdRombel",
                table: "TblAnggotaRombel",
                column: "IdRombel");

            migrationBuilder.CreateIndex(
                name: "IX_TblJadwalMengajar_IdMataPelajaran",
                table: "TblJadwalMengajar",
                column: "IdMataPelajaran");

            migrationBuilder.CreateIndex(
                name: "IX_TblJadwalMengajar_IdRombel",
                table: "TblJadwalMengajar",
                column: "IdRombel");

            migrationBuilder.CreateIndex(
                name: "IX_TblKelas_TahunAjaranId",
                table: "TblKelas",
                column: "TahunAjaranId");

            migrationBuilder.CreateIndex(
                name: "IX_TblNilai_AnggotaRombelNISN_AnggotaRombelIdRombel",
                table: "TblNilai",
                columns: new[] { "AnggotaRombelNISN", "AnggotaRombelIdRombel" });

            migrationBuilder.CreateIndex(
                name: "IX_TblNilai_JadwalMengajarNIP_JadwalMengajarIdMataPelajaran_Ja~",
                table: "TblNilai",
                columns: new[] { "JadwalMengajarNIP", "JadwalMengajarIdMataPelajaran", "JadwalMengajarIdRombel" });

            migrationBuilder.CreateIndex(
                name: "IX_TblPegawai_AppUserId",
                table: "TblPegawai",
                column: "AppUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TblPegawai_DivisiId",
                table: "TblPegawai",
                column: "DivisiId");

            migrationBuilder.CreateIndex(
                name: "IX_TblPegawai_JabatanId",
                table: "TblPegawai",
                column: "JabatanId");

            migrationBuilder.CreateIndex(
                name: "IX_TblRombel_KelasId",
                table: "TblRombel",
                column: "KelasId");

            migrationBuilder.CreateIndex(
                name: "IX_TblRombel_WaliId",
                table: "TblRombel",
                column: "WaliId");

            migrationBuilder.CreateIndex(
                name: "IX_TblSiswa_AppUserId",
                table: "TblSiswa",
                column: "AppUserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblAbsen");

            migrationBuilder.DropTable(
                name: "TblNilai");

            migrationBuilder.DropTable(
                name: "TblAnggotaRombel");

            migrationBuilder.DropTable(
                name: "TblJadwalMengajar");

            migrationBuilder.DropTable(
                name: "TblSiswa");

            migrationBuilder.DropTable(
                name: "TblMataPelajaran");

            migrationBuilder.DropTable(
                name: "TblRombel");

            migrationBuilder.DropTable(
                name: "TblKelas");

            migrationBuilder.DropTable(
                name: "TblPegawai");

            migrationBuilder.DropTable(
                name: "TblTahunAjaran");

            migrationBuilder.DropTable(
                name: "AppUser");

            migrationBuilder.DropTable(
                name: "TblDivisi");

            migrationBuilder.DropTable(
                name: "TblJabatan");
        }
    }
}
