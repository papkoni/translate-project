using System.Reflection;
using Microsoft.EntityFrameworkCore;
using TranslateService.Persistence.Abstractions;
using TranslateService.Persistence.Configurations;
using TranslateService.Persistence.Entities;

namespace TranslateService.Persistence;

public class ApplicationDbContext(
    DbContextOptions<ApplicationDbContext> options): DbContext(options), IApplicationDbContext
{
    public DbSet<Language> Languages { get; set; }
    public DbSet<LocalizationKey> LocalizationKeys { get; set; }
    public DbSet<Translation> Translations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new LanguageEntityConfiguration());
        modelBuilder.ApplyConfiguration(new LocalizationKeyEntityConfiguration());
        modelBuilder.ApplyConfiguration(new TranslationEntityConfiguration());
    }
}