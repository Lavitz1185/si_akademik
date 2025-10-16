using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TambahCatatanNaikDanKeteranganNaikKelasDiSiswa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CatatanWaliKelas",
                table: "TblAnggotaRombel",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "NaikKelasLulus",
                table: "TblAnggotaRombel",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CatatanWaliKelas", "NaikKelasLulus" },
                values: new object[] { "", false });

            migrationBuilder.UpdateData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CatatanWaliKelas", "NaikKelasLulus" },
                values: new object[] { "", false });

            migrationBuilder.UpdateData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CatatanWaliKelas", "NaikKelasLulus" },
                values: new object[] { "", false });

            migrationBuilder.UpdateData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CatatanWaliKelas", "NaikKelasLulus" },
                values: new object[] { "", false });

            migrationBuilder.UpdateData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CatatanWaliKelas", "NaikKelasLulus" },
                values: new object[] { "", false });

            migrationBuilder.UpdateData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CatatanWaliKelas", "NaikKelasLulus" },
                values: new object[] { "", false });

            migrationBuilder.UpdateData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CatatanWaliKelas", "NaikKelasLulus" },
                values: new object[] { "", false });

            migrationBuilder.UpdateData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CatatanWaliKelas", "NaikKelasLulus" },
                values: new object[] { "", false });

            migrationBuilder.UpdateData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CatatanWaliKelas", "NaikKelasLulus" },
                values: new object[] { "", false });

            migrationBuilder.UpdateData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CatatanWaliKelas", "NaikKelasLulus" },
                values: new object[] { "", false });

            migrationBuilder.UpdateData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CatatanWaliKelas", "NaikKelasLulus" },
                values: new object[] { "", false });

            migrationBuilder.UpdateData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CatatanWaliKelas", "NaikKelasLulus" },
                values: new object[] { "", false });

            migrationBuilder.UpdateData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CatatanWaliKelas", "NaikKelasLulus" },
                values: new object[] { "", false });

            migrationBuilder.UpdateData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CatatanWaliKelas", "NaikKelasLulus" },
                values: new object[] { "", false });

            migrationBuilder.UpdateData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CatatanWaliKelas", "NaikKelasLulus" },
                values: new object[] { "", false });

            migrationBuilder.UpdateData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CatatanWaliKelas", "NaikKelasLulus" },
                values: new object[] { "", false });

            migrationBuilder.UpdateData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CatatanWaliKelas", "NaikKelasLulus" },
                values: new object[] { "", false });

            migrationBuilder.UpdateData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CatatanWaliKelas", "NaikKelasLulus" },
                values: new object[] { "", false });

            migrationBuilder.UpdateData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CatatanWaliKelas", "NaikKelasLulus" },
                values: new object[] { "", false });

            migrationBuilder.UpdateData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CatatanWaliKelas", "NaikKelasLulus" },
                values: new object[] { "", false });

            migrationBuilder.UpdateData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CatatanWaliKelas", "NaikKelasLulus" },
                values: new object[] { "", false });

            migrationBuilder.UpdateData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CatatanWaliKelas", "NaikKelasLulus" },
                values: new object[] { "", false });

            migrationBuilder.UpdateData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CatatanWaliKelas", "NaikKelasLulus" },
                values: new object[] { "", false });

            migrationBuilder.UpdateData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CatatanWaliKelas", "NaikKelasLulus" },
                values: new object[] { "", false });

            migrationBuilder.UpdateData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CatatanWaliKelas", "NaikKelasLulus" },
                values: new object[] { "", false });

            migrationBuilder.UpdateData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CatatanWaliKelas", "NaikKelasLulus" },
                values: new object[] { "", false });

            migrationBuilder.UpdateData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CatatanWaliKelas", "NaikKelasLulus" },
                values: new object[] { "", false });

            migrationBuilder.UpdateData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CatatanWaliKelas", "NaikKelasLulus" },
                values: new object[] { "", false });

            migrationBuilder.UpdateData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CatatanWaliKelas", "NaikKelasLulus" },
                values: new object[] { "", false });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CatatanWaliKelas",
                table: "TblAnggotaRombel");

            migrationBuilder.DropColumn(
                name: "NaikKelasLulus",
                table: "TblAnggotaRombel");
        }
    }
}
