using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TambahAktifKeAnggotaRombel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Aktif",
                table: "TblAnggotaRombel",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 1,
                column: "Aktif",
                value: true);

            migrationBuilder.UpdateData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 2,
                column: "Aktif",
                value: true);

            migrationBuilder.UpdateData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 3,
                column: "Aktif",
                value: true);

            migrationBuilder.UpdateData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 4,
                column: "Aktif",
                value: true);

            migrationBuilder.UpdateData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 5,
                column: "Aktif",
                value: true);

            migrationBuilder.UpdateData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 6,
                column: "Aktif",
                value: true);

            migrationBuilder.UpdateData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 7,
                column: "Aktif",
                value: true);

            migrationBuilder.UpdateData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 8,
                column: "Aktif",
                value: true);

            migrationBuilder.UpdateData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 9,
                column: "Aktif",
                value: true);

            migrationBuilder.UpdateData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 10,
                column: "Aktif",
                value: true);

            migrationBuilder.UpdateData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 11,
                column: "Aktif",
                value: true);

            migrationBuilder.UpdateData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 12,
                column: "Aktif",
                value: true);

            migrationBuilder.UpdateData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 13,
                column: "Aktif",
                value: true);

            migrationBuilder.UpdateData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 14,
                column: "Aktif",
                value: true);

            migrationBuilder.UpdateData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 15,
                column: "Aktif",
                value: true);

            migrationBuilder.UpdateData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 16,
                column: "Aktif",
                value: true);

            migrationBuilder.UpdateData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 17,
                column: "Aktif",
                value: true);

            migrationBuilder.UpdateData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 18,
                column: "Aktif",
                value: true);

            migrationBuilder.UpdateData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 19,
                column: "Aktif",
                value: true);

            migrationBuilder.UpdateData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 20,
                column: "Aktif",
                value: true);

            migrationBuilder.UpdateData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 21,
                column: "Aktif",
                value: true);

            migrationBuilder.UpdateData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 22,
                column: "Aktif",
                value: true);

            migrationBuilder.UpdateData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 23,
                column: "Aktif",
                value: true);

            migrationBuilder.UpdateData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 24,
                column: "Aktif",
                value: true);

            migrationBuilder.UpdateData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 25,
                column: "Aktif",
                value: true);

            migrationBuilder.UpdateData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 26,
                column: "Aktif",
                value: true);

            migrationBuilder.UpdateData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 27,
                column: "Aktif",
                value: true);

            migrationBuilder.UpdateData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 28,
                column: "Aktif",
                value: true);

            migrationBuilder.UpdateData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 29,
                column: "Aktif",
                value: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Aktif",
                table: "TblAnggotaRombel");
        }
    }
}
