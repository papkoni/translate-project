using TranslateService.Application.DTOs;
using TranslateService.Persistence.Entities;

namespace TranslateService.Application.Abstractions.Services;

public interface ILocalizationKeysService
{
    Task CreateLocalizationKeyAsync(LocalizationKeyRequestDto localizationKeyDto, CancellationToken cancellationToken);
    Task<List<LocalizationKey>> GetAllLocalizationKeysAsync(CancellationToken cancellationToken);
    Task<LocalizationKey> GetLocalizationKeyByIdAsync(Guid id, CancellationToken cancellationToken);
    Task UpdateLocalizationKeyAsync(LocalizationKey localizationKey, CancellationToken cancellationToken);
    Task DeleteLocalizationKeyAsync(Guid id, CancellationToken cancellationToken);
}
