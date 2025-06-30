using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TranslateService.Persistence.Abstractions;
using TranslateService.Persistence.Abstractions.Repositories;
using TranslateService.Persistence.Repositories;

namespace TranslateService.Persistence.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddPersistence(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING") 
                               ?? configuration.GetConnectionString(nameof(ApplicationDbContext));

        services.AddDbContextPool<ApplicationDbContext>(
            options =>
            {
                options.UseNpgsql(connectionString);
            },
            128);

        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        services.AddScoped<ILanguageRepository, LanguageRepository>();
        services.AddScoped<ITranslationRepository, TranslationRepository>();
        services.AddScoped<ILocalizationKeyRepository, LocalizationKeyRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}