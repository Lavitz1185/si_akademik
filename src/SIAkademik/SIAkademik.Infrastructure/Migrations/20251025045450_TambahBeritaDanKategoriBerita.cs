using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TambahBeritaDanKategoriBerita : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblKategoriBerita",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nama = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblKategoriBerita", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblBerita",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Judul = table.Column<string>(type: "text", nullable: false),
                    Isi = table.Column<string>(type: "text", nullable: false),
                    Tanggal = table.Column<DateOnly>(type: "date", nullable: false),
                    Foto = table.Column<string>(type: "text", nullable: false),
                    KategoriBeritaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblBerita", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblBerita_TblKategoriBerita_KategoriBeritaId",
                        column: x => x.KategoriBeritaId,
                        principalTable: "TblKategoriBerita",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TblKategoriBerita",
                columns: new[] { "Id", "Nama" },
                values: new object[,]
                {
                    { 1, "Berita" },
                    { 2, "Pengumuman" }
                });

            migrationBuilder.InsertData(
                table: "TblBerita",
                columns: new[] { "Id", "Foto", "Isi", "Judul", "KategoriBeritaId", "Tanggal" },
                values: new object[] { 1, "/images/siswa1.jpg", "<p>Tahun ajaran 2025/2026 menjadi momen yang sangat berharga bagi para siswa kelas XII di seluruh Indonesia. Setelah menempuh perjalanan panjang selama tiga tahun, penuh dengan tantangan akademik maupun non-akademik, akhirnya mereka sampai pada titik akhir pendidikan menengah. Kelulusan ini bukan hanya menjadi bukti pencapaian secara akademik, tetapi juga mencerminkan kedewasaan dan kesiapan siswa untuk melangkah ke jenjang yang lebih tinggi. Selama masa pendidikan, para siswa telah menghadapi berbagai perubahan, mulai dari kurikulum Merdeka Belajar, metode pembelajaran digital, hingga tantangan pasca-pandemi. Namun, dengan semangat belajar dan dukungan dari guru, orang tua, serta lingkungan sekolah, mereka mampu menyelesaikan studi dengan baik.</p><br><p>Pencapaian ini tentu patut dibanggakan karena mencerminkan kerja keras dan ketekunan yang konsisten. Kelulusan tahun ini juga menjadi momentum penting untuk merefleksikan potensi dan tujuan ke depan. Bagi sebagian siswa, ini menjadi awal untuk melanjutkan pendidikan ke perguruan tinggi, sementara yang lain mungkin memilih jalur vokasi, wirausaha, atau dunia kerja. Apa pun pilihannya, bekal ilmu, karakter, dan pengalaman selama di SMA akan menjadi fondasi penting dalam menghadapi masa depan. Pihak sekolah turut memberikan apresiasi kepada seluruh siswa atas pencapaian mereka. Acara kelulusan tahun ini dirancang secara khidmat namun tetap meriah, menghadirkan suasana haru sekaligus kegembiraan. Guru-guru juga memberikan pesan motivasi agar para lulusan tidak hanya menjadi pribadi yang cerdas, tetapi juga beretika dan peduli terhadap lingkungan sosial mereka. Akhirnya, kelulusan bukanlah akhir dari segalanya, melainkan awal dari perjalanan hidup yang lebih menantang. Harapan besar ditujukan kepada seluruh lulusan SMA tahun ajaran 2025/2026 agar terus belajar, tumbuh, dan memberikan kontribusi positif bagi masyarakat. Selamat atas kelulusan, semoga langkah selanjutnya selalu diberkati dan penuh kesuksesan.</p>", "Kelulusan Kelas XII Tahun Pelajaran 2024/2025", 2, new DateOnly(2025, 8, 27) });

            migrationBuilder.CreateIndex(
                name: "IX_TblBerita_KategoriBeritaId",
                table: "TblBerita",
                column: "KategoriBeritaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblBerita");

            migrationBuilder.DropTable(
                name: "TblKategoriBerita");
        }
    }
}
