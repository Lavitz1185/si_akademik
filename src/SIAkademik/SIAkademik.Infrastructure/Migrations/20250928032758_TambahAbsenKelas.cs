using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TambahAbsenKelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblAbsenKelas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Tanggal = table.Column<DateOnly>(type: "date", nullable: false),
                    Absensi = table.Column<int>(type: "integer", nullable: false),
                    Catatan = table.Column<string>(type: "text", nullable: false),
                    AnggotaRombelIdSiswa = table.Column<int>(type: "integer", nullable: false),
                    AnggotaRombelIdRombel = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblAbsenKelas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblAbsenKelas_TblAnggotaRombel_AnggotaRombelIdSiswa_Anggota~",
                        columns: x => new { x.AnggotaRombelIdSiswa, x.AnggotaRombelIdRombel },
                        principalTable: "TblAnggotaRombel",
                        principalColumns: new[] { "IdSiswa", "IdRombel" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblAbsenKelas_AnggotaRombelIdSiswa_AnggotaRombelIdRombel",
                table: "TblAbsenKelas",
                columns: new[] { "AnggotaRombelIdSiswa", "AnggotaRombelIdRombel" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblAbsenKelas");
        }
    }
}
