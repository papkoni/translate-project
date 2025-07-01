namespace TranslateService.Persistence.Entities;

public class LocalizationKey
{
    public LocalizationKey(string key, string description)
    {
        Id = Guid.NewGuid();
        Key = key;
        Description = description;
    }
    
    public Guid Id { get; set; }
    public string Key { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public virtual ICollection<Translation> Translations { get; set; } = [];
}