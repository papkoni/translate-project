using FluentValidation;
using TranslateService.Application.Abstractions.Services;
using TranslateService.Application.DTOs;
using TranslateService.Application.Exceptions;
using TranslateService.Persistence.Abstractions;
using TranslateService.Persistence.Entities;

namespace TranslateService.Application.Services;

public class LocalizationKeysService(
    IUnitOfWork unitOfWork,
    IValidator<LocalizationKey> localizationKeyValidator): ILocalizationKeysService
{
    public async Task CreateLocalizationKeyAsync(LocalizationKeyRequestDto localizationKeyDto, CancellationToken cancellationToken)
    {
        var newLocalizationKey = new LocalizationKey(localizationKeyDto.Key, localizationKeyDto.Description);
        var validationResult = await localizationKeyValidator.ValidateAsync(newLocalizationKey, cancellationToken);
        if (!validationResult.IsValid)
        {
            var errorMessages = string.Join(Environment.NewLine, validationResult.Errors.Select(error => error.ErrorMessage));
            throw new ValidationException(errorMessages);
        }

        await unitOfWork.LocalizationKeyRepository.CreateAsync(newLocalizationKey, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<LocalizationKey>> GetAllLocalizationKeysAsync(CancellationToken cancellationToken)
    {
        return await unitOfWork.LocalizationKeyRepository.GetAllAsync(cancellationToken);
    }

    public async Task<LocalizationKey> GetLocalizationKeyByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var localizationKey = await unitOfWork.LocalizationKeyRepository.GetByIdAsync(id, cancellationToken)
            ?? throw new NotFoundException($"LocalizationKey with id '{id}' not found.");
        return localizationKey;
    }

    public async Task UpdateLocalizationKeyAsync(LocalizationKey localizationKey, CancellationToken cancellationToken)
    {
        var existingLocalizationKey = await unitOfWork.LocalizationKeyRepository.GetByIdAsync(localizationKey.Id, cancellationToken)
            ?? throw new NotFoundException($"LocalizationKey with id {localizationKey.Id} doesn't exist");

        var validationResult = await localizationKeyValidator.ValidateAsync(localizationKey, cancellationToken);
        if (!validationResult.IsValid)
        {
            var errorMessages = string.Join(Environment.NewLine, validationResult.Errors.Select(error => error.ErrorMessage));
            throw new ValidationException(errorMessages);
        }

        unitOfWork.LocalizationKeyRepository.Update(localizationKey);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteLocalizationKeyAsync(Guid id, CancellationToken cancellationToken)
    {
        var existingLocalizationKey = await unitOfWork.LocalizationKeyRepository.GetByIdAsync(
                                          id,
                                          cancellationToken) 
                                      ?? throw new NotFoundException($"LocalizationKey with id {id} doesn't exist");

        unitOfWork.LocalizationKeyRepository.Delete(existingLocalizationKey);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
