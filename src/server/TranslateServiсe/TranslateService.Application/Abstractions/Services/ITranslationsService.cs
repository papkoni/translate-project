using TranslateService.Persistence.Entities;

namespace TranslateService.Application.Abstractions.Services;

public interface ITranslationsService
{
    Task CreateTranslationAsync(Translation translation, CancellationToken cancellationToken);
    Task<List<Translation>> GetAllTranslationsAsync(CancellationToken cancellationToken);
    Task<Translation> GetTranslationByIdAsync(Guid id, CancellationToken cancellationToken);
    Task UpdateTranslationAsync(Translation translation, CancellationToken cancellationToken);
    Task DeleteTranslationAsync(Guid id, CancellationToken cancellationToken);
}
