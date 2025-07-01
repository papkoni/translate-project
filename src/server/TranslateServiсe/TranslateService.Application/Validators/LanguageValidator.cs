using FluentValidation;
using TranslateService.Persistence.Entities;

namespace TranslateService.Application.Validators;

public class LanguageValidator : AbstractValidator<Language>
{
    public LanguageValidator()
    {
        RuleFor(language => language.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");

        RuleFor(language => language.Code)
            .NotEmpty().WithMessage("Code is required.")
            .Length(2).WithMessage("Code must be exactly 2 characters long.");
    }
}