using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TambahAkunGuru : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "PasswordHash", "Role", "UserName" },
                values: new object[] { 47, "AQAAAAIAAYagAAAAEKXsR8woVHO5DgmyBgmfe5b4I7jeJZYtk71JFY4HkDSCsimeHtIwzOueTyHo8gBH/A==", "GURU", "etymissa0703@gmail.com" });

            migrationBuilder.UpdateData(
                table: "TblPegawai",
                keyColumn: "Id",
                keyValue: "PJ18-012",
                column: "AppUserId",
                value: 47);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.UpdateData(
                table: "TblPegawai",
                keyColumn: "Id",
                keyValue: "PJ18-012",
                column: "AppUserId",
                value: null);
        }
    }
}
