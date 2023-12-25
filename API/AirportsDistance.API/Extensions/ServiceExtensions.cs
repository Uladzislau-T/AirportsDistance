using AirportsDistance.API.Connections.Http.Clients;
using AirportsDistance.API.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace AirportsDistance.API.Extensions
{
  public static class ServiceExtensions
  {
    public static void ConfigureCors(this IServiceCollection services)
    {
      services.AddCors(options =>
      {
          options.AddPolicy("CorsPolicy", builder =>
          builder.AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader());
      });
    }
    public static void ConfigureHttpClients(this IServiceCollection services)
    {
      services.AddHttpClient<PlacesDevCteleportHttpClient>();
    }

    public static void ConfigureActionFilters(this IServiceCollection services)
    {
      services.AddScoped<ValidationFilterAttribute>();
    }

    public static IServiceCollection AddRedis(this IServiceCollection services, IConfiguration configuration)
    {
      return services.AddSingleton(sp =>
      {
        var redisConfig = ConfigurationOptions.Parse(configuration.GetConnectionString("redis"), true);

        return ConnectionMultiplexer.Connect(redisConfig);
      });
    }
  }
}