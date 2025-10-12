using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ResetMigrations2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblAbsen_TblAnggotaRombel_AnggotaRombelId",
                table: "TblAbsen");

            migrationBuilder.DropForeignKey(
                name: "FK_TblAbsenKelas_TblAnggotaRombel_AnggotaRombelId",
                table: "TblAbsenKelas");

            migrationBuilder.DropForeignKey(
                name: "FK_TblAnggotaRombel_TblRombel_IdRombel",
                table: "TblAnggotaRombel");

            migrationBuilder.DropForeignKey(
                name: "FK_TblAnggotaRombel_TblSiswa_IdSiswa",
                table: "TblAnggotaRombel");

            migrationBuilder.DropForeignKey(
                name: "FK_TblNilaiEvaluasiSiswa_TblAnggotaRombel_IdAnggotaRombel",
                table: "TblNilaiEvaluasiSiswa");

            migrationBuilder.DropForeignKey(
                name: "FK_TblRaport_TblAnggotaRombel_AnggotaRombelId",
                table: "TblRaport");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TblAnggotaRombel",
                table: "TblAnggotaRombel");

            migrationBuilder.RenameTable(
                name: "TblAnggotaRombel",
                newName: "AnggotaRombel");

            migrationBuilder.RenameIndex(
                name: "IX_TblAnggotaRombel_IdSiswa",
                table: "AnggotaRombel",
                newName: "IX_AnggotaRombel_IdSiswa");

            migrationBuilder.RenameIndex(
                name: "IX_TblAnggotaRombel_IdRombel",
                table: "AnggotaRombel",
                newName: "IX_AnggotaRombel_IdRombel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AnggotaRombel",
                table: "AnggotaRombel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AnggotaRombel_TblRombel_IdRombel",
                table: "AnggotaRombel",
                column: "IdRombel",
                principalTable: "TblRombel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AnggotaRombel_TblSiswa_IdSiswa",
                table: "AnggotaRombel",
                column: "IdSiswa",
                principalTable: "TblSiswa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TblAbsen_AnggotaRombel_AnggotaRombelId",
                table: "TblAbsen",
                column: "AnggotaRombelId",
                principalTable: "AnggotaRombel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TblAbsenKelas_AnggotaRombel_AnggotaRombelId",
                table: "TblAbsenKelas",
                column: "AnggotaRombelId",
                principalTable: "AnggotaRombel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TblNilaiEvaluasiSiswa_AnggotaRombel_IdAnggotaRombel",
                table: "TblNilaiEvaluasiSiswa",
                column: "IdAnggotaRombel",
                principalTable: "AnggotaRombel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TblRaport_AnggotaRombel_AnggotaRombelId",
                table: "TblRaport",
                column: "AnggotaRombelId",
                principalTable: "AnggotaRombel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnggotaRombel_TblRombel_IdRombel",
                table: "AnggotaRombel");

            migrationBuilder.DropForeignKey(
                name: "FK_AnggotaRombel_TblSiswa_IdSiswa",
                table: "AnggotaRombel");

            migrationBuilder.DropForeignKey(
                name: "FK_TblAbsen_AnggotaRombel_AnggotaRombelId",
                table: "TblAbsen");

            migrationBuilder.DropForeignKey(
                name: "FK_TblAbsenKelas_AnggotaRombel_AnggotaRombelId",
                table: "TblAbsenKelas");

            migrationBuilder.DropForeignKey(
                name: "FK_TblNilaiEvaluasiSiswa_AnggotaRombel_IdAnggotaRombel",
                table: "TblNilaiEvaluasiSiswa");

            migrationBuilder.DropForeignKey(
                name: "FK_TblRaport_AnggotaRombel_AnggotaRombelId",
                table: "TblRaport");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AnggotaRombel",
                table: "AnggotaRombel");

            migrationBuilder.RenameTable(
                name: "AnggotaRombel",
                newName: "TblAnggotaRombel");

            migrationBuilder.RenameIndex(
                name: "IX_AnggotaRombel_IdSiswa",
                table: "TblAnggotaRombel",
                newName: "IX_TblAnggotaRombel_IdSiswa");

            migrationBuilder.RenameIndex(
                name: "IX_AnggotaRombel_IdRombel",
                table: "TblAnggotaRombel",
                newName: "IX_TblAnggotaRombel_IdRombel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblAnggotaRombel",
                table: "TblAnggotaRombel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TblAbsen_TblAnggotaRombel_AnggotaRombelId",
                table: "TblAbsen",
                column: "AnggotaRombelId",
                principalTable: "TblAnggotaRombel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TblAbsenKelas_TblAnggotaRombel_AnggotaRombelId",
                table: "TblAbsenKelas",
                column: "AnggotaRombelId",
                principalTable: "TblAnggotaRombel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TblAnggotaRombel_TblRombel_IdRombel",
                table: "TblAnggotaRombel",
                column: "IdRombel",
                principalTable: "TblRombel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TblAnggotaRombel_TblSiswa_IdSiswa",
                table: "TblAnggotaRombel",
                column: "IdSiswa",
                principalTable: "TblSiswa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TblNilaiEvaluasiSiswa_TblAnggotaRombel_IdAnggotaRombel",
                table: "TblNilaiEvaluasiSiswa",
                column: "IdAnggotaRombel",
                principalTable: "TblAnggotaRombel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TblRaport_TblAnggotaRombel_AnggotaRombelId",
                table: "TblRaport",
                column: "AnggotaRombelId",
                principalTable: "TblAnggotaRombel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
