using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SIAkademik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TambahTujuanPembelajaran : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblTujuanPembelajaran",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Deskripsi = table.Column<string>(type: "text", nullable: false),
                    Fase = table.Column<int>(type: "integer", nullable: false),
                    MataPelajaranId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblTujuanPembelajaran", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblTujuanPembelajaran_TblMataPelajaran_MataPelajaranId",
                        column: x => x.MataPelajaranId,
                        principalTable: "TblMataPelajaran",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "TblMataPelajaran",
                keyColumn: "Id",
                keyValue: 11,
                column: "Nama",
                value: "Matematika Tingkat Lanjut");

            migrationBuilder.InsertData(
                table: "TblTujuanPembelajaran",
                columns: new[] { "Id", "Deskripsi", "Fase", "MataPelajaranId" },
                values: new object[,]
                {
                    { 1, "Memahami arti dewasa secara fisik, intelektual, emosional, sosial, moral dan spiritual", 0, 3 },
                    { 2, "Menghayati makna perilaku dewasa dan tidak dewasa dilingkungan keluarga dan masyarakat", 0, 3 },
                    { 3, "Memahami arti dewasa secara fisik, intelektual, emosional, sosial, moral dan spiritual", 0, 3 },
                    { 4, "Memahami arti dewasa secara fisik, intelektual, emosional, sosial, moral dan spiritual", 0, 3 },
                    { 5, "Memahami arti dewasa secara fisik, intelektual, emosional, sosial, moral dan spiritual", 0, 3 },
                    { 6, "Memahami arti dewasa secara fisik, intelektual, emosional, sosial, moral dan spiritual", 0, 3 },
                    { 7, "Memahami arti dewasa secara fisik, intelektual, emosional, sosial, moral dan spiritual", 0, 3 },
                    { 8, "Memahami arti dewasa secara fisik, intelektual, emosional, sosial, moral dan spiritual", 0, 3 },
                    { 9, "Memahami arti dewasa secara fisik, intelektual, emosional, sosial, moral dan spiritual", 0, 3 },
                    { 10, "Memahami arti dewasa secara fisik, intelektual, emosional, sosial, moral dan spiritual", 0, 3 },
                    { 11, "Memahami arti dewasa secara fisik, intelektual, emosional, sosial, moral dan spiritual", 0, 3 },
                    { 12, "Memahami arti dewasa secara fisik, intelektual, emosional, sosial, moral dan spiritual", 0, 3 },
                    { 13, "Memahami arti dewasa secara fisik, intelektual, emosional, sosial, moral dan spiritual", 0, 3 },
                    { 14, "Memahami arti dewasa secara fisik, intelektual, emosional, sosial, moral dan spiritual", 0, 3 },
                    { 15, "Memahami arti dewasa secara fisik, intelektual, emosional, sosial, moral dan spiritual", 0, 3 },
                    { 16, "Memahami arti dewasa secara fisik, intelektual, emosional, sosial, moral dan spiritual", 0, 3 },
                    { 17, "Memahami arti dewasa secara fisik, intelektual, emosional, sosial, moral dan spiritual", 0, 3 },
                    { 18, "Memahami arti dewasa secara fisik, intelektual, emosional, sosial, moral dan spiritual", 0, 3 },
                    { 19, "Memahami arti dewasa secara fisik, intelektual, emosional, sosial, moral dan spiritual", 0, 3 },
                    { 20, "Memahami arti dewasa secara fisik, intelektual, emosional, sosial, moral dan spiritual", 0, 3 },
                    { 21, "Memahami arti dewasa secara fisik, intelektual, emosional, sosial, moral dan spiritual", 0, 3 },
                    { 22, "Memahami arti dewasa secara fisik, intelektual, emosional, sosial, moral dan spiritual", 0, 3 },
                    { 23, "Memahami arti dewasa secara fisik, intelektual, emosional, sosial, moral dan spiritual", 0, 3 },
                    { 24, "Memahami arti dewasa secara fisik, intelektual, emosional, sosial, moral dan spiritual", 0, 3 },
                    { 25, "Memahami arti dewasa secara fisik, intelektual, emosional, sosial, moral dan spiritual", 0, 3 },
                    { 26, "Memahami arti dewasa secara fisik, intelektual, emosional, sosial, moral dan spiritual", 0, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblTujuanPembelajaran_MataPelajaranId",
                table: "TblTujuanPembelajaran",
                column: "MataPelajaranId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblTujuanPembelajaran");

            migrationBuilder.UpdateData(
                table: "TblMataPelajaran",
                keyColumn: "Id",
                keyValue: 11,
                column: "Nama",
                value: "Matematika");
        }
    }
}
