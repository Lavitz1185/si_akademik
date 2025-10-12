using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TambahAsesmenSumatifAkhirSemester : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblAsesmenSumatifAkhirSemester",
                columns: table => new
                {
                    JadwalMengajarId = table.Column<int>(type: "integer", nullable: false),
                    AnggotaRombelId = table.Column<int>(type: "integer", nullable: false),
                    Nilai = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblAsesmenSumatifAkhirSemester", x => new { x.AnggotaRombelId, x.JadwalMengajarId });
                    table.ForeignKey(
                        name: "FK_TblAsesmenSumatifAkhirSemester_TblAnggotaRombel_AnggotaRomb~",
                        column: x => x.AnggotaRombelId,
                        principalTable: "TblAnggotaRombel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblAsesmenSumatifAkhirSemester_TblJadwalMengajar_JadwalMeng~",
                        column: x => x.JadwalMengajarId,
                        principalTable: "TblJadwalMengajar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TblAsesmenSumatifAkhirSemester",
                columns: new[] { "AnggotaRombelId", "JadwalMengajarId", "Nilai" },
                values: new object[,]
                {
                    { 1, 1, 100.0 },
                    { 1, 2, 91.0 },
                    { 1, 3, 90.0 },
                    { 1, 4, 90.0 },
                    { 1, 5, 89.0 },
                    { 1, 6, 87.0 },
                    { 1, 7, 93.0 },
                    { 1, 8, 86.0 },
                    { 1, 9, 90.0 },
                    { 1, 10, 92.0 },
                    { 1, 11, 86.0 },
                    { 1, 12, 95.0 },
                    { 1, 13, 97.0 },
                    { 1, 14, 90.0 },
                    { 1, 15, 87.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblAsesmenSumatifAkhirSemester_JadwalMengajarId",
                table: "TblAsesmenSumatifAkhirSemester",
                column: "JadwalMengajarId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblAsesmenSumatifAkhirSemester");
        }
    }
}
