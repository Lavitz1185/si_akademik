using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NamaMigrationBaru : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Nilai",
                table: "TblNilaiEvaluasiSiswa",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 1 },
                column: "Nilai",
                value: 100.0);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 2 },
                column: "Nilai",
                value: 100.0);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 3 },
                column: "Nilai",
                value: 100.0);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 4 },
                column: "Nilai",
                value: 100.0);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 5 },
                column: "Nilai",
                value: 91.0);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 6 },
                column: "Nilai",
                value: 91.0);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 7 },
                column: "Nilai",
                value: 91.0);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 8 },
                column: "Nilai",
                value: 91.0);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 9 },
                column: "Nilai",
                value: 90.0);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 10 },
                column: "Nilai",
                value: 90.0);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 11 },
                column: "Nilai",
                value: 90.0);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 12 },
                column: "Nilai",
                value: 90.0);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 13 },
                column: "Nilai",
                value: 90.0);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 14 },
                column: "Nilai",
                value: 90.0);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 15 },
                column: "Nilai",
                value: 90.0);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 16 },
                column: "Nilai",
                value: 90.0);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 17 },
                column: "Nilai",
                value: 89.0);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 18 },
                column: "Nilai",
                value: 89.0);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 19 },
                column: "Nilai",
                value: 89.0);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 20 },
                column: "Nilai",
                value: 89.0);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 21 },
                column: "Nilai",
                value: 87.0);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 22 },
                column: "Nilai",
                value: 87.0);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 23 },
                column: "Nilai",
                value: 87.0);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 24 },
                column: "Nilai",
                value: 87.0);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 25 },
                column: "Nilai",
                value: 93.0);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 26 },
                column: "Nilai",
                value: 93.0);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 27 },
                column: "Nilai",
                value: 93.0);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 28 },
                column: "Nilai",
                value: 93.0);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 29 },
                column: "Nilai",
                value: 86.0);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 30 },
                column: "Nilai",
                value: 86.0);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 31 },
                column: "Nilai",
                value: 86.0);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 32 },
                column: "Nilai",
                value: 86.0);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 33 },
                column: "Nilai",
                value: 90.0);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 34 },
                column: "Nilai",
                value: 90.0);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 35 },
                column: "Nilai",
                value: 90.0);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 36 },
                column: "Nilai",
                value: 90.0);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 37 },
                column: "Nilai",
                value: 92.0);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 38 },
                column: "Nilai",
                value: 92.0);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 39 },
                column: "Nilai",
                value: 92.0);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 40 },
                column: "Nilai",
                value: 92.0);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 41 },
                column: "Nilai",
                value: 86.0);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 42 },
                column: "Nilai",
                value: 86.0);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 43 },
                column: "Nilai",
                value: 86.0);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 44 },
                column: "Nilai",
                value: 86.0);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 45 },
                column: "Nilai",
                value: 95.0);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 46 },
                column: "Nilai",
                value: 95.0);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 47 },
                column: "Nilai",
                value: 95.0);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 48 },
                column: "Nilai",
                value: 95.0);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 49 },
                column: "Nilai",
                value: 97.0);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 50 },
                column: "Nilai",
                value: 97.0);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 51 },
                column: "Nilai",
                value: 97.0);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 52 },
                column: "Nilai",
                value: 97.0);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 53 },
                column: "Nilai",
                value: 90.0);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 54 },
                column: "Nilai",
                value: 90.0);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 55 },
                column: "Nilai",
                value: 90.0);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 56 },
                column: "Nilai",
                value: 90.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Nilai",
                table: "TblNilaiEvaluasiSiswa",
                type: "integer",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 1 },
                column: "Nilai",
                value: 100);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 2 },
                column: "Nilai",
                value: 100);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 3 },
                column: "Nilai",
                value: 100);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 4 },
                column: "Nilai",
                value: 100);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 5 },
                column: "Nilai",
                value: 91);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 6 },
                column: "Nilai",
                value: 91);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 7 },
                column: "Nilai",
                value: 91);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 8 },
                column: "Nilai",
                value: 91);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 9 },
                column: "Nilai",
                value: 90);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 10 },
                column: "Nilai",
                value: 90);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 11 },
                column: "Nilai",
                value: 90);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 12 },
                column: "Nilai",
                value: 90);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 13 },
                column: "Nilai",
                value: 90);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 14 },
                column: "Nilai",
                value: 90);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 15 },
                column: "Nilai",
                value: 90);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 16 },
                column: "Nilai",
                value: 90);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 17 },
                column: "Nilai",
                value: 89);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 18 },
                column: "Nilai",
                value: 89);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 19 },
                column: "Nilai",
                value: 89);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 20 },
                column: "Nilai",
                value: 89);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 21 },
                column: "Nilai",
                value: 87);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 22 },
                column: "Nilai",
                value: 87);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 23 },
                column: "Nilai",
                value: 87);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 24 },
                column: "Nilai",
                value: 87);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 25 },
                column: "Nilai",
                value: 93);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 26 },
                column: "Nilai",
                value: 93);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 27 },
                column: "Nilai",
                value: 93);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 28 },
                column: "Nilai",
                value: 93);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 29 },
                column: "Nilai",
                value: 86);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 30 },
                column: "Nilai",
                value: 86);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 31 },
                column: "Nilai",
                value: 86);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 32 },
                column: "Nilai",
                value: 86);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 33 },
                column: "Nilai",
                value: 90);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 34 },
                column: "Nilai",
                value: 90);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 35 },
                column: "Nilai",
                value: 90);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 36 },
                column: "Nilai",
                value: 90);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 37 },
                column: "Nilai",
                value: 92);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 38 },
                column: "Nilai",
                value: 92);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 39 },
                column: "Nilai",
                value: 92);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 40 },
                column: "Nilai",
                value: 92);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 41 },
                column: "Nilai",
                value: 86);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 42 },
                column: "Nilai",
                value: 86);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 43 },
                column: "Nilai",
                value: 86);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 44 },
                column: "Nilai",
                value: 86);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 45 },
                column: "Nilai",
                value: 95);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 46 },
                column: "Nilai",
                value: 95);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 47 },
                column: "Nilai",
                value: 95);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 48 },
                column: "Nilai",
                value: 95);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 49 },
                column: "Nilai",
                value: 97);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 50 },
                column: "Nilai",
                value: 97);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 51 },
                column: "Nilai",
                value: 97);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 52 },
                column: "Nilai",
                value: 97);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 53 },
                column: "Nilai",
                value: 90);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 54 },
                column: "Nilai",
                value: 90);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 55 },
                column: "Nilai",
                value: 90);

            migrationBuilder.UpdateData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 56 },
                column: "Nilai",
                value: 90);
        }
    }
}
