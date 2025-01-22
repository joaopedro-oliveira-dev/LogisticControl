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
        builder.HasKey(u => u.Id);

        builder.HasIndex(u => u.Email)
            .IsUnique();

        builder.Property(u => u.Role)
            .HasConversion(new EnumToStringConverter<RoleEnum>());

        builder.HasData(new List<User>
        {
            new User(Guid.NewGuid().ToString(), "JOAO PEDRO ADM","joao.adm@gmail.com", "Administrador123#", RoleEnum.Administrador, true),
            new User(Guid.NewGuid().ToString(), "JOAO PEDRO ANALISTA", "joao.analista@gmail.com", "Analista123#", RoleEnum.Analista, true),
        });
    }
}