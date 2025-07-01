using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TranslateService.Persistence.Entities;

namespace TranslateService.Persistence.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class TranslationEntityConfiguration : IEntityTypeConfiguration<Translation>
{
    public void Configure(EntityTypeBuilder<Translation> builder)
    {
        builder.ToTable("translations");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Id)
            .HasColumnName("id")
            .IsRequired();

        builder.Property(t => t.LocalizationKeyId)
            .HasColumnName("localization_key_id")
            .IsRequired();

        builder.Property(t => t.LanguageId)
            .HasColumnName("language_id")
            .IsRequired();

        builder.Property(t => t.Text)
            .HasColumnName("text")
            .IsRequired(false);

        builder.HasOne(t => t.LocalizationKey)
            .WithMany(lk => lk.Translations)
            .HasForeignKey(t => t.LocalizationKeyId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(t => t.Language)
            .WithMany()
            .HasForeignKey(t => t.LanguageId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(t => new { t.LocalizationKeyId, t.LanguageId })
            .IsUnique();
    }
}
