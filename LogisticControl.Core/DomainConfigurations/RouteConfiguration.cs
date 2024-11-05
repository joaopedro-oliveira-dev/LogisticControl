using LogisticControl.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogisticControl.Core.DomainConfigurations;

public class RouteConfiguration : IEntityTypeConfiguration<Route>
{
    public void Configure(EntityTypeBuilder<Route> builder)
    {
        builder.HasKey(r => r.Id);

        builder.HasOne(r => r.Driver)
            .WithMany()
            .HasForeignKey(r => r.Driver_Id)
            .IsRequired(false);

        builder.HasMany(r => r.Services)
            .WithOne()
            .IsRequired();
    }
}