using AspNetCoreRateLimit;
using Hangfire;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartEdu.Configurations;
using SmartEdu.Data;
using Serilog;
using System.Text.Json.Serialization;
using Microsoft.OpenApi.Models;
using System.Text.Json;
using SmartEdu.Services.SeederService;

var builder = WebApplication.CreateBuilder(args);

/* Add services to the container. */

// Configure DbContext
builder.Services.ConfigureDbContext(builder.Configuration);

// Add memory cache to keep track of who requested and how many times he requested
builder.Services.AddMemoryCache();

// Configure rate limiting
//builder.Services.ConfigureRateLimiting();

// Add HttpContextAccessor
builder.Services.AddHttpContextAccessor();

// Add proxy caching
//builder.Services.ConfigureHttpCacheHeaders();

// Configure Identity and External authentication
builder.Services.ConfigureIdentity();
builder.Services.AddAuthentication();
builder.Services.ConfigureExternalAuth();

// Configure Identity Token's lifespan
builder.Services.ConfigureTokenLifespan();

// Configure JWT
builder.Services.ConfigureJWT(builder.Configuration);

// Configure CORS policy
builder.Services.ConfigureCORS();

// Configure AutoMapper
builder.Services.ConfigureAutoMapper();

// Configure Serilog
ServiceBuilderExtensions.ConfigureSerilog(builder.Configuration);

// Register services
builder.Services.RegisterServices();

// Configure email
builder.Services.ConfigureEmaill(builder.Configuration);

// Configure Twilio for sending SMS
builder.Services.ConfigureTwilio(builder.Configuration);

// Configure client app
builder.Services.ConfigureClientApp(builder.Configuration);

// Add caching profile, disable Automapper reference looping
builder.Services.AddControllers(config =>
{
    config.CacheProfiles.Add("120SecondDuration", new CacheProfile
    {
        Duration = 120
    });
}).AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

// Configure Hangfire
//builder.Services.ConfigureHangfire(builder.Configuration);

// Configure API Versioning
builder.Services.ConfigureVersioning();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureSwaggerGen();

var app = builder.Build();

//Configure the HTTP request pipeline.
app.UseSwagger(options =>
{
    options.SerializeAsV2 = true;

});
app.UseSwaggerUI(options =>
{
    string swaggerJsonBasePath = string.IsNullOrWhiteSpace(options.RoutePrefix) ? "." : "..";
    options.SwaggerEndpoint($"{swaggerJsonBasePath}/swagger/v1/swagger.json", "SmartEdu API");

});

// Configure the global error handling
app.ConfigureExceptionHandler();

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseResponseCaching();
//app.UseHttpCacheHeaders();
//app.UseIpRateLimiting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
//app.MapHangfireDashboard();

await app.PromptDatabase();

app.Run();
