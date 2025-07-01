using FluentValidation;
using TranslateService.Application.Abstractions.Services;
using TranslateService.Application.DTOs;
using TranslateService.Application.Exceptions;
using TranslateService.Persistence.Abstractions;
using TranslateService.Persistence.Entities;

namespace TranslateService.Application.Services;

public class LanguagesService(
    IUnitOfWork unitOfWork,
    IValidator<Language> languageValidator): ILanguagesService
{
    public async Task CreateLanguageAsync(LanguageRequestDto languageDto, CancellationToken cancellationToken)
    {
        var newLanguage = new Language(languageDto.Name, languageDto.Code);

        var validationResult = await languageValidator.ValidateAsync(newLanguage, cancellationToken);
        if (!validationResult.IsValid)
        {
            var errorMessages = string.Join(Environment.NewLine, validationResult.Errors);
            throw new ValidationException(errorMessages);
        }

        await unitOfWork.LanguageRepository.CreateAsync(newLanguage, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<Language>> GetAllLanguagesAsync(CancellationToken cancellationToken)
    {
        return await unitOfWork.LanguageRepository.GetAllAsync(cancellationToken);
    }

    public async Task<Language?> GetLanguageByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var product = await unitOfWork.LanguageRepository.GetByIdAsync(id, cancellationToken)
                      ?? throw new NotFoundException($"Language with id '{id}' not found.");

        return product;
    }

    public async Task UpdateLanguageAsync(Language language, CancellationToken cancellationToken)
    {
        _ = await unitOfWork.LanguageRepository.GetByIdAsync(language.Id, cancellationToken)
                               ?? throw new NotFoundException($"Language with id {language.Id} doesn't exist");

        var validationResult = await languageValidator.ValidateAsync(language, cancellationToken);
        if (!validationResult.IsValid)
        {
            var errorMessages = string.Join(Environment.NewLine, validationResult.Errors);
            throw new ValidationException(errorMessages);
        }

        unitOfWork.LanguageRepository.Update(language);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteLanguageAsync(Language language, CancellationToken cancellationToken)
    {
        var existingLanguage = await unitOfWork.LanguageRepository.GetByIdAsync(
                                   language.Id,
                                   cancellationToken) 
                               ?? throw new NotFoundException($"Language with id {language.Id} doesn't exists");

        unitOfWork.LanguageRepository.Delete(existingLanguage);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}