using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class BuatAccounDiPegawaiRequired : Migration
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
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "PasswordHash", "Role", "UserName" },
                values: new object[] { 48, "AQAAAAIAAYagAAAAEKXsR8woVHO5DgmyBgmfe5b4I7jeJZYtk71JFY4HkDSCsimeHtIwzOueTyHo8gBH/A==", "GURU", "sndymeha55@gmail.com" });

            migrationBuilder.UpdateData(
                table: "TblPegawai",
                keyColumn: "Id",
                keyValue: "PJ22-026",
                column: "AppUserId",
                value: 48);

            migrationBuilder.AddForeignKey(
                name: "FK_TblPegawai_AppUser_AppUserId",
                table: "TblPegawai",
                column: "AppUserId",
                principalTable: "AppUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblPegawai_AppUser_AppUserId",
                table: "TblPegawai");

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "TblPegawai",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.UpdateData(
                table: "TblPegawai",
                keyColumn: "Id",
                keyValue: "PJ22-026",
                column: "AppUserId",
                value: null);

            migrationBuilder.AddForeignKey(
                name: "FK_TblPegawai_AppUser_AppUserId",
                table: "TblPegawai",
                column: "AppUserId",
                principalTable: "AppUser",
                principalColumn: "Id");
        }
    }
}
