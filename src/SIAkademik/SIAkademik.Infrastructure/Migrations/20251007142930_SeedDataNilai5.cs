using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataNilai5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TblNilaiEvaluasiSiswa",
                columns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa", "Nilai" },
                values: new object[,]
                {
                    { 1, 17, 89 },
                    { 1, 18, 89 },
                    { 1, 19, 89 },
                    { 1, 20, 89 },
                    { 1, 21, 87 },
                    { 1, 22, 87 },
                    { 1, 23, 87 },
                    { 1, 24, 87 },
                    { 1, 25, 93 },
                    { 1, 26, 93 },
                    { 1, 27, 93 },
                    { 1, 28, 93 },
                    { 1, 29, 86 },
                    { 1, 30, 86 },
                    { 1, 31, 86 },
                    { 1, 32, 86 },
                    { 1, 33, 90 },
                    { 1, 34, 90 },
                    { 1, 35, 90 },
                    { 1, 36, 90 },
                    { 1, 37, 92 },
                    { 1, 38, 92 },
                    { 1, 39, 92 },
                    { 1, 40, 92 },
                    { 1, 41, 86 },
                    { 1, 42, 86 },
                    { 1, 43, 86 },
                    { 1, 44, 86 },
                    { 1, 45, 95 },
                    { 1, 46, 95 },
                    { 1, 47, 95 },
                    { 1, 48, 95 },
                    { 1, 49, 97 },
                    { 1, 50, 97 },
                    { 1, 51, 97 },
                    { 1, 52, 97 },
                    { 1, 53, 90 },
                    { 1, 54, 90 },
                    { 1, 55, 90 },
                    { 1, 56, 90 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 17 });

            migrationBuilder.DeleteData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 18 });

            migrationBuilder.DeleteData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 19 });

            migrationBuilder.DeleteData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 20 });

            migrationBuilder.DeleteData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 21 });

            migrationBuilder.DeleteData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 22 });

            migrationBuilder.DeleteData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 23 });

            migrationBuilder.DeleteData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 24 });

            migrationBuilder.DeleteData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 25 });

            migrationBuilder.DeleteData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 26 });

            migrationBuilder.DeleteData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 27 });

            migrationBuilder.DeleteData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 28 });

            migrationBuilder.DeleteData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 29 });

            migrationBuilder.DeleteData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 30 });

            migrationBuilder.DeleteData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 31 });

            migrationBuilder.DeleteData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 32 });

            migrationBuilder.DeleteData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 33 });

            migrationBuilder.DeleteData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 34 });

            migrationBuilder.DeleteData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 35 });

            migrationBuilder.DeleteData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 36 });

            migrationBuilder.DeleteData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 37 });

            migrationBuilder.DeleteData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 38 });

            migrationBuilder.DeleteData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 39 });

            migrationBuilder.DeleteData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 40 });

            migrationBuilder.DeleteData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 41 });

            migrationBuilder.DeleteData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 42 });

            migrationBuilder.DeleteData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 43 });

            migrationBuilder.DeleteData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 44 });

            migrationBuilder.DeleteData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 45 });

            migrationBuilder.DeleteData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 46 });

            migrationBuilder.DeleteData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 47 });

            migrationBuilder.DeleteData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 48 });

            migrationBuilder.DeleteData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 49 });

            migrationBuilder.DeleteData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 50 });

            migrationBuilder.DeleteData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 51 });

            migrationBuilder.DeleteData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 52 });

            migrationBuilder.DeleteData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 53 });

            migrationBuilder.DeleteData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 54 });

            migrationBuilder.DeleteData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 55 });

            migrationBuilder.DeleteData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 56 });
        }
    }
}
