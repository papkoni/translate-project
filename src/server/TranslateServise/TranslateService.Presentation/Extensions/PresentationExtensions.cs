using Asp.Versioning;
using Microsoft.OpenApi.Models;

namespace TranslateService.Presentation.Extensions;

public static class PresentationExtensions
{
    public static IServiceCollection AddPresentation(
        this IServiceCollection services,
        IConfiguration configuration)
    {

        services.AddProblemDetails();

        services.AddHttpContextAccessor();

        services.AddControllers();

        services.AddEndpointsApiExplorer();
        
        return services;
    }
    
    
    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        var apiVersioningBuilder = services.AddApiVersioning(
            o =>
            {
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new ApiVersion(1, 0);
                o.ReportApiVersions = true;
                o.ApiVersionReader = new UrlSegmentApiVersionReader();
            });

        apiVersioningBuilder.AddApiExplorer(
            options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
		
        services.AddSwaggerGen(
            options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Web API v1", Version = "v1" });
            });

        return services;
    }
}