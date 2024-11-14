using LogisticControl.Domain;
using LogisticControl.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LogisticControl.Core.DomainConfigurations;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.HasKey(a =>  a.Id);

        builder.HasOne(a => a.Company)
            .WithMany()
            .HasForeignKey(a => a.Company_Id)
            .IsRequired();

        builder.Property(a => a.State)
            .HasConversion(new EnumToStringConverter<StateEnum>());
    }
}