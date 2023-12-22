using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using AirportsDistance.Domain.Models;

namespace AirportsDistance.API.Connections.Http.Clients
{
  public class PlacesDevCteleportHttpClient
  {
    private readonly HttpClient _client;
    private readonly JsonSerializerOptions _options;     

    public PlacesDevCteleportHttpClient(HttpClient client)
    {
      _client = client;
      _client.BaseAddress = new Uri("https://places-dev.cteleport.com/");
      _client.Timeout = new TimeSpan(0, 0, 30);
      _client.DefaultRequestHeaders.Clear();
      _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true }; 
    }

    public async Task<Airport> GetAirportByIataAsync(string iata)
    {
      var url = Path.Combine("airports", iata);
      using var response = await _client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);

      response.EnsureSuccessStatusCode();

      var stream = await response.Content.ReadAsStreamAsync();

      var airport = await JsonSerializer.DeserializeAsync<Airport>(stream, _options);

      return airport;
    }
  }
}
