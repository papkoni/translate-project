using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TranslateService.Persistence.Entities;

namespace TranslateService.Persistence.Configurations;

public class LanguageEntityConfiguration : IEntityTypeConfiguration<Language>
{
    public void Configure(EntityTypeBuilder<Language> builder)
    {
        builder.ToTable("languages");

        builder.HasKey(l => l.Id);

        builder.Property(l => l.Id)
            .HasColumnName("id")
            .IsRequired();

        builder.Property(l => l.Name)
            .HasColumnName("name")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(l => l.Code)
            .HasColumnName("code")
            .HasMaxLength(10)
            .IsRequired();

        builder.HasIndex(l => l.Code)
            .IsUnique();
    }
}
