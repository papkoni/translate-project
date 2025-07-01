using Microsoft.AspNetCore.Mvc;
using TranslateService.Application.Abstractions.Services;
using TranslateService.Persistence.Entities;

namespace TranslateService.Presentation.Controllers;

[ApiController]
[Route("api/translations")]
public class TranslationsController(ITranslationsService translationsService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateTranslation([FromBody] Translation translation, CancellationToken cancellationToken)
    {
        await translationsService.CreateTranslationAsync(translation, cancellationToken);
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTranslations(CancellationToken cancellationToken)
    {
        var translations = await translationsService.GetAllTranslationsAsync(cancellationToken);
        return Ok(translations);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTranslationById(Guid id, CancellationToken cancellationToken)
    {
        var translation = await translationsService.GetTranslationByIdAsync(id, cancellationToken);
        return Ok(translation);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateTranslation([FromBody] Translation translation, CancellationToken cancellationToken)
    {
        await translationsService.UpdateTranslationAsync(translation, cancellationToken);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTranslation(Guid id, CancellationToken cancellationToken)
    {
        await translationsService.DeleteTranslationAsync(id, cancellationToken);
        return Ok();
    }
}
