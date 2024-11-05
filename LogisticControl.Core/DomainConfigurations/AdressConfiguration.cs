using LogisticControl.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
    }
}