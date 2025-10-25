using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIAkademik.Domain.ModulProfil.Entities;
using SIAkademik.Domain.ValueObjects;
using SIAkademik.Infrastructure.Database.ValueConverters;

namespace SIAkademik.Infrastructure.ModulProfil.EntityConfigurations;

internal class InformasiUmumEntityConfiguration : IEntityTypeConfiguration<InformasiUmum>
{
    public void Configure(EntityTypeBuilder<InformasiUmum> builder)
    {
        builder.HasKey(i => i.Id);
        builder.Property(i => i.NoHPSekolah).HasConversion<NoHPIntConverter>();

        builder.HasData(
            new InformasiUmum
            {
                Id = 1,
                NamaSekolah = "SMA Kristen Pandhega Jaya",
                SloganSekolah = "Sekolah berlandaskan nilai-nilai Kristiani yang membimbing setiap peserta didik untuk tumbuh menjadi pribadi yang " +
                                "beriman, berkarakter, dan berprestasi. Bersama kami, raih masa depan yang cerah melalui pendidikan yang unggul dan " +
                                "penuh kasih. ",
                AlamatSekolah = "Jl. Tilong Dam Km 5, Desa Oelnasi, Kecamatan Kupang Tengah. Kabupaten Kupang. NTT – 85361",
                EmailSekolah = "smapandhegajaya@gmail.com",
                NoHPSekolah = NoHP.Create("081238007577").Value,
                ProfilSingkatSekolah = "Selamat datang di SMA Kristen Pandhega Jaya, tempat dimana ilmu dan keterampilan diajarkan dengan penuh kasih" +
                                       " sayang. Kami bangga dapat menyediakan lingkungan belajar yang menyenangkan dan menyegarkan bagi siswa-siswi" +
                                       " kami. ",
                LirikMarsSekolah = "<p>Kamilah pemimpin </p><p> Yang siap untuk dibentuk</p><p> Berkarakter Kristus dan cintai bangsa </p>" +
                                   "<p> Di atas kebenaran kami berpijak </p><p> Percaya diri untuk mandiri </p>" +
                                   "<p> Berani berkreasi kembangkan potensi </p><p> Menjadi anak bangsa yang penuh prestasi </p>" +
                                   "<p> Memajukan negeri tercinta </p><p> Bangkitlah Pandhega Jaya </p><p> Berkaryalah bagi bangsa </p>" +
                                   "<p> Dengan Nilai kebenaran </p><p> Bersiaplah tuk menjadi </p><p> Pembangun Indonesia </p>" +
                                   "<p> Pandhega Berjayalah </p>",
                VisiSekolah = "<p>Visi SMAKr. Pandhega Jaya adalah “Mempersiapkan calon pemimpin yang cakap, berintegritas, penuh pengabdian, dan " +
                              "mencintai bangsa”.</p><ul class=\"isi\"><li>Cakap artinya mempunyai kemampuan dan kepandaian untuk mengerjakan " +
                              "tanggung jawab dengan cekatan.</li><li>Berintegritas artinya berani bertanggung jawab atas tindakan maupun perkataan" +
                              ", serta dapat diandalkan.</li><li>Penuh pengabdian artinya atas kesadaran pribadi memberikan diri untuk melakukan " +
                              "tanggung jawab tanpa pamrih.</li><li>Mencintai bangsa artinya memikirkan kelangsungan hidup bangsa dan melakukan " +
                              "berbagai upaya untuk membangunnya.</li></ul>",
                MisiSekolah = "<ol class=\"isi\"><li>Membangkitkan kesadaran dalam diri setiap siswa bahwa mereka adalah ciptaan Tuhan yang unik " +
                              "dan ditetapkan sebagai pemimpin.</li> <li>Menanamkan dan menumbuhkan jiwa kewirausahaan dalam diri setiap siswa. " +
                              "</li><li>Menanamkan nilai-nilai pengabdian kepada bangsa dan negara.</li></ol>",
                FacebookSekolah = new Uri("https://www.facebook.com", UriKind.Absolute),
                InstagramSekolah = new Uri("https://www.instagram.com", UriKind.Absolute),
                LogoSekolah = new Uri("/images/logo_sekolah_transparent.png", UriKind.Relative),
                VideoHalamanBeranda = new Uri("https://www.youtube.com/embed/0F0zrVop0Gg?si=-bMdPjk3DHJkXz7H", UriKind.Absolute),
                VideoHalamanTentangKami = new Uri("https://www.youtube.com/embed/4Wt526OVxGg?si=L2EcPoD6nAunNxC6", UriKind.Absolute),
                NamaYayasan = "Yayasan Pandhega Jaya",
                SambutanPimpinanYayasan = "Selamat datang di SMA Kristen Pandhega Jaya, tempat dimana ilmu dan keterampilan diajarkan dengan penuh " +
                                          "kasih sayang. Kami bangga dapat menyediakan lingkungan belajar yang menyenangkan dan menyegarkan bagi " +
                                          "siswa-siswi kami. Kami bertekad untuk memberikan pendidikan yang berkualitas dan berkelanjutan, yang " +
                                          "akan mempersiapkan siswa-siswi kami untuk menjadi pemimpin masa depan yang sukses. Terima kasih atas " +
                                          "dukungan dan kerja sama anda.",
                DewanPembinaYayasan = "Budi Utomo, S.T., M.TH",
                KetuaUmumYayasan = "Anton Darmawan, S.T",
                KetuaUmum2Yayasan = "Erlangga Dharma, S.E., M.SC",
            }
        );
    }
}
