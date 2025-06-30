namespace TranslateService.Persistence.Entities;

public class LocalizationKey
{
    public Guid Id { get; set; }
    public string Key { get; set; } 
    public string Description { get; set; } 

    public virtual ICollection<Translation> Translations { get; set; } = [];
}