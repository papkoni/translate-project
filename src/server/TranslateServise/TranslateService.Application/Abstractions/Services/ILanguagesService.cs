using TranslateService.Application.DTOs;
using TranslateService.Persistence.Entities;

namespace TranslateService.Application.Abstractions.Services;

public interface ILanguagesService
{
    Task CreateLanguageAsync(LanguageRequestDto languageDto, CancellationToken cancellationToken);
    Task<List<Language>> GetAllLanguagesAsync(CancellationToken cancellationToken);
    Task<Language> GetLanguageByIdAsync(Guid id, CancellationToken cancellationToken);
    Task UpdateLanguageAsync(Language language, CancellationToken cancellationToken);
    Task DeleteLanguageAsync(Language language, CancellationToken cancellationToken);
}
