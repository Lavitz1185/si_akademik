using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TambahKKMDiMataPelajaran : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "KKM",
                table: "TblMataPelajaran",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "TblMataPelajaran",
                keyColumn: "Id",
                keyValue: 1,
                column: "KKM",
                value: 70.0);

            migrationBuilder.UpdateData(
                table: "TblMataPelajaran",
                keyColumn: "Id",
                keyValue: 2,
                column: "KKM",
                value: 80.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KKM",
                table: "TblMataPelajaran");
        }
    }
}
