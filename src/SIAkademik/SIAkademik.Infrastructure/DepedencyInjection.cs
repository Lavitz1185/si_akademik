using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SIAkademik.Domain.Abstracts;
using SIAkademik.Infrastructure.Database;

namespace SIAkademik.Infrastructure;

public static class DepedencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Default") ?? throw new NullReferenceException("connection string 'default' is null");

        services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString).EnableSensitiveDataLogging());

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
