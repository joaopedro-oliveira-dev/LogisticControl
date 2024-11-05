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
        services.AddDbContext<AppDbContext>(options => options.UseNpgsql(_configuration.GetConnectionString("MyAppCs")));
    }
}