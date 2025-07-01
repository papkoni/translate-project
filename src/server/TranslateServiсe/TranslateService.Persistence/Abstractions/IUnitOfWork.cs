using TranslateService.Persistence.Abstractions.Repositories;

namespace TranslateService.Persistence.Abstractions;

public interface IUnitOfWork
{
    Task SaveChangesAsync(CancellationToken cancellationToken);
    ILanguageRepository LanguageRepository { get; }
    ILocalizationKeyRepository LocalizationKeyRepository { get; }
    ITranslationRepository TranslationRepository { get; }
}