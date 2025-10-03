using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TambahFotoProfildanIjazah : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblSiswa_TblPeminatan_PeminatanId",
                table: "TblSiswa");

            migrationBuilder.DropIndex(
                name: "IX_TblSiswa_PeminatanId",
                table: "TblSiswa");

            migrationBuilder.DropColumn(
                name: "PeminatanId",
                table: "TblSiswa");

            migrationBuilder.AddColumn<string>(
                name: "FotoProfil",
                table: "TblSiswa",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IjazahSMP",
                table: "TblSiswa",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Jenjang",
                table: "TblSiswa",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "TblSiswa",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FotoProfil", "IjazahSMP", "Jenjang" },
                values: new object[] { null, null, 2 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FotoProfil",
                table: "TblSiswa");

            migrationBuilder.DropColumn(
                name: "IjazahSMP",
                table: "TblSiswa");

            migrationBuilder.DropColumn(
                name: "Jenjang",
                table: "TblSiswa");

            migrationBuilder.AddColumn<int>(
                name: "PeminatanId",
                table: "TblSiswa",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "TblSiswa",
                keyColumn: "Id",
                keyValue: 2,
                column: "PeminatanId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_TblSiswa_PeminatanId",
                table: "TblSiswa",
                column: "PeminatanId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblSiswa_TblPeminatan_PeminatanId",
                table: "TblSiswa",
                column: "PeminatanId",
                principalTable: "TblPeminatan",
                principalColumn: "Id");
        }
    }
}
