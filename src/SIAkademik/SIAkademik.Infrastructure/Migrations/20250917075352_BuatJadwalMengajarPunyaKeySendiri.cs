using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class BuatJadwalMengajarPunyaKeySendiri : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblHariMengajar_TblJadwalMengajar_JadwalMengajarNIP_JadwalM~",
                table: "TblHariMengajar");

            migrationBuilder.DropForeignKey(
                name: "FK_TblJadwalMengajar_TblMataPelajaran_IdMataPelajaran",
                table: "TblJadwalMengajar");

            migrationBuilder.DropForeignKey(
                name: "FK_TblJadwalMengajar_TblPegawai_NIP",
                table: "TblJadwalMengajar");

            migrationBuilder.DropForeignKey(
                name: "FK_TblJadwalMengajar_TblRombel_IdRombel",
                table: "TblJadwalMengajar");

            migrationBuilder.DropForeignKey(
                name: "FK_TblNilai_TblJadwalMengajar_JadwalMengajarNIP_JadwalMengajar~",
                table: "TblNilai");

            migrationBuilder.DropIndex(
                name: "IX_TblNilai_JadwalMengajarNIP_JadwalMengajarIdMataPelajaran_Ja~",
                table: "TblNilai");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TblJadwalMengajar",
                table: "TblJadwalMengajar");

            migrationBuilder.DropIndex(
                name: "IX_TblJadwalMengajar_IdMataPelajaran",
                table: "TblJadwalMengajar");

            migrationBuilder.DropIndex(
                name: "IX_TblHariMengajar_JadwalMengajarNIP_JadwalMengajarIdMataPelaj~",
                table: "TblHariMengajar");

            migrationBuilder.DropColumn(
                name: "JadwalMengajarIdMataPelajaran",
                table: "TblNilai");

            migrationBuilder.DropColumn(
                name: "JadwalMengajarNIP",
                table: "TblNilai");

            migrationBuilder.DropColumn(
                name: "JadwalMengajarIdMataPelajaran",
                table: "TblHariMengajar");

            migrationBuilder.DropColumn(
                name: "JadwalMengajarNIP",
                table: "TblHariMengajar");

            migrationBuilder.RenameColumn(
                name: "JadwalMengajarIdRombel",
                table: "TblNilai",
                newName: "JadwalMengajarId");

            migrationBuilder.RenameColumn(
                name: "IdRombel",
                table: "TblJadwalMengajar",
                newName: "RombelId");

            migrationBuilder.RenameColumn(
                name: "IdMataPelajaran",
                table: "TblJadwalMengajar",
                newName: "MataPelajaranId");

            migrationBuilder.RenameColumn(
                name: "NIP",
                table: "TblJadwalMengajar",
                newName: "PegawaiId");

            migrationBuilder.RenameIndex(
                name: "IX_TblJadwalMengajar_IdRombel",
                table: "TblJadwalMengajar",
                newName: "IX_TblJadwalMengajar_RombelId");

            migrationBuilder.RenameColumn(
                name: "JadwalMengajarIdRombel",
                table: "TblHariMengajar",
                newName: "JadwalMengajarId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "TblJadwalMengajar",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblJadwalMengajar",
                table: "TblJadwalMengajar",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TblNilai_JadwalMengajarId",
                table: "TblNilai",
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
                name: "IX_TblHariMengajar_JadwalMengajarId",
                table: "TblHariMengajar",
                column: "JadwalMengajarId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblHariMengajar_TblJadwalMengajar_JadwalMengajarId",
                table: "TblHariMengajar",
                column: "JadwalMengajarId",
                principalTable: "TblJadwalMengajar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TblJadwalMengajar_TblMataPelajaran_MataPelajaranId",
                table: "TblJadwalMengajar",
                column: "MataPelajaranId",
                principalTable: "TblMataPelajaran",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TblJadwalMengajar_TblPegawai_PegawaiId",
                table: "TblJadwalMengajar",
                column: "PegawaiId",
                principalTable: "TblPegawai",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TblJadwalMengajar_TblRombel_RombelId",
                table: "TblJadwalMengajar",
                column: "RombelId",
                principalTable: "TblRombel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TblNilai_TblJadwalMengajar_JadwalMengajarId",
                table: "TblNilai",
                column: "JadwalMengajarId",
                principalTable: "TblJadwalMengajar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblHariMengajar_TblJadwalMengajar_JadwalMengajarId",
                table: "TblHariMengajar");

            migrationBuilder.DropForeignKey(
                name: "FK_TblJadwalMengajar_TblMataPelajaran_MataPelajaranId",
                table: "TblJadwalMengajar");

            migrationBuilder.DropForeignKey(
                name: "FK_TblJadwalMengajar_TblPegawai_PegawaiId",
                table: "TblJadwalMengajar");

            migrationBuilder.DropForeignKey(
                name: "FK_TblJadwalMengajar_TblRombel_RombelId",
                table: "TblJadwalMengajar");

            migrationBuilder.DropForeignKey(
                name: "FK_TblNilai_TblJadwalMengajar_JadwalMengajarId",
                table: "TblNilai");

            migrationBuilder.DropIndex(
                name: "IX_TblNilai_JadwalMengajarId",
                table: "TblNilai");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TblJadwalMengajar",
                table: "TblJadwalMengajar");

            migrationBuilder.DropIndex(
                name: "IX_TblJadwalMengajar_MataPelajaranId_RombelId_PegawaiId",
                table: "TblJadwalMengajar");

            migrationBuilder.DropIndex(
                name: "IX_TblJadwalMengajar_PegawaiId",
                table: "TblJadwalMengajar");

            migrationBuilder.DropIndex(
                name: "IX_TblHariMengajar_JadwalMengajarId",
                table: "TblHariMengajar");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "TblJadwalMengajar");

            migrationBuilder.RenameColumn(
                name: "JadwalMengajarId",
                table: "TblNilai",
                newName: "JadwalMengajarIdRombel");

            migrationBuilder.RenameColumn(
                name: "RombelId",
                table: "TblJadwalMengajar",
                newName: "IdRombel");

            migrationBuilder.RenameColumn(
                name: "PegawaiId",
                table: "TblJadwalMengajar",
                newName: "NIP");

            migrationBuilder.RenameColumn(
                name: "MataPelajaranId",
                table: "TblJadwalMengajar",
                newName: "IdMataPelajaran");

            migrationBuilder.RenameIndex(
                name: "IX_TblJadwalMengajar_RombelId",
                table: "TblJadwalMengajar",
                newName: "IX_TblJadwalMengajar_IdRombel");

            migrationBuilder.RenameColumn(
                name: "JadwalMengajarId",
                table: "TblHariMengajar",
                newName: "JadwalMengajarIdRombel");

            migrationBuilder.AddColumn<int>(
                name: "JadwalMengajarIdMataPelajaran",
                table: "TblNilai",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "JadwalMengajarNIP",
                table: "TblNilai",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "JadwalMengajarIdMataPelajaran",
                table: "TblHariMengajar",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "JadwalMengajarNIP",
                table: "TblHariMengajar",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblJadwalMengajar",
                table: "TblJadwalMengajar",
                columns: new[] { "NIP", "IdMataPelajaran", "IdRombel" });

            migrationBuilder.CreateIndex(
                name: "IX_TblNilai_JadwalMengajarNIP_JadwalMengajarIdMataPelajaran_Ja~",
                table: "TblNilai",
                columns: new[] { "JadwalMengajarNIP", "JadwalMengajarIdMataPelajaran", "JadwalMengajarIdRombel" });

            migrationBuilder.CreateIndex(
                name: "IX_TblJadwalMengajar_IdMataPelajaran",
                table: "TblJadwalMengajar",
                column: "IdMataPelajaran");

            migrationBuilder.CreateIndex(
                name: "IX_TblHariMengajar_JadwalMengajarNIP_JadwalMengajarIdMataPelaj~",
                table: "TblHariMengajar",
                columns: new[] { "JadwalMengajarNIP", "JadwalMengajarIdMataPelajaran", "JadwalMengajarIdRombel" });

            migrationBuilder.AddForeignKey(
                name: "FK_TblHariMengajar_TblJadwalMengajar_JadwalMengajarNIP_JadwalM~",
                table: "TblHariMengajar",
                columns: new[] { "JadwalMengajarNIP", "JadwalMengajarIdMataPelajaran", "JadwalMengajarIdRombel" },
                principalTable: "TblJadwalMengajar",
                principalColumns: new[] { "NIP", "IdMataPelajaran", "IdRombel" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TblJadwalMengajar_TblMataPelajaran_IdMataPelajaran",
                table: "TblJadwalMengajar",
                column: "IdMataPelajaran",
                principalTable: "TblMataPelajaran",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TblJadwalMengajar_TblPegawai_NIP",
                table: "TblJadwalMengajar",
                column: "NIP",
                principalTable: "TblPegawai",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TblJadwalMengajar_TblRombel_IdRombel",
                table: "TblJadwalMengajar",
                column: "IdRombel",
                principalTable: "TblRombel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TblNilai_TblJadwalMengajar_JadwalMengajarNIP_JadwalMengajar~",
                table: "TblNilai",
                columns: new[] { "JadwalMengajarNIP", "JadwalMengajarIdMataPelajaran", "JadwalMengajarIdRombel" },
                principalTable: "TblJadwalMengajar",
                principalColumns: new[] { "NIP", "IdMataPelajaran", "IdRombel" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
