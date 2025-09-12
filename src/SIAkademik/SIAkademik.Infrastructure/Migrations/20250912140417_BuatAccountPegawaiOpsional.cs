using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class BuatAccountPegawaiOpsional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblPegawai_AppUser_AppUserId",
                table: "TblPegawai");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "TblPegawai",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_TblPegawai_AppUser_AppUserId",
                table: "TblPegawai",
                column: "AppUserId",
                principalTable: "AppUser",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblPegawai_AppUser_AppUserId",
                table: "TblPegawai");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "TblPegawai",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TblPegawai_AppUser_AppUserId",
                table: "TblPegawai",
                column: "AppUserId",
                principalTable: "AppUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
