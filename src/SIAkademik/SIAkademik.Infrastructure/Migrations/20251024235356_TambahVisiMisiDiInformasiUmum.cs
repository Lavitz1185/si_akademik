using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TambahVisiMisiDiInformasiUmum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MisiSekolah",
                table: "TblInformasiUmum",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VisiSekolah",
                table: "TblInformasiUmum",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "TblInformasiUmum",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "MisiSekolah", "VisiSekolah" },
                values: new object[] { "<ol class=\"isi\"><li>Membangkitkan kesadaran dalam diri setiap siswa bahwa mereka adalah ciptaan Tuhan yang unik dan ditetapkan sebagai pemimpin.</li> <li>Menanamkan dan menumbuhkan jiwa kewirausahaan dalam diri setiap siswa. </li><li>Menanamkan nilai-nilai pengabdian kepada bangsa dan negara.</li></ol>", "<p>Visi SMAKr. Pandhega Jaya adalah “Mempersiapkan calon pemimpin yang cakap, berintegritas, penuh pengabdian, dan mencintai bangsa”./p><ul class=\"isi\"><li>Cakap artinya mempunyai kemampuan dan kepandaian untuk mengerjakan tanggung jawab dengan cekatan.</li><li>Berintegritas artinya berani bertanggung jawab atas tindakan maupun perkataan, serta dapat diandalkan.</li><li>Penuh pengabdian artinya atas kesadaran pribadi memberikan diri untuk melakukan tanggung jawab tanpa pamrih.</li><li>Mencintai bangsa artinya memikirkan kelangsungan hidup bangsa dan melakukan berbagai upaya untuk membangunnya.</li></ul>" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MisiSekolah",
                table: "TblInformasiUmum");

            migrationBuilder.DropColumn(
                name: "VisiSekolah",
                table: "TblInformasiUmum");
        }
    }
}
