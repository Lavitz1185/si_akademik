using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TambahPertemuan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PertemuanId",
                table: "TblAbsen",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TblPertemuan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nomor = table.Column<int>(type: "integer", nullable: false),
                    Tanggal = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Keterangan = table.Column<string>(type: "text", nullable: false),
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

            migrationBuilder.CreateIndex(
                name: "IX_TblAbsen_PertemuanId",
                table: "TblAbsen",
                column: "PertemuanId");

            migrationBuilder.CreateIndex(
                name: "IX_TblPertemuan_JadwalMengajarId",
                table: "TblPertemuan",
                column: "JadwalMengajarId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblAbsen_TblPertemuan_PertemuanId",
                table: "TblAbsen",
                column: "PertemuanId",
                principalTable: "TblPertemuan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblAbsen_TblPertemuan_PertemuanId",
                table: "TblAbsen");

            migrationBuilder.DropTable(
                name: "TblPertemuan");

            migrationBuilder.DropIndex(
                name: "IX_TblAbsen_PertemuanId",
                table: "TblAbsen");

            migrationBuilder.DropColumn(
                name: "PertemuanId",
                table: "TblAbsen");
        }
    }
}
