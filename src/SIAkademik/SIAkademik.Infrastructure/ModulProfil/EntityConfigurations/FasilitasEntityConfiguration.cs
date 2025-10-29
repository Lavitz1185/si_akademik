using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIAkademik.Domain.ModulProfil.Entities;

namespace SIAkademik.Infrastructure.ModulProfil.EntityConfigurations;

internal class FasilitasEntityConfiguration : IEntityTypeConfiguration<Fasilitas>
{
    public void Configure(EntityTypeBuilder<Fasilitas> builder)
    {
        builder.HasKey(f => f.Id);

        builder.HasData(
            new Fasilitas
            {
                Id = 1,
                Nama = "Asrama",
                Deskripsi = "Bangunan ini digunakan oleh siswa/i untuk beristirahat. Bangunan ini dilengkapi dengan lemari, tempat tidur, dan " +
                            "kamar mandi. Asrama dibagi menjadi dua, yaitu asrama putera dan asrama puteri.",
                Foto = new Uri("/images/fasilitas/asrama.png", UriKind.Relative)
            },
            new Fasilitas
            {
                Id = 2,
                Nama = "Lab Komputer",
                Deskripsi = "Tempat ini digunakan siswa/i untuk mencari tugas dan informasi untuk keperluan sekolah. Tempat ini dilengkapi 30 " +
                            "komputer yang bisa mengakses internet, memberikan kemudahan bagi siswa dalam mengakses sumber belajar secara online. ",
                Foto = new Uri("/images/fasilitas/lab_komputer.png", UriKind.Relative)
            },
            new Fasilitas
            {
                Id = 3,
                Nama = "Perpustakaan",
                Deskripsi = "Tempat ini digunakan untuk menyimpan buku-buku bacaan di SMA Kr PANDHEGA JAYA, buku-buku yang tersedia juga adalah " +
                            "buku yang sudah di survei oleh tim perpustakaan agar dapat menunjang pembelajaran di SMA Kr PANDHEGA JAYA.",
                Foto = new Uri("/images/fasilitas/perpustakaan.png", UriKind.Relative)
            },
            new Fasilitas
            {
                Id = 4,
                Nama = "Dapur",
                Deskripsi = "Fasilitas dapur digunakan sebagai tempat kegiatan memasak dan pengolahan makanan bagi seluruh warga asrama. Dapur " +
                            "dilengkapi dengan peralatan memasak yang memadai untuk mendukung penyediaan konsumsi harian, serta menjadi area " +
                            "pendukung dalam menjaga kebersihan dan kesehatan lingkungan asrama.",
                Foto = new Uri("/images/fasilitas/dapur.png", UriKind.Relative)
            }
        );
    }
}
