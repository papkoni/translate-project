using FluentValidation;
using TranslateService.Application.Abstractions.Services;
using TranslateService.Application.Exceptions;
using TranslateService.Persistence.Abstractions;
using TranslateService.Persistence.Entities;

namespace TranslateService.Application.Services;

public class TranslationsService(
    IUnitOfWork unitOfWork, 
    IValidator<Translation> translationValidator): ITranslationsService
{
    public async Task CreateTranslationAsync(Translation translation, CancellationToken cancellationToken)
    {
        var validationResult = await translationValidator.ValidateAsync(translation, cancellationToken);
        if (!validationResult.IsValid)
        {
            var errorMessages = string.Join(
                Environment.NewLine, 
                validationResult.Errors.Select(error => error.ErrorMessage));
            throw new ValidationException(errorMessages);
        }

        _ = await unitOfWork.LocalizationKeyRepository.GetByIdAsync(
                                          translation.LocalizationKeyId,
                                          cancellationToken) 
                                      ?? throw new NotFoundException($"LocalizationKey with id {translation.LocalizationKeyId} doesn't exist");

        _ = await unitOfWork.LanguageRepository.GetByIdAsync(
                                   translation.LanguageId,
                                   cancellationToken) 
                               ?? throw new NotFoundException($"Language with id {translation.LanguageId} doesn't exists");
        
        await unitOfWork.TranslationRepository.CreateAsync(translation, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<Translation>> GetAllTranslationsAsync(CancellationToken cancellationToken)
    {
        return await unitOfWork.TranslationRepository.GetAllAsync(cancellationToken);
    }

    public async Task<Translation> GetTranslationByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var translation = await unitOfWork.TranslationRepository.GetByIdAsync(id, cancellationToken)
            ?? throw new NotFoundException($"Translation with id '{id}' not found.");
        return translation;
    }

    public async Task UpdateTranslationAsync(Translation translation, CancellationToken cancellationToken)
    {
        _ = await unitOfWork.TranslationRepository.GetByIdAsync(translation.Id, cancellationToken)
            ?? throw new NotFoundException($"Translation with id {translation.Id} doesn't exist");

        var validationResult = await translationValidator.ValidateAsync(translation, cancellationToken);
        if (!validationResult.IsValid)
        {
            var errorMessages = string.Join(Environment.NewLine, validationResult.Errors.Select(error => error.ErrorMessage));
            throw new ValidationException(errorMessages);
        }

        unitOfWork.TranslationRepository.Update(translation);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteTranslationAsync(Guid id, CancellationToken cancellationToken)
    {
        var existingTranslation = await unitOfWork.TranslationRepository.GetByIdAsync(id, cancellationToken)
            ?? throw new NotFoundException($"Translation with id {id} doesn't exist");

        unitOfWork.TranslationRepository.Delete(existingTranslation);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
