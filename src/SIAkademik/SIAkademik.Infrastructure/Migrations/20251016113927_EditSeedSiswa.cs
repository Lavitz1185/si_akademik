using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EditSeedSiswa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CatatanWaliKelas", "NaikKelasLulus" },
                values: new object[] { "Luar biasa tingkatkan", true });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TblAnggotaRombel",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CatatanWaliKelas", "NaikKelasLulus" },
                values: new object[] { "", false });
        }
    }
}
