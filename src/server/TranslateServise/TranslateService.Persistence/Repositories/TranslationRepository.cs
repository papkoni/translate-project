using Microsoft.EntityFrameworkCore;
using TranslateService.Persistence.Abstractions.Repositories;
using TranslateService.Persistence.Entities;

namespace TranslateService.Persistence.Repositories;

public class TranslationRepository(ApplicationDbContext context):
    BaseRepository<Translation>(context), 
    ITranslationRepository
{
    public async Task<Translation?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken)
    {
        return await context.Translations
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
    }
}