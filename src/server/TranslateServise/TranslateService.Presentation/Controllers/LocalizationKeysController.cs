using Microsoft.AspNetCore.Mvc;
using TranslateService.Application.Abstractions.Services;
using TranslateService.Application.DTOs;
using TranslateService.Persistence.Entities;

namespace TranslateService.Presentation.Controllers;


[ApiController]
[Route("api/localization-keys")]
public class LocalizationKeysController(ILocalizationKeysService localizationKeysService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateLocalizationKey([FromBody] LocalizationKeyRequestDto localizationKeyDto, CancellationToken cancellationToken)
    {
        await localizationKeysService.CreateLocalizationKeyAsync(localizationKeyDto, cancellationToken);
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllLocalizationKeys(CancellationToken cancellationToken)
    {
        var localizationKeys = await localizationKeysService.GetAllLocalizationKeysAsync(cancellationToken);
        return Ok(localizationKeys);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetLocalizationKeyById(Guid id, CancellationToken cancellationToken)
    {
        var localizationKey = await localizationKeysService.GetLocalizationKeyByIdAsync(id, cancellationToken);
        return Ok(localizationKey);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateLocalizationKey([FromBody] LocalizationKey localizationKey, CancellationToken cancellationToken)
    {
        await localizationKeysService.UpdateLocalizationKeyAsync(localizationKey, cancellationToken);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLocalizationKey(Guid id, CancellationToken cancellationToken)
    {
        await localizationKeysService.DeleteLocalizationKeyAsync(id, cancellationToken);
        return Ok();
    }
}
