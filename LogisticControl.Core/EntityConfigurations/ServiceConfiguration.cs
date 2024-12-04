using LogisticControl.Domain.Enums;
using LogisticControl.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LogisticControl.Core.EntityConfigurations;

public class ServiceConfiguration : IEntityTypeConfiguration<Service>
{
    public void Configure(EntityTypeBuilder<Service> builder)
    {
        builder.HasKey(s => s.Id);

        builder.HasOne(s => s.Address)
            .WithMany(a => a.Services)
            .HasForeignKey(s => s.AddressId)
            .IsRequired(false);

        builder.HasOne(s => s.Route)
            .WithMany(r => r.Services)
            .HasForeignKey(s => s.RouteId)
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

        builder.HasData(new List<Service>
        {
            new Service(1, ServiceTypeEnum.Entrega, 1, PriorityEnum.Alta, TrackingTypeEnum.NF, "2024/586", null, StatusItemEnum.Liberado, null, null, StatusServiceEnum.Realizado, 1),
            new Service(2, ServiceTypeEnum.Coleta, 2, PriorityEnum.Media, TrackingTypeEnum.OS, "547", "Material pesado", StatusItemEnum.Liberado, "Carlos", null, StatusServiceEnum.NaoRealizado, 1),
            new Service(3, ServiceTypeEnum.Entrega, 2, PriorityEnum.Alta, TrackingTypeEnum.NF, "2024/587", null, StatusItemEnum.Liberado, null, null, StatusServiceEnum.EmAndamento, 2),
            new Service(4, ServiceTypeEnum.Coleta, 3, PriorityEnum.Baixa, TrackingTypeEnum.OS, "548", null, StatusItemEnum.NaoLiberado, null, null, StatusServiceEnum.Pendente, null)
        });
    }
}