using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TambahBatasBawahDiAsesmenSumatif : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "BatasBawahBaik",
                table: "TblAsesmenSumatif",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "BatasBawahCukup",
                table: "TblAsesmenSumatif",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "BatasBawahSangatBaik",
                table: "TblAsesmenSumatif",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "TblAsesmenSumatif",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BatasBawahBaik", "BatasBawahCukup", "BatasBawahSangatBaik" },
                values: new object[] { 80.0, 70.0, 90.0 });

            migrationBuilder.UpdateData(
                table: "TblAsesmenSumatif",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BatasBawahBaik", "BatasBawahCukup", "BatasBawahSangatBaik" },
                values: new object[] { 80.0, 70.0, 90.0 });

            migrationBuilder.UpdateData(
                table: "TblAsesmenSumatif",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BatasBawahBaik", "BatasBawahCukup", "BatasBawahSangatBaik" },
                values: new object[] { 80.0, 70.0, 90.0 });

            migrationBuilder.UpdateData(
                table: "TblAsesmenSumatif",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BatasBawahBaik", "BatasBawahCukup", "BatasBawahSangatBaik" },
                values: new object[] { 80.0, 70.0, 90.0 });

            migrationBuilder.UpdateData(
                table: "TblAsesmenSumatif",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "BatasBawahBaik", "BatasBawahCukup", "BatasBawahSangatBaik" },
                values: new object[] { 80.0, 70.0, 90.0 });

            migrationBuilder.UpdateData(
                table: "TblAsesmenSumatif",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "BatasBawahBaik", "BatasBawahCukup", "BatasBawahSangatBaik" },
                values: new object[] { 80.0, 70.0, 90.0 });

            migrationBuilder.UpdateData(
                table: "TblAsesmenSumatif",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "BatasBawahBaik", "BatasBawahCukup", "BatasBawahSangatBaik" },
                values: new object[] { 80.0, 70.0, 90.0 });

            migrationBuilder.UpdateData(
                table: "TblAsesmenSumatif",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "BatasBawahBaik", "BatasBawahCukup", "BatasBawahSangatBaik" },
                values: new object[] { 80.0, 70.0, 90.0 });

            migrationBuilder.UpdateData(
                table: "TblAsesmenSumatif",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "BatasBawahBaik", "BatasBawahCukup", "BatasBawahSangatBaik" },
                values: new object[] { 80.0, 70.0, 90.0 });

            migrationBuilder.UpdateData(
                table: "TblAsesmenSumatif",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "BatasBawahBaik", "BatasBawahCukup", "BatasBawahSangatBaik" },
                values: new object[] { 80.0, 70.0, 90.0 });

            migrationBuilder.UpdateData(
                table: "TblAsesmenSumatif",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "BatasBawahBaik", "BatasBawahCukup", "BatasBawahSangatBaik" },
                values: new object[] { 80.0, 70.0, 90.0 });

            migrationBuilder.UpdateData(
                table: "TblAsesmenSumatif",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "BatasBawahBaik", "BatasBawahCukup", "BatasBawahSangatBaik" },
                values: new object[] { 80.0, 70.0, 90.0 });

            migrationBuilder.UpdateData(
                table: "TblAsesmenSumatif",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "BatasBawahBaik", "BatasBawahCukup", "BatasBawahSangatBaik" },
                values: new object[] { 80.0, 70.0, 90.0 });

            migrationBuilder.UpdateData(
                table: "TblAsesmenSumatif",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "BatasBawahBaik", "BatasBawahCukup", "BatasBawahSangatBaik" },
                values: new object[] { 80.0, 70.0, 90.0 });

            migrationBuilder.UpdateData(
                table: "TblAsesmenSumatif",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "BatasBawahBaik", "BatasBawahCukup", "BatasBawahSangatBaik" },
                values: new object[] { 80.0, 70.0, 90.0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BatasBawahBaik",
                table: "TblAsesmenSumatif");

            migrationBuilder.DropColumn(
                name: "BatasBawahCukup",
                table: "TblAsesmenSumatif");

            migrationBuilder.DropColumn(
                name: "BatasBawahSangatBaik",
                table: "TblAsesmenSumatif");
        }
    }
}
