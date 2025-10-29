using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UbahLirikMarsDiInformasiUmum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TblInformasiUmum",
                keyColumn: "Id",
                keyValue: 1,
                column: "LirikMarsSekolah",
                value: "<p>Kamilah pemimpin </p><p> Yang siap untuk dibentuk</p><p> Berkarakter Kristus dan cintai bangsa </p><p> Di atas kebenaran kami berpijak </p><p> Percaya diri untuk mandiri </p><p> Berani berkreasi kembangkan potensi </p><p> Menjadi anak bangsa yang penuh prestasi </p><p> Memajukan negeri tercinta </p><p> Bangkitlah Pandhega Jaya </p><p> Berkaryalah bagi bangsa </p><p> Dengan Nilai kebenaran </p><p> Bersiaplah tuk menjadi </p><p> Pembangun Indonesia </p><p> Pandhega Berjayalah </p>");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TblInformasiUmum",
                keyColumn: "Id",
                keyValue: 1,
                column: "LirikMarsSekolah",
                value: "Kamilah pemimpin yang siap untuk dibentuk berkarakter Kristus dan cintai bangsa di atas kebenaran kami berpijak percaya diri untuk mandiri berani berkreasi kembangkan potensi menjadi anak bangsa yang penuh prestasi memajukan negeri tercinta bangkitlah Pandhega Jayab berkaryalah bagi bangsa dengan Nilai kebenaran Bersiaplah tuk menjadi Pembangun Indonesia Pandhega Berjayalah");
        }
    }
}
