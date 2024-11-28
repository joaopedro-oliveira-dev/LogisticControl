using LogisticControl.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogisticControl.Core.EntityConfigurations;

public class DriverConfiguration : IEntityTypeConfiguration<Driver>
{
    public void Configure(EntityTypeBuilder<Driver> builder)
    {
        builder.HasKey(d => d.Id);

        builder.HasMany(d => d.Routes)
            .WithOne(r => r.Driver)
            .IsRequired(false);

        builder.HasData(new List<Driver>
        {
            new Driver(1, "Amaro", "(31) 95648-7854"),
            new Driver(2, "Higor", "(31) 94756-5467"),
            new Driver(3, "Samuel", "(31) 98965-4756"),
        });
    }
}