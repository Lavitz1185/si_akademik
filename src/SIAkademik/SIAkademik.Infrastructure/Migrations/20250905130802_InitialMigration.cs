using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

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
                    Nama = table.Column<string>(type: "text", nullable: false)
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
                    JenisKelamin = table.Column<int>(type: "integer", nullable: false),
                    TanggalLahir = table.Column<DateOnly>(type: "date", nullable: false),
                    TempatLahir = table.Column<string>(type: "text", nullable: false),
                    Agama = table.Column<string>(type: "text", nullable: false),
                    Suku = table.Column<string>(type: "text", nullable: false),
                    AsalSekolah = table.Column<string>(type: "text", nullable: false),
                    GolonganDarah = table.Column<int>(type: "integer", nullable: false),
                    TinggiBadan = table.Column<double>(type: "double precision", nullable: false),
                    BeratBadan = table.Column<double>(type: "double precision", nullable: false),
                    Hobi = table.Column<string>(type: "text", nullable: false),
                    NoHP = table.Column<string>(type: "text", nullable: false),
                    JumlahSaudara = table.Column<int>(type: "integer", nullable: false),
                    AnakKe = table.Column<int>(type: "integer", nullable: false),
                    AktaKelahiran = table.Column<string>(type: "text", nullable: false),
                    NomorKartuKeluarga = table.Column<string>(type: "text", nullable: false),
                    Peminatan = table.Column<int>(type: "integer", nullable: false),
                    NamaAyah = table.Column<string>(type: "text", nullable: false),
                    PekerjaanAyah = table.Column<string>(type: "text", nullable: false),
                    AgamaAyah = table.Column<string>(type: "text", nullable: false),
                    NoHPAyah = table.Column<string>(type: "text", nullable: false),
                    TanggalLahirAyah = table.Column<DateOnly>(type: "date", nullable: false),
                    StatusHidupAyah = table.Column<int>(type: "integer", nullable: false),
                    PendidikanTerakhirAyah = table.Column<string>(type: "text", nullable: false),
                    NamaIbu = table.Column<string>(type: "text", nullable: false),
                    PekerjaanIbu = table.Column<string>(type: "text", nullable: false),
                    AgamaIbu = table.Column<string>(type: "text", nullable: false),
                    NoHPIbu = table.Column<string>(type: "text", nullable: false),
                    TanggalLahirIbu = table.Column<DateOnly>(type: "date", nullable: false),
                    StatusHidupIbu = table.Column<int>(type: "integer", nullable: false),
                    PendidikanTerakhirIbu = table.Column<string>(type: "text", nullable: false),
                    NamaWali = table.Column<string>(type: "text", nullable: true),
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
                    Agama = table.Column<string>(type: "text", nullable: false),
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
                    AppUserId = table.Column<int>(type: "integer", nullable: false),
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
