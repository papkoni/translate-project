using FluentValidation;
using TranslateService.Persistence.Entities;

namespace TranslateService.Application.Validators;

public class TranslationValidator: AbstractValidator<Translation>
{
    public TranslationValidator()
    {
        RuleFor(translation => translation.Text)
            .NotEmpty().WithMessage("Text is required.")
            .MaximumLength(1000).WithMessage("Text must not exceed 1000 characters.");

    }
}