using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TambahRaport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblRaport",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Predikat = table.Column<string>(type: "text", nullable: false),
                    Deskripsi = table.Column<string>(type: "text", nullable: false),
                    KategoriNilai = table.Column<int>(type: "integer", nullable: false),
                    AnggotaRombelIdSiswa = table.Column<int>(type: "integer", nullable: false),
                    AnggotaRombelIdRombel = table.Column<int>(type: "integer", nullable: false),
                    JadwalMengajarId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblRaport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblRaport_TblAnggotaRombel_AnggotaRombelIdSiswa_AnggotaRomb~",
                        columns: x => new { x.AnggotaRombelIdSiswa, x.AnggotaRombelIdRombel },
                        principalTable: "TblAnggotaRombel",
                        principalColumns: new[] { "IdSiswa", "IdRombel" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblRaport_TblJadwalMengajar_JadwalMengajarId",
                        column: x => x.JadwalMengajarId,
                        principalTable: "TblJadwalMengajar",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblRaport_AnggotaRombelIdSiswa_AnggotaRombelIdRombel",
                table: "TblRaport",
                columns: new[] { "AnggotaRombelIdSiswa", "AnggotaRombelIdRombel" });

            migrationBuilder.CreateIndex(
                name: "IX_TblRaport_JadwalMengajarId",
                table: "TblRaport",
                column: "JadwalMengajarId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblRaport");
        }
    }
}
