namespace TranslateService.Persistence.Entities;

public class Language
{
    public Language(string name, string code)
    {
        Id = Guid.NewGuid();
        Name = name;
        Code = code;
    }
    
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
}