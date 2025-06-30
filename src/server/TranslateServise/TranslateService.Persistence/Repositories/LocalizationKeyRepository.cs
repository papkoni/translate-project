using Microsoft.EntityFrameworkCore;
using TranslateService.Persistence.Abstractions.Repositories;
using TranslateService.Persistence.Entities;

namespace TranslateService.Persistence.Repositories;

public class LocalizationKeyRepository(ApplicationDbContext context):
    BaseRepository<LocalizationKey>(context),
    ILocalizationKeyRepository
{
    public async Task<LocalizationKey?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken)
    {
        return await context.LocalizationKeys
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
    }
}