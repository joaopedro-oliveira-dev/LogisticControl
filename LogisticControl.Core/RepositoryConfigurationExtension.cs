using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LogisticControl.Core;

public static class RepositoryConfigurationExtension
{
    public static void AddRepositoryServices(this IServiceCollection services)
    {

    }
    public static void AddDatabaseSettings(this IServiceCollection services, IConfiguration _configuration)
    {
        var conectionString = "Server=localhost;Port=5432;Database=LogisticControlDB;;Username=postgres;Password=1234";
        services.AddDbContext<AppDbContext>(options => options.UseNpgsql(conectionString));
    }
}