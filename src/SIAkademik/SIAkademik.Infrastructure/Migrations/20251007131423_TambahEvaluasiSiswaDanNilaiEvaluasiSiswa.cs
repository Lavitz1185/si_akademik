using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TambahEvaluasiSiswaDanNilaiEvaluasiSiswa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblNilai");

            migrationBuilder.CreateTable(
                name: "TblEvaluasiSiswa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Deskripsi = table.Column<string>(type: "text", nullable: false),
                    Jenis = table.Column<int>(type: "integer", nullable: false),
                    JadwalMengajarId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblEvaluasiSiswa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblEvaluasiSiswa_TblJadwalMengajar_JadwalMengajarId",
                        column: x => x.JadwalMengajarId,
                        principalTable: "TblJadwalMengajar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TblNilaiEvaluasiSiswa",
                columns: table => new
                {
                    AnggotaRombelId = table.Column<int>(type: "integer", nullable: false),
                    EvaluasiSiswaId = table.Column<int>(type: "integer", nullable: false),
                    IdAnggotaRombel = table.Column<int>(type: "integer", nullable: false),
                    IdEvaluasiSiswa = table.Column<int>(type: "integer", nullable: false),
                    Nilai = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblNilaiEvaluasiSiswa", x => new { x.AnggotaRombelId, x.EvaluasiSiswaId });
                    table.ForeignKey(
                        name: "FK_TblNilaiEvaluasiSiswa_TblAnggotaRombel_AnggotaRombelId",
                        column: x => x.AnggotaRombelId,
                        principalTable: "TblAnggotaRombel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblNilaiEvaluasiSiswa_TblEvaluasiSiswa_EvaluasiSiswaId",
                        column: x => x.EvaluasiSiswaId,
                        principalTable: "TblEvaluasiSiswa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblEvaluasiSiswa_JadwalMengajarId",
                table: "TblEvaluasiSiswa",
                column: "JadwalMengajarId");

            migrationBuilder.CreateIndex(
                name: "IX_TblNilaiEvaluasiSiswa_EvaluasiSiswaId",
                table: "TblNilaiEvaluasiSiswa",
                column: "EvaluasiSiswaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblNilaiEvaluasiSiswa");

            migrationBuilder.DropTable(
                name: "TblEvaluasiSiswa");

            migrationBuilder.CreateTable(
                name: "TblNilai",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AnggotaRombelId = table.Column<int>(type: "integer", nullable: false),
                    JadwalMengajarId = table.Column<int>(type: "integer", nullable: false),
                    Deskripsi = table.Column<string>(type: "text", nullable: false),
                    Jenis = table.Column<int>(type: "integer", nullable: false),
                    Skor = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblNilai", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblNilai_TblAnggotaRombel_AnggotaRombelId",
                        column: x => x.AnggotaRombelId,
                        principalTable: "TblAnggotaRombel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblNilai_TblJadwalMengajar_JadwalMengajarId",
                        column: x => x.JadwalMengajarId,
                        principalTable: "TblJadwalMengajar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblNilai_AnggotaRombelId",
                table: "TblNilai",
                column: "AnggotaRombelId");

            migrationBuilder.CreateIndex(
                name: "IX_TblNilai_JadwalMengajarId",
                table: "TblNilai",
                column: "JadwalMengajarId");
        }
    }
}
