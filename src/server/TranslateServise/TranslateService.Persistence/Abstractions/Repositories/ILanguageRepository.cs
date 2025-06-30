using TranslateService.Persistence.Entities;

namespace TranslateService.Persistence.Abstractions.Repositories;

public interface ILanguageRepository
{
    Task<Language?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken);
    
    
}