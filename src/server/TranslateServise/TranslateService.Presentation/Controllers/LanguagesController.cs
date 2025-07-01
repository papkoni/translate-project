using Microsoft.AspNetCore.Mvc;
using TranslateService.Application.Abstractions.Services;
using TranslateService.Application.DTOs;
using TranslateService.Persistence.Entities;

namespace TranslateService.Presentation.Controllers;

[ApiController]
[Route("api/languages")]
public class LanguagesController(ILanguagesService languagesService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateLanguage([FromBody] LanguageRequestDto languageDto, CancellationToken cancellationToken)
    {
        await languagesService.CreateLanguageAsync(languageDto, cancellationToken);
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllLanguages(CancellationToken cancellationToken)
    {
        var languages = await languagesService.GetAllLanguagesAsync(cancellationToken);
        return Ok(languages);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetLanguageById(Guid id, CancellationToken cancellationToken)
    {
        var language = await languagesService.GetLanguageByIdAsync(id, cancellationToken);
        return Ok(language);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateLanguage([FromBody] Language language, CancellationToken cancellationToken)
    {
        await languagesService.UpdateLanguageAsync(language, cancellationToken);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLanguage(Guid id, CancellationToken cancellationToken)
    {
        var language = new Language(string.Empty, string.Empty) { Id = id };
        await languagesService.DeleteLanguageAsync(language, cancellationToken);
        return Ok();
    }
}