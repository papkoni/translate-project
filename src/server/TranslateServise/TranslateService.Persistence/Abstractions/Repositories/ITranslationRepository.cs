using TranslateService.Persistence.Entities;

namespace TranslateService.Persistence.Abstractions.Repositories;

public interface ITranslationRepository
{
    Task<Translation?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken);
}