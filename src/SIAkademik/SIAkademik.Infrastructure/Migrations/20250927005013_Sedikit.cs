using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Sedikit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Keterangan",
                table: "TblPertemuan",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.InsertData(
                table: "TblMataPelajaran",
                columns: new[] { "Id", "Jenjang", "Nama", "Peminatan" },
                values: new object[] { 2, 0, "Bahasa Indonesia", 0 });

            migrationBuilder.UpdateData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 1,
                column: "Keterangan",
                value: null);

            migrationBuilder.UpdateData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 2,
                column: "Keterangan",
                value: null);

            migrationBuilder.UpdateData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 3,
                column: "Keterangan",
                value: null);

            migrationBuilder.UpdateData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 4,
                column: "Keterangan",
                value: null);

            migrationBuilder.UpdateData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 5,
                column: "Keterangan",
                value: null);

            migrationBuilder.UpdateData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 6,
                column: "Keterangan",
                value: null);

            migrationBuilder.UpdateData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 7,
                column: "Keterangan",
                value: null);

            migrationBuilder.UpdateData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 8,
                column: "Keterangan",
                value: null);

            migrationBuilder.UpdateData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 9,
                column: "Keterangan",
                value: null);

            migrationBuilder.UpdateData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 10,
                column: "Keterangan",
                value: null);

            migrationBuilder.InsertData(
                table: "TblJadwalMengajar",
                columns: new[] { "Id", "MataPelajaranId", "PegawaiId", "RombelId" },
                values: new object[] { 2, 2, "PJ24-003", 1 });

            migrationBuilder.InsertData(
                table: "TblPertemuan",
                columns: new[] { "Id", "JadwalMengajarId", "Keterangan", "Nomor", "StatusPertemuan", "TanggalPelaksanaan" },
                values: new object[,]
                {
                    { 11, 2, null, 1, 0, null },
                    { 12, 2, null, 2, 0, null },
                    { 13, 2, null, 3, 0, null },
                    { 14, 2, null, 4, 0, null },
                    { 15, 2, null, 5, 0, null },
                    { 16, 2, null, 6, 0, null },
                    { 17, 2, null, 7, 0, null },
                    { 18, 2, null, 8, 0, null },
                    { 19, 2, null, 9, 0, null },
                    { 20, 2, null, 10, 0, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TblMataPelajaran",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<string>(
                name: "Keterangan",
                table: "TblPertemuan",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 1,
                column: "Keterangan",
                value: "");

            migrationBuilder.UpdateData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 2,
                column: "Keterangan",
                value: "");

            migrationBuilder.UpdateData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 3,
                column: "Keterangan",
                value: "");

            migrationBuilder.UpdateData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 4,
                column: "Keterangan",
                value: "");

            migrationBuilder.UpdateData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 5,
                column: "Keterangan",
                value: "");

            migrationBuilder.UpdateData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 6,
                column: "Keterangan",
                value: "");

            migrationBuilder.UpdateData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 7,
                column: "Keterangan",
                value: "");

            migrationBuilder.UpdateData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 8,
                column: "Keterangan",
                value: "");

            migrationBuilder.UpdateData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 9,
                column: "Keterangan",
                value: "");

            migrationBuilder.UpdateData(
                table: "TblPertemuan",
                keyColumn: "Id",
                keyValue: 10,
                column: "Keterangan",
                value: "");
        }
    }
}
