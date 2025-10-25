using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TambahInformasiUmum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblInformasiUmum",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NamaSekolah = table.Column<string>(type: "text", nullable: false),
                    ProfilSingkatSekolah = table.Column<string>(type: "text", nullable: false),
                    SloganSekolah = table.Column<string>(type: "text", nullable: false),
                    AlamatSekolah = table.Column<string>(type: "text", nullable: false),
                    NoHPSekolah = table.Column<string>(type: "text", nullable: false),
                    EmailSekolah = table.Column<string>(type: "text", nullable: false),
                    FacebookSekolah = table.Column<string>(type: "text", nullable: false),
                    InstagramSekolah = table.Column<string>(type: "text", nullable: false),
                    LirikMarsSekolah = table.Column<string>(type: "text", nullable: false),
                    NamaYayasan = table.Column<string>(type: "text", nullable: false),
                    SambutanPimpinanYayasan = table.Column<string>(type: "text", nullable: false),
                    DewanPembinaYayasan = table.Column<string>(type: "text", nullable: false),
                    KetuaUmumYayasan = table.Column<string>(type: "text", nullable: false),
                    KetuaUmum2Yayasan = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblInformasiUmum", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TblInformasiUmum",
                columns: new[] { "Id", "AlamatSekolah", "DewanPembinaYayasan", "EmailSekolah", "FacebookSekolah", "InstagramSekolah", "KetuaUmum2Yayasan", "KetuaUmumYayasan", "LirikMarsSekolah", "NamaSekolah", "NamaYayasan", "NoHPSekolah", "ProfilSingkatSekolah", "SambutanPimpinanYayasan", "SloganSekolah" },
                values: new object[] { 1, "Jl. Tilong Dam Km 5, Desa Oelnasi, Kecamatan Kupang Tengah. Kabupaten Kupang. NTT – 85361", "Budi Utomo, S.T., M.TH", "smapandhegajaya@gmail.com", "https://www.facebook.com/", "https://www.instagram.com/", "Erlangga Dharma, S.E., M.SC", "Anton Darmawan, S.T", "Kamilah pemimpin yang siap untuk dibentuk berkarakter Kristus dan cintai bangsa di atas kebenaran kami berpijak percaya diri untuk mandiri berani berkreasi kembangkan potensi menjadi anak bangsa yang penuh prestasi memajukan negeri tercinta bangkitlah Pandhega Jayab berkaryalah bagi bangsa dengan Nilai kebenaran Bersiaplah tuk menjadi Pembangun Indonesia Pandhega Berjayalah", "SMA Kristen Pandhega Jaya", "Yayasan Pandhega Jaya", "081238007577", "Selamat datang di SMA Kristen Pandhega Jaya, tempat dimana ilmu dan keterampilan diajarkan dengan penuh kasih sayang. Kami bangga dapat menyediakan lingkungan belajar yang menyenangkan dan menyegarkan bagi siswa-siswi kami. ", "Selamat datang di SMA Kristen Pandhega Jaya, tempat dimana ilmu dan keterampilan diajarkan dengan penuh kasih sayang. Kami bangga dapat menyediakan lingkungan belajar yang menyenangkan dan menyegarkan bagi siswa-siswi kami. Kami bertekad untuk memberikan pendidikan yang berkualitas dan berkelanjutan, yang akan mempersiapkan siswa-siswi kami untuk menjadi pemimpin masa depan yang sukses. Terima kasih atas dukungan dan kerja sama anda.", "Sekolah berlandaskan nilai-nilai Kristiani yang membimbing setiap peserta didik untuk tumbuh menjadi pribadi yang beriman, berkarakter, dan berprestasi. Bersama kami, raih masa depan yang cerah melalui pendidikan yang unggul dan penuh kasih. " });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblInformasiUmum");
        }
    }
}
