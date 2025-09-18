using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TambahHariMengajar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hari",
                table: "TblJadwalMengajar");

            migrationBuilder.DropColumn(
                name: "JamMulai",
                table: "TblJadwalMengajar");

            migrationBuilder.CreateTable(
                name: "TblHariMengajar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Hari = table.Column<int>(type: "integer", nullable: false),
                    JamMulai = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    JamAkhir = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    JadwalMengajarNIP = table.Column<string>(type: "text", nullable: false),
                    JadwalMengajarIdMataPelajaran = table.Column<int>(type: "integer", nullable: false),
                    JadwalMengajarIdRombel = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblHariMengajar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblHariMengajar_TblJadwalMengajar_JadwalMengajarNIP_JadwalM~",
                        columns: x => new { x.JadwalMengajarNIP, x.JadwalMengajarIdMataPelajaran, x.JadwalMengajarIdRombel },
                        principalTable: "TblJadwalMengajar",
                        principalColumns: new[] { "NIP", "IdMataPelajaran", "IdRombel" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblHariMengajar_JadwalMengajarNIP_JadwalMengajarIdMataPelaj~",
                table: "TblHariMengajar",
                columns: new[] { "JadwalMengajarNIP", "JadwalMengajarIdMataPelajaran", "JadwalMengajarIdRombel" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblHariMengajar");

            migrationBuilder.AddColumn<int>(
                name: "Hari",
                table: "TblJadwalMengajar",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<TimeOnly>(
                name: "JamMulai",
                table: "TblJadwalMengajar",
                type: "time without time zone",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));
        }
    }
}
