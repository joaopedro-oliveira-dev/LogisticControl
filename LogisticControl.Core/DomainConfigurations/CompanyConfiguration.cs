using LogisticControl.Domain;
using LogisticControl.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LogisticControl.Core.DomainConfigurations;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.HasKey(c => c.Id);

        builder.HasMany(c => c.Adresses)
            .WithOne()
            .IsRequired(false);

        builder.Property(c => c.PartnershipType)
            .HasConversion(new EnumToStringConverter<PartnershipTypeEnum>());
    }
}