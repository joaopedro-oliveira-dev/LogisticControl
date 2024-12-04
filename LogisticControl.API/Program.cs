using LogisticControl.Core;
using LogisticControl.Domain.Models;
using LogisticControl.Repository;
using LogisticControl.Repository.Interfaces;
using LogisticControl.Services;
using LogisticControl.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.Development.json").AddEnvironmentVariables().Build();

builder.Services.AddDatabaseSettings(config);

builder.Services.AddControllers()
                .AddJsonOptions(options => {
                options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                options.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
                options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                options.JsonSerializerOptions.WriteIndented = true;
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                    }             
                );

builder.Services.AddControllersWithViews(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);

builder.Services.AddScoped<IBaseRepository, BaseRepository>();
builder.Services.AddTransient<IAddressRepository, AddressRepository>();
builder.Services.AddTransient<ICompanyRepository, CompanyRepository>();
builder.Services.AddTransient<IDriverRepository, DriverRepository>();
builder.Services.AddTransient<IRouteRepository, RouteRepository>();
builder.Services.AddTransient<IServiceRepository, ServiceRepository>();

builder.Services.AddTransient<IAddressService, AddressService>();
builder.Services.AddTransient<ICompanyService, CompanyService>();
builder.Services.AddTransient<IDriverService, DriverService>();
builder.Services.AddTransient<IRouteService, RouteService>();
builder.Services.AddTransient<IServiceService, ServiceService>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapControllers();

app.UseAuthorization();

app.MapRazorPages();

ApplyMigration();

app.Run();


void ApplyMigration()
{
    using var scope = app.Services.CreateScope();

    var database = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    if (database != null)
    {
        if (database.Database.GetPendingMigrations().Any())
        {
            database.Database.Migrate();
        }

    }

}

