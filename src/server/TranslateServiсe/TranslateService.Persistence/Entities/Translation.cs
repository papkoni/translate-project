namespace TranslateService.Persistence.Entities;

public class Translation
{
    public Guid Id { get; set; }
    public Guid LocalizationKeyId { get; set; }
    public LocalizationKey LocalizationKey { get; set; }
    public Guid LanguageId { get; set; }
    public Language Language { get; set; }
    public string Text { get; set; } = string.Empty;
}