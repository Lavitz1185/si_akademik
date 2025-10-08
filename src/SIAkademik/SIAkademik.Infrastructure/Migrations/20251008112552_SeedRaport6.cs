using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedRaport6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TblMataPelajaran",
                columns: new[] { "Id", "KKM", "Nama", "PeminatanId" },
                values: new object[] { 17, 75.0, "Seni Budaya", 1 });

            migrationBuilder.InsertData(
                table: "TblJadwalMengajar",
                columns: new[] { "Id", "MataPelajaranId", "PegawaiId", "RombelId" },
                values: new object[] { 31, 17, "PJ17-010", 2 });

            migrationBuilder.InsertData(
                table: "TblEvaluasiSiswa",
                columns: new[] { "Id", "Deskripsi", "JadwalMengajarId", "Jenis" },
                values: new object[,]
                {
                    { 57, "Tugas 1", 31, 0 },
                    { 58, "UH 1", 31, 1 },
                    { 59, "UTS", 31, 2 },
                    { 60, "UAS", 31, 3 }
                });

            migrationBuilder.InsertData(
                table: "TblRaport",
                columns: new[] { "Id", "AnggotaRombelId", "Deskripsi", "JadwalMengajarId", "KategoriNilai", "Nama", "Predikat" },
                values: new object[] { 18, 1, "Kompetensi pengetahuan baik, sangat menguasai sistem produksi kerajinan inovatif sesuai kebutuhan pasar global berdasarkan daya dukung yang dimiliki oleh daerah setempat, sangat menguasai perencanaan usaha kerajinan inovatif berdasarkan kebutuhan pasar global", 31, 1, "", "A" });

            migrationBuilder.InsertData(
                table: "TblNilaiEvaluasiSiswa",
                columns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa", "Nilai" },
                values: new object[,]
                {
                    { 1, 57, 90.0 },
                    { 1, 58, 90.0 },
                    { 1, 59, 90.0 },
                    { 1, 60, 90.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 57 });

            migrationBuilder.DeleteData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 58 });

            migrationBuilder.DeleteData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 59 });

            migrationBuilder.DeleteData(
                table: "TblNilaiEvaluasiSiswa",
                keyColumns: new[] { "IdAnggotaRombel", "IdEvaluasiSiswa" },
                keyValues: new object[] { 1, 60 });

            migrationBuilder.DeleteData(
                table: "TblRaport",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "TblEvaluasiSiswa",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "TblEvaluasiSiswa",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "TblEvaluasiSiswa",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "TblEvaluasiSiswa",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "TblJadwalMengajar",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "TblMataPelajaran",
                keyColumn: "Id",
                keyValue: 17);
        }
    }
}
