using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SIAkademik.Domain.Abstracts;
using SIAkademik.Domain.Authentication;
using SIAkademik.Domain.ModulProfil.Repositories;
using SIAkademik.Domain.ModulSiakad.Repositories;
using SIAkademik.Infrastructure.Authentication;
using SIAkademik.Infrastructure.Configurations;
using SIAkademik.Infrastructure.Database;
using SIAkademik.Infrastructure.ModulProfil.Repositories;
using SIAkademik.Infrastructure.ModulSiakad.Repositories;
using SIAkademik.Infrastructure.Services.FileServices;

namespace SIAkademik.Infrastructure;

public static class DepedencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Default")
            ?? throw new NullReferenceException("connection string 'Default' is null");

        services.AddDbContext<AppDbContext>(options => options
            .UseNpgsql(connectionString, o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery))
            .EnableSensitiveDataLogging());

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IAppUserRepository, AppUserRepository>();

        // Modul Profil
        services.AddScoped<IBeritaRepository, BeritaRepository>();
        services.AddScoped<IInformasiUmumRepository, InformasiUmumRepository>();
        services.AddScoped<IKategoriBeritaRepository, KategoriBeritaRepository>();

        // Modul Siakad
        services.AddScoped<IAbsenRepository, AbsenRepository>();
        services.AddScoped<IAbsenKelasRepository, AbsenKelasRepository>();
        services.AddScoped<IAnggotaRombelRepository, AnggotaRombelRepository>();
        services.AddScoped<IAsesmenSumatifRepository, AsesmenSumatifRepository>();
        services.AddScoped<IAsesmenSumatifAkhirSemesterRepository, AsesmenSumatifAkhirSemesterRepository>();
        services.AddScoped<IDivisiRepository, DivisiRepository>();
        services.AddScoped<IEvaluasiSiswaRepository, EvaluasiSiswaRepository>();
        services.AddScoped<IHariMengajarRepository, HariMengajarRepository>();
        services.AddScoped<IJabatanRepository, JabatanRepository>();
        services.AddScoped<IJadwalMengajarRepository, JadwalMengajarRepository>();
        services.AddScoped<IKelasRepository, KelasRepository>();
        services.AddScoped<IMataPelajaranRepository, MataPelajaranRepository>();
        services.AddScoped<INilaiEvaluasiSiswaRepository, NilaiEvaluasiSiswaRepository>();
        services.AddScoped<IPegawaiRepository, PegawaiRepository>();
        services.AddScoped<IPeminatanRepository, PeminatanRepository>();
        services.AddScoped<IPertemuanRepository, PertemuanRepository>();
        services.AddScoped<IRaportRepository, RaportRepository>();
        services.AddScoped<IRombelRepository, RombelRepository>();
        services.AddScoped<ISiswaRepository, SiswaRepository>();
        services.AddScoped<ITahunAjaranRepository, TahunAjaranRepository>();
        services.AddScoped<ITujuanPembelajaranRepository, TujuanPembelajaranRepository>();

        services.Configure<FileConfigurationOptions>(configuration.GetSection(FileConfigurationOptions.FileConfiguration));
        services.AddScoped(sp => sp.GetRequiredService<IOptionsSnapshot<FileConfigurationOptions>>().Value);
        services.AddScoped<IFileService, FileService>();

        return services;
    }
}
