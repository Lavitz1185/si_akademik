using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataNilai2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TblEvaluasiSiswa",
                columns: new[] { "Id", "Deskripsi", "JadwalMengajarId", "Jenis" },
                values: new object[,]
                {
                    { 5, "Tugas 1", 4, 0 },
                    { 6, "UH 1", 4, 1 },
                    { 7, "UTS", 4, 2 },
                    { 8, "UAS", 4, 3 },
                    { 9, "Tugas 1", 5, 0 },
                    { 10, "UH 1", 5, 1 },
                    { 11, "UTS", 5, 2 },
                    { 12, "UAS", 5, 3 },
                    { 13, "Tugas 1", 6, 0 },
                    { 14, "UH 1", 6, 1 },
                    { 15, "UTS", 6, 2 },
                    { 16, "UAS", 6, 3 }
                });

            migrationBuilder.InsertData(
                table: "TblNilaiEvaluasiSiswa",
                columns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa", "Nilai" },
                values: new object[,]
                {
                    { 1, 4, 100 },
                    { 1, 5, 91 },
                    { 1, 6, 91 },
                    { 1, 7, 91 },
                    { 1, 8, 91 },
                    { 1, 9, 90 },
                    { 1, 10, 90 },
                    { 1, 11, 90 },
                    { 1, 12, 90 },
                    { 1, 13, 90 },
                    { 1, 14, 90 },
                    { 1, 15, 90 },
                    { 1, 16, 90 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 6 });

            migrationBuilder.DeleteData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 7 });

            migrationBuilder.DeleteData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 8 });

            migrationBuilder.DeleteData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 9 });

            migrationBuilder.DeleteData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 10 });

            migrationBuilder.DeleteData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 11 });

            migrationBuilder.DeleteData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 12 });

            migrationBuilder.DeleteData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 13 });

            migrationBuilder.DeleteData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 14 });

            migrationBuilder.DeleteData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 15 });

            migrationBuilder.DeleteData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 16 });

            migrationBuilder.DeleteData(
                table: "TblEvaluasiSiswa",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TblEvaluasiSiswa",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TblEvaluasiSiswa",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TblEvaluasiSiswa",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TblEvaluasiSiswa",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TblEvaluasiSiswa",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "TblEvaluasiSiswa",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "TblEvaluasiSiswa",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "TblEvaluasiSiswa",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "TblEvaluasiSiswa",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "TblEvaluasiSiswa",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "TblEvaluasiSiswa",
                keyColumn: "Id",
                keyValue: 16);
        }
    }
}
