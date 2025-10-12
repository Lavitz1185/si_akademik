using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ResetMigrations : Migration
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
                name: "TblPeminatan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nama = table.Column<string>(type: "text", nullable: false),
                    Jenis = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblPeminatan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblTahunAjaran",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Tahun = table.Column<int>(type: "integer", nullable: false),
                    Semester = table.Column<int>(type: "integer", nullable: false),
                    TanggalMulai = table.Column<DateOnly>(type: "date", nullable: false),
                    TanggalSelesai = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblTahunAjaran", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblSiswa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nama = table.Column<string>(type: "text", nullable: false),
                    NISN = table.Column<string>(type: "text", nullable: false),
                    NIS = table.Column<string>(type: "text", nullable: false),
                    JenisKelamin = table.Column<int>(type: "integer", nullable: false),
                    TanggalLahir = table.Column<DateOnly>(type: "date", nullable: false),
                    TempatLahir = table.Column<string>(type: "text", nullable: false),
                    Agama = table.Column<int>(type: "integer", nullable: false),
                    TanggalMasuk = table.Column<DateOnly>(type: "date", nullable: false),
                    StatusAktif = table.Column<int>(type: "integer", nullable: false),
                    Jenjang = table.Column<int>(type: "integer", nullable: false),
                    Suku = table.Column<string>(type: "text", nullable: true),
                    GolonganDarah = table.Column<int>(type: "integer", nullable: true),
                    TinggiBadan = table.Column<double>(type: "double precision", nullable: true),
                    BeratBadan = table.Column<double>(type: "double precision", nullable: true),
                    Hobi = table.Column<string>(type: "text", nullable: true),
                    NoHP = table.Column<string>(type: "text", nullable: true),
                    JumlahSaudara = table.Column<int>(type: "integer", nullable: true),
                    AnakKe = table.Column<int>(type: "integer", nullable: true),
                    NomorKartuKeluarga = table.Column<string>(type: "text", nullable: true),
                    NomorKartuPelajar = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    AsalSekolah = table.Column<string>(type: "text", nullable: true),
                    AktaKelahiran = table.Column<string>(type: "text", nullable: true),
                    IjazahSMP = table.Column<string>(type: "text", nullable: true),
                    FotoProfil = table.Column<string>(type: "text", nullable: true),
                    NamaAyah = table.Column<string>(type: "text", nullable: true),
                    NIKAyah = table.Column<string>(type: "text", nullable: true),
                    PekerjaanAyah = table.Column<string>(type: "text", nullable: true),
                    AgamaAyah = table.Column<int>(type: "integer", nullable: true),
                    NoHPAyah = table.Column<string>(type: "text", nullable: true),
                    TanggalLahirAyah = table.Column<DateOnly>(type: "date", nullable: true),
                    StatusHidupAyah = table.Column<int>(type: "integer", nullable: true),
                    PendidikanTerakhirAyah = table.Column<string>(type: "text", nullable: true),
                    NamaIbu = table.Column<string>(type: "text", nullable: true),
                    NIKIbu = table.Column<string>(type: "text", nullable: true),
                    PekerjaanIbu = table.Column<string>(type: "text", nullable: true),
                    AgamaIbu = table.Column<int>(type: "integer", nullable: true),
                    NoHPIbu = table.Column<string>(type: "text", nullable: true),
                    TanggalLahirIbu = table.Column<DateOnly>(type: "date", nullable: true),
                    StatusHidupIbu = table.Column<int>(type: "integer", nullable: true),
                    PendidikanTerakhirIbu = table.Column<string>(type: "text", nullable: true),
                    NamaWali = table.Column<string>(type: "text", nullable: true),
                    NIKWali = table.Column<string>(type: "text", nullable: true),
                    PekerjaanWali = table.Column<string>(type: "text", nullable: true),
                    AgamaWali = table.Column<int>(type: "integer", nullable: true),
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
                    FotoProfil = table.Column<string>(type: "text", nullable: true),
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
                name: "TblMataPelajaran",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nama = table.Column<string>(type: "text", nullable: false),
                    KKM = table.Column<double>(type: "double precision", nullable: false),
                    PeminatanId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblMataPelajaran", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblMataPelajaran_TblPeminatan_PeminatanId",
                        column: x => x.PeminatanId,
                        principalTable: "TblPeminatan",
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
                    TahunAjaranId = table.Column<int>(type: "integer", nullable: false),
                    PeminatanId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblKelas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblKelas_TblPeminatan_PeminatanId",
                        column: x => x.PeminatanId,
                        principalTable: "TblPeminatan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblKelas_TblTahunAjaran_TahunAjaranId",
                        column: x => x.TahunAjaranId,
                        principalTable: "TblTahunAjaran",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TblTujuanPembelajaran",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nomor = table.Column<int>(type: "integer", nullable: false),
                    Deskripsi = table.Column<string>(type: "text", nullable: false),
                    Fase = table.Column<int>(type: "integer", nullable: false),
                    MataPelajaranId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblTujuanPembelajaran", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblTujuanPembelajaran_TblMataPelajaran_MataPelajaranId",
                        column: x => x.MataPelajaranId,
                        principalTable: "TblMataPelajaran",
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdSiswa = table.Column<int>(type: "integer", nullable: false),
                    IdRombel = table.Column<int>(type: "integer", nullable: false),
                    TanggalMasuk = table.Column<DateOnly>(type: "date", nullable: false),
                    TanggalKeluar = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblAnggotaRombel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblAnggotaRombel_TblRombel_IdRombel",
                        column: x => x.IdRombel,
                        principalTable: "TblRombel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblAnggotaRombel_TblSiswa_IdSiswa",
                        column: x => x.IdSiswa,
                        principalTable: "TblSiswa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TblJadwalMengajar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PegawaiId = table.Column<string>(type: "text", nullable: false),
                    MataPelajaranId = table.Column<int>(type: "integer", nullable: false),
                    RombelId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblJadwalMengajar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblJadwalMengajar_TblMataPelajaran_MataPelajaranId",
                        column: x => x.MataPelajaranId,
                        principalTable: "TblMataPelajaran",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblJadwalMengajar_TblPegawai_PegawaiId",
                        column: x => x.PegawaiId,
                        principalTable: "TblPegawai",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblJadwalMengajar_TblRombel_RombelId",
                        column: x => x.RombelId,
                        principalTable: "TblRombel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TblAbsenKelas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Tanggal = table.Column<DateOnly>(type: "date", nullable: false),
                    Absensi = table.Column<int>(type: "integer", nullable: false),
                    Catatan = table.Column<string>(type: "text", nullable: false),
                    AnggotaRombelId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblAbsenKelas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblAbsenKelas_TblAnggotaRombel_AnggotaRombelId",
                        column: x => x.AnggotaRombelId,
                        principalTable: "TblAnggotaRombel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AsesmenSumatif",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdTujuanPembelajaran = table.Column<int>(type: "integer", nullable: false),
                    IdJadwalMengajar = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AsesmenSumatif", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AsesmenSumatif_TblJadwalMengajar_IdJadwalMengajar",
                        column: x => x.IdJadwalMengajar,
                        principalTable: "TblJadwalMengajar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AsesmenSumatif_TblTujuanPembelajaran_IdTujuanPembelajaran",
                        column: x => x.IdTujuanPembelajaran,
                        principalTable: "TblTujuanPembelajaran",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TblHariMengajar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Hari = table.Column<int>(type: "integer", nullable: false),
                    JamMulai = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    JamAkhir = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    JadwalMengajarId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblHariMengajar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblHariMengajar_TblJadwalMengajar_JadwalMengajarId",
                        column: x => x.JadwalMengajarId,
                        principalTable: "TblJadwalMengajar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TblPertemuan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nomor = table.Column<int>(type: "integer", nullable: false),
                    TanggalPelaksanaan = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Keterangan = table.Column<string>(type: "text", nullable: true),
                    StatusPertemuan = table.Column<int>(type: "integer", nullable: false),
                    JadwalMengajarId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblPertemuan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblPertemuan_TblJadwalMengajar_JadwalMengajarId",
                        column: x => x.JadwalMengajarId,
                        principalTable: "TblJadwalMengajar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TblRaport",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Predikat = table.Column<string>(type: "text", nullable: false),
                    Nama = table.Column<string>(type: "text", nullable: false),
                    Deskripsi = table.Column<string>(type: "text", nullable: false),
                    KategoriNilai = table.Column<int>(type: "integer", nullable: false),
                    AnggotaRombelId = table.Column<int>(type: "integer", nullable: false),
                    JadwalMengajarId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblRaport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblRaport_TblAnggotaRombel_AnggotaRombelId",
                        column: x => x.AnggotaRombelId,
                        principalTable: "TblAnggotaRombel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblRaport_TblJadwalMengajar_JadwalMengajarId",
                        column: x => x.JadwalMengajarId,
                        principalTable: "TblJadwalMengajar",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TblEvaluasiSiswa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Deskripsi = table.Column<string>(type: "text", nullable: false),
                    Jenis = table.Column<int>(type: "integer", nullable: false),
                    AsesmenSumatifId = table.Column<int>(type: "integer", nullable: false),
                    JadwalMengajarId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblEvaluasiSiswa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblEvaluasiSiswa_AsesmenSumatif_AsesmenSumatifId",
                        column: x => x.AsesmenSumatifId,
                        principalTable: "AsesmenSumatif",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblEvaluasiSiswa_TblJadwalMengajar_JadwalMengajarId",
                        column: x => x.JadwalMengajarId,
                        principalTable: "TblJadwalMengajar",
                        principalColumn: "Id");
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
                    AnggotaRombelId = table.Column<int>(type: "integer", nullable: false),
                    PertemuanId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblAbsen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblAbsen_TblAnggotaRombel_AnggotaRombelId",
                        column: x => x.AnggotaRombelId,
                        principalTable: "TblAnggotaRombel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblAbsen_TblPertemuan_PertemuanId",
                        column: x => x.PertemuanId,
                        principalTable: "TblPertemuan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TblNilaiEvaluasiSiswa",
                columns: table => new
                {
                    IdAnggotaRombel = table.Column<int>(type: "integer", nullable: false),
                    IdEvaluasiSiswa = table.Column<int>(type: "integer", nullable: false),
                    Nilai = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblNilaiEvaluasiSiswa", x => new { x.IdAnggotaRombel, x.IdEvaluasiSiswa });
                    table.ForeignKey(
                        name: "FK_TblNilaiEvaluasiSiswa_TblAnggotaRombel_IdAnggotaRombel",
                        column: x => x.IdAnggotaRombel,
                        principalTable: "TblAnggotaRombel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblNilaiEvaluasiSiswa_TblEvaluasiSiswa_IdEvaluasiSiswa",
                        column: x => x.IdEvaluasiSiswa,
                        principalTable: "TblEvaluasiSiswa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "PasswordHash", "Role", "UserName" },
                values: new object[,]
                {
                    { 1, "AQAAAAIAAYagAAAAEKXsR8woVHO5DgmyBgmfe5b4I7jeJZYtk71JFY4HkDSCsimeHtIwzOueTyHo8gBH/A==", "ADMIN", "Admin" },
                    { 2, "AQAAAAIAAYagAAAAEKXsR8woVHO5DgmyBgmfe5b4I7jeJZYtk71JFY4HkDSCsimeHtIwzOueTyHo8gBH/A==", "GURU", "megalello99@gmail.com" },
                    { 4, "AQAAAAIAAYagAAAAEKXsR8woVHO5DgmyBgmfe5b4I7jeJZYtk71JFY4HkDSCsimeHtIwzOueTyHo8gBH/A==", "GURU", "johanis@pandhegajaya.sch.id" },
                    { 5, "AQAAAAIAAYagAAAAEKXsR8woVHO5DgmyBgmfe5b4I7jeJZYtk71JFY4HkDSCsimeHtIwzOueTyHo8gBH/A==", "GURU", "jeheskia@pandhegajaya.sch.id" },
                    { 6, "AQAAAAIAAYagAAAAEKXsR8woVHO5DgmyBgmfe5b4I7jeJZYtk71JFY4HkDSCsimeHtIwzOueTyHo8gBH/A==", "GURU", "umbujonas22@gmail.com" },
                    { 7, "AQAAAAIAAYagAAAAEKXsR8woVHO5DgmyBgmfe5b4I7jeJZYtk71JFY4HkDSCsimeHtIwzOueTyHo8gBH/A==", "GURU", "nerlanemu@pandhegajaya.sch.id" },
                    { 8, "AQAAAAIAAYagAAAAEKXsR8woVHO5DgmyBgmfe5b4I7jeJZYtk71JFY4HkDSCsimeHtIwzOueTyHo8gBH/A==", "GURU", "yefrykuafeu@gmail.com" },
                    { 9, "AQAAAAIAAYagAAAAEKXsR8woVHO5DgmyBgmfe5b4I7jeJZYtk71JFY4HkDSCsimeHtIwzOueTyHo8gBH/A==", "GURU", "landoseran99@gmail.com" },
                    { 10, "AQAAAAIAAYagAAAAEKXsR8woVHO5DgmyBgmfe5b4I7jeJZYtk71JFY4HkDSCsimeHtIwzOueTyHo8gBH/A==", "GURU", "ellapandie@gmail.com" },
                    { 11, "AQAAAAIAAYagAAAAEKXsR8woVHO5DgmyBgmfe5b4I7jeJZYtk71JFY4HkDSCsimeHtIwzOueTyHo8gBH/A==", "GURU", "lindajanitaa@gmail.com" },
                    { 12, "AQAAAAIAAYagAAAAEKXsR8woVHO5DgmyBgmfe5b4I7jeJZYtk71JFY4HkDSCsimeHtIwzOueTyHo8gBH/A==", "GURU", "sofiablegur14@gmail.com" },
                    { 13, "AQAAAAIAAYagAAAAEKXsR8woVHO5DgmyBgmfe5b4I7jeJZYtk71JFY4HkDSCsimeHtIwzOueTyHo8gBH/A==", "GURU", "putrolas@gmail.com" },
                    { 14, "AQAAAAIAAYagAAAAEKXsR8woVHO5DgmyBgmfe5b4I7jeJZYtk71JFY4HkDSCsimeHtIwzOueTyHo8gBH/A==", "GURU", "tupuyane@gmail.com" },
                    { 15, "AQAAAAIAAYagAAAAEKXsR8woVHO5DgmyBgmfe5b4I7jeJZYtk71JFY4HkDSCsimeHtIwzOueTyHo8gBH/A==", "Siswa", "0047892929" },
                    { 16, "AQAAAAIAAYagAAAAEKXsR8woVHO5DgmyBgmfe5b4I7jeJZYtk71JFY4HkDSCsimeHtIwzOueTyHo8gBH/A==", "GURU", "sam.meha@pandhegajaya.sch.id" },
                    { 17, "AQAAAAIAAYagAAAAEKXsR8woVHO5DgmyBgmfe5b4I7jeJZYtk71JFY4HkDSCsimeHtIwzOueTyHo8gBH/A==", "GURU", "yunias@pandhegajaya.sch.id" },
                    { 18, "AQAAAAIAAYagAAAAEKXsR8woVHO5DgmyBgmfe5b4I7jeJZYtk71JFY4HkDSCsimeHtIwzOueTyHo8gBH/A==", "GURU", "dussebotahala02@gmail.com" },
                    { 19, "AQAAAAIAAYagAAAAEKXsR8woVHO5DgmyBgmfe5b4I7jeJZYtk71JFY4HkDSCsimeHtIwzOueTyHo8gBH/A==", "Siswa", "252601" },
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
                table: "TblDivisi",
                columns: new[] { "Id", "Nama" },
                values: new object[,]
                {
                    { 1, "SMA" },
                    { 2, "Pengadaan dan Keuangan" },
                    { 3, "DPU" },
                    { 4, "HRD" },
                    { 5, "R&D" },
                    { 6, "Yayasan" }
                });

            migrationBuilder.InsertData(
                table: "TblJabatan",
                columns: new[] { "Id", "Jenis", "Nama" },
                values: new object[,]
                {
                    { 1, 0, "Guru Matematika" },
                    { 2, 0, "Kepala Sekolah" },
                    { 3, 0, "Wakil Kepala Bidang Kesiswaan" },
                    { 4, 1, "Kepala Asrama" },
                    { 5, 0, "Guru Honor Olahraga" },
                    { 6, 0, "Wakil Kepala Bidang Kurikulum" },
                    { 7, 0, "Pembina OSIS" },
                    { 8, 0, "Guru Honor Geografi" },
                    { 9, 1, "Karyawan Pengadaan dan Keuangan" },
                    { 10, 0, "Guru Honor Fisika" },
                    { 11, 0, "Guru Honor Bahasa Indonesia" },
                    { 12, 0, "Guru English Center" },
                    { 13, 0, "Guru PPKN" },
                    { 14, 0, "Guru Biologi" },
                    { 15, 0, "Kordinator Pengadaan dan Keuangan" },
                    { 16, 0, "Direktor Sekolah" },
                    { 17, 0, "Guru Honor" },
                    { 18, 0, "Guru Honor Ekonomi" },
                    { 19, 0, "Guru Honor Matematika" },
                    { 20, 0, "Kordinator Operasional dan Kor DPU" },
                    { 21, 0, "Kordinator Sekolah" },
                    { 22, 1, "Karyawan SPV DPU" },
                    { 23, 1, "Karyawan Pengadaan dan Keuangan" },
                    { 24, 1, "Karyawan DPU" },
                    { 25, 1, "Kordinator HRD" },
                    { 26, 1, "Kordinator R&D" },
                    { 27, 1, "Karyawan Dapur" }
                });

            migrationBuilder.InsertData(
                table: "TblPeminatan",
                columns: new[] { "Id", "Jenis", "Nama" },
                values: new object[,]
                {
                    { 1, 0, "Umum" },
                    { 2, 1, "MIPA" },
                    { 3, 1, "IPS" },
                    { 4, 1, "Bahasa" },
                    { 5, 1, "IPA" }
                });

            migrationBuilder.InsertData(
                table: "TblTahunAjaran",
                columns: new[] { "Id", "Semester", "Tahun", "TanggalMulai", "TanggalSelesai" },
                values: new object[,]
                {
                    { 1, 0, 2021, new DateOnly(2021, 8, 1), new DateOnly(2021, 12, 31) },
                    { 2, 0, 2025, new DateOnly(2025, 7, 1), new DateOnly(2025, 12, 31) }
                });

            migrationBuilder.InsertData(
                table: "TblKelas",
                columns: new[] { "Id", "Jenjang", "PeminatanId", "TahunAjaranId" },
                values: new object[,]
                {
                    { 1, 2, 1, 1 },
                    { 2, 0, 5, 2 },
                    { 3, 1, 1, 2 },
                    { 4, 2, 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "TblMataPelajaran",
                columns: new[] { "Id", "KKM", "Nama", "PeminatanId" },
                values: new object[,]
                {
                    { 1, 75.0, "Pendidikan Agama dan Budi Pekerti", 1 },
                    { 2, 75.0, "Pendidikan Pancasila dan Kewarganegaraan", 1 },
                    { 3, 75.0, "Bahasa Indonesia", 1 },
                    { 4, 75.0, "Matematika", 1 },
                    { 5, 75.0, "Sejarah Indonesia", 1 },
                    { 6, 75.0, "Bahasa Inggris", 1 },
                    { 7, 75.0, "Seni Budaya", 1 },
                    { 8, 75.0, "Prakarya dan Kewirausahaan", 1 },
                    { 9, 75.0, "Pendidikan Jasmani Olah Raga Kesehatan", 1 },
                    { 10, 75.0, "Matematika Tingkat Lanjut", 5 },
                    { 11, 75.0, "Fisika", 5 },
                    { 12, 75.0, "Biologi", 5 },
                    { 13, 75.0, "Kimia", 5 },
                    { 14, 75.0, "Pendalaman Minat Matematika", 5 },
                    { 15, 75.0, "Pendalaman Minat Bahasa Inggris", 5 },
                    { 16, 75.0, "Pendidikan Pancasila", 1 },
                    { 17, 75.0, "Coding", 1 },
                    { 18, 75.0, "Sosiologi", 1 },
                    { 19, 75.0, "Ekonomi", 1 },
                    { 20, 75.0, "Geografi", 1 },
                    { 21, 75.0, "Seni Tari, Teater, dan Rupa", 1 }
                });

            migrationBuilder.InsertData(
                table: "TblPegawai",
                columns: new[] { "Id", "Agama", "AppUserId", "DivisiId", "Email", "FotoProfil", "GolonganDarah", "JabatanId", "JenisKelamin", "NIK", "Nama", "NamaInstagram", "NoHP", "NoRekening", "StatusPerkawinan", "TanggalLahir", "TanggalMasuk", "TempatLahir", "AlamatKTP_KodePos", "AlamatKTP_Jalan", "AlamatKTP_RT", "AlamatKTP_RW", "AlamatKTP_KelurahanDesa", "AlamatKTP_Kecamatan", "AlamatKTP_KotaKabupaten", "AlamatKTP_Provinsi" },
                values: new object[,]
                {
                {
                        "PJ14-003",
                        0,
                        16,
                        6,
                        "sam.meha@pandhegajaya.sch.id",
                        null,
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
                        "NTT"

                },
                {
                        "PJ14-004",
                        0,
                        4,
                        1,
                        "johanis@pandhegajaya.sch.id",
                        null,
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
                        null,
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
                        "PJ17-010",
                        0,
                        14,
                        2,
                        "tupuyane@gmail.com",
                        null,
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
                },
                {
                        "PJ18-012",
                        0,
                        null,
                        1,
                        "etymissa0703@gmail.com",
                        null,
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
                        "PJ18-013",
                        0,
                        6,
                        1,
                        "umbujonas22@gmail.com",
                        null,
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
                        null,
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
                        17,
                        1,
                        "yunias@pandhegajaya.sch.id",
                        null,
                        0,
                        7,
                        0,
                        "5301060607000002",
                        "Yunias Lopes Beka, S.I.Kom",
                        "yuniaslopesbeka",
                        "081339638529",
                        "4677 0104 6004 534 (BRI)",
                        1,
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
                        "NTT",
                },
                {
                        "PJ22-024",
                        0,
                        8,
                        1,
                        "yefrykuafeu@gmail.com",
                        null,
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
                        "PJ22-026",
                        0,
                        null,
                        1,
                        "sndymeha55@gmail.com",
                        null,
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
                        "PJ23-029",
                        0,
                        18,
                        1,
                        "dussebotahala02@gmail.com",
                        null,
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
                },
                {
                        "PJ23-030",
                        0,
                        9,
                        1,
                        "landoseran99@gmail.com",
                        null,
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
                        null,
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
                        null,
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
                        "PJ24-003",
                        0,
                        2,
                        1,
                        "megalello99@gmail.com",
                        null,
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
                },
                {
                        "PJ24-004",
                        0,
                        12,
                        1,
                        "sofiablegur14@gmail.com",
                        null,
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
                        null,
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

            migrationBuilder.InsertData(
                table: "TblSiswa",
                columns: new[] { "Id", "Agama", "AgamaAyah", "AgamaIbu", "AgamaWali", "AktaKelahiran", "AnakKe", "AppUserId", "AsalSekolah", "BeratBadan", "Email", "FotoProfil", "GolonganDarah", "Hobi", "HubunganDenganWali", "IjazahSMP", "JenisKelamin", "Jenjang", "JumlahSaudara", "NIKAyah", "NIKIbu", "NIKWali", "NIS", "NISN", "Nama", "NamaAyah", "NamaIbu", "NamaWali", "NoHP", "NoHPAyah", "NoHPIbu", "NoHPWali", "NomorKartuKeluarga", "NomorKartuPelajar", "PekerjaanAyah", "PekerjaanIbu", "PekerjaanWali", "PendidikanTerakhirAyah", "PendidikanTerakhirIbu", "PendidikanTerakhirWali", "StatusAktif", "StatusHidupAyah", "StatusHidupIbu", "StatusHidupWali", "Suku", "TanggalLahir", "TanggalLahirAyah", "TanggalLahirIbu", "TanggalLahirWali", "TanggalMasuk", "TempatLahir", "TinggiBadan", "AlamatLengkap_KodePos", "AlamatLengkap_Jalan", "AlamatLengkap_RT", "AlamatLengkap_RW", "AlamatLengkap_KelurahanDesa", "AlamatLengkap_Kecamatan", "AlamatLengkap_KotaKabupaten", "AlamatLengkap_Provinsi" },
                values: new object[,]
                {
                    { 1, 0, null, null, null, null, null, 15, null, null, null, null, null, null, null, null, 1, 2, null, null, null, null, "192005", "0047892929", "Anlidua Lua Hingmadi", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 1, null, null, null, null, new DateOnly(2004, 5, 10), null, null, null, new DateOnly(2019, 8, 1), "Kalabahi", null, "", "", 0, 0, "", "", "", "" },
                    { 2, 0, null, null, null, null, null, 19, null, null, null, null, null, null, null, null, 1, 0, null, null, null, null, "252601", "252601", "Ajesta Winarti Banamtuan", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 0, null, null, null, null, new DateOnly(2010, 1, 1), null, null, null, new DateOnly(2025, 8, 1), "Kupang", null, "", "", 0, 0, "", "", "", ""  },
                    { 3, 0, null, null, null, null, null, 20, null, null, null, null, null, null, null, null, 0, 0, null, null, null, null, "252602", "252602", "Alfa Alfino Tunbonat", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 0, null, null, null, null, new DateOnly(2010, 1, 1), null, null, null, new DateOnly(2025, 8, 1), "Kupang", null, "", "", 0, 0, "", "", "", "" },
                    { 4, 0, null, null, null, null, null, 21, null, null, null, null, null, null, null, null, 0, 0, null, null, null, null, "252603", "252603", "Alfiko Musa Manekat Duka", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 0, null, null, null, null, new DateOnly(2010, 1, 1), null, null, null, new DateOnly(2025, 8, 1), "Kupang", null, "", "", 0, 0, "", "", "", "" },
                    { 5, 0, null, null, null, null, null, 22, null, null, null, null, null, null, null, null, 1, 0, null, null, null, null, "252605", "252605", "Anastasya Anin", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 0, null, null, null, null, new DateOnly(2010, 1, 1), null, null, null, new DateOnly(2025, 8, 1), "Kupang", null , "", "", 0, 0, "", "", "", "" },
                    { 6, 0, null, null, null, null, null, 23, null, null, null, null, null, null, null, null, 0, 0, null, null, null, null, "252606", "252606", "Aprian Lorenso Bauky", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 0, null, null, null, null, new DateOnly(2010, 1, 1), null, null, null, new DateOnly(2025, 8, 1), "Kupang", null, "", "", 0, 0, "", "", "", "" },
                    { 7, 0, null, null, null, null, null, 24, null, null, null, null, null, null, null, null, 0, 0, null, null, null, null, "252607", "252607", "Aryo Arjuna Ekaputra Bili", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 0, null, null, null, null, new DateOnly(2010, 1, 1), null, null, null, new DateOnly(2025, 8, 1), "Kupang", null, "", "", 0, 0, "", "", "", "" },
                    { 8, 0, null, null, null, null, null, 25, null, null, null, null, null, null, null, null, 0, 0, null, null, null, null, "252608", "252608", "Benediktus G. Araujo", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 0, null, null, null, null, new DateOnly(2010, 1, 1), null, null, null, new DateOnly(2025, 8, 1), "Kupang", null, "", "", 0, 0, "", "", "", "" },
                    { 9, 0, null, null, null, null, null, 26, null, null, null, null, null, null, null, null, 0, 0, null, null, null, null, "252609", "252609", "Brigida Frida Tampani", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 0, null, null, null, null, new DateOnly(2010, 1, 1), null, null, null, new DateOnly(2025, 8, 1), "Kupang", null, "", "", 0, 0, "", "", "", "" },
                    { 10, 0, null, null, null, null, null, 27, null, null, null, null, null, null, null, null, 1, 0, null, null, null, null, "252610", "252610", "Chenaniah Bona Ventura Buling", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 0, null, null, null, null, new DateOnly(2010, 1, 1), null, null, null, new DateOnly(2025, 8, 1), "Kupang", null, "", "", 0, 0, "", "", "", "" },
                    { 11, 0, null, null, null, null, null, 28, null, null, null, null, null, null, null, null, 0, 0, null, null, null, null, "252611", "252611", "Christian Alvaro Ufi", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 0, null, null, null, null, new DateOnly(2010, 1, 1), null, null, null, new DateOnly(2025, 8, 1), "Kupang", null, "", "", 0, 0, "", "", "", "" },
                    { 12, 0, null, null, null, null, null, 29, null, null, null, null, null, null, null, null, 1, 0, null, null, null, null, "252612", "252612", "Cici Novelita Tung Lily", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 0, null, null, null, null, new DateOnly(2010, 1, 1), null, null, null, new DateOnly(2025, 8, 1), "Kupang", null, "", "", 0, 0, "", "", "", "" },
                    { 13, 0, null, null, null, null, null, 30, null, null, null, null, null, null, null, null, 1, 0, null, null, null, null, "252613", "252613", "Deviltha Andini Landupari", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 0, null, null, null, null, new DateOnly(2010, 1, 1), null, null, null, new DateOnly(2025, 8, 1), "Kupang", null, "", "", 0, 0, "", "", "", "" },
                    { 14, 0, null, null, null, null, null, 31, null, null, null, null, null, null, null, null, 0, 0, null, null, null, null, "252614", "252614", "Efranto Mesa", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 0, null, null, null, null, new DateOnly(2010, 1, 1), null, null, null, new DateOnly(2025, 8, 1), "Kupang", null , "", "", 0, 0, "", "", "", "" },
                    { 15, 0, null, null, null, null, null, 32, null, null, null, null, null, null, null, null, 1, 0, null, null, null, null, "252615", "252615", "Gracia Prita Pandie", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 0, null, null, null, null, new DateOnly(2010, 1, 1), null, null, null, new DateOnly(2025, 8, 1), "Kupang", null, "", "", 0, 0, "", "", "", "" },
                    { 16, 0, null, null, null, null, null, 33, null, null, null, null, null, null, null, null, 0, 0, null, null, null, null, "252616", "252616", "Guenerva Kristivan Pieter Tauk", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 0, null, null, null, null, new DateOnly(2010, 1, 1), null, null, null, new DateOnly(2025, 8, 1), "Kupang", null, "", "", 0, 0, "", "", "", "" },
                    { 17, 0, null, null, null, null, null, 34, null, null, null, null, null, null, null, null, 0, 0, null, null, null, null, "252617", "252617", "Helder Yahya Lopes Beka", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 0, null, null, null, null, new DateOnly(2010, 1, 1), null, null, null, new DateOnly(2025, 8, 1), "Kupang", null, "", "", 0, 0, "", "", "", "" },
                    { 18, 0, null, null, null, null, null, 35, null, null, null, null, null, null, null, null, 1, 0, null, null, null, null, "252618", "252618", "Jenesty Elbitry Appu", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 0, null, null, null, null, new DateOnly(2010, 1, 1), null, null, null, new DateOnly(2025, 8, 1), "Kupang", null, "", "", 0, 0, "", "", "", "" },
                    { 19, 0, null, null, null, null, null, 36, null, null, null, null, null, null, null, null, 1, 0, null, null, null, null, "252619", "252619", "Kesyia Jetika Humsibu", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 0, null, null, null, null, new DateOnly(2010, 1, 1), null, null, null, new DateOnly(2025, 8, 1), "Kupang", null, "", "", 0, 0, "", "", "", "" },
                    { 20, 0, null, null, null, null, null, 37, null, null, null, null, null, null, null, null, 1, 0, null, null, null, null, "252620", "252620", "Lady Grace Julius", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 0, null, null, null, null, new DateOnly(2010, 1, 1), null, null, null, new DateOnly(2025, 8, 1), "Kupang", null, "", "", 0, 0, "", "", "", "" },
                    { 21, 0, null, null, null, null, null, 38, null, null, null, null, null, null, null, null, 0, 0, null, null, null, null, "252621", "252621", "Mean Grenaldi Aditia Dawa", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 0, null, null, null, null, new DateOnly(2010, 1, 1), null, null, null, new DateOnly(2025, 8, 1), "Kupang", null, "", "", 0, 0, "", "", "", "" },
                    { 22, 0, null, null, null, null, null, 39, null, null, null, null, null, null, null, null, 1, 0, null, null, null, null, "252622", "252622", "Michelle Paulina Alwara", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 0, null, null, null, null, new DateOnly(2010, 1, 1), null, null, null, new DateOnly(2025, 8, 1), "Kupang", null, "", "", 0, 0, "", "", "", "" },
                    { 23, 0, null, null, null, null, null, 40, null, null, null, null, null, null, null, null, 0, 0, null, null, null, null, "252623", "252623", "Natanael U. T. Ngudang", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 0, null, null, null, null, new DateOnly(2010, 1, 1), null, null, null, new DateOnly(2025, 8, 1), "Kupang", null, "", "", 0, 0, "", "", "", "" },
                    { 24, 0, null, null, null, null, null, 41, null, null, null, null, null, null, null, null, 1, 0, null, null, null, null, "252624", "252624", "Natasia Desta Moto", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 0, null, null, null, null, new DateOnly(2010, 1, 1), null, null, null, new DateOnly(2025, 8, 1), "Kupang", null, "", "", 0, 0, "", "", "", "" },
                    { 25, 0, null, null, null, null, null, 42, null, null, null, null, null, null, null, null, 1, 0, null, null, null, null, "252625", "252625", "Nicholyn Rambu Lunga", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 0, null, null, null, null, new DateOnly(2010, 1, 1), null, null, null, new DateOnly(2025, 8, 1), "Kupang", null, "", "", 0, 0, "", "", "", "" },
                    { 26, 0, null, null, null, null, null, 43, null, null, null, null, null, null, null, null, 1, 0, null, null, null, null, "252626", "252626", "Salomi Meriyanti Bekamau", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 0, null, null, null, null, new DateOnly(2010, 1, 1), null, null, null, new DateOnly(2025, 8, 1), "Kupang", null, "", "", 0, 0, "", "", "", "" },
                    { 27, 0, null, null, null, null, null, 44, null, null, null, null, null, null, null, null, 0, 0, null, null, null, null, "252627", "252627", "Sanjuan Heiland Lado", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 0, null, null, null, null, new DateOnly(2010, 1, 1), null, null, null, new DateOnly(2025, 8, 1), "Kupang", null, "", "", 0, 0, "", "", "", "" },
                    { 28, 0, null, null, null, null, null, 45, null, null, null, null, null, null, null, null, 0, 0, null, null, null, null, "252628", "252628", "Yodirson Dimas Jogoritno Kause", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 0, null, null, null, null, new DateOnly(2010, 1, 1), null, null, null, new DateOnly(2025, 8, 1), "Kupang", null, "", "", 0, 0, "", "", "", "" },
                    { 29, 0, null, null, null, null, null, 46, null, null, null, null, null, null, null, null, 1, 0, null, null, null, null, "252629", "252629", "Zhailla Hiama", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 0, null, null, null, null, new DateOnly(2010, 1, 1), null, null, null, new DateOnly(2025, 8, 1), "Kupang", null, "", "", 0, 0, "", "", "", ""  }
                });

            migrationBuilder.InsertData(
                table: "TblRombel",
                columns: new[] { "Id", "KelasId", "Nama", "WaliId" },
                values: new object[,]
                {
                    { 1, 1, "A", "PJ17-010" },
                    { 2, 2, "A", "PJ22-024" },
                    { 3, 3, "A", "PJ24-004" },
                    { 4, 3, "B", "PJ18-013" },
                    { 5, 4, "A", "PJ19-017" },
                    { 6, 4, "B", "PJ23-031" }
                });

            migrationBuilder.InsertData(
                table: "TblTujuanPembelajaran",
                columns: new[] { "Id", "Deskripsi", "Fase", "MataPelajaranId", "Nomor" },
                values: new object[,]
                {
                    { 1, "Memahami arti dewasa secara fisik, intelektual, emosional, sosial, moral dan spiritual", 0, 1, 1 },
                    { 2, "Memahami secara kritis perkembangan kebudayaan, ilmu pengetahuan dan tehnologi sebagai anugerah Allah.", 1, 1, 1 },
                    { 3, "Menganalisis cara pandang para pendiri negara tentang dasar negara", 0, 2, 1 },
                    { 4, "Mendeskripsikan rumusan dan keterkaitan sila-sila dalam Pancasila", 1, 2, 1 },
                    { 5, "Memahami dan menganalisis gagasan teks, makna kata, dan informasi faktual yang dibaca untuk dapat dievaluasi keakuratan informasinya. (menyimak dan membaca)", 0, 3, 1 },
                    { 6, "Mengidentifikasi ide pokok dan pendukung teks yang dibaca serta menulis opini untuk berbagai tujuan secara logis, kritis, dan kreatif.", 1, 3, 1 },
                    { 7, "Menggeneralisasi sifat-sifat bilangan berpangkat", 0, 4, 1 },
                    { 8, "Memodelkan pinjaman dan investasi dengan bunga majemuk dan anuitas.", 1, 4, 1 },
                    { 9, "Memahami konsep-konsep dasar ilmu sejarah yaitu: manusia, ruang, waktu, diakronik (kronologi), sinkronik, dan penelitian sejarah", 0, 5, 1 },
                    { 10, "Memahami berbagai peristiwa sejarah pada masa penjajahan bangsa barat.", 1, 5, 1 },
                    { 11, "Menggunakan bahasa Inggris untuk memproduksi teks deskripsi lisan, tulisan, dan visual.", 0, 6, 1 },
                    { 12, "Menganalisis ekspresi di berbagai konteks dalam bentuk percakapan transaksional lisan.", 1, 6, 1 },
                    { 13, "Menggunakan dan mengembangkan unsur-unsur bunyi musik berupa nada, irama, melodi, harmoni, timbre, tempo, dan dinamika menggunakan instrumen atau teknologi yang tersedia", 0, 7, 1 },
                    { 14, "Memahami bunyi musik dan elemen musik dengan melibatkan diri secara aktif.", 1, 7, 1 },
                    { 15, "Menemutunjukkan bahan, alat, teknik, prosedur, dan sistem budidaya produk bernilai ekonomis dari berbagai sumber", 0, 8, 1 },
                    { 16, "Menganalisis potensi internal dan eksternal produk budi daya.", 1, 8, 1 },
                    { 17, "Merancang, menerapkan, dan menghaluskan keterampilan gerak dalam situasi gerak yang menantang.", 0, 9, 1 },
                    { 18, "Merancang, menerapkan, menghaluskan dan mengevaluasi keterampilan gerak spesifik di dalam berbagai situasi gerak yang menantang untuk meningkatkan kinerja gerak.", 1, 9, 1 },
                    { 19, "Melakukan operasi aritmetika pada polinomial (suku banyak), menentukan faktor polinomial, dan menggunakan identitas polinomial untuk menyelesaikan masalah", 1, 10, 1 },
                    { 20, "Mendeskripsikan gejala alam dalam cakupan keterampilan proses dalam pengukuran", 0, 11, 1 },
                    { 21, "Menganalisis konsep gerak menggunakan vektor untuk menjelaskan berbagai fenomena.", 1, 11, 1 },
                    { 22, "Mengidentifikasi jenis-jenis interaksi pada ekosistem dan aliran  energi dalam ekositemual", 0, 12, 1 },
                    { 23, "Memahami struktur sel dan organel sel beserta fungsinya sebagai unit fungsional terintegrasi", 1, 12, 1 },
                    { 24, "Menerapkan  konsep kimia dalam pengelolaan lingkungan termasuk menjelaskan  fenomena pemanasan global", 0, 13, 1 },
                    { 25, "Menganalisis proses terjadinya ikatan kimia dari unsur-unsur pembentuknya dan implikasinya terhadap sifat-sifat fisik senyawa yang dihasilkan.", 1, 13, 1 },
                    { 26, "Menguasai ukuran pemusatan dan penyebaran data yang disajikan dalam bentuk tabel distribusi frekuensi dan histogram", 1, 14, 1 },
                    { 27, "Menguasai perbedaan fungsi sosial struktur teks news item lisan dan tulis dari radio, koran, dan TV", 1, 15, 1 }
                });

            migrationBuilder.InsertData(
                table: "TblAnggotaRombel",
                columns: new[] { "Id", "IdRombel", "IdSiswa", "TanggalKeluar", "TanggalMasuk" },
                values: new object[,]
                {
                    { 1, 1, 1, null, new DateOnly(2021, 8, 1) },
                    { 2, 2, 2, null, new DateOnly(2025, 8, 1) },
                    { 3, 2, 3, null, new DateOnly(2025, 8, 1) },
                    { 4, 2, 4, null, new DateOnly(2025, 8, 1) },
                    { 5, 2, 5, null, new DateOnly(2025, 8, 1) },
                    { 6, 2, 6, null, new DateOnly(2025, 8, 1) },
                    { 7, 2, 7, null, new DateOnly(2025, 8, 1) },
                    { 8, 2, 8, null, new DateOnly(2025, 8, 1) },
                    { 9, 2, 9, null, new DateOnly(2025, 8, 1) },
                    { 10, 2, 10, null, new DateOnly(2025, 8, 1) },
                    { 11, 2, 11, null, new DateOnly(2025, 8, 1) },
                    { 12, 2, 12, null, new DateOnly(2025, 8, 1) },
                    { 13, 2, 13, null, new DateOnly(2025, 8, 1) },
                    { 14, 2, 14, null, new DateOnly(2025, 8, 1) },
                    { 15, 2, 15, null, new DateOnly(2025, 8, 1) },
                    { 16, 2, 16, null, new DateOnly(2025, 8, 1) },
                    { 17, 2, 17, null, new DateOnly(2025, 8, 1) },
                    { 18, 2, 18, null, new DateOnly(2025, 8, 1) },
                    { 19, 2, 19, null, new DateOnly(2025, 8, 1) },
                    { 20, 2, 20, null, new DateOnly(2025, 8, 1) },
                    { 21, 2, 21, null, new DateOnly(2025, 8, 1) },
                    { 22, 2, 22, null, new DateOnly(2025, 8, 1) },
                    { 23, 2, 23, null, new DateOnly(2025, 8, 1) },
                    { 24, 2, 24, null, new DateOnly(2025, 8, 1) },
                    { 25, 2, 25, null, new DateOnly(2025, 8, 1) },
                    { 26, 2, 26, null, new DateOnly(2025, 8, 1) },
                    { 27, 2, 27, null, new DateOnly(2025, 8, 1) },
                    { 28, 2, 28, null, new DateOnly(2025, 8, 1) },
                    { 29, 2, 29, null, new DateOnly(2025, 8, 1) }
                });

            migrationBuilder.InsertData(
                table: "TblJadwalMengajar",
                columns: new[] { "Id", "MataPelajaranId", "PegawaiId", "RombelId" },
                values: new object[,]
                {
                    { 1, 1, "PJ17-010", 1 },
                    { 2, 2, "PJ17-010", 1 },
                    { 3, 3, "PJ17-010", 1 },
                    { 4, 4, "PJ17-010", 1 },
                    { 5, 5, "PJ17-010", 1 },
                    { 6, 6, "PJ17-010", 1 },
                    { 7, 7, "PJ17-010", 1 },
                    { 8, 8, "PJ17-010", 1 },
                    { 9, 9, "PJ17-010", 1 },
                    { 10, 10, "PJ17-010", 1 },
                    { 11, 11, "PJ17-010", 1 },
                    { 12, 12, "PJ17-010", 1 },
                    { 13, 13, "PJ17-010", 1 },
                    { 14, 14, "PJ17-010", 1 },
                    { 15, 15, "PJ17-010", 1 }
                });

            migrationBuilder.InsertData(
                table: "AsesmenSumatif",
                columns: new[] { "Id", "IdJadwalMengajar", "IdTujuanPembelajaran" },
                values: new object[,]
                {
                    { 1, 1, 2 },
                    { 2, 2, 4 },
                    { 3, 3, 6 },
                    { 4, 4, 8 },
                    { 5, 5, 10 },
                    { 6, 6, 12 },
                    { 7, 7, 14 },
                    { 8, 8, 16 },
                    { 9, 9, 18 },
                    { 10, 10, 19 },
                    { 11, 11, 21 },
                    { 12, 12, 23 },
                    { 13, 13, 25 },
                    { 14, 14, 26 },
                    { 15, 15, 27 }
                });

            migrationBuilder.InsertData(
                table: "TblRaport",
                columns: new[] { "Id", "AnggotaRombelId", "Deskripsi", "JadwalMengajarId", "KategoriNilai", "Nama", "Predikat" },
                values: new object[,]
                {
                    { 1, 1, "Anlidua Lua Hingmadi, baik dalam sikap berinisiatif berdoa sebelum-sesudah melakukan kegiatan, baik dalam sikap mengikuit jadwal kegiatan sekolah, baik dalam sikap menolong teman sebaya yang membutuhkan, baik dalam sikap disiplin dalam kelas, baik dalam bertanggung jawab menjaga lingkungan sekolah, baik dalam sikap menjaga hubungan dengan orang lain", null, 0, "Sikap Spiritual", "Baik" },
                    { 2, 1, "Anlidua Lua Hingmadi, baik dalam sikap jujur, baik dalam sikap disiplin, baik dalam sikap tanggungjawab, baik dalam sikap toleransi, baik dalam sikap gotong royong, baik dalam sikap santun, selalu peduli, baik dalam sikap percaya diri, selalu memiliki rasa ingin tahu, baik dalam sikap ramah tamah", null, 0, "Sikap Sosial", "Baik" },
                    { 3, 1, "Aktif dalam ekstrakulikuler Microsoft Word", null, 3, "Microsoft Word", "Memuaskan" },
                    { 4, 1, "Kompetensi pengetahuan sangat baik, sangat menguasai peran dan fungsi pria dan wanita dalam rumah tangga, sangat menguasai peran dan fungsi pria dan wanita dalam rumah tangga, sangat menguasai prinsip dasar pernikahan dan rumah tangga Kristen", 1, 1, "", "A" },
                    { 5, 1, "Kompetensi pengetahuan sangat baik, sangat menguasai perlindungan dan penegakan hukum di Indonesia, menguasai kasus-kasus pelanggaran hak dan pengikaran kewajiban warga negara", 2, 1, "", "A" },
                    { 6, 1, "Kompetensi pengetahuan baik, sangat menguasai teks editorial, cukup menguasai teks lamaran pekerjaan", 3, 1, "", "B" },
                    { 7, 1, "Kompetensi pengetahuan baik, sangat menguasai ukuran pemusatan dan penyebaran data yang disajikan dalam bentuk tabel distribusi frekuensi dan histogram, menguasai jarak dalam ruang", 4, 1, "", "B" },
                    { 8, 1, "Kompetensi pengetahuan baik, sangat menguasai peran dan nilai-nilai perjuangan tokoh nasional dan daerah dalam mempertahankan keutuhan negara, menguasai upaya bangsa indonesia menghadapi ancaman disintegrasi negara", 5, 1, "", "B" },
                    { 9, 1, "Kompetensi pengetahuan baik, sangat menguasai perbedaan fungsi sosial, struktur teks dan kebahasaan dalam teks news item lisan dan tulis dari radio, koran, dan TV, menguasai penerapan fungsi sosial, struktur teks, dan unsur kebahasan teks dalam tindakan menawarkan jasa", 6, 1, "", "B" },
                    { 10, 1, "Kompetensi pengetahuan sangat baik, sangat menguasai teknik menyusun naskah teater kontemporer, sangat menguasai perencangan pemetasan teater kontemporer", 7, 1, "", "A" },
                    { 11, 1, "Kompetensi pengetahuan baik, sangat menguasai sistem produksi kerajinan inovatif sesuai kebutuhan pasar global berdasarkan daya dukung yang dimiliki oleh daerah setempat, sangat menguasai perencanaan usaha kerajinan inovatif berdasarkan kebutuhan pasar global", 8, 1, "", "A" },
                    { 12, 1, "Kompetensi pengetahuan baik, sangat menguasai atletik jalan cepat, lompat tinggi, lari jarak pendek, sangat menguasai permainan bulu tangkis, softball, tenis meja", 9, 1, "", "B" },
                    { 13, 1, "Kompetensi pengetahuan sangat baik, sangat menguasai limit di ketakhinggaan fungsi aljabar dan trigonometri,menguasai limit fungsi trigonometri", 10, 1, "", "B" },
                    { 14, 1, "Kompetensi pengetahuan baik, sangat menguasai rangkaian arus bolak balik, cukup menguasai prinsip kerja peralatan listrik searah", 11, 1, "", "A" },
                    { 15, 1, "Kompetensi pengetahuan sangat baik, sangat menguasai pola-pola hereditas, menguasai pengaruh faktor internal dan faktor eksternal terhadap pertumbuhan dan perkembangan", 12, 1, "", "B" },
                    { 16, 1, "Kompetensi pengetahuan sangat baik, sangat menguasai analisis gejala yang terjadi sel elektrolisis yang digunakan dalam kehidupan, sangat menguasai penyebab adanya fenomena sifat koligatif larutan, dan tekanan osmosis", 13, 1, "", "A" },
                    { 17, 1, "Kompetensi pengetahuan baik, sangat menguasai ukuran pemusatan dan penyebaran data yang disajikan dalam bentuk tabel distribusi frekuensi dan histogram, menguasai jarak dalam ruang", 14, 1, "", "A" },
                    { 18, 1, "Kompetensi pengetahuan baik, sangat menguasai perbedaan fungsi sosial struktur teks news item lisan dan tulis dari radio, koran, dan TV, menguasai penerapan fungsi sosial, struktur teks dan unsur kebahasaan teks dalam tindakan menawarkan jasa", 15, 1, "", "B" },
                    { 19, 1, "Kompetensi pengetahuan sangat baik, sangat menguasai peran dan fungsi pria dan wanita dalam rumah tangga, sangat menguasai peran dan fungsi pria dan wanita dalam rumah tangga, sangat menguasai prinsip dasar pernikahan dan rumah tangga Kristen", 1, 2, "", "A" },
                    { 20, 1, "Kompetensi pengetahuan sangat baik, sangat menguasai perlindungan dan penegakan hukum di Indonesia, menguasai kasus-kasus pelanggaran hak dan pengikaran kewajiban warga negara", 2, 2, "", "A" },
                    { 21, 1, "Kompetensi pengetahuan baik, sangat menguasai teks editorial, cukup menguasai teks lamaran pekerjaan", 3, 2, "", "B" },
                    { 22, 1, "Kompetensi pengetahuan baik, sangat menguasai ukuran pemusatan dan penyebaran data yang disajikan dalam bentuk tabel distribusi frekuensi dan histogram, menguasai jarak dalam ruang", 4, 2, "", "B" },
                    { 23, 1, "Kompetensi pengetahuan baik, sangat menguasai peran dan nilai-nilai perjuangan tokoh nasional dan daerah dalam mempertahankan keutuhan negara, menguasai upaya bangsa indonesia menghadapi ancaman disintegrasi negara", 5, 2, "", "B" },
                    { 24, 1, "Kompetensi pengetahuan baik, sangat menguasai perbedaan fungsi sosial, struktur teks dan kebahasaan dalam teks news item lisan dan tulis dari radio, koran, dan TV, menguasai penerapan fungsi sosial, struktur teks, dan unsur kebahasan teks dalam tindakan menawarkan jasa", 6, 2, "", "B" },
                    { 25, 1, "Kompetensi pengetahuan sangat baik, sangat menguasai teknik menyusun naskah teater kontemporer, sangat menguasai perencangan pemetasan teater kontemporer", 7, 2, "", "A" },
                    { 26, 1, "Kompetensi pengetahuan baik, sangat menguasai sistem produksi kerajinan inovatif sesuai kebutuhan pasar global berdasarkan daya dukung yang dimiliki oleh daerah setempat, sangat menguasai perencanaan usaha kerajinan inovatif berdasarkan kebutuhan pasar global", 8, 2, "", "A" },
                    { 27, 1, "Kompetensi pengetahuan baik, sangat menguasai atletik jalan cepat, lompat tinggi, lari jarak pendek, sangat menguasai permainan bulu tangkis, softball, tenis meja", 9, 2, "", "B" },
                    { 28, 1, "Kompetensi pengetahuan sangat baik, sangat menguasai limit di ketakhinggaan fungsi aljabar dan trigonometri,menguasai limit fungsi trigonometri", 10, 2, "", "B" },
                    { 29, 1, "Kompetensi pengetahuan baik, sangat menguasai rangkaian arus bolak balik, cukup menguasai prinsip kerja peralatan listrik searah", 11, 2, "", "A" },
                    { 30, 1, "Kompetensi pengetahuan sangat baik, sangat menguasai pola-pola hereditas, menguasai pengaruh faktor internal dan faktor eksternal terhadap pertumbuhan dan perkembangan", 12, 2, "", "B" },
                    { 31, 1, "Kompetensi pengetahuan sangat baik, sangat menguasai analisis gejala yang terjadi sel elektrolisis yang digunakan dalam kehidupan, sangat menguasai penyebab adanya fenomena sifat koligatif larutan, dan tekanan osmosis", 13, 2, "", "A" },
                    { 32, 1, "Kompetensi pengetahuan baik, sangat menguasai ukuran pemusatan dan penyebaran data yang disajikan dalam bentuk tabel distribusi frekuensi dan histogram, menguasai jarak dalam ruang", 14, 2, "", "A" },
                    { 33, 1, "Kompetensi pengetahuan baik, sangat menguasai perbedaan fungsi sosial struktur teks news item lisan dan tulis dari radio, koran, dan TV, menguasai penerapan fungsi sosial, struktur teks dan unsur kebahasaan teks dalam tindakan menawarkan jasa", 15, 2, "", "B" }
                });

            migrationBuilder.InsertData(
                table: "TblEvaluasiSiswa",
                columns: new[] { "Id", "AsesmenSumatifId", "Deskripsi", "JadwalMengajarId", "Jenis" },
                values: new object[,]
                {
                    { 1, 1, "Tugas", null, 0 },
                    { 2, 1, "Ulangan Harian", null, 1 },
                    { 3, 2, "Tugas", null, 0 },
                    { 4, 2, "Ulangan Harian", null, 1 },
                    { 5, 3, "Tugas", null, 0 },
                    { 6, 3, "Ulangan Harian", null, 1 },
                    { 7, 4, "Tugas", null, 0 },
                    { 8, 4, "Ulangan Harian", null, 1 },
                    { 9, 5, "Tugas", null, 0 },
                    { 10, 5, "Ulangan Harian", null, 1 },
                    { 11, 6, "Tugas", null, 0 },
                    { 12, 6, "Ulangan Harian", null, 1 },
                    { 13, 7, "Tugas", null, 0 },
                    { 14, 7, "Ulangan Harian", null, 1 },
                    { 15, 8, "Tugas", null, 0 },
                    { 16, 8, "Ulangan Harian", null, 1 },
                    { 17, 9, "Tugas", null, 0 },
                    { 18, 9, "Ulangan Harian", null, 1 },
                    { 19, 10, "Tugas", null, 0 },
                    { 20, 10, "Ulangan Harian", null, 1 },
                    { 21, 11, "Tugas", null, 0 },
                    { 22, 11, "Ulangan Harian", null, 1 },
                    { 23, 12, "Tugas", null, 0 },
                    { 24, 12, "Ulangan Harian", null, 1 },
                    { 25, 13, "Tugas", null, 0 },
                    { 26, 13, "Ulangan Harian", null, 1 },
                    { 27, 14, "Tugas", null, 0 },
                    { 28, 14, "Ulangan Harian", null, 1 },
                    { 29, 15, "Tugas", null, 0 },
                    { 30, 15, "Ulangan Harian", null, 1 }
                });

            migrationBuilder.InsertData(
                table: "TblNilaiEvaluasiSiswa",
                columns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa", "Nilai" },
                values: new object[,]
                {
                    { 1, 1, 100.0 },
                    { 1, 2, 100.0 },
                    { 1, 3, 91.0 },
                    { 1, 4, 91.0 },
                    { 1, 5, 90.0 },
                    { 1, 6, 90.0 },
                    { 1, 7, 90.0 },
                    { 1, 8, 90.0 },
                    { 1, 9, 89.0 },
                    { 1, 10, 89.0 },
                    { 1, 11, 87.0 },
                    { 1, 12, 87.0 },
                    { 1, 13, 93.0 },
                    { 1, 14, 93.0 },
                    { 1, 15, 86.0 },
                    { 1, 16, 86.0 },
                    { 1, 17, 90.0 },
                    { 1, 18, 90.0 },
                    { 1, 19, 92.0 },
                    { 1, 20, 92.0 },
                    { 1, 21, 86.0 },
                    { 1, 22, 86.0 },
                    { 1, 23, 95.0 },
                    { 1, 24, 95.0 },
                    { 1, 25, 97.0 },
                    { 1, 26, 97.0 },
                    { 1, 27, 90.0 },
                    { 1, 28, 90.0 },
                    { 1, 29, 87.0 },
                    { 1, 30, 87.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AsesmenSumatif_IdJadwalMengajar",
                table: "AsesmenSumatif",
                column: "IdJadwalMengajar");

            migrationBuilder.CreateIndex(
                name: "IX_AsesmenSumatif_IdTujuanPembelajaran",
                table: "AsesmenSumatif",
                column: "IdTujuanPembelajaran");

            migrationBuilder.CreateIndex(
                name: "IX_TblAbsen_AnggotaRombelId",
                table: "TblAbsen",
                column: "AnggotaRombelId");

            migrationBuilder.CreateIndex(
                name: "IX_TblAbsen_PertemuanId",
                table: "TblAbsen",
                column: "PertemuanId");

            migrationBuilder.CreateIndex(
                name: "IX_TblAbsenKelas_AnggotaRombelId",
                table: "TblAbsenKelas",
                column: "AnggotaRombelId");

            migrationBuilder.CreateIndex(
                name: "IX_TblAnggotaRombel_IdRombel",
                table: "TblAnggotaRombel",
                column: "IdRombel");

            migrationBuilder.CreateIndex(
                name: "IX_TblAnggotaRombel_IdSiswa",
                table: "TblAnggotaRombel",
                column: "IdSiswa");

            migrationBuilder.CreateIndex(
                name: "IX_TblEvaluasiSiswa_AsesmenSumatifId",
                table: "TblEvaluasiSiswa",
                column: "AsesmenSumatifId");

            migrationBuilder.CreateIndex(
                name: "IX_TblEvaluasiSiswa_JadwalMengajarId",
                table: "TblEvaluasiSiswa",
                column: "JadwalMengajarId");

            migrationBuilder.CreateIndex(
                name: "IX_TblHariMengajar_JadwalMengajarId",
                table: "TblHariMengajar",
                column: "JadwalMengajarId");

            migrationBuilder.CreateIndex(
                name: "IX_TblJadwalMengajar_MataPelajaranId_RombelId_PegawaiId",
                table: "TblJadwalMengajar",
                columns: new[] { "MataPelajaranId", "RombelId", "PegawaiId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TblJadwalMengajar_PegawaiId",
                table: "TblJadwalMengajar",
                column: "PegawaiId");

            migrationBuilder.CreateIndex(
                name: "IX_TblJadwalMengajar_RombelId",
                table: "TblJadwalMengajar",
                column: "RombelId");

            migrationBuilder.CreateIndex(
                name: "IX_TblKelas_PeminatanId",
                table: "TblKelas",
                column: "PeminatanId");

            migrationBuilder.CreateIndex(
                name: "IX_TblKelas_TahunAjaranId",
                table: "TblKelas",
                column: "TahunAjaranId");

            migrationBuilder.CreateIndex(
                name: "IX_TblMataPelajaran_PeminatanId",
                table: "TblMataPelajaran",
                column: "PeminatanId");

            migrationBuilder.CreateIndex(
                name: "IX_TblNilaiEvaluasiSiswa_IdEvaluasiSiswa",
                table: "TblNilaiEvaluasiSiswa",
                column: "IdEvaluasiSiswa");

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
                name: "IX_TblPertemuan_JadwalMengajarId",
                table: "TblPertemuan",
                column: "JadwalMengajarId");

            migrationBuilder.CreateIndex(
                name: "IX_TblRaport_AnggotaRombelId",
                table: "TblRaport",
                column: "AnggotaRombelId");

            migrationBuilder.CreateIndex(
                name: "IX_TblRaport_JadwalMengajarId",
                table: "TblRaport",
                column: "JadwalMengajarId");

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

            migrationBuilder.CreateIndex(
                name: "IX_TblTujuanPembelajaran_MataPelajaranId",
                table: "TblTujuanPembelajaran",
                column: "MataPelajaranId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblAbsen");

            migrationBuilder.DropTable(
                name: "TblAbsenKelas");

            migrationBuilder.DropTable(
                name: "TblHariMengajar");

            migrationBuilder.DropTable(
                name: "TblNilaiEvaluasiSiswa");

            migrationBuilder.DropTable(
                name: "TblRaport");

            migrationBuilder.DropTable(
                name: "TblPertemuan");

            migrationBuilder.DropTable(
                name: "TblEvaluasiSiswa");

            migrationBuilder.DropTable(
                name: "TblAnggotaRombel");

            migrationBuilder.DropTable(
                name: "AsesmenSumatif");

            migrationBuilder.DropTable(
                name: "TblSiswa");

            migrationBuilder.DropTable(
                name: "TblJadwalMengajar");

            migrationBuilder.DropTable(
                name: "TblTujuanPembelajaran");

            migrationBuilder.DropTable(
                name: "TblRombel");

            migrationBuilder.DropTable(
                name: "TblMataPelajaran");

            migrationBuilder.DropTable(
                name: "TblKelas");

            migrationBuilder.DropTable(
                name: "TblPegawai");

            migrationBuilder.DropTable(
                name: "TblPeminatan");

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
