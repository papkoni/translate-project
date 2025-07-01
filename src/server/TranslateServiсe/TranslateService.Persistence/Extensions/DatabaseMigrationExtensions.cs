using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace TranslateService.Persistence.Extensions;

public static class DatabaseMigrationExtensions
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateAsyncScope();

        using ApplicationDbContext translateServiceDbContext =
            scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        translateServiceDbContext.Database.Migrate();
    }
}