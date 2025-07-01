using TranslateService.Persistence.Entities;

namespace TranslateService.Persistence.Abstractions.Repositories;

public interface ILocalizationKeyRepository: IBaseRepository<LocalizationKey>
{
    Task<LocalizationKey?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken);
}