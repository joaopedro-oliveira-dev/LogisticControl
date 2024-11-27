using LogisticControl.Domain;
using LogisticControl.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Route = LogisticControl.Domain.Route;

namespace LogisticControl.Core.DomainConfigurations;

public class RouteConfiguration : IEntityTypeConfiguration<Route>
{
    public void Configure(EntityTypeBuilder<Route> builder)
    {
        builder.HasKey(r => r.Id);

        builder.HasOne(r => r.Driver)
            .WithMany(a => a.Routes)
            .HasForeignKey(r => r.DriverId)
            .IsRequired(false);

        builder.HasMany(r => r.Services);

        builder.Property(r => r.Status)
            .HasConversion(new EnumToStringConverter<StatusRouteEnum>());

        builder.HasData(new List<Route>
        {
            new Route(1, new DateTime(2024, 11, 12, 14, 30, 0), new DateTime(2024, 11, 12, 17, 0, 0), new DateTime(2024, 11, 13, 7, 30, 0), 1, StatusRouteEnum.Finalizada, null),
            new Route(2, new DateTime(2024, 11, 14, 16, 0, 0), null, null, null, StatusRouteEnum.Pendente, null)
        });
    }
}