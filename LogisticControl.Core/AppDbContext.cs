using LogisticControl.Core.Helpers;
using LogisticControl.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Reflection.Emit;
using Route = LogisticControl.Domain.Route;

namespace LogisticControl.Core;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
    { 
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    public DbSet<Address> Addresses { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Driver> Drivers { get; set; }
    public DbSet<Route> Routes { get; set; }
    public DbSet<Service> Services { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(CoreEventId.RedundantIndexRemoved));
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasDefaultSchema("api");
        builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        foreach (var entity in builder.Model.GetEntityTypes())
        {
            entity.SetTableName(entity.GetTableName().ToUnderscoreCase());

            foreach (var property in entity.GetProperties())
            {
                property.SetColumnName(property.GetColumnName().ToUnderscoreCase());
            }
            foreach (var key in entity.GetKeys())
            {
                key.SetName(key.GetName().ToUnderscoreCase());
            }
            foreach (var key in entity.GetForeignKeys())
            {
                key.SetConstraintName(key.GetConstraintName().ToUnderscoreCase());
                key.DeleteBehavior = DeleteBehavior.ClientSetNull;
            }
            foreach (var index in entity.GetIndexes())
            {
                index.SetDatabaseName(index.GetDatabaseName().ToUnderscoreCase());
            }
        }

        base.OnModelCreating(builder);
    }
}