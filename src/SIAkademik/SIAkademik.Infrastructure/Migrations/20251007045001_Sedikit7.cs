using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Sedikit7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblAbsen_TblAnggotaRombel_AnggotaRombelIdSiswa_AnggotaRombe~",
                table: "TblAbsen");

            migrationBuilder.DropForeignKey(
                name: "FK_TblAbsenKelas_TblAnggotaRombel_AnggotaRombelIdSiswa_Anggota~",
                table: "TblAbsenKelas");

            migrationBuilder.DropForeignKey(
                name: "FK_TblNilai_TblAnggotaRombel_AnggotaRombelIdSiswa_AnggotaRombe~",
                table: "TblNilai");

            migrationBuilder.DropForeignKey(
                name: "FK_TblRaport_TblAnggotaRombel_AnggotaRombelIdSiswa_AnggotaRomb~",
                table: "TblRaport");

            migrationBuilder.DropIndex(
                name: "IX_TblRaport_AnggotaRombelIdSiswa_AnggotaRombelIdRombel",
                table: "TblRaport");

            migrationBuilder.DropIndex(
                name: "IX_TblNilai_AnggotaRombelIdSiswa_AnggotaRombelIdRombel",
                table: "TblNilai");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TblAnggotaRombel",
                table: "TblAnggotaRombel");

            migrationBuilder.DropIndex(
                name: "IX_TblAbsenKelas_AnggotaRombelIdSiswa_AnggotaRombelIdRombel",
                table: "TblAbsenKelas");

            migrationBuilder.DropIndex(
                name: "IX_TblAbsen_AnggotaRombelIdSiswa_AnggotaRombelIdRombel",
                table: "TblAbsen");

            migrationBuilder.DeleteData(
                table: "TblAnggotaRombel",
                keyColumns: new[] { "IdRombel", "IdSiswa" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "TblAnggotaRombel",
                keyColumns: new[] { "IdRombel", "IdSiswa" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DropColumn(
                name: "AnggotaRombelIdRombel",
                table: "TblRaport");

            migrationBuilder.DropColumn(
                name: "AnggotaRombelIdRombel",
                table: "TblNilai");

            migrationBuilder.DropColumn(
                name: "AnggotaRombelIdRombel",
                table: "TblAbsenKelas");

            migrationBuilder.DropColumn(
                name: "AnggotaRombelIdRombel",
                table: "TblAbsen");

            migrationBuilder.RenameColumn(
                name: "AnggotaRombelIdSiswa",
                table: "TblRaport",
                newName: "AnggotaRombelId");

            migrationBuilder.RenameColumn(
                name: "AnggotaRombelIdSiswa",
                table: "TblNilai",
                newName: "AnggotaRombelId");

            migrationBuilder.RenameColumn(
                name: "AnggotaRombelIdSiswa",
                table: "TblAbsenKelas",
                newName: "AnggotaRombelId");

            migrationBuilder.RenameColumn(
                name: "AnggotaRombelIdSiswa",
                table: "TblAbsen",
                newName: "AnggotaRombelId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "TblAnggotaRombel",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblAnggotaRombel",
                table: "TblAnggotaRombel",
                column: "Id");

            migrationBuilder.InsertData(
                table: "TblAnggotaRombel",
                columns: new[] { "Id", "IdRombel", "IdSiswa", "TanggalKeluar", "TanggalMasuk" },
                values: new object[,]
                {
                    { 1, 2, 2, null, new DateOnly(2021, 8, 1) },
                    { 2, 1, 3, null, new DateOnly(2025, 8, 1) }
                });

            migrationBuilder.UpdateData(
                table: "TblRaport",
                keyColumn: "Id",
                keyValue: 1,
                column: "AnggotaRombelId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TblRaport",
                keyColumn: "Id",
                keyValue: 2,
                column: "AnggotaRombelId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TblRaport",
                keyColumn: "Id",
                keyValue: 3,
                column: "AnggotaRombelId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_TblRaport_AnggotaRombelId",
                table: "TblRaport",
                column: "AnggotaRombelId");

            migrationBuilder.CreateIndex(
                name: "IX_TblNilai_AnggotaRombelId",
                table: "TblNilai",
                column: "AnggotaRombelId");

            migrationBuilder.CreateIndex(
                name: "IX_TblAnggotaRombel_IdSiswa",
                table: "TblAnggotaRombel",
                column: "IdSiswa");

            migrationBuilder.CreateIndex(
                name: "IX_TblAbsenKelas_AnggotaRombelId",
                table: "TblAbsenKelas",
                column: "AnggotaRombelId");

            migrationBuilder.CreateIndex(
                name: "IX_TblAbsen_AnggotaRombelId",
                table: "TblAbsen",
                column: "AnggotaRombelId");

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
                name: "FK_TblNilai_TblAnggotaRombel_AnggotaRombelId",
                table: "TblNilai",
                column: "AnggotaRombelId",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblAbsen_TblAnggotaRombel_AnggotaRombelId",
                table: "TblAbsen");

            migrationBuilder.DropForeignKey(
                name: "FK_TblAbsenKelas_TblAnggotaRombel_AnggotaRombelId",
                table: "TblAbsenKelas");

            migrationBuilder.DropForeignKey(
                name: "FK_TblNilai_TblAnggotaRombel_AnggotaRombelId",
                table: "TblNilai");

            migrationBuilder.DropForeignKey(
                name: "FK_TblRaport_TblAnggotaRombel_AnggotaRombelId",
                table: "TblRaport");

            migrationBuilder.DropIndex(
                name: "IX_TblRaport_AnggotaRombelId",
                table: "TblRaport");

            migrationBuilder.DropIndex(
                name: "IX_TblNilai_AnggotaRombelId",
                table: "TblNilai");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TblAnggotaRombel",
                table: "TblAnggotaRombel");

            migrationBuilder.DropIndex(
                name: "IX_TblAnggotaRombel_IdSiswa",
                table: "TblAnggotaRombel");

            migrationBuilder.DropIndex(
                name: "IX_TblAbsenKelas_AnggotaRombelId",
                table: "TblAbsenKelas");

            migrationBuilder.DropIndex(
                name: "IX_TblAbsen_AnggotaRombelId",
                table: "TblAbsen");

            migrationBuilder.DeleteData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyColumnType: "integer",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyColumnType: "integer",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "Id",
                table: "TblAnggotaRombel");

            migrationBuilder.RenameColumn(
                name: "AnggotaRombelId",
                table: "TblRaport",
                newName: "AnggotaRombelIdSiswa");

            migrationBuilder.RenameColumn(
                name: "AnggotaRombelId",
                table: "TblNilai",
                newName: "AnggotaRombelIdSiswa");

            migrationBuilder.RenameColumn(
                name: "AnggotaRombelId",
                table: "TblAbsenKelas",
                newName: "AnggotaRombelIdSiswa");

            migrationBuilder.RenameColumn(
                name: "AnggotaRombelId",
                table: "TblAbsen",
                newName: "AnggotaRombelIdSiswa");

            migrationBuilder.AddColumn<int>(
                name: "AnggotaRombelIdRombel",
                table: "TblRaport",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AnggotaRombelIdRombel",
                table: "TblNilai",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AnggotaRombelIdRombel",
                table: "TblAbsenKelas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AnggotaRombelIdRombel",
                table: "TblAbsen",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblAnggotaRombel",
                table: "TblAnggotaRombel",
                columns: new[] { "IdSiswa", "IdRombel" });

            migrationBuilder.InsertData(
                table: "TblAnggotaRombel",
                columns: new[] { "IdRombel", "IdSiswa", "TanggalKeluar", "TanggalMasuk" },
                values: new object[,]
                {
                    { 2, 2, null, new DateOnly(2021, 8, 1) },
                    { 1, 3, null, new DateOnly(2025, 8, 1) }
                });

            migrationBuilder.UpdateData(
                table: "TblRaport",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AnggotaRombelIdRombel", "AnggotaRombelIdSiswa" },
                values: new object[] { 2, 2 });

            migrationBuilder.UpdateData(
                table: "TblRaport",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AnggotaRombelIdRombel", "AnggotaRombelIdSiswa" },
                values: new object[] { 2, 2 });

            migrationBuilder.UpdateData(
                table: "TblRaport",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AnggotaRombelIdRombel", "AnggotaRombelIdSiswa" },
                values: new object[] { 2, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_TblRaport_AnggotaRombelIdSiswa_AnggotaRombelIdRombel",
                table: "TblRaport",
                columns: new[] { "AnggotaRombelIdSiswa", "AnggotaRombelIdRombel" });

            migrationBuilder.CreateIndex(
                name: "IX_TblNilai_AnggotaRombelIdSiswa_AnggotaRombelIdRombel",
                table: "TblNilai",
                columns: new[] { "AnggotaRombelIdSiswa", "AnggotaRombelIdRombel" });

            migrationBuilder.CreateIndex(
                name: "IX_TblAbsenKelas_AnggotaRombelIdSiswa_AnggotaRombelIdRombel",
                table: "TblAbsenKelas",
                columns: new[] { "AnggotaRombelIdSiswa", "AnggotaRombelIdRombel" });

            migrationBuilder.CreateIndex(
                name: "IX_TblAbsen_AnggotaRombelIdSiswa_AnggotaRombelIdRombel",
                table: "TblAbsen",
                columns: new[] { "AnggotaRombelIdSiswa", "AnggotaRombelIdRombel" });

            migrationBuilder.AddForeignKey(
                name: "FK_TblAbsen_TblAnggotaRombel_AnggotaRombelIdSiswa_AnggotaRombe~",
                table: "TblAbsen",
                columns: new[] { "AnggotaRombelIdSiswa", "AnggotaRombelIdRombel" },
                principalTable: "TblAnggotaRombel",
                principalColumns: new[] { "IdSiswa", "IdRombel" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TblAbsenKelas_TblAnggotaRombel_AnggotaRombelIdSiswa_Anggota~",
                table: "TblAbsenKelas",
                columns: new[] { "AnggotaRombelIdSiswa", "AnggotaRombelIdRombel" },
                principalTable: "TblAnggotaRombel",
                principalColumns: new[] { "IdSiswa", "IdRombel" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TblNilai_TblAnggotaRombel_AnggotaRombelIdSiswa_AnggotaRombe~",
                table: "TblNilai",
                columns: new[] { "AnggotaRombelIdSiswa", "AnggotaRombelIdRombel" },
                principalTable: "TblAnggotaRombel",
                principalColumns: new[] { "IdSiswa", "IdRombel" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TblRaport_TblAnggotaRombel_AnggotaRombelIdSiswa_AnggotaRomb~",
                table: "TblRaport",
                columns: new[] { "AnggotaRombelIdSiswa", "AnggotaRombelIdRombel" },
                principalTable: "TblAnggotaRombel",
                principalColumns: new[] { "IdSiswa", "IdRombel" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
