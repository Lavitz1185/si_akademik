using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataNilai1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblNilaiEvaluasiSiswa_TblAnggotaRombel_AnggotaRombelId",
                table: "TblNilaiEvaluasiSiswa");

            migrationBuilder.DropForeignKey(
                name: "FK_TblNilaiEvaluasiSiswa_TblEvaluasiSiswa_EvaluasiSiswaId",
                table: "TblNilaiEvaluasiSiswa");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TblNilaiEvaluasiSiswa",
                table: "TblNilaiEvaluasiSiswa");

            migrationBuilder.DropIndex(
                name: "IX_TblNilaiEvaluasiSiswa_EvaluasiSiswaId",
                table: "TblNilaiEvaluasiSiswa");

            migrationBuilder.DropColumn(
                name: "AnggotaRombelId",
                table: "TblNilaiEvaluasiSiswa");

            migrationBuilder.DropColumn(
                name: "EvaluasiSiswaId",
                table: "TblNilaiEvaluasiSiswa");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblNilaiEvaluasiSiswa",
                table: "TblNilaiEvaluasiSiswa",
                columns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" });

            migrationBuilder.InsertData(
                table: "TblEvaluasiSiswa",
                columns: new[] { "Id", "Deskripsi", "JadwalMengajarId", "Jenis" },
                values: new object[,]
                {
                    { 1, "Tugas 1", 3, 0 },
                    { 2, "UH 1", 3, 1 },
                    { 3, "UTS", 3, 2 },
                    { 4, "UAS", 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "TblNilaiEvaluasiSiswa",
                columns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa", "Nilai" },
                values: new object[,]
                {
                    { 1, 1, 100 },
                    { 1, 2, 100 },
                    { 1, 3, 100 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblNilaiEvaluasiSiswa_IdEvaluasiSiswa",
                table: "TblNilaiEvaluasiSiswa",
                column: "IdEvaluasiSiswa");

            migrationBuilder.AddForeignKey(
                name: "FK_TblNilaiEvaluasiSiswa_TblAnggotaRombel_IdAnggotaRombel",
                table: "TblNilaiEvaluasiSiswa",
                column: "IdAnggotaRombel",
                principalTable: "TblAnggotaRombel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TblNilaiEvaluasiSiswa_TblEvaluasiSiswa_IdEvaluasiSiswa",
                table: "TblNilaiEvaluasiSiswa",
                column: "IdEvaluasiSiswa",
                principalTable: "TblEvaluasiSiswa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblNilaiEvaluasiSiswa_TblAnggotaRombel_IdAnggotaRombel",
                table: "TblNilaiEvaluasiSiswa");

            migrationBuilder.DropForeignKey(
                name: "FK_TblNilaiEvaluasiSiswa_TblEvaluasiSiswa_IdEvaluasiSiswa",
                table: "TblNilaiEvaluasiSiswa");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TblNilaiEvaluasiSiswa",
                table: "TblNilaiEvaluasiSiswa");

            migrationBuilder.DropIndex(
                name: "IX_TblNilaiEvaluasiSiswa_IdEvaluasiSiswa",
                table: "TblNilaiEvaluasiSiswa");

            migrationBuilder.DeleteData(
                table: "TblEvaluasiSiswa",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "TblEvaluasiSiswa",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TblEvaluasiSiswa",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TblEvaluasiSiswa",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AddColumn<int>(
                name: "AnggotaRombelId",
                table: "TblNilaiEvaluasiSiswa",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EvaluasiSiswaId",
                table: "TblNilaiEvaluasiSiswa",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblNilaiEvaluasiSiswa",
                table: "TblNilaiEvaluasiSiswa",
                columns: new[] { "AnggotaRombelId", "EvaluasiSiswaId" });

            migrationBuilder.CreateIndex(
                name: "IX_TblNilaiEvaluasiSiswa_EvaluasiSiswaId",
                table: "TblNilaiEvaluasiSiswa",
                column: "EvaluasiSiswaId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblNilaiEvaluasiSiswa_TblAnggotaRombel_AnggotaRombelId",
                table: "TblNilaiEvaluasiSiswa",
                column: "AnggotaRombelId",
                principalTable: "TblAnggotaRombel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TblNilaiEvaluasiSiswa_TblEvaluasiSiswa_EvaluasiSiswaId",
                table: "TblNilaiEvaluasiSiswa",
                column: "EvaluasiSiswaId",
                principalTable: "TblEvaluasiSiswa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
