using LogisticControl.Domain.Enums;
using LogisticControl.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LogisticControl.Core.EntityConfigurations;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.HasKey(c => c.Id);

        builder.HasMany(c => c.Addresses)
            .WithOne(a => a.Company)
            .IsRequired(false);

        builder.Property(c => c.PartnershipType)
            .HasConversion(new EnumToStringConverter<PartnershipTypeEnum>());

        builder.HasData(new List<Company>
        {
            new Company(1, "Mecbrun Industrial", PartnershipTypeEnum.Cliente, "(31) 96523-4789"),
            new Company(2, "Geosol Geologia e Sondagens", PartnershipTypeEnum.Cliente, "(31) 99874-3642")
        });
    }
}