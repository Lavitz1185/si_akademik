using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PindahTahunAjaranKeRombel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblKelas_TblTahunAjaran_TahunAjaranId",
                table: "TblKelas");

            migrationBuilder.DropIndex(
                name: "IX_TblKelas_TahunAjaranId",
                table: "TblKelas");

            migrationBuilder.DropColumn(
                name: "TahunAjaranId",
                table: "TblKelas");

            migrationBuilder.AddColumn<int>(
                name: "TahunAjaranId",
                table: "TblRombel",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "TblRombel",
                keyColumn: "Id",
                keyValue: 1,
                column: "TahunAjaranId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TblRombel",
                keyColumn: "Id",
                keyValue: 2,
                column: "TahunAjaranId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "TblRombel",
                keyColumn: "Id",
                keyValue: 3,
                column: "TahunAjaranId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "TblRombel",
                keyColumn: "Id",
                keyValue: 4,
                column: "TahunAjaranId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "TblRombel",
                keyColumn: "Id",
                keyValue: 5,
                column: "TahunAjaranId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "TblRombel",
                keyColumn: "Id",
                keyValue: 6,
                column: "TahunAjaranId",
                value: 2);

            migrationBuilder.CreateIndex(
                name: "IX_TblRombel_TahunAjaranId",
                table: "TblRombel",
                column: "TahunAjaranId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblRombel_TblTahunAjaran_TahunAjaranId",
                table: "TblRombel",
                column: "TahunAjaranId",
                principalTable: "TblTahunAjaran",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblRombel_TblTahunAjaran_TahunAjaranId",
                table: "TblRombel");

            migrationBuilder.DropIndex(
                name: "IX_TblRombel_TahunAjaranId",
                table: "TblRombel");

            migrationBuilder.DropColumn(
                name: "TahunAjaranId",
                table: "TblRombel");

            migrationBuilder.AddColumn<int>(
                name: "TahunAjaranId",
                table: "TblKelas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "TblKelas",
                keyColumn: "Id",
                keyValue: 1,
                column: "TahunAjaranId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TblKelas",
                keyColumn: "Id",
                keyValue: 2,
                column: "TahunAjaranId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "TblKelas",
                keyColumn: "Id",
                keyValue: 3,
                column: "TahunAjaranId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "TblKelas",
                keyColumn: "Id",
                keyValue: 4,
                column: "TahunAjaranId",
                value: 2);

            migrationBuilder.CreateIndex(
                name: "IX_TblKelas_TahunAjaranId",
                table: "TblKelas",
                column: "TahunAjaranId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblKelas_TblTahunAjaran_TahunAjaranId",
                table: "TblKelas",
                column: "TahunAjaranId",
                principalTable: "TblTahunAjaran",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
