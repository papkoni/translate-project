using TranslateService.Persistence.Entities;

namespace TranslateService.Persistence.Abstractions.Repositories;

public interface ILanguageRepository: IBaseRepository<Language>
{
    Task<Language?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken);
    
    
}