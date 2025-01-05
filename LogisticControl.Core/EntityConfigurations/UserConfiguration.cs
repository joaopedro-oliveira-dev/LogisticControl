using LogisticControl.Domain.Enums;
using LogisticControl.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LogisticControl.Core.EntityConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u =>  u.UserName);

        builder.Property(u => u.Role)
            .HasConversion(new EnumToStringConverter<RoleEnum>());

        builder.HasData(new List<User>
        {
            new User("JOAO PEDRO ADM", "1234567891", RoleEnum.Administrador),
            new User("JOAO PEDRO ANALISTA", "1234567891", RoleEnum.Administrador),
        });
    }
}