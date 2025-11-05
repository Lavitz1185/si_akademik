using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TambahDurasiDiJadwalMengajar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JamAkhir",
                table: "TblHariMengajar");

            migrationBuilder.AddColumn<int>(
                name: "DurasiMenit",
                table: "TblJadwalMengajar",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 1,
                column: "DurasiMenit",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 2,
                column: "DurasiMenit",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 3,
                column: "DurasiMenit",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 4,
                column: "DurasiMenit",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 5,
                column: "DurasiMenit",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 6,
                column: "DurasiMenit",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 7,
                column: "DurasiMenit",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 8,
                column: "DurasiMenit",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 9,
                column: "DurasiMenit",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 10,
                column: "DurasiMenit",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 11,
                column: "DurasiMenit",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 12,
                column: "DurasiMenit",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 13,
                column: "DurasiMenit",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 14,
                column: "DurasiMenit",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 15,
                column: "DurasiMenit",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 17,
                column: "DurasiMenit",
                value: 45);

            migrationBuilder.UpdateData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 18,
                column: "DurasiMenit",
                value: 45);

            migrationBuilder.UpdateData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 19,
                column: "DurasiMenit",
                value: 45);

            migrationBuilder.UpdateData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 20,
                column: "DurasiMenit",
                value: 45);

            migrationBuilder.UpdateData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 21,
                column: "DurasiMenit",
                value: 45);

            migrationBuilder.UpdateData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 22,
                column: "DurasiMenit",
                value: 45);

            migrationBuilder.UpdateData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 23,
                column: "DurasiMenit",
                value: 45);

            migrationBuilder.UpdateData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 24,
                column: "DurasiMenit",
                value: 45);

            migrationBuilder.UpdateData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 25,
                column: "DurasiMenit",
                value: 45);

            migrationBuilder.UpdateData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 26,
                column: "DurasiMenit",
                value: 45);

            migrationBuilder.UpdateData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 27,
                column: "DurasiMenit",
                value: 45);

            migrationBuilder.UpdateData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 28,
                column: "DurasiMenit",
                value: 45);

            migrationBuilder.UpdateData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 29,
                column: "DurasiMenit",
                value: 45);

            migrationBuilder.UpdateData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 30,
                column: "DurasiMenit",
                value: 45);

            migrationBuilder.UpdateData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 31,
                column: "DurasiMenit",
                value: 45);

            migrationBuilder.UpdateData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 32,
                column: "DurasiMenit",
                value: 45);

            migrationBuilder.UpdateData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 33,
                column: "DurasiMenit",
                value: 45);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DurasiMenit",
                table: "TblJadwalMengajar");

            migrationBuilder.AddColumn<TimeOnly>(
                name: "JamAkhir",
                table: "TblHariMengajar",
                type: "time without time zone",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.UpdateData(
                table: "TblHariMengajar",
                keyColumn: "Id",
                keyValue: 1,
                column: "JamAkhir",
                value: new TimeOnly(9, 5, 0));

            migrationBuilder.UpdateData(
                table: "TblHariMengajar",
                keyColumn: "Id",
                keyValue: 2,
                column: "JamAkhir",
                value: new TimeOnly(10, 45, 0));

            migrationBuilder.UpdateData(
                table: "TblHariMengajar",
                keyColumn: "Id",
                keyValue: 3,
                column: "JamAkhir",
                value: new TimeOnly(12, 25, 0));

            migrationBuilder.UpdateData(
                table: "TblHariMengajar",
                keyColumn: "Id",
                keyValue: 4,
                column: "JamAkhir",
                value: new TimeOnly(14, 35, 0));

            migrationBuilder.UpdateData(
                table: "TblHariMengajar",
                keyColumn: "Id",
                keyValue: 5,
                column: "JamAkhir",
                value: new TimeOnly(14, 35, 0));

            migrationBuilder.UpdateData(
                table: "TblHariMengajar",
                keyColumn: "Id",
                keyValue: 6,
                column: "JamAkhir",
                value: new TimeOnly(9, 5, 0));

            migrationBuilder.UpdateData(
                table: "TblHariMengajar",
                keyColumn: "Id",
                keyValue: 7,
                column: "JamAkhir",
                value: new TimeOnly(10, 45, 0));

            migrationBuilder.UpdateData(
                table: "TblHariMengajar",
                keyColumn: "Id",
                keyValue: 8,
                column: "JamAkhir",
                value: new TimeOnly(12, 25, 0));

            migrationBuilder.UpdateData(
                table: "TblHariMengajar",
                keyColumn: "Id",
                keyValue: 9,
                column: "JamAkhir",
                value: new TimeOnly(21, 0, 0));

            migrationBuilder.UpdateData(
                table: "TblHariMengajar",
                keyColumn: "Id",
                keyValue: 10,
                column: "JamAkhir",
                value: new TimeOnly(9, 55, 0));

            migrationBuilder.UpdateData(
                table: "TblHariMengajar",
                keyColumn: "Id",
                keyValue: 11,
                column: "JamAkhir",
                value: new TimeOnly(12, 25, 0));

            migrationBuilder.UpdateData(
                table: "TblHariMengajar",
                keyColumn: "Id",
                keyValue: 12,
                column: "JamAkhir",
                value: new TimeOnly(14, 35, 0));

            migrationBuilder.UpdateData(
                table: "TblHariMengajar",
                keyColumn: "Id",
                keyValue: 13,
                column: "JamAkhir",
                value: new TimeOnly(9, 5, 0));

            migrationBuilder.UpdateData(
                table: "TblHariMengajar",
                keyColumn: "Id",
                keyValue: 14,
                column: "JamAkhir",
                value: new TimeOnly(10, 45, 0));

            migrationBuilder.UpdateData(
                table: "TblHariMengajar",
                keyColumn: "Id",
                keyValue: 15,
                column: "JamAkhir",
                value: new TimeOnly(12, 25, 0));

            migrationBuilder.UpdateData(
                table: "TblHariMengajar",
                keyColumn: "Id",
                keyValue: 16,
                column: "JamAkhir",
                value: new TimeOnly(9, 55, 0));

            migrationBuilder.UpdateData(
                table: "TblHariMengajar",
                keyColumn: "Id",
                keyValue: 17,
                column: "JamAkhir",
                value: new TimeOnly(12, 25, 0));

            migrationBuilder.UpdateData(
                table: "TblHariMengajar",
                keyColumn: "Id",
                keyValue: 18,
                column: "JamAkhir",
                value: new TimeOnly(14, 35, 0));
        }
    }
}
