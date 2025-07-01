using Microsoft.EntityFrameworkCore;
using TranslateService.Persistence.Abstractions.Repositories;
using TranslateService.Persistence.Entities;

namespace TranslateService.Persistence.Repositories;

public class LanguageRepository(ApplicationDbContext context):
    BaseRepository<Language>(context),
    ILanguageRepository
{
    public async Task<Language?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken)
    {
        return await context.Languages
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
    }
}