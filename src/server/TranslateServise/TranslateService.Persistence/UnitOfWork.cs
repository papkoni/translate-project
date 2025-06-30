using TranslateService.Persistence.Abstractions;
using TranslateService.Persistence.Abstractions.Repositories;
using TranslateService.Persistence.Entities;

namespace TranslateService.Persistence;

public class UnitOfWork: IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public UnitOfWork(
        ApplicationDbContext context,
        ILanguageRepository languageRepository,
        ILocalizationKeyRepository localizationKeyRepository,
        ITranslationRepository translationRepository)
    {
        _context = context;
        LanguageRepository = languageRepository;
        LocalizationKeyRepository = localizationKeyRepository;
        TranslationRepository = translationRepository;
    }

    public ILanguageRepository LanguageRepository { get; }
    public ILocalizationKeyRepository LocalizationKeyRepository { get; }
    public ITranslationRepository TranslationRepository { get; }
    
    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}