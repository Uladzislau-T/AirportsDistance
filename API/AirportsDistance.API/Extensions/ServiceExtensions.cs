using AirportsDistance.API.Connections.Http.Clients;
using AirportsDistance.API.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace AirportsDistance.API.Extensions
{
  public static class ServiceExtensions
  {
    public static void ConfigureHttpClients(this IServiceCollection services)
    {
      services.AddHttpClient<PlacesDevCteleportHttpClient>();
    }

    public static void ConfigureActionFilters(this IServiceCollection services)
    {
      services.AddScoped<ValidationFilterAttribute>();
    }
  }
}