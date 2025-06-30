using Microsoft.EntityFrameworkCore;

namespace TranslateService.Persistence.Abstractions;

public interface IApplicationDbContext
{
    DbSet<T> Set<T>() where T : class;
}