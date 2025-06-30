using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TranslateService.Persistence.Entities;

namespace TranslateService.Persistence.Configurations;

public class LocalizationKeyEntityConfiguration : IEntityTypeConfiguration<LocalizationKey>
{
    public void Configure(EntityTypeBuilder<LocalizationKey> builder)
    {
        builder.ToTable("localization_keys");

        builder.HasKey(lk => lk.Id);

        builder.Property(lk => lk.Id)
            .HasColumnName("id")
            .IsRequired();

        builder.Property(lk => lk.Key)
            .HasColumnName("key")
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(lk => lk.Description)
            .HasColumnName("description")
            .HasMaxLength(1000);

        builder.HasIndex(lk => lk.Key)
            .IsUnique();
    }
}
