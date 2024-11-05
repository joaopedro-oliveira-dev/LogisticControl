using LogisticControl.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogisticControl.Core.DomainConfigurations;

public class ServiceConfiguration : IEntityTypeConfiguration<Service>
{
    public void Configure(EntityTypeBuilder<Service> builder)
    {
        builder.HasKey(s => s.Id);

        builder.HasOne(s => s.Adress)
            .WithMany()
            .HasForeignKey(s => s.Adress_Id)
            .IsRequired(false);

        builder.HasOne(s => s.Route)
            .WithMany()
            .HasForeignKey(s => s.Route_Id)
            .IsRequired(false);
    }
}