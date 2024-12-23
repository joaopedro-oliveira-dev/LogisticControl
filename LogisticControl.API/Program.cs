using LogisticControl.Core;
using LogisticControl.Repository;
using LogisticControl.Repository.Interfaces;
using LogisticControl.Services;
using LogisticControl.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;
using Scalar.AspNetCore;

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
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<IDriverRepository, DriverRepository>();
builder.Services.AddScoped<IRouteRepository, RouteRepository>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();

builder.Services.AddTransient<IAddressService, AddressService>();
builder.Services.AddTransient<ICompanyService, CompanyService>();
builder.Services.AddTransient<IDriverService, DriverService>();
builder.Services.AddTransient<IRouteService, RouteService>();
builder.Services.AddTransient<IServiceService, ServiceService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(options =>
    {
        options.RouteTemplate = "/openapi/{documentName}.json";
    });
    app.MapScalarApiReference();
}


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

