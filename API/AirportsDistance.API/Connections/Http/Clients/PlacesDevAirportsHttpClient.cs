using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using AirportsDistance.API.Exceptions;
using AirportsDistance.API.Extensions;
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
      _options = new JsonSerializerOptions { 
        PropertyNameCaseInsensitive = true, 
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        
      }; 
    }

    public async Task<Airport> GetAirportByIataAsync(string iata)
    {
      var url = Path.Combine("airports", iata);
      using (var response = await _client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead))
      {
        if(!response.IsSuccessStatusCode)
        {
          if (response.StatusCode.Equals(HttpStatusCode.NotFound))
          {
            throw new HttpResponseException(HttpStatusCode.NotFound, $"The airport with iata: {iata} couldn't be found.");
          }
          if(response.StatusCode.Equals(HttpStatusCode.BadRequest))
          {
            throw new HttpResponseException(HttpStatusCode.BadRequest,"String should match pattern '^[A-Z]{3}$'");
          }
          response.EnsureSuccessStatusCode();
        }

        var stream = await response.Content.ReadAsStreamAsync();

        var airport = await JsonSerializer.DeserializeAsync<Airport>(stream, _options);

        return airport;
      }
    }
  }
}
