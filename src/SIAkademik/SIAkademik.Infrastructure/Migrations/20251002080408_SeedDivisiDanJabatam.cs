using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedDivisiDanJabatam : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TblDivisi",
                columns: new[] { "Id", "Nama" },
                values: new object[,]
                {
                    { 3, "DPU" },
                    { 4, "HRD" },
                    { 5, "R&D" },
                    { 6, "Yayasan" }
                });

            migrationBuilder.InsertData(
                table: "TblJabatan",
                columns: new[] { "Id", "Jenis", "Nama" },
                values: new object[,]
                {
                    { 16, 0, "Direktor Sekolah" },
                    { 17, 0, "Guru Honor" },
                    { 18, 0, "Guru Honor Ekonomi" },
                    { 19, 0, "Guru Honor Matematika" },
                    { 20, 0, "Kordinator Operasional dan Kor DPU" },
                    { 21, 0, "Kordinator Sekolah" },
                    { 22, 1, "Karyawan SPV DPU" },
                    { 23, 1, "Karyawan Pengadaan dan Keuangan" },
                    { 24, 1, "Karyawan DPU" },
                    { 25, 1, "Kordinator HRD" },
                    { 26, 1, "Kordinator R&D" },
                    { 27, 1, "Karyawan Dapur" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TblDivisi",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TblDivisi",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TblDivisi",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TblDivisi",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TblJabatan",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "TblJabatan",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "TblJabatan",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "TblJabatan",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "TblJabatan",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "TblJabatan",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "TblJabatan",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "TblJabatan",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "TblJabatan",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "TblJabatan",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "TblJabatan",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "TblJabatan",
                keyColumn: "Id",
                keyValue: 27);
        }
    }
}
