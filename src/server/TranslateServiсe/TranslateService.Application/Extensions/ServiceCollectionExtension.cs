using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using TranslateService.Application.Abstractions.Services;
using TranslateService.Application.Services;
using TranslateService.Application.Validators;

namespace TranslateService.Application.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        services.AddScoped<ILanguagesService, LanguagesService>();
        services.AddScoped<ILocalizationKeysService, LocalizationKeysService>();
        services.AddScoped<ITranslationsService, TranslationsService>();

        services.AddValidatorsFromAssemblyContaining<LanguageValidator>();

        return services;
    }
}