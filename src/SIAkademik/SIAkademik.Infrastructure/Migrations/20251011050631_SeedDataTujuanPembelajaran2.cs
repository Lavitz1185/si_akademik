using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataTujuanPembelajaran2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TblTujuanPembelajaran",
                columns: new[] { "Id", "Deskripsi", "Fase", "MataPelajaranId", "Nomor" },
                values: new object[,]
                {
                    { 34, "Memahami secara kritis perkembangan kebudayaan, ilmu pengetahuan dan tehnologi sebagai anugerah Allah.", 1, 3, 1 },
                    { 35, "Memahami Demokrasi dan HAM sebagai anugerah Allah serta mewujudkan dalam praktik.", 1, 3, 2 },
                    { 36, "Mengembangkan serta memanfaatkan talenta untuk kepentingan bangsa dan negara.", 1, 3, 3 },
                    { 37, "Mengembangkan serta memanfaatkan talenta untuk kepentingan bangsa dan negara.", 1, 3, 4 },
                    { 38, "Memahami tantangan dalam kehidupan keluarga masa kini dan solusinya berdasarkan teks Alkitab.", 1, 3, 5 },
                    { 39, "Mengembangkan komunikasi dalam konteks lokal dan global.", 1, 3, 6 },
                    { 40, "Memahami Allah membarui serta memulihkan kehidupan keluarga Kristen, gereja dan bangsa", 1, 3, 7 },
                    { 41, "Mewujudkan tanggung jawab sebagai manusia dewasa dalam konteks yang lebih luas.", 1, 3, 8 },
                    { 42, "Memahami keadilan sebagai dasar demokrasi dan HAM.", 1, 3, 9 },
                    { 43, "Memahami nilai iman sebagai landasan hidup berkeluarga.", 1, 3, 10 },
                    { 44, "Menerapkan sikap proaktif sebagai pembawa damai sejahtera menurut Alkitab", 1, 3, 11 },
                    { 45, "Memahami karakter tokoh-tokoh agama yang mengabdikan hidupnya bagi persaudaraan dan solidaritas antar umat beragama serta menerapkannya dalam kehidupan sehari-hari.", 1, 3, 12 },
                    { 46, "Memahami issu-issu ras, etnis dan gender dalam rangka mewujudkan keadilan.", 1, 3, 13 },
                    { 47, "Menerapkan transformasi sosial dalam lingkup masyarakat majemuk.", 1, 3, 14 },
                    { 48, "Menerapkan moderasi beragama di tengah kehidupan masyarakat", 1, 3, 15 },
                    { 49, "Memahami prinsip pemeliharaan dan pelestarian alam serta keutuhan ciptaan Allah", 1, 3, 16 },
                    { 50, "Menerapkan tanggung-jawab memelihara alam", 1, 3, 17 },
                    { 51, "Menerapkan sikap ugahari demi kelestarian alam.", 1, 3, 18 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TblTujuanPembelajaran",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "TblTujuanPembelajaran",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "TblTujuanPembelajaran",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "TblTujuanPembelajaran",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "TblTujuanPembelajaran",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "TblTujuanPembelajaran",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "TblTujuanPembelajaran",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "TblTujuanPembelajaran",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "TblTujuanPembelajaran",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "TblTujuanPembelajaran",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "TblTujuanPembelajaran",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "TblTujuanPembelajaran",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "TblTujuanPembelajaran",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "TblTujuanPembelajaran",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "TblTujuanPembelajaran",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "TblTujuanPembelajaran",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "TblTujuanPembelajaran",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "TblTujuanPembelajaran",
                keyColumn: "Id",
                keyValue: 51);
        }
    }
}
