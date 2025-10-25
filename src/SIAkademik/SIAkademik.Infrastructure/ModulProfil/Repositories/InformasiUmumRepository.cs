using Microsoft.EntityFrameworkCore;
using SIAkademik.Domain.ModulProfil.Entities;
using SIAkademik.Domain.ModulProfil.Repositories;
using SIAkademik.Domain.ValueObjects;
using SIAkademik.Infrastructure.Database;

namespace SIAkademik.Infrastructure.ModulProfil.Repositories;

internal class InformasiUmumRepository : IInformasiUmumRepository
{
    private readonly AppDbContext _appDbContext;

    public InformasiUmumRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<InformasiUmum> Get()
    {
        var informasiUmum = await _appDbContext.TblInformasiUmum.FirstOrDefaultAsync();
        if (informasiUmum is null)
        {
            informasiUmum = new InformasiUmum
            {
                NamaSekolah = string.Empty,
                SloganSekolah = string.Empty,
                AlamatSekolah = string.Empty,
                EmailSekolah = string.Empty,
                NoHPSekolah = NoHP.Create("081238007577").Value,
                ProfilSingkatSekolah = string.Empty,
                LirikMarsSekolah = string.Empty,
                FacebookSekolah = new Uri("https://www.facebook.com", UriKind.Absolute),
                InstagramSekolah = new Uri("https://www.instagram.com", UriKind.Absolute),
                VisiSekolah = string.Empty,
                MisiSekolah = string.Empty,
                LogoSekolah = new Uri("/images/logo_sekolah.jpg", UriKind.Relative),
                VideoHalamanBeranda = new Uri("https://www.youtube.com/embed/0F0zrVop0Gg?si=-bMdPjk3DHJkXz7H", UriKind.Absolute),
                VideoHalamanTentangKami = new Uri("https://www.youtube.com/embed/4Wt526OVxGg?si=L2EcPoD6nAunNxC6", UriKind.Absolute),
                NamaYayasan = string.Empty,
                SambutanPimpinanYayasan = string.Empty,
                DewanPembinaYayasan = string.Empty,
                KetuaUmumYayasan = string.Empty,
                KetuaUmum2Yayasan = string.Empty
            };

            _appDbContext.TblInformasiUmum.Add(informasiUmum);
            await _appDbContext.SaveChangesAsync();
        }

        return informasiUmum;
    }

    public void Update(InformasiUmum informasiUmum) => _appDbContext.TblInformasiUmum.Update(informasiUmum);
}
