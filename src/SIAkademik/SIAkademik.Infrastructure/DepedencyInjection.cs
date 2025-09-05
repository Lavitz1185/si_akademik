using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SIAkademik.Domain.Abstracts;
using SIAkademik.Domain.Repositories;
using SIAkademik.Infrastructure.Database;
using SIAkademik.Infrastructure.Repositories;

namespace SIAkademik.Infrastructure;

public static class DepedencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Default") ?? throw new NullReferenceException("connection string 'default' is null");

        services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString).EnableSensitiveDataLogging());

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IAbsenRepository, IAbsenRepository>();
        services.AddScoped<IAnggotaRombelRepository, IAnggotaRombelRepository>();
        services.AddScoped<IDivisiRepository, DivisiRepository>();
        services.AddScoped<IJabatanRepository, JabatanRepository>();
        services.AddScoped<IJadwalMengajarRepository, JadwalMengajarRepository>();
        services.AddScoped<IKelasRepository, KelasRepository>();
        services.AddScoped<IMataPelajaranRepository, MataPelajaranRepository>();
        services.AddScoped<INilaiRepository, NilaiRepository>();
        services.AddScoped<IPegawaiRepository, PegawaiRepository>();
        services.AddScoped<IRombelRepository, RombelRepository>();
        services.AddScoped<ISiswaRepository, SiswaRepository>();
        services.AddScoped<ITahunAjaranRepository, TahunAjaranRepository>();

        return services;
    }
}
