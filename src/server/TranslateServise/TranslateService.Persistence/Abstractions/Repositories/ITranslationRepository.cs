using TranslateService.Persistence.Entities;

namespace TranslateService.Persistence.Abstractions.Repositories;

public interface ITranslationRepository: IBaseRepository<Translation>
{
    Task<Translation?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken);
}