using FluentValidation;
using TranslateService.Persistence.Entities;

namespace TranslateService.Application.Validators;

public class LocalizationKeyValidator: AbstractValidator<LocalizationKey>
{
    public LocalizationKeyValidator()
    {
        RuleFor(localizationKey => localizationKey.Key)
            .NotEmpty().WithMessage("Key is required.")
            .MaximumLength(100).WithMessage("Key must not exceed 100 characters.");

        RuleFor(localizationKey => localizationKey.Description)
            .NotEmpty().WithMessage("Description is required.")
            .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");
    }
}