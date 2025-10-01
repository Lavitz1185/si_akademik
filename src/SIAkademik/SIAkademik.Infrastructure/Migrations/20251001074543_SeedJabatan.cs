using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedJabatan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TblJabatan",
                columns: new[] { "Id", "Jenis", "Nama" },
                values: new object[,]
                {
                    { 2, 0, "Kepala Sekolah" },
                    { 3, 0, "Wakil Kepala Bidang Kesiswaan" },
                    { 4, 1, "Kepala Asrama" },
                    { 5, 0, "Guru Honor Olahraga" },
                    { 6, 0, "Wakil Kepala Bidang Kurikulum" },
                    { 7, 0, "Pembina OSIS" },
                    { 8, 0, "Guru Honor Geografi" },
                    { 9, 1, "Karyawan Pengadaan dan Keuangan" },
                    { 10, 0, "Guru Honor Fisika" },
                    { 11, 0, "Guru Honor Bahasa Indonesia" },
                    { 12, 0, "Guru English Center" },
                    { 13, 0, "Guru PPKN" },
                    { 14, 0, "Guru Biologi" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TblJabatan",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TblJabatan",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TblJabatan",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TblJabatan",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TblJabatan",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TblJabatan",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TblJabatan",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TblJabatan",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TblJabatan",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "TblJabatan",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "TblJabatan",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "TblJabatan",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "TblJabatan",
                keyColumn: "Id",
                keyValue: 14);
        }
    }
}
