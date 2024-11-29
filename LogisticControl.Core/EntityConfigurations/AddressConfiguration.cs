using LogisticControl.Domain.Enums;
using LogisticControl.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LogisticControl.Core.EntityConfigurations;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.HasKey(a =>  a.Id);

        builder.HasOne(a => a.Company)
            .WithMany( c=> c.Addresses)
            .HasForeignKey(a => a.CompanyId)
            .IsRequired();

        builder.Property(a => a.State)
            .HasConversion(new EnumToStringConverter<StateEnum>());
        

        builder.HasData(new List<Address>
        {
            new Address(1, "Av. Lincoln Diogo Viana", 560, null, "Manoel Carlos", "Pedro Leopoldo", StateEnum.MG, 1),
            new Address(2, "R. São Vicente", 255, null, "Olhos D'Água", "Belo Horizonte", StateEnum.MG, 2),
            new Address(3, "R. das Goiabeiras", 333, null, "Vila Asas", "Lagoa Santa", StateEnum.MG, 2),
        });
        
    }
}