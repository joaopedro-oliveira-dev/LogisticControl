using LogisticControl.Domain;
using LogisticControl.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

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

        builder.Property(s => s.ServiceType)
            .HasConversion(new EnumToStringConverter<ServiceTypeEnum>());

        builder.Property(s => s.Priority)
            .HasConversion(new EnumToStringConverter<PriorityEnum>());

        builder.Property(s => s.TrackingType)
            .HasConversion(new EnumToStringConverter<TrackingTypeEnum>());

        builder.Property(s => s.StatusItem)
            .HasConversion(new EnumToStringConverter<StatusItemEnum>());

        builder.Property(s => s.Status)
            .HasConversion(new EnumToStringConverter<StatusServiceEnum>());
    }
}