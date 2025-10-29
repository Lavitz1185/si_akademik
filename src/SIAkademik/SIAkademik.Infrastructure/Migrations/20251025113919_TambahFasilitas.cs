using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TambahFasilitas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblFasilitas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nama = table.Column<string>(type: "text", nullable: false),
                    Deskripsi = table.Column<string>(type: "text", nullable: false),
                    Foto = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblFasilitas", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TblFasilitas",
                columns: new[] { "Id", "Deskripsi", "Foto", "Nama" },
                values: new object[,]
                {
                    { 1, "Bangunan ini digunakan oleh siswa/i untuk beristirahat. Bangunan ini dilengkapi dengan lemari, tempat tidur, dan kamar mandi. Asrama dibagi menjadi dua, yaitu asrama putera dan asrama puteri.", "/images/fasilitas/asrama.png", "Asrama" },
                    { 2, "Tempat ini digunakan siswa/i untuk mencari tugas dan informasi untuk keperluan sekolah. Tempat ini dilengkapi 30 komputer yang bisa mengakses internet, memberikan kemudahan bagi siswa dalam mengakses sumber belajar secara online. ", "/images/fasilitas/lab_komputer.png", "Lab Komputer" },
                    { 3, "Tempat ini digunakan untuk menyimpan buku-buku bacaan di SMA Kr PANDHEGA JAYA, buku-buku yang tersedia juga adalah buku yang sudah di survei oleh tim perpustakaan agar dapat menunjang pembelajaran di SMA Kr PANDHEGA JAYA.", "/images/fasilitas/perpustakaan.png", "Perpustakaan" },
                    { 4, "Fasilitas dapur digunakan sebagai tempat kegiatan memasak dan pengolahan makanan bagi seluruh warga asrama. Dapur dilengkapi dengan peralatan memasak yang memadai untuk mendukung penyediaan konsumsi harian, serta menjadi area pendukung dalam menjaga kebersihan dan kesehatan lingkungan asrama.", "/images/fasilitas/dapur.png", "Dapur" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblFasilitas");
        }
    }
}
