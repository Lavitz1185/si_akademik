using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TambahPeminatan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Peminatan",
                table: "TblSiswa",
                newName: "PeminatanId");

            migrationBuilder.RenameColumn(
                name: "Peminatan",
                table: "TblMataPelajaran",
                newName: "PeminatanId");

            migrationBuilder.RenameColumn(
                name: "Peminatan",
                table: "TblKelas",
                newName: "PeminatanId");

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

            migrationBuilder.UpdateData(
                table: "TblKelas",
                keyColumn: "Id",
                keyValue: 1,
                column: "PeminatanId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TblMataPelajaran",
                keyColumn: "Id",
                keyValue: 1,
                column: "PeminatanId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TblMataPelajaran",
                keyColumn: "Id",
                keyValue: 2,
                column: "PeminatanId",
                value: 1);

            migrationBuilder.InsertData(
                table: "TblPeminatan",
                columns: new[] { "Id", "Jenis", "Nama" },
                values: new object[,]
                {
                    { 1, 0, "Umum" },
                    { 2, 1, "MIPA" },
                    { 3, 1, "IPS" },
                    { 4, 1, "Bahasa" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblSiswa_PeminatanId",
                table: "TblSiswa",
                column: "PeminatanId");

            migrationBuilder.CreateIndex(
                name: "IX_TblMataPelajaran_PeminatanId",
                table: "TblMataPelajaran",
                column: "PeminatanId");

            migrationBuilder.CreateIndex(
                name: "IX_TblKelas_PeminatanId",
                table: "TblKelas",
                column: "PeminatanId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblKelas_TblPeminatan_PeminatanId",
                table: "TblKelas",
                column: "PeminatanId",
                principalTable: "TblPeminatan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TblMataPelajaran_TblPeminatan_PeminatanId",
                table: "TblMataPelajaran",
                column: "PeminatanId",
                principalTable: "TblPeminatan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TblSiswa_TblPeminatan_PeminatanId",
                table: "TblSiswa",
                column: "PeminatanId",
                principalTable: "TblPeminatan",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblKelas_TblPeminatan_PeminatanId",
                table: "TblKelas");

            migrationBuilder.DropForeignKey(
                name: "FK_TblMataPelajaran_TblPeminatan_PeminatanId",
                table: "TblMataPelajaran");

            migrationBuilder.DropForeignKey(
                name: "FK_TblSiswa_TblPeminatan_PeminatanId",
                table: "TblSiswa");

            migrationBuilder.DropTable(
                name: "TblPeminatan");

            migrationBuilder.DropIndex(
                name: "IX_TblSiswa_PeminatanId",
                table: "TblSiswa");

            migrationBuilder.DropIndex(
                name: "IX_TblMataPelajaran_PeminatanId",
                table: "TblMataPelajaran");

            migrationBuilder.DropIndex(
                name: "IX_TblKelas_PeminatanId",
                table: "TblKelas");

            migrationBuilder.RenameColumn(
                name: "PeminatanId",
                table: "TblSiswa",
                newName: "Peminatan");

            migrationBuilder.RenameColumn(
                name: "PeminatanId",
                table: "TblMataPelajaran",
                newName: "Peminatan");

            migrationBuilder.RenameColumn(
                name: "PeminatanId",
                table: "TblKelas",
                newName: "Peminatan");

            migrationBuilder.UpdateData(
                table: "TblKelas",
                keyColumn: "Id",
                keyValue: 1,
                column: "Peminatan",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TblMataPelajaran",
                keyColumn: "Id",
                keyValue: 1,
                column: "Peminatan",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TblMataPelajaran",
                keyColumn: "Id",
                keyValue: 2,
                column: "Peminatan",
                value: 0);
        }
    }
}
