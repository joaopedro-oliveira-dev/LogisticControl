using LogisticControl.Domain;
using LogisticControl.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LogisticControl.Core.DomainConfigurations;

public class AdressConfiguration : IEntityTypeConfiguration<Adress>
{
    public void Configure(EntityTypeBuilder<Adress> builder)
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