using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TambahFotoProfilDiPegawai : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FotoProfil",
                table: "TblPegawai",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "TblPegawai",
                keyColumn: "Id",
                keyValue: "PJ14-003",
                column: "FotoProfil",
                value: null);

            migrationBuilder.UpdateData(
                table: "TblPegawai",
                keyColumn: "Id",
                keyValue: "PJ14-004",
                column: "FotoProfil",
                value: null);

            migrationBuilder.UpdateData(
                table: "TblPegawai",
                keyColumn: "Id",
                keyValue: "PJ14-005",
                column: "FotoProfil",
                value: null);

            migrationBuilder.UpdateData(
                table: "TblPegawai",
                keyColumn: "Id",
                keyValue: "PJ17-010",
                column: "FotoProfil",
                value: null);

            migrationBuilder.UpdateData(
                table: "TblPegawai",
                keyColumn: "Id",
                keyValue: "PJ18-012",
                column: "FotoProfil",
                value: null);

            migrationBuilder.UpdateData(
                table: "TblPegawai",
                keyColumn: "Id",
                keyValue: "PJ18-013",
                column: "FotoProfil",
                value: null);

            migrationBuilder.UpdateData(
                table: "TblPegawai",
                keyColumn: "Id",
                keyValue: "PJ19-016",
                column: "FotoProfil",
                value: null);

            migrationBuilder.UpdateData(
                table: "TblPegawai",
                keyColumn: "Id",
                keyValue: "PJ19-017",
                column: "FotoProfil",
                value: null);

            migrationBuilder.UpdateData(
                table: "TblPegawai",
                keyColumn: "Id",
                keyValue: "PJ22-024",
                column: "FotoProfil",
                value: null);

            migrationBuilder.UpdateData(
                table: "TblPegawai",
                keyColumn: "Id",
                keyValue: "PJ22-026",
                column: "FotoProfil",
                value: null);

            migrationBuilder.UpdateData(
                table: "TblPegawai",
                keyColumn: "Id",
                keyValue: "PJ23-029",
                column: "FotoProfil",
                value: null);

            migrationBuilder.UpdateData(
                table: "TblPegawai",
                keyColumn: "Id",
                keyValue: "PJ23-030",
                column: "FotoProfil",
                value: null);

            migrationBuilder.UpdateData(
                table: "TblPegawai",
                keyColumn: "Id",
                keyValue: "PJ23-031",
                column: "FotoProfil",
                value: null);

            migrationBuilder.UpdateData(
                table: "TblPegawai",
                keyColumn: "Id",
                keyValue: "PJ24-002",
                column: "FotoProfil",
                value: null);

            migrationBuilder.UpdateData(
                table: "TblPegawai",
                keyColumn: "Id",
                keyValue: "PJ24-003",
                column: "FotoProfil",
                value: null);

            migrationBuilder.UpdateData(
                table: "TblPegawai",
                keyColumn: "Id",
                keyValue: "PJ24-004",
                column: "FotoProfil",
                value: null);

            migrationBuilder.UpdateData(
                table: "TblPegawai",
                keyColumn: "Id",
                keyValue: "PJ24-005",
                column: "FotoProfil",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FotoProfil",
                table: "TblPegawai");
        }
    }
}
