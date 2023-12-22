using AirportsDistance.API.Connections.Http.Clients;
using Microsoft.Extensions.DependencyInjection;

namespace AirportsDistance.API.Extensions
{
  public static class ServiceExtensions
  {
    public static void ConfigureHttpClients(this IServiceCollection services)
    {
      services.AddHttpClient<PlacesDevCteleportHttpClient>();
    }
  }
}